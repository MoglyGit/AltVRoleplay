
using AltV.Net;
using AltVRoleplay.Events.Player;

namespace AltVRoleplay.Events.Wardrobe
{
    public class WardrobeEvents : IScript
    {
        [ClientEvent("getWardrobeItems")]
        public static void GetWardrobeItemsForInv(MyPlayer.Player player)
        {
            if (!player.HasData("WardrobeUse")) return;
            player.GetData("WardrobeUse",out SQL.Inventory.Wardrobe w);

            if (w == null || w.UsedBy != player) { player.Notification(ServerEnums.Notify.Warning, "Fehler bei der Schrank nutzung"); return; }
            float actuallMass = PlayerInv_Handler.LoadOtherInv(player,w.Inv);
            player.Emit("addOtherHud", w.MaxWeight.ToString("0.00"), actuallMass.ToString("0.00"));
        }
        [ClientEvent("closeOtherInfWardrobe")]
        public static void CloseWardrobe(MyPlayer.Player player)
        {
            if (!player.HasData("WardrobeUse")) return;
            player.GetData("WardrobeUse", out SQL.Inventory.Wardrobe w);
            w.UsedBy = null;
            player.DeleteData("WardrobeUse");
        }
    }
}
