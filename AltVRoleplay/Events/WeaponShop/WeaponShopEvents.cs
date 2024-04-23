using AltV.Net;
using AltVRoleplay.Items;
using AltVRoleplay.Ped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Events.WeaponShop
{
    public class WeaponShopEvents : IScript
    {
        [ClientEvent("sellPlayerWeapon")]
        public static void SellPlayerWeapon(MyPlayer.Player player, int weaponid, int price)
        {
            if (!player.LoggedIn) return;
            if(player.Money < price)
            {
                player.Emit("weaponError", "Das Produkt liegt leider über Ihren Buget.");
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] == -1 && place[1] == -1)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.notEnougInvPlace);
                return;
            }
            Items.Items item = new Items.Items();
            switch (weaponid)
            {
                case 1://pistol
                    item.CreateWepon(ServerEnums.Weapons.Pistol);
                    break;
                case 2://MP
                    item.CreateWepon(ServerEnums.Weapons.MicroMP);
                    break;
                default:
                    return;
            }
            if (place[0] != -1) player.Inv[place[0]] = item.Id;
            else if (place[1] != -1)
            {
                Backpack? back = player.GetPlayerBackPack();
                if (back != null)
                {
                    back.AddItem(place[1], item.Id);
                }
            }
            player.GiveInvWeapons();
            player.GiveMoney(-price);
            player.Emit("weaponError", "Vielen Dank für ihren Einkaufen, brauchen Sie noch etwas?");
        }
        [ClientEvent("sellPlayerMuni")]
        public static void sellPlayerMuni(MyPlayer.Player player, int muni, int price)
        {
            if (!player.LoggedIn) return;
            if (player.Money < price)
            {
                player.Emit("weaponError", "Das Produkt liegt leider über Ihren Buget.");
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] == -1 && place[1] == -1)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.notEnougInvPlace);
                return;
            }
            Items.Items item = new Items.Items();
            switch (muni)
            {
                case 1://pistol
                    item.CreateMuni(ServerEnums.Muni.Pistol);
                    break;
                case 3://MP
                    item.CreateMuni(ServerEnums.Muni.MP);
                    break;
                default:
                    return;
            }
            if (place[0] != -1) player.Inv[place[0]] = item.Id;
            else if (place[1] != -1)
            {
                Backpack? back = player.GetPlayerBackPack();
                if (back != null)
                {
                    back.AddItem(place[1], item.Id);
                }
            }
            player.GiveInvWeapons();
            player.GiveMoney(-price);
        }
        public static void ShowWeaponShop(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            PedEntity? ped = StaticPeds.Gunmann.Find(p => p.TextLabel != null && p.TextLabel.x == x);
            if (ped == null) return;
            player.Emit("showWeaponShop");
        }
    }
}
