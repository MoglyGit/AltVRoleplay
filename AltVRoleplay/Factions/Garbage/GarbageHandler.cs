using AltV.Net;

namespace AltVRoleplay.Factions.Garbage
{
    public class GarbageHandler
    {
        public static void UnLoadGarbage(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            if (player.Duty == 0) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            if (veh == null) return;
            if (veh.Model != Alt.Hash("trash") && veh.Model != Alt.Hash("trash2")) return;
            if (!veh.HasData("Trash")) return;
            veh.GetData("Trash", out float volume);
            if(volume < 500)
            {
                player.Notification(ServerEnums.Notify.Warning, "Mindestens 500 sind nötig");
                return;
            }
            veh.DeleteData("Trash");
            float money = volume * 0.1f;
            if(money <= 0) money = 10;
            player.PayDayMoney += (int)money;
            player.Notification(ServerEnums.Notify.Info, "Gehalt +"+(int)money);
        }
    }
}
