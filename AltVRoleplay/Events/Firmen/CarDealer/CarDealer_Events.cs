

using AltV.Net;
using AltV.Net.Data;
using AltVRoleplay.Bank;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Firma.Class;

namespace AltVRoleplay.Events.Firmen.CarDealer
{
    internal class CarDealer_Events : IScript
    {
        [ClientEvent("getAllCarDealerContracts")]
        public static void GetAllCarDealerContracts(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(x => x.Id == player.Firma);
            if (firma == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist in keiner Firma");
                return;
            }
            if (firma.FirmenType != (int)ServerEnums.Firmen.CarDealer)
            {
                player.Notification(ServerEnums.Notify.Warning, "Keine Bestellungen");
                return;
            }
            foreach(CarDealerContract c in CarDealerContractList.carDealerContractServerList)
            {
                if (c.FirmaId != player.Firma) continue;
                bool rdy = c.Delivery <= DateTime.Now;
                player.Emit("createCarContract", c.Modell, c.Delivery.ToString("dd.MM.yyyy HH:mm"), rdy, c.OrderdByName);
            }
        }
        [ClientEvent("teleportCarDealer")]
        public static void TeleportInCarHouse(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if(player.HasData("CarDealerTp"))
            {
                player.GetData("CarDealerTp", out Position pos);
                player.SetPosition(pos.X,pos.Y,pos.Z+0.1f);
                player.DeleteData("CarDealerTp");
                return;
            }
            player.SetPosition(190.43077f, -993.8505f, -99.01465f);
            player.SetData("CarDealerTp", player.Position);
        }
        [ClientEvent("isCarallowedToSell")]
        public static void IsCarallowedToSell(MyPlayer.Player player, string modelname)
        {
            if (!player.LoggedIn) return;
            uint model = Alt.Hash(modelname);
            int price = CarDealer_Handler.CanSellModel(model);
            if(price == -1)
            {
                player.Emit("AllowCar", false);
                return;
            }
            int[] vehData = MyVehicle.VehList.GetInfosFromModel(model);
            string modelFixedName = string.Concat(modelname[0].ToString().ToUpper(), modelname.ToLower().AsSpan(1));
            player.Emit("AllowCar", true, modelFixedName, price, MyVehicle.VehList.GetFuelTypeName((ServerEnums.FillType)vehData[0]), vehData[1] , vehData[2]);
        }
        [ClientEvent("CarDealerBuyVehicle")]
        public static void CarDealerBuyVehicle(MyPlayer.Player player, uint model, int p1, int p2, int p3, int s1, int s2, int s3)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(x => x.Id == player.Firma);
            if (firma == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist in keiner Firma");
                return;
            }
            if(firma.FirmenType != (int)ServerEnums.Firmen.CarDealer)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du kannst keine Fahrzeuge bestellen");
                return;
            }
            int price = CarDealer_Handler.CanSellModel(model);
            if (price == -1)
            {
                player.Notification(ServerEnums.Notify.Warning,"Fahrzeug kann nicht gekauft werden");
                return;
            }
            if (player.Firma_Rank == ServerEnums.FirmenRanks.Praktikant)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du darfst noch kein Fahrzeug bestellen");
                return;
            }
            if(firma.Konto < price)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.firmaNotEnoughKonto);
                return;
            }
            if(CarDealerContractList.carDealerContractServerList.Count(x=>x.FirmaId == firma.Id) > 5)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.carDealerMaxContracts);
                return;
            }
            firma.Konto -= price;
            firma.Save();
            BankTransfers_Firmen ba = new BankTransfers_Firmen(firma.Id, -price, player.GetFullName(), Alt.GetVehicleModelInfo(model).Title+" gekauft");
            ba.Create();
            SQL.Firma.CarDealer.CarDealerSQL.CreateContract(firma, player.GetFullName(), model, price, p1, p2, p3, s1, s2, s3);
            player.Notification(ServerEnums.Notify.Check, "Fahrzeug bestellt");
        }

    }
}
