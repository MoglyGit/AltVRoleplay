

using AltV.Net;
using AltVRoleplay.Items;
using AltVRoleplay.SQL.Store.Class;

namespace AltVRoleplay.Events.Shop247
{
    public class Shop247Events : IScript
    {
        [ClientEvent("Buy247Shop")]
        public static void Buy247Shop(MyPlayer.Player player, int price, int id)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s => s.Id == id);
            if (store == null) return;
            if(store.Owned != 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Laden steht nicht zum Verkauf");
                return;
            }
            if (player.Position.Distance(store.GetPosition()) > 5)
            {
                player.Notification(ServerEnums.Notify.Warning,"Du bist zu weit Weg");
                return;
            }
            if(player.Bank < price)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast nicht genug Geld auf deinem Konto");
                return;
            }
            store.Owned = player.SocialClubId;
            store.Owner = player.GetFullName();
            store.SellPrice = 0;
            player.BankTransfer(-price, store.Name, "Business Gekauft");
            store.Update();
            store.Save();
        }
        [ClientEvent("changeShopName")]
        public static void ChangeShopName(MyPlayer.Player player, string name, int id)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s => s.Id == id);
            if (store == null) return;
            if (store.Ped == null) return;
            ServerMethods.ChangeBlipName(store.Ped.x, store.Ped.y, store.Name, name);
            store.Name = name;
            store.Update();
            store.Save();
        }
        [ClientEvent("ChangeProduktSell")]
        public static void ChangeProduktSell(MyPlayer.Player player,int id, int number, int price, string item)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s => s.Id == id);
            if (store == null) return;
            if (store.Ped == null) return;
            if (number > store.SellProducts.Length) return;
            if (Shop247Handler.SellItems.TryGetValue(item, out ServerEnums.Items itemId))
            {
                store.SellProducts[number] = (int)itemId;
                store.Products_Price[number] = price;
                store.Save();
                return;
            }
            player.Notification(ServerEnums.Notify.Danger, "Produkt nicht gefunden, Kontaktiere ein Admin");
        }
        [ClientEvent("BuyShopItem")]
        public static void BuyShopItem(MyPlayer.Player player, int i, int id)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s => s.Id == id);
            if (store == null) return;
            if (store.Ped == null) return;
            if (i > store.SellProducts.Length) return;
            int price = store.Products_Price[i];
            if(player.Money < price)
            {
                player.Notification(ServerEnums.Notify.Check, "Nicht genug Geld dabei");
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                int itemamount = 1;
                if ((ServerEnums.Items)store.SellProducts[i] == ServerEnums.Items.Wurm) itemamount = 100;
                if ((ServerEnums.Items)store.SellProducts[i] == ServerEnums.Items.Made) itemamount = 100;
                item.CreateItem((ServerEnums.Items)store.SellProducts[i], itemamount);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.Notification(ServerEnums.Notify.Check, "Produkt für " + price + "$ gekauft");
                player.GiveMoney(-price);
                store.Konto += price;
                Random rnd = new Random();
                store.Products -= 10 + rnd.Next(1, 20);
                if(store.Products < 0)store.Products = 0;
                store.Save();
                return;
            }
            player.Notification(ServerEnums.Notify.Warning, "Kein Platz im Inventar mehr");
            player.Emit("CloseShop247Hud");
        }
    }
}
