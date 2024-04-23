using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltVRoleplay.MyVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Minijobs.Lieferant
{
    public class MiniJobLieferant
    {
        public static void StartMiniJobLieferant(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (Server.h() < 12)
            {
                player.Notification(ServerEnums.Notify.Info, Message.notOpen);
                return;
            }
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
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Lieferant] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Lieferant])
            {
                player.Notification(ServerEnums.Notify.Warning,"Komm später wieder");
                return;
            }
            Random rnd = new Random();
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle("faggio", new Position(-138.18462f, -253.23956f, 43.046143f), new Rotation(roll: -0.15834236f, pitch: 0.019547261f,yaw: -1.8895376f));
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Kein Rasenmäher verfügbar");
                return;
            }
            veh.PrimaryColorRgb = new Rgba((byte) rnd.Next(255), (byte) rnd.Next(255), (byte) rnd.Next(255), 0);
            veh.SecondaryColorRgb = new Rgba((byte) rnd.Next(255), (byte) rnd.Next(255), (byte) rnd.Next(255), 0);
            player.SetIntoVehicle(veh, 1);
            veh.EngineOn = true;
            veh.LockState = VehicleLockState.Locked;
            veh.ScriptMaxSpeed = 15;
            veh.NumberplateText = "MJEB";
            veh.VehName = "Faggio";
            player.MiniJobCar = veh;
            player.MiniJobMoneyTimer = 5 * 60;
            player.Notification(ServerEnums.Notify.Check, "Minijob gestartet, bringe das Essen zum Kunden");
            player.MiniJob = (int) ServerEnums.MiniJobs.Lieferant;
            Position pos = new Position(306.40878f, -235.27911f, 54.09961f);
            switch(rnd.Next(6))
            {
                case 0:
                    pos = new Position(306.40878f, -235.27911f, 54.09961f);
                    break;
                case 1:
                    pos = new Position(316.95825f, -80.5978f, 69.44983f);
                    break;
                case 2:
                    pos = new Position(-33.30989f, -404.45276f, 39.575073f);
                    break;
                case 3:
                    pos = new Position(-256.53625f, 22.391209f, 54.77368f);
                    break;
                case 4:
                    pos = new Position(-152.91429f, 75.797806f, 70.7135f);
                    break;
                case 5:
                    pos = new Position(-31.81978f, -144.58022f, 57.065186f);
                    break;
            }
            player.SetRoute(12, pos.X,pos.Y,pos.Z, ServerEnums.CheckpointEvent.MinijobPizza);
            if (player.MiniJobPed != null) player.MiniJobPed.Remove();
            player.MiniJobPed = new Ped.PedEntity("s_m_o_busker_01", 0, 180, pos, 50, 0);
            //player.MiniJobMoneyTimer = 10;
        }
    }
}
