using AltV.Net;
using AltVRoleplay.Events.Player;
using AltVRoleplay.Items;

namespace AltVRoleplay.Events.Vehicle
{
    public class VehInvEvents : IScript
    {
        [ClientEvent("closeOtherInfVehicle")]
        public static void CloseVehicleTrunk(MyPlayer.Player player)
        {
            if (!player.HasData("TrunkUse")) return;
            player.GetData("TrunkUse", out MyVehicle.MyVehicle veh);
            veh.TrunkUsedBy = null;
            player.DeleteData("TrunkUse");
            veh.SetDoorState(5, 0);
        }
        [ClientEvent("getTrunkItems")]
        public static void GetTrunkItems(MyPlayer.Player player)
        {
            if (!player.HasData("TrunkUse")) return;
            player.GetData("TrunkUse", out MyVehicle.MyVehicle veh);
            if (veh.TrunkUsedBy != player)
            {
                player.Emit("closeInventory");
                return;
            }
            float actuallMass = PlayerInv_Handler.LoadOtherInv(player, veh.Inv);
            player.Emit("addOtherHud", veh.MaxWeight.ToString("0.00"), actuallMass.ToString("0.00"));
        }
        [ClientEvent("VehicleTrunk")]
        public static void TryOpenTrunk(MyPlayer.Player player, MyVehicle.MyVehicle vehicle)
        {
            if (!player.LoggedIn) return;
            if (player.HasData("HasFishingRod")) return;
            if (!CanTrunkUsed(vehicle))
            {
                player.Notification(ServerEnums.Notify.Warning, "Kofferraum in nutzung");
                return;
            }
            if(vehicle.LockState != AltV.Net.Enums.VehicleLockState.Unlocked)
            {
                player.Notification(ServerEnums.Notify.Warning, "Fahrzeug ist abgeschlossen");
                return;
            }
            player.SetData("TrunkUse", vehicle);
            vehicle.TrunkUsedBy = player;
            vehicle.SetDoorState(5, 7);
            player.Emit("openInventory", (int)ServerEnums.OtherInventoryTypes.Vehicle, vehicle.Inv.Length);
        }
        public static bool CanTrunkUsed(MyVehicle.MyVehicle vehicle)
        {
            if (vehicle.TrunkUsedBy != null)
            {
                foreach (MyPlayer.Player p in Alt.GetAllPlayers())
                {
                    if (p != vehicle.TrunkUsedBy) continue;
                    if (p.Position.Distance(vehicle.Position) <= 3 && p.HasData("TrunkUse"))
                    {
                        p.GetData("TrunkUse", out MyVehicle.MyVehicle pveh);
                        if (pveh == vehicle) return false;
                        p.Emit("closeInventory");
                        vehicle.TrunkUsedBy = null;
                        return true;
                    }
                    return true;
                }
            }
            return true;
        }
    }
}
