using AltV.Net;
using AltV.Net.Enums;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Data;
using AltVRoleplay.Events.CreatePed;

namespace AltVRoleplay.Events.Login
{
    public class LoginEvents : IScript
    {

        [ClientEvent("Event.Register")]
        public static void OnPlayerRegister(MyPlayer.Player player, string password)
        {
            if (!Database.ExistAccount(player))
            {
                if (!player.LoggedIn && password.Length > 6)
                {
                    Database.CreateAccount(player, password);
                    player.Emit("CloseLoginHud");
                    player.LoggedIn = true;
                    player.Sex = 3;
                    PedEvents.CreateChar(player);
                }
            }
            else
            {
                player.Emit("CloseLoginHud");
                player.Emit("LoginHud");
            }
        }

        [ClientEvent("Event.Login")]
        public static void OnPlayerLogin(MyPlayer.Player player, string password)
        {
            if (Database.ExistAccount(player))
            {
                if (!player.LoggedIn && password.Length > 6)
                {
                    if (Database.PasswordCheck(player, password))
                    {
                        Database.LoadAccount(player);
                        player.Emit("CloseLoginHud");
                        player.SendChatMessage("Erfolgreich eingeloggt!");
                    }
                    else
                    {
                        player.Emit("SendErrorMessage", "Das Password ist Falsch");
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
