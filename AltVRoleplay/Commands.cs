using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;

namespace AltVRoleplay
{
    public class Commands : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(MyPlayer.Player player, string command)
        {
            player.SendChatMessage("{FF0000}Der Befehl " + command + " wurde nicht gefunden!");
            Database.Log("Aufruftest");
            return;
        }

        [Command("veh")]
        public void CMD_Car(MyPlayer.Player player, string vehicleName, byte color_first=0, byte color_second=0)
        {
            IVehicle veh = Alt.CreateVehicle(Alt.Hash(vehicleName), new AltV.Net.Data.Position(player.Position.X, player.Position.Y, player.Position.Z + 1.0f), player.Rotation);
            if(veh == null)
            {
                player.SendChatMessage("{FF0000}Das Fahrzeug konnte nicht erstellt werden!");
                return;
            }
            player.SendChatMessage("Das Fahrzeug "+ vehicleName + " wurde erfolgrich gespawnnt!");
            veh.PrimaryColor = color_first;
            veh.SecondaryColor = color_second;

            player.SetIntoVehicle(veh, 1);
            return;
        }

        [Command("freezeme")]
        public void CMD_Freezeme(MyPlayer.Player player, bool freeze=true)
        {
            player.Emit("freezeMe", freeze);
            player.SendChatMessage("Du hast dich gefreezt");
        }

        [Command("test")]
        public void CMD_Test(MyPlayer.Player player, bool freeze = true)
        {
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CombatMG, 100, true);
            player.Armor = 100;
            player.SendChatMessage("Name: " +player.SocialClubId);
        }
    }
}
