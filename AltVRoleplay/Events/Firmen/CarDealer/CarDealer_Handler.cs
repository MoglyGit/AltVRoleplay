using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Firma;
using AltV.Net.Data;
using AltV.Net;
using AltVRoleplay.Items;
using AltVRoleplay.MyVehicle;

namespace AltVRoleplay.Events.Firmen.CarDealer
{
    public class CarDealer_Handler
    {
        public static void GetOrderedCar(MyPlayer.Player player)
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
                player.Notification(ServerEnums.Notify.Warning, "Du bist kein Autohändler");
                return;
            }
            foreach(CarDealerContract c in CarDealerContractList.carDealerContractServerList)
            {
                if (c.FirmaId != firma.Id) continue;
                if (c.Delivery > DateTime.Now) continue;
                string vehName = Alt.GetVehicleModelInfo(c.Modell).Title;

                MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle(vehName, new Position(986.16266f, -2973.7979f, 5.5216064f), new Rotation(-6.6592506E-06f, 0.0009769412f, 1.5844289f));
                if (veh == null)
                {
                    player.Notification(ServerEnums.Notify.Danger, "Versuch es nochmal");
                    return;
                }
                veh.PrimaryColorRgb = new Rgba((byte)c.P_R, (byte)c.P_G, (byte)c.P_B, 255);
                veh.SecondaryColorRgb = new Rgba((byte)c.S_R, (byte)c.S_G, (byte)c.S_B, 255);
                veh.OwnerSocialclubId = firma.Owner_Id;
                veh.OwnerName = firma.Owner_Name;

                veh.VehName = vehName.ToLower();
                veh.Price = c.Price;
                veh.Dbid = Database.CreateVehicle(veh);
                veh.ManualEngineControl = true;
                veh.EngineOn = false;
                veh.SetRange(0);
                veh.SetFill(veh.FillMax);


                player.Notification(ServerEnums.Notify.Check, "Fahrzeug erfolgreich abgeholt");
                VehList.AddDbVehicle(veh);

                int[] place = player.GetFreeInvPlace();
                Items.Items item = new Items.Items();
                item.CreateVehicleKey(veh);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                c.Delete();
                return;
            }
            player.Notification(ServerEnums.Notify.Warning, "Kein Fahrzeug zum Abholen bereit");
        }
        public static int CanSellModel(uint model)
        {
            return model switch
            {
                //adder
                3078201489 => 4500,
                //brioso
                1549126457 => 6000,
                //infernus
                418536135 => 8000,
                //baller3
                1878062887 => 2500,
                //stanier
                2817386317 => 1000,
                //blista
                3950024287 => 1500,
                //asbo
                1118611807 => 2000,
                //dilettante
                3164157193 => 3500,
                //elegy
                196747873 => 3000,
                _ => -1
            };
        }
    }
}
