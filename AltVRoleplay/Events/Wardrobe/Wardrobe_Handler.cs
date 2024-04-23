
using AltV.Net;

namespace AltVRoleplay.Events.Wardrobe
{
    public class Wardrobe_Handler
    {
        public static void OpendWardrobe(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            SQL.Inventory.Wardrobe? w = SQL.Inventory.WardrobeList.WardrobeServerList.Find(w=> w.X == x && w.Dimension == player.Dimension);
            if (w == null) return;
            if (player.Position.Distance(w.GetPosition()) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                return;
            }
            if(!CanUseWardrobe(w))
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Schrank wird gerade genutzt");
                return;
            }
            player.Emit("openInventory",(int)ServerEnums.OtherInventoryTypes.Wardrobe, w.Inv.Length);
            player.SetData("WardrobeUse", w);
            w.UsedBy = player;
        }

        public static bool CanUseWardrobe(SQL.Inventory.Wardrobe? w)
        {
            if (w == null) return false;
            if (w.UsedBy == null) return true;
            foreach (MyPlayer.Player p in Alt.GetAllPlayers())
            {
                if (p != w.UsedBy) continue;
                if(p.Position.Distance(w.GetPosition()) <= 5 && p.HasData("WardrobeUse"))
                {
                    p.GetData("WardrobeUse", out SQL.Inventory.Wardrobe pw);
                    if (w == pw) return false;
                    p.Emit("closeInventory");
                    w.UsedBy = null;
                    return true;
                }
                return true;
            }
            return true;
        }
    }
}
