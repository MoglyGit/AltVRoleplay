using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Muellspace
{
    public class MuellEvent
    {
        public static void Search(MyPlayer.Player player, int size)
        {
            int[] place = player.GetFreeInvPlace();
            if (place[0] == -1 && place[1] == -1)
            {
                player.SendChatMessage("Du hast kein Platz im Inventar für neue Items");
                return;
            }
            player.SendChatMessage("Du krammst im Müll");
            
            Random rnd = new Random();
            switch (size)
            {
                case 2:
                    if (rnd.Next(100) > 98)
                    {
                        player.SendChatMessage("Du hast in eine Nadel gefasst, lass dich auf Krankheiten untersuchen");
                    }
                    if (rnd.Next(100) > 98)
                    {
                        player.SendChatMessage("Du hast eine Waffe gefunden");
                        player.GiveDBWeapon(ServerEnums.Weapons.Pistol);
                    }
                    if (rnd.Next(100) > 90)
                    {
                        player.GiveMoney(100+rnd.Next(200));
                        player.SendChatMessage("Du hast Geld gefunden");
                    }
                    if (rnd.Next(100) > 60)
                    {
                        player.Health = (ushort)(player.Health-5);
                        player.SendChatMessage("Du hast dich an Glas geschnitten und Blutest jetzt");
                    }
                    if (rnd.Next(100) > 40)
                    {
                        int pfand = 1 + rnd.Next(10);
                        player.SendChatMessage("Du hast "+pfand+" Pfandflaschen gefunden");
                    }
                    else player.SendChatMessage("Du findest nichts");
                    break;
                case 1:
                    if (rnd.Next(100) > 40)
                    {
                        int pfand = 1 + rnd.Next(10);
                        player.SendChatMessage("Du hast " + pfand + " Pfandflaschen gefunden");
                    }
                    else player.SendChatMessage("Du findest nichts");
                    break;
            }

        }
    }
}
