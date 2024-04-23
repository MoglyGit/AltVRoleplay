

using AltV.Net;
using AltV.Net.Data;

namespace AltVRoleplay.Events.Fishing
{
    public class FishingInventoryHandler
    {
        public static void EquipFishingRod(MyPlayer.Player player)
        {
            if (player.HasData("HasFishingRod"))
            {
                UnEquipFishingRod(player);
                return;
            }
            if (player.HasattachedObject(ServerEnums.PlayerAttachedSlots.Left_Hand))
            {
                player.Notification(ServerEnums.Notify.Warning,"Linke Hand ist nicht Frei");
                return;
            }
            player.AttachObjectToPlayer(ServerEnums.PlayerAttachedSlots.Left_Hand, "prop_fishing_rod_02", 18905, 0, new Position(0.1f,0.05f,0), new Rotation(-2,0.4f,0), false, false);
            player.Notification(ServerEnums.Notify.Check, "Angel ausgerüstet");
            player.Emit("ShowFishingIndicator");
            player.SetData("HasFishingRod",1);
        }

        public static void UnEquipFishingRod(MyPlayer.Player player)
        {
            if (!player.HasData("HasFishingRod")) return;
            player.DeleteData("HasFishingRod");
            player.DetachObjectFromPlayer(ServerEnums.PlayerAttachedSlots.Left_Hand);
            player.Notification(ServerEnums.Notify.Check, "Angel abgelegt");
            player.Emit("StopFishingIndicator");
            UnEuqipKoeder(player);
        }

        public static void EuqipKoeder(MyPlayer.Player player, Items.Items? item)
        {
            if (item == null) return;
            if (!player.HasData("HasFishingRod"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast keine Angel ausgerüstet");
                return;
            }
            if (player.HasData("Koeder"))
            {
                UnEuqipKoeder(player);
                return;
            }
            player.SetData("Koeder", item);
            player.Notification(ServerEnums.Notify.Info, item.Description+" angebracht");
        }
        public static void UnEuqipKoeder(MyPlayer.Player player)
        {
            if (!player.HasData("Koeder")) return;
            player.DeleteData("Koeder");
            player.Notification(ServerEnums.Notify.Info,"Köder entfernt");
        }

        public static void IsItemActualKoeder(MyPlayer.Player player, Items.Items item)
        {
            if (!player.HasData("Koeder")) return;
            player.GetData("Koeder", out Items.Items? koeder);
            if (koeder != null)
            {
                if (koeder.Id != item.Id) return;
                UnEuqipKoeder(player);
            }
        }
    }
}
