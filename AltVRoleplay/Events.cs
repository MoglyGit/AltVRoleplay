using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
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
            player.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
            player.Model = (uint)PedModel.Paramedic01SMM;

            Server.Log($"Der Spieler {player.Name} hat den Server betreten");
        }
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(MyPlayer.Player player, string reason)
        {
            Server.Log($"Spieler {player.Name} hat den Server verlassen - Grund: {reason}");
        }
    }
}
