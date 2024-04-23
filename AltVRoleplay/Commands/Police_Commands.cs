using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Commands
{
    public class Police_Commands : IScript
    {
        [Command("mdc")]
        public static void CMD_MDC(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            player.Emit("showMDC",player.GetFullName());
        }
        [Command("checkperso")]
        public static void CMD_Unrent(MyPlayer.Player player, string id)
        {
            if (!player.LoggedIn) return;
            string getid="";
            string getsocial = "";
            int start = 0;
            int persoid = 0;
            ulong socialid = 0;
            foreach(char s in id)
            {
                if (start == 2) getsocial += s;
                if (s == 'S') start = 2;
                if (start==1) getid += s;
                if (s == 'L') start = 1;
            }
            bool success = int.TryParse(getid, out persoid) && ulong.TryParse(getsocial, out socialid);
            if(!success)
            {
                player.SendChatMessage("Personalausweis wurde im System nicht gefunden");
                return;
            }
            Perso? p = PersoList.PersoServerList.Find(x => x.id == persoid && x.Socialclubid == socialid);
            if(p==null)
            {
                player.SendChatMessage("Personalausweis wurde im System nicht gefunden");
                return;
            }
            if(p.Searched == 1)
            {
                player.SendChatMessage("Personalausweis wird vom Amt als gestohlen gemeldet");
                return;
            }
            player.SendChatMessage("Gültiger Ausweis");
        }
    }
}
