using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.MyPlayer;
using AltVRoleplay.MyVehicle;
using System.Text;
using System.Text.Json;

namespace AltVRoleplay
{
    public class Player_Commands : IScript
    {
        [Command("unrent")]
        public static void CMD_Unrent(MyPlayer.Player player)
        {
            if (player.RentedVehicle == null) return;
            player.UnrentVehilce();
            player.SendChatMessage("Dein gemietetes Fahrzeug wurde abgeholt");
        }

        [Command("motor")]
        public static void CMD_Motor(MyPlayer.Player player)
        {
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            if (veh.Model == Alt.Hash("bmx") || veh.Model == Alt.Hash("cruiser") || veh.Model == Alt.Hash("fixter") || veh.Model == Alt.Hash("scorcher") || veh.Model == Alt.Hash("tribike") || veh.Model == Alt.Hash("tribike2") || veh.Model == Alt.Hash("tribike2") || veh.Model == Alt.Hash("tribike3")) return;
            if (!player.HasVehicleKey(veh.Dbid) && veh.RentOwner != player.SocialClubId && !player.IsAduty()) return;
            if (veh.GetFill() <= 0) return;
            if (veh.MotorDamage) return;
            if (veh.Death) return;
            if (veh.EngineOn)
            {
                veh.EngineOn = false;
                player.SendChatMessage("Motor abgeschalten");
            }
            else
            {
                veh.EngineOn = true;
                player.SendChatMessage("Motor Angeschaltet");
            }
            Server.Log("" + veh.Rotation);
        }

        [Command("giveadmin")]
        public static void CMD_Test(MyPlayer.Player player)
        {
            player.SendChatMessage("Player Command works");
            player.AdminLevel = (int)MyPlayer.Player.AdminRanks.Administrator;
            return;
        }

        [Command("torso")]
        public static void CMD_FACE(MyPlayer.Player player, byte torso)
        {
            if (torso < 0 || torso > 10) return;
            switch(torso)
            {
                case 0:
                    torso = 15;
                    break;
                case 1:
                    torso = 0;
                    break;
                case 2:
                    torso = 1;
                    break;
                case 3:
                    torso = 2;
                    break;
                case 4:
                    torso = 4;
                    break;
                case 5:
                    torso = 5;
                    break;
                case 6:
                    torso = 6;
                    break;
                case 7:
                    torso = 8;
                    break;
                case 8:
                    torso = 1;
                    break;
                case 9:
                    torso = 12;
                    break;
                case 10:
                    torso = 14;
                    break;

            }
            player.SetClothes(3, torso, 0, 0);
            return;
        }
    }
}