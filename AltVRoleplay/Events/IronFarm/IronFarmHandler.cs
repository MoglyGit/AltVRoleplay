
using AltV.Net.Data;

namespace AltVRoleplay.Events.IronFarm
{
    public class IronFarmHandler
    {
        public static void EquipPickAxe(MyPlayer.Player player)
        {
            if (player.HasData("HasPickAxe"))
            {
                UnEquipPickAxe(player);
                return;
            }
            if (player.HasattachedObject(ServerEnums.PlayerAttachedSlots.Right_Hand))
            {
                player.Notification(ServerEnums.Notify.Warning, "Rechte Hand ist nicht Frei");
                return;
            }
            player.AttachObjectToPlayer(ServerEnums.PlayerAttachedSlots.Right_Hand, "prop_tool_pickaxe", 6286, 0, new Position(0.1f,-0.3f,-0.21f), new Rotation(-1,0,0), false, false);
            player.Notification(ServerEnums.Notify.Check, "Spitzhacke ausgerüstet");
            player.SetData("HasPickAxe", 1);
        }

        public static void UnEquipPickAxe(MyPlayer.Player player)
        {
            if (!player.HasData("HasPickAxe")) return;
            player.DeleteData("HasPickAxe");
            player.DetachObjectFromPlayer(ServerEnums.PlayerAttachedSlots.Right_Hand);
            player.Notification(ServerEnums.Notify.Check, "Spitzhacke abgelegt");
        }
    }
}
