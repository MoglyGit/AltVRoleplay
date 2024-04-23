using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltVRoleplay.Jobs
{
    public class GravelWorker
    {
        static readonly int am = 10;
        static readonly int pm = 16;
        public static void GravelDumpUnload(MyPlayer.Player player)
        {
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (!player.IsInVehicle) return;
            if (player.Vehicle.Model != Alt.Hash("Dump")) return;
            if (player.MiniJob != (int)ServerEnums.MiniJobs.Gravel) return;
            if (!player.SetProgress(7, (int)ServerEnums.ProgressEvent.UnLoadGravel, "Abladen...")) return;
        }
        public static void CheckGravelArea(MyPlayer.Player player)
        {
            if (player.MiniJob != (int)ServerEnums.MiniJobs.Gravel) return;
            if (ServerMethods.IsJobClosed(player, am, pm)) return;
            if (!(player.Position.X < 3114.4746f && player.Position.X > 2550.29f && player.Position.Y > 2631.6265f && player.Position.Y < 2970.9626f))
            {
                player.WarnLeavingArea();
                return;
            }
        }
        public static void UnLoadDump(MyPlayer.Player player)
        {
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (player.MiniJob != (int)ServerEnums.MiniJobs.Gravel) return;
            if (!player.HasData("Gravel")) return;
            player.GetData("Gravel", out int money);
            money += 20 + player.BergBau * 50;
            money = money / 10;
            player.PayDayMoney += money;
            player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] += money;
            player.Notification(ServerEnums.Notify.Info, "Payday +" + money);
            player.DeleteData("Gravel");
            player.ResetRouteAndCheckpoint();
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Gravel] + player.BergBau * 50)
            {
                player.Notification(ServerEnums.Notify.Warning, "Genug gearbeitet");
                player.StopMinijob();
                return;
            }
        }
        public static void LoadDump(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.MiniJob != (int)ServerEnums.MiniJobs.Gravel) return;
            if (!player.IsInVehicle) return;
            if (player.Vehicle.Model != Alt.Hash("dump")) return;
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (ServerLists.GetGravel() <= 0)
            {
                player.Notification(ServerEnums.Notify.Warning,"nicht genug Kies zum einladen");
                return;
            }
            if (player.HasData("Gravel")) return;
            if (!player.SetProgress(6, (int)ServerEnums.ProgressEvent.LoadGravel, "lade Kies auf...")) return;
        }
        public static void StartDump(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (player.BergBau < 2)
            {
                player.Notification(ServerEnums.Notify.Info, "Du brauchst mindestens die zweite Schulung");
                player.StopMinijob();
                return;
            }
            if (player.MiniJob != (int)ServerEnums.MiniJobs.None)
            {
                player.Notification(ServerEnums.Notify.Warning,"Du bist noch in einem Job unterwegs");
                return;
            }
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Gravel] + player.BergBau * 50)
            {
                player.Notification(ServerEnums.Notify.Warning, "Komm später wieder");
                return;
            }
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (player.MiniJobCar != null)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.hasMiniJob);
                return;
            }
            if (player.BankType == 0)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.noBankKonto);
                return;
            }
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle("dump", new Position(2955.4285f, 2736.3428f, 44.562622f), new Rotation(-0.03772676f, 0.075258695f, -1.0866089f));
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Kein Dump verfügbar");
                return;
            }
            veh.PrimaryColorRgb = new Rgba(255, 185, 0, 0);
            veh.SecondaryColorRgb = new Rgba(255, 185, 0, 0);
            player.SetIntoVehicle(veh, 1);
            veh.SetRange(0);
            veh.EngineOn = true;
            veh.LockState = VehicleLockState.Locked;
            player.MiniJobCar = veh;
            player.Notification(ServerEnums.Notify.Check, "Transportiere den Kies weg");
            player.MiniJob = (int)ServerEnums.MiniJobs.Gravel;
        }
        public static void StartDozer(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (player.BergBau < 1)
            {
                player.Notification(ServerEnums.Notify.Info, "Du brauhcst mindestens die erste Schulung");
                player.StopMinijob();
                return;
            }
            if (player.MiniJob != (int)ServerEnums.MiniJobs.None)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist noch in einem Job unterwegs");
                return;
            }
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Gravel] + player.BergBau * 50)
            {
                player.Notification(ServerEnums.Notify.Warning, "Komm später wieder");
                return;
            }
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (player.MiniJobCar != null)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.hasMiniJob);
                return;
            }
            if (player.BankType == 0)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.noBankKonto);
                return;
            }
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle("bulldozer", new Position(2949.7715f, 2748.1318f, 42.961914f), new Rotation(0.017178979f, -0.0038907751f, -1.3376579f));
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Kein Bulldozer verfügbar");
                return;
            }
            veh.PrimaryColorRgb = new Rgba(255,185,0, 0);
            veh.SecondaryColorRgb = new Rgba(255, 185, 0, 0);
            player.SetIntoVehicle(veh, 1);
            veh.SetRange(0);
            veh.VehName = "bulldozer";
            veh.EngineOn = true;
            veh.LockState = VehicleLockState.Locked;
            player.MiniJobCar = veh;
            player.Notification(ServerEnums.Notify.Check, "Schaufel Kies zusammen");
            player.MiniJob = (int)ServerEnums.MiniJobs.Gravel;
        }
    }
}
