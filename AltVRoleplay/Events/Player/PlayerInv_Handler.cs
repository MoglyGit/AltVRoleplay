
using AltVRoleplay.Items;

namespace AltVRoleplay.Events.Player
{
    public class PlayerInv_Handler
    {
        public static float LoadOtherInv(MyPlayer.Player player,int[] Inventory)
        {
            float actuallMass = 0f;
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == 0 || Inventory[i] == -1) continue;
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inventory[i]);
                if (item == null) continue;
                string src = PedEvents.GetSource(item);
                int type = PedEvents.GetType(player, item);
                if(item.Backpack != 0)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null) continue;
                    float backmass = back.GetBackpackMass();
                    player.Emit("addOther", item.Id, item.Description, type, i, src, backmass, 0, item.MaxAmount);
                    actuallMass += backmass;
                    continue;
                }
                player.Emit("addOther", item.Id, item.Description, type, i, src, item.Amount, item.Mass, item.MaxAmount);
                actuallMass += item.Mass * item.Amount;
            }
            return actuallMass;
        }
    }
}
