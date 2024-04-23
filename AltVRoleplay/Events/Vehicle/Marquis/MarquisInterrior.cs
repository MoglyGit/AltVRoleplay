using AltV.Net;

namespace AltVRoleplay.Events.Vehicle.Marquis
{
    public class MarquisInterrior : IScript
    {
        [ClientEvent("TryEnterMarquis")]
        public static void PlayerTryingEnterMarquis(MyPlayer.Player player, MyVehicle.MyVehicle vehicle)
        {
            if (vehicle.Model != Alt.Hash("marquis")) return;
            if(vehicle.Dbid == -1)
            {
                player.Notification(ServerEnums.Notify.Info, "Abgeschlossen");
                return;
            }
            if (vehicle.LockState != AltV.Net.Enums.VehicleLockState.Unlocked)
            {
                player.Notification(ServerEnums.Notify.Info, "Abgeschlossen");
                return;
            }
            if (!player.SetProgress(3, (int)ServerEnums.ProgressEvent.EnterMarquis, "Öffne Tür")) return;
            player.SetData("MarquisVehicle", vehicle);
        }

        public static void EnterMarquis(MyPlayer.Player player)
        {
            if (!player.HasData("MarquisVehicle")) return;
            player.GetData("MarquisVehicle", out MyVehicle.MyVehicle vehicle);
            player.Dimension = vehicle.Dbid;
            player.SetPosition(976.636f, 70.295f, 115.164f); 
        }
    }
}
