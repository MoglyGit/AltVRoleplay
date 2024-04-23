
using AltVRoleplay.Items;
using static AltVRoleplay.ServerEnums;

namespace AltVRoleplay.Events.Dealer
{
    public class Dealer_Handler
    {
        public static int SellItem(MyPlayer.Player player, ServerEnums.Items removeditem, int course, bool usingMass=false)
        {
            float money = 0;
            int[] inv = player.Inv;
            for (int i = 0; i < inv.Length; i++)
            {
                Items.Items? backitem = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Backpack != 0);
                if (backitem != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == backitem.Backpack);
                    if (back != null)
                    {
                        for (int a = 0; a < back.Inv.Length; a++)
                        {
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == removeditem);
                            if (itemb != null)
                            {
                                if(usingMass) money += course * itemb.Mass;
                                else money += course * itemb.Amount;
                                itemb.Remove();
                                back.Inv[a] = 0;
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == removeditem);
                if (item != null)
                {
                    if (usingMass) money += course * item.Mass;
                    else money += course * item.Amount;
                    item.Remove();
                    inv[i] = 0;
                }
            }
            return (int)money;
        }
    }
}
