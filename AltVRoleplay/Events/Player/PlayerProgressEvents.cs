using AltV.Net;
using AltVRoleplay.Events.Boats;
using AltVRoleplay.Events.Firmen.Mechanic;
using AltVRoleplay.Events.Fishing;
using AltVRoleplay.Events.Vehicle;
using AltVRoleplay.Events.Vehicle.Flatbed;
using AltVRoleplay.Events.Vehicle.Marquis;
using AltVRoleplay.Factions.Garbage;
using AltVRoleplay.Jobs;
using AltVRoleplay.Objects;

namespace AltVRoleplay.Events.Player
{
    public class PlayerProgressEvents :IScript
    {
        [ClientEvent("PlayerProgDone")]
        public static void FreePlayerFromProgDone(MyPlayer.Player player, int eventType)
        {
            if (!player.LoggedIn) return;
            player.canDoProg = true;
            switch (eventType)
            {
                case (int)ServerEnums.ProgressEvent.ChangeLockMechanic:
                    Mechanic_Handler.ChangeLockVehicle(player);
                    break;
                case (int)ServerEnums.ProgressEvent.TuevVehicleMechanic:
                    Mechanic_Handler.TuevVehicle(player);
                    break;
                case (int)ServerEnums.ProgressEvent.RepairVehicleMechanic:
                    Mechanic_Handler.RepariVehicle(player);
                    break;
                case (int)ServerEnums.ProgressEvent.LoadFlatbed:
                    FlatBed_Handler.LoadVehicle(player);
                    break;
                case (int)ServerEnums.ProgressEvent.UnLoadFlatbed:
                    FlatBed_Handler.UnLoadVehicle(player);
                    break;
                case (int)ServerEnums.ProgressEvent.SellFishes:
                    FishSell_Handler.SellFishes(player);
                    break;
                case (int)ServerEnums.ProgressEvent.Toolbox:
                    if (!player.HasData("ToolboxVeh")) return;
                    if (!player.HasData("ToolBox")) return;
                    player.GetData("ToolboxVeh", out MyVehicle.MyVehicle veh);
                    player.GetData("ToolBox", out Items.Items item);
                    if (veh == null) return;
                    if (item == null) return;
                    item.Amount -= 1;
                    if (item.Amount <= 0) item.Remove();
                    veh.MotorDamage = false;
                    player.Notification(ServerEnums.Notify.Check, "Motorschaden repariert");
                    player.DeleteData("ToolboxVeh");
                    player.DeleteData("ToolBox");
                    break;
                case (int)ServerEnums.ProgressEvent.CutLog:
                    if (!player.HasData("tree")) return;
                    player.GetData("tree", out Objects.Tree tree);
                    Logs log = new Logs(tree.X, tree.Y, player.Position.Z);
                    tree.Log = log;
                    tree.Remove();
                    break;
                case (int)ServerEnums.ProgressEvent.ProcessingWood:
                    LumberJack.GiveProcessedWood(player);
                    break;
                case (int)ServerEnums.ProgressEvent.SellingWood:
                    LumberJack.SellWood(player);
                    break;
                case (int)ServerEnums.ProgressEvent.SellingIron:
                    IronFarm.IronFarmEvents.SellIron(player);
                    break;
                case (int)ServerEnums.ProgressEvent.ChangeIron:
                    IronFarm.IronFarmEvents.ChangeIron(player);
                    break;
                case (int)ServerEnums.ProgressEvent.LoadGravel:
                    int mass = ServerLists.GetGravel() < 200 ? ServerLists.GetGravel() : 200;
                    player.SetData("Gravel", mass);
                    ServerLists.AddGravel(-mass);
                    player.SetRoute(12, 2687.3142f, 2837.8945f, 40.282837f, ServerEnums.CheckpointEvent.GravelDump, 1.2177426f, 0.3f);
                    break;
                case (int)ServerEnums.ProgressEvent.UnLoadGravel:
                    GravelWorker.UnLoadDump(player);
                    break;
                case (int)ServerEnums.ProgressEvent.UnLoadGarbage:
                    GarbageHandler.UnLoadGarbage(player);
                    break;
                case (int)ServerEnums.ProgressEvent.Anchor:
                    if (!player.IsInVehicle) return;
                    if (player.Seat != 1) return;
                    BoatAnchor_Handler.Anchor(player, (MyVehicle.MyVehicle)player.Vehicle);
                    break;
                case (int)ServerEnums.ProgressEvent.EnterMarquis:
                    MarquisInterrior.EnterMarquis(player);
                    break;
                case (int)ServerEnums.ProgressEvent.BoatTrailer:
                    Trailer_Handler.SlipBoat(player);
                    break;
            }
        }
        [ClientEvent("StopPlayerProg")]
        public static void StopPlayerProg(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            player.canDoProg = true;
            if(player.HasData("FlatBed"))
            {
                player.GetData("FlatBed", out MyVehicle.MyVehicle flatbed);
                if (flatbed == null) return;
                if (!flatbed.HasData("TryLoadVehicle")) return;
                flatbed.DeleteData("TryLoadVehicle");
                player.DeleteData("FlatBed");
                return;
            }
            if(player.HasData("tree"))
            {
                player.GetData("tree", out Objects.Tree tree);
                tree.interaction = true;
                player.DeleteData("tree");
                return;
            }
            if(player.HasData("Gravel"))
            {
                player.SetRoute(12, 2687.3142f, 2837.8945f, 40.282837f, ServerEnums.CheckpointEvent.GravelDump, 1.2177426f, 0.3f);
                return;
            }
        }
    }
}
