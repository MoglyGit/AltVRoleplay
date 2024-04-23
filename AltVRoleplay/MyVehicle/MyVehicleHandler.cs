using AltV.Net;

namespace AltVRoleplay.MyVehicle
{
    public class MyVehicleHandler : IScript
    {
        [ClientEvent("SellVehicle")]
        public static void SellCarConfirm(MyPlayer.Player player, MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            if (player.Seat != 1) return;
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Das Fahrzeug konnte nicht gefunden werden");
                return;
            }
            if(player.Vehicle.Id != veh.Id)
            { 
                player.Notification(ServerEnums.Notify.Warning, "Das ist nicht das richtige Fahrzeug");
                return;
            }
            if (veh.Dbid == -1)
            {
                player.Notification(ServerEnums.Notify.Warning, "Mit diesem Fahrzeug kann ich nichts anfangen");
                return;
            }
            if (veh.FactionId != 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Den Ärger mach ich mir nicht, versuch es wo anders");
                return;
            }
            int money = (int)(veh.Price * Server.CarSellCourse);
            if (money < 200) money = 200;
            player.GiveMoney(money);
            veh.RemoveFromGame();
        }
        public static void SellCar(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            if (player.Seat != 1) return;
            MyVehicle? veh = VehList.Find((int)player.Vehicle.Id);
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Das Fahrzeug hat keinen Wert");
                return;
            }
            if (!player.HasVehicleKey(veh.Dbid))
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast keinen Schlüssel für das Fahrzeug");
                return;
            }
            int money = (int)(veh.Price * Server.CarSellCourse);
            if(money < 200)money = 200;
            player.Emit("ShowCarSell", money, veh);
        }

        public static void RegisterCar(MyPlayer.Player player)
        {
            player.Emit("CloseRegisterCar");
            foreach (MyVehicle veh in VehList.VehicleServerList)
            {
                if (veh.OwnerSocialclubId != player.SocialClubId) continue;
                if (veh.NumberplateText != "New") continue;
                if (veh.VehName == null) continue;
                player.Emit("CreateRegisterCar", veh.VehName.ToUpper(),veh.Price/5, veh.Dbid);
            }
        }
    }
}
