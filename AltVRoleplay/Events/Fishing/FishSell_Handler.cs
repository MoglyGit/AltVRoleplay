
using AltVRoleplay.Items;
using AltVRoleplay.Ped;

namespace AltVRoleplay.Events.Fishing
{
    public class FishSell_Handler
    {
        public static void SellFishes(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            int money = 0;
            money += RemoveFishesForMoney(player, ServerEnums.Items.Fish, 30);
            money += RemoveFishesForMoney(player, ServerEnums.Items.KugelFish, 60);
            money += RemoveFishesForMoney(player, ServerEnums.Items.TropicalFish, 70);
            money += RemoveFishesForMoney(player, ServerEnums.Items.Kraken, 100);
            if (money == 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast nichts zum verkaufen");
                return;
            }
            player.Notification(ServerEnums.Notify.Check, "Fishe verkauft +"+money);
            player.GiveMoney(money);
        }

        public static int RemoveFishesForMoney(MyPlayer.Player player,ServerEnums.Items removeditem, int course)
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
                                money += course * itemb.Mass;
                                itemb.Remove();
                                back.Inv[a] = 0;
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == removeditem);
                if (item != null)
                {
                    money += course * item.Mass;
                    item.Remove();
                    inv[i] = 0;
                }
            }
            return (int)money;
        }
    }
}
