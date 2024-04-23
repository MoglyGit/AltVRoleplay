
using AltV.Net;

namespace AltVRoleplay.Events.Vehicle
{
    public class BoatAnchor_Handler : IScript
    {
        [ClientEvent("ToggleAnker")]
        public static void ToggleAnker(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.IsInVehicle) return;
            if (player.Seat != 1) return;
            if (Alt.GetVehicleModelInfo(player.Vehicle.Model).Type != AltV.Net.Data.VehicleModelType.BOAT) return;
            player.SetProgress(5, (int)ServerEnums.ProgressEvent.Anchor, "Anker...");
        }
        public static void Anchor(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (Alt.GetVehicleModelInfo(veh.Model).Type != AltV.Net.Data.VehicleModelType.BOAT) return;
            if (!veh.HasSyncedMetaData("BoatAnchor"))
            {
                veh.SetSyncedMetaData("BoatAnchor", 1);
                player.Notification(ServerEnums.Notify.Info, "Anker geworfen");
                return;
            }
            veh.GetSyncedMetaData("BoatAnchor", out int state);
            if(state == 1)
            {
                veh.SetSyncedMetaData("BoatAnchor", 0);
                player.Notification(ServerEnums.Notify.Info, "Anker eingeholt");
            }
            else
            {
                veh.SetSyncedMetaData("BoatAnchor", 1);
                player.Notification(ServerEnums.Notify.Info, "Anker geworfen");
            }
        }
    }
}
