

using AltV.Net;
using AltVRoleplay.SQL.LTD_Gas.Class;
namespace AltVRoleplay.Events.LTDGas
{
    internal class LTD_Events : IScript
    {
        [ClientEvent("tryFillVehicle")]
        public static void TryFillVehicle(MyPlayer.Player player)
        {
            if(!player.LoggedIn) return;
            MyVehicle.MyVehicle? veh = player.GetClosestVehicle();
            if(veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.noVehicleNearBy);
                return;
            }
            LTDGasStation? ltdUsed = null;
            foreach (LTDGasStation ltd in SQL.LTD_Gas.LTDList.LTDServerList)
            {
                if (player.Position.Distance(ltd.GetPosition()) > 150) continue;
                ltdUsed = ltd;
                break;
            }
            if (ltdUsed == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Zapfsäule ist nicht angeschlossen");
                return;
            }
            if(veh.EngineOn)
            {
                player.Notification(ServerEnums.Notify.Warning, "Motor vom Fahrzeug ist noch an");
                return;
            }
            if(veh.GetFill() == veh.FillMax)
            {
                player.Notification(ServerEnums.Notify.Warning, "Fahrzeug ist voll");
                return;
            }
            if(player.HasData("LTD:PAYMENT") && player.HasData("LTD:ID"))
            {
                player.GetData("LTD:PAYMENT", out int pay);
                if (pay > 0)
                {
                    player.GetData("LTD:ID", out int id);
                    LTDGasStation? ltdStolen = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == id);
                    if (ltdStolen != null)
                    {
                        player.CreateCrime(2, pay, "Tankstellen Rechnung nicht bezahlt", 1, 3 * 60, "Tankstelle: " + ltdStolen.Name);
                        player.Notification(ServerEnums.Notify.Info, "Tankstellen Rechnung nicht gezahlt");
                    }
                }
                player.DeleteData("LTD:PAYMENT");
                player.DeleteData("LTD:ID");
            }
            player.SetData("LTD:VEH", veh);
            float maxAddfill = veh.FillMax - veh.GetFill();
            player.Emit("ShowGasFill", maxAddfill, ltdUsed.Id, ltdUsed.FillPrice[0], ltdUsed.FillPrice[1], ltdUsed.FillPrice[2], ltdUsed.FillPrice[3]);
        }
        [ClientEvent("setLTDStats")]
        public static void SetLTDStats(MyPlayer.Player player, int storeId, int pay, float fuel)
        {
            if (!player.LoggedIn) return;
            if (pay == 0 || fuel == 0)
            {
                player.DeleteData("LTD:VEH");
                return;
            }
            LTDGasStation? ltdUsed = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == storeId);
            if(ltdUsed == null || !player.HasData("LTD:VEH"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Fehler beim tanken");
                return;
            }
            player.GetData("LTD:VEH", out MyVehicle.MyVehicle veh);
            player.DeleteData("LTD:VEH");
            veh.SetFill(veh.GetFill()+fuel);
            ltdUsed.Products -= (int)fuel +2;
            player.SetData("LTD:PAYMENT", pay);
            player.SetData("LTD:ID", ltdUsed.Id);
            player.timeToPayGas = DateTime.Now.AddMinutes(2);
        }
        [ClientEvent("PayGas")]
        public static void PayGas(MyPlayer.Player player, int storeId, int pay)
        {
            if (!player.LoggedIn) return;
            LTDGasStation? ltdUsed = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == storeId);
            if(ltdUsed == null)
            {
                player.DeleteData("LTD:PAYMENT");
                player.DeleteData("LTD:ID");
                player.Notification(ServerEnums.Notify.Warning, "Für dich wurde schon gezahlt");
                return;
            }
            if(player.Money < pay)
            {
                player.Notification(ServerEnums.Notify.Warning,Message.notEnoughMoney);
                return;
            }
            player.DeleteData("LTD:PAYMENT");
            player.DeleteData("LTD:ID");
            player.GiveMoney(-pay);
            ltdUsed.Konto += pay;
            ltdUsed.Save();
        }
    }
}
