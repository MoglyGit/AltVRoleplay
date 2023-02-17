using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay
{
    public class Events: IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(MyPlayer.Player player, string reason)
        {
            Server.Log($"Der Spieler {player.Name} hat den Server betreten");
            //Login/reg page
            if(Database.ExistAccount(player))
            {
                player.Emit("LoginHud");
            }
            else
            {
                player.Emit("RegisterHud");
            }
        }
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(MyPlayer.Player player, string reason)
        {
            Server.Log($"Spieler {player.Name} hat den Server verlassen - Grund: {reason}");
        }

        [ClientEvent("Event.Register")]
        public void OnPlayerRegister(MyPlayer.Player player, string password)
        {
            if (!Database.ExistAccount(player))
            {
                if (!player.LoggedIn && password.Length > 6)
                {
                    Database.CreateAccount(player, password);
                    player.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
                    player.Model = (uint)PedModel.Paramedic01SMM;
                    player.LoggedIn = true;
                    player.Emit("CloseLoginHud");
                    player.SendChatMessage("Erfolgreich registriert! : " + password);
                }
            }
            else
            {
                player.Emit("CloseLoginHud");
                player.Emit("LoginHud");
            }
        }

        [ClientEvent("Event.Login")]
        public void OnPlayerLogin(MyPlayer.Player player, string password)
        {
            if(Database.ExistAccount(player))
            {
                if(!player.LoggedIn && password.Length > 6)
                {
                    if(Database.PasswordCheck(player,password))
                    {
                        Database.LoadAccount(player);
                        player.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
                        player.Model = (uint)PedModel.Paramedic01SMM;
                        player.LoggedIn = true;
                        player.Emit("CloseLoginHud");
                        player.SendChatMessage("Erfolgreich eingeloggt!");
                    }
                    else
                    {
                        player.Emit("SendErrorMessage", ""+password);
                    }
                }
                else
                {
                    player.Emit("SendErrorMessage", "Ungültige eingabe");
                }
            }
            else
            {
                player.Emit("CloseLoginHud");
                player.Emit("RegisterHud");
            }
        }
    }
}
