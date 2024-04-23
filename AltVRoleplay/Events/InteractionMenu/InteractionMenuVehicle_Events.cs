
using AltV.Net;
using AltV.Net.Enums;
using AltVRoleplay.Events.Player;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Firma;

namespace AltVRoleplay.Events.InteractionMenu
{
    internal class InteractionMenuVehicle_Events : IScript
    {
        [ClientEvent("DoShortSiren")]
        public static void DoShortSiren(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (!player.IsInVehicle || player.Seat > 2)
            {
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (player.Vehicle.Id != veh.Id)
            {
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (veh.HasSyncedMetaData("shortsiren")) veh.DeleteSyncedMetaData("shortsiren");
            else veh.SetSyncedMetaData("shortsiren", 1);

        }
        [ClientEvent("ChangeVehicleSirenMute")]
        public static void ChangeVehicleSirenMute(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (!player.IsInVehicle || player.Seat > 2)
            {
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if(player.Vehicle.Id != veh.Id)
            {
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (veh.HasSyncedMetaData("siren")) veh.DeleteSyncedMetaData("siren");
            else veh.SetSyncedMetaData("siren",1);

        }
        [ClientEvent("ChangeLockVehicle")]
        public static void ChangeLockVehicle(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (player.Position.Distance(veh.Position) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (!player.SetProgress(15, (int)ServerEnums.ProgressEvent.ChangeLockMechanic, "Wechsle Fahrzeugschloss..")) return;
            player.SetData("Mechanic:ChangeLock", veh);
        }
        [ClientEvent("TuevVehicleMechanic")]
        public static void TuevVehicleMechanic(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (player.Position.Distance(veh.Position) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (!player.SetProgress(15, (int)ServerEnums.ProgressEvent.TuevVehicleMechanic, "Prüfe Fahrzeug..")) return;
            player.SetData("Mechanic:Tuev", veh);
        }
        [ClientEvent("RepairVehicleMechanic")]
        public static void RepairVehicleMechanic(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (player.Position.Distance(veh.Position) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (!player.SetProgress(15, (int)ServerEnums.ProgressEvent.RepairVehicleMechanic, "Repariere Fahrzeug..")) return;
            player.SetData("Mechanic:Repair", veh);
        }
        [ClientEvent("ShowNumberPlateFromVehicle")]
        public static void ShowNumberPlateFromVehicle(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (player.Position.Distance(veh.Position) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            string tuevDate = veh.Tuev.Day + "." + veh.Tuev.Month + "." + veh.Tuev.Year;
            player.Emit("ShowVehicleNumberPlate", tuevDate, veh.NumberplateText, Alt.GetVehicleModelInfo(veh.Model).Title);

        }
        [ClientEvent("closeOtherFrontInfVehicle")]
        public static void CloseVehicleTrunk(MyPlayer.Player player)
        {
            if (!player.HasData("HandschuhfachUse")) return;
            player.GetData("HandschuhfachUse", out MyVehicle.MyVehicle veh);
            veh.HandschuhfachUsedBy = null;
            player.DeleteData("HandschuhfachUse");
        }
        [ClientEvent("getHandschufachItems")]
        public static void GetHandschufachItems(MyPlayer.Player player)
        {
            if (!player.HasData("HandschuhfachUse")) return;
            player.GetData("HandschuhfachUse", out MyVehicle.MyVehicle veh);
            if (veh.HandschuhfachUsedBy != player)
            {
                player.Emit("closeInventory");
                return;
            }
            float actuallMass = PlayerInv_Handler.LoadOtherInv(player, veh.FrontInv);
            player.Emit("addOtherHud", veh.MaxWeightFront.ToString("0.00"), actuallMass.ToString("0.00"));
        }
        [ClientEvent("OpenHandschuhfach")]
        public static void OpenHandschuhfach(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (!player.IsInVehicle || player.Vehicle != veh) return;
            if (player.Seat != 1 && player.Seat != 2) return;
            if (!CanHandschuhfachUsed(veh))
            {
                player.Notification(ServerEnums.Notify.Warning, "Kofferraum in nutzung");
                return;
            }
            player.SetData("HandschuhfachUse", veh);
            veh.HandschuhfachUsedBy = player;
            player.Emit("openInventory", (int)ServerEnums.OtherInventoryTypes.VehicleFront, veh.FrontInv.Length);
        }
        [ClientEvent("TryToggleTrunk")]
        public static void TryToggleTrunk(MyPlayer.Player player, MyVehicle.MyVehicle veh, bool noBackdoors)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (!player.IsInVehicle) return;
            if (noBackdoors)
            {
                if (veh.GetDoorState(3) == 0) veh.SetDoorState(5, 7);
                else veh.SetDoorState(5, 0);
                return;
            }
            if (veh.GetDoorState(5) == 0) veh.SetDoorState(5, 7);
            else veh.SetDoorState(5, 0);

        }
        [ClientEvent("TryToggleHood")]
        public static void TryToggleHood(MyPlayer.Player player, MyVehicle.MyVehicle veh, bool noBackdoors)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (!player.IsInVehicle) return;
            if(noBackdoors)
            {
                if (veh.GetDoorState(2) == 0) veh.SetDoorState(4, 7);
                else veh.SetDoorState(4, 0);
                return;
            }
            if (veh.GetDoorState(4) == 0) veh.SetDoorState(4, 7);
            else veh.SetDoorState(4, 0);

        }
        [ClientEvent("GetVehicleMenuInfo")]
        public static void GetVehicleMenuInfo(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (player.Position.Distance(veh.Position) > 25)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            bool hasKey = player.HasVehicleKey(veh.Dbid);
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) player.Emit("ShowVehicleMenu", hasKey, veh);
            else if(!player.IsInVehicle && firma.FirmenType == (int)ServerEnums.Firmen.Mechanic) player.Emit("ShowVehicleMenu", hasKey, veh, true);
            else if (player.IsInVehicle && firma.FirmenType == (int)ServerEnums.Firmen.Tuner) player.Emit("ShowVehicleMenu", hasKey, veh, false, true);
            else player.Emit("ShowVehicleMenu", hasKey, veh);

        }
        [ClientEvent("TryEngineVehicle")]
        public static void TryEngineVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            if (veh.Model == Alt.Hash("bmx") || veh.Model == Alt.Hash("cruiser") || veh.Model == Alt.Hash("fixter") || veh.Model == Alt.Hash("scorcher") || veh.Model == Alt.Hash("tribike") || veh.Model == Alt.Hash("tribike2") || veh.Model == Alt.Hash("tribike2") || veh.Model == Alt.Hash("tribike3")) return;
            if (!player.HasVehicleKey(veh.Dbid))
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast kein Schlüssel");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (veh.GetFill() <= 0) return;
            if (veh.MotorDamage)
            {
                player.Notification(ServerEnums.Notify.Warning, "Motor springt nicht an");
                return;
            }
            if (veh.Death)
            {
                player.Notification(ServerEnums.Notify.Warning, "Motor kaputt");
                return;
            }
            if (veh.EngineOn)
            {
                veh.EngineOn = false;
                player.Notification(ServerEnums.Notify.Check,"Motor abgeschalten");
            }
            else
            {
                veh.EngineOn = true;
                player.Notification(ServerEnums.Notify.Check, "Motor Angeschaltet");
            }
        }
        [ClientEvent("TryLockingVehicle")]
        public static void TryLockingVehicle(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if(!player.HasVehicleKey(veh.Dbid))
            {
                player.Notification(ServerEnums.Notify.Warning,"Du hast kein Schlüssel");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (player.Position.Distance(veh.Position) > 5)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                player.Emit("CloseVehicleInteraction");
                return;
            }
            if (veh.LockState == VehicleLockState.Unlocked)
            {
                veh.Lock(VehicleLockState.Locked);
                player.Notification(ServerEnums.Notify.Check, "Fahrzeug abgeschlossen");
            }
            else
            {
                veh.Lock(VehicleLockState.Unlocked);
                player.Notification(ServerEnums.Notify.Check, "Fahrzeug aufgeschlossen");
            }
            player.Emit("vehlock", veh);
        }

        public static bool CanHandschuhfachUsed(MyVehicle.MyVehicle vehicle)
        {
            if (vehicle.HandschuhfachUsedBy != null)
            {
                foreach (MyPlayer.Player p in Alt.GetAllPlayers())
                {
                    if (p != vehicle.HandschuhfachUsedBy) continue;
                    if (p.Position.Distance(vehicle.Position) <= 3 && p.HasData("HandschuhfachUse"))
                    {
                        p.GetData("HandschuhfachUse", out MyVehicle.MyVehicle pveh);
                        if (pveh == vehicle) return false;
                        p.Emit("closeInventory");
                        vehicle.HandschuhfachUsedBy = null;
                        return true;
                    }
                    return true;
                }
            }
            return true;
        }
    }
}
