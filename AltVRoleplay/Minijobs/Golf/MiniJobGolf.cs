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

namespace AltVRoleplay.Minijobs.Golf
{
    public class MiniJobGolf
    {
        [ClientEvent("ShowMiniJobGolf")]
        public static void ShowMiniJobGolf(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle)  return;
            if(Server.h() > 15 || Server.h() < 8)
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
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Mower] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Mower])
            {
                player.Notification(ServerEnums.Notify.Warning, "Komm später wieder");
                return;
            }
            Random rnd = new Random();
            Position pos;
            Rotation rot;
            switch (rnd.Next(3))
            {
                case 0:
                    pos = new Position(-1357.1736f, 130.36484f, 55.666626f);
                    rot = new Rotation(roll: 0.0040460755f, pitch: -0.002737569f,yaw: -1.4734668f);
                    break;
                case 1:
                    pos = new Position(-1357.2263f, 133.72748f, 55.68347f);
                    rot = new Rotation(roll: 0.003258073f,pitch: -0.009666359f,yaw: -1.5035301f);
                    break;
                default:
                    pos = new Position(-1357.134f, 136.85275f, 55.68347f);
                    rot = new Rotation(roll: 0.0013485567f,pitch: -0.011687663f,yaw: -1.5073327f);
                    break;
            }
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle("mower", pos, rot);
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Kein Rasenmäher verfügbar");
                return;
            }
            veh.PrimaryColorRgb = new Rgba((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255), 0);
            veh.SecondaryColorRgb = new Rgba((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255), 0);
            player.SetIntoVehicle(veh, 1);
            veh.SetRange(0);
            veh.VehName = "Mower";
            veh.EngineOn = true;
            veh.LockState = VehicleLockState.Locked;
            veh.ScriptMaxSpeed = 3;
            player.MiniJobCar = veh;
            player.Notification(ServerEnums.Notify.Check, "Minijob gestartet, mähe den Rasen");
            player.MiniJob = (int)ServerEnums.MiniJobs.Mower;
            player.MiniJobMoneyTimer = 10;
        }
    }
}
