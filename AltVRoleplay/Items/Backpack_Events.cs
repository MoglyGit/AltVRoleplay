using AltV.Net;
using AltVRoleplay.Events.Player;

namespace AltVRoleplay.Items
{
    public class Backpack_Events : IScript
    {
        [ClientEvent("getOtherBackPackItems")]
        public static void GetOtherBackPackItems(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Items? item = ItemList.ItemsList.Find(x=> x.Id == id);
            if (item == null) return;
            Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
            if (back == null) return;
            if(!CanUseBackpack(back))
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Rucksack wird gerade genutzt");
                return;
            }
            player.Emit("showOtherHud", 3, back.Inv.Length);
            float actuallMass = PlayerInv_Handler.LoadOtherInv(player, back.Inv);
            player.Emit("addOtherHud", back.MaxWeight.ToString("0.00"), actuallMass.ToString("0.00"));

            if (player.HasData("OpenedOtherBackpack"))
            {
                player.GetData("OpenedOtherBackpack", out Backpack? oldback);
                if(oldback != null)
                {
                    oldback.UsedBy = null;
                }
            }
            player.SetData("OpenedOtherBackpack",back);
            back.UsedBy = player;
        }

        [ClientEvent("CloseOtherBackpack")]
        public static void CloseOtherBackpack(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.HasData("OpenedOtherBackpack"))
            {
                player.GetData("OpenedOtherBackpack", out Backpack? oldback);
                if (oldback != null)
                {
                    oldback.UsedBy = null;
                }
            }
            player.DeleteData("OpenedOtherBackpack");
        }

        public static bool CanUseBackpack(Backpack? back)
        {
            if (back == null) return false;
            if (back.UsedBy == null) return true;
            foreach (MyPlayer.Player p in Alt.GetAllPlayers())
            {
                if (p != back.UsedBy) continue;
                if (p.HasData("OpenedOtherBackpack"))
                {
                    p.GetData("OpenedOtherBackpack", out Backpack pback);
                    if (pback == back) return false;
                    p.Emit("closeInventory");
                    back.UsedBy = null;
                    return true;
                }
                return true;
            }
            return true;
        }
    }
}
