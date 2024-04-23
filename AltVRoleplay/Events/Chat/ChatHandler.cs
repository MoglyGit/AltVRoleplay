using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Events.Chat
{
    class ChatHandler : IScript
    {
        [ClientEvent("chat:message")]
        public void OnChatMessage(MyPlayer.Player player, string msg)
        {
            if (msg.Length == 0 || msg[0] == '/') return;
            foreach(MyPlayer.Player target in Alt.GetAllPlayers())
            {
                if (!target.LoggedIn) continue;
                if (target.Position.Distance(player.Position) > 10) continue;
                player.SendChatMessage($"{player.GetFullName()} sagt: {msg}");
            }
        }
        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(MyPlayer.Player player, string cmd)
        {
            player.SendChatMessage("{FF0000}[Server] {FFFFFF}Der Befehl /"+cmd+" konnte nicht gefunden werden");
        }
    }
}
