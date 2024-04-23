

using AltVRoleplay.SQL.Store.Class;

namespace AltVRoleplay.Events.Shop247
{
    public class Shop247Handler
    {
        public static Dictionary<string, ServerEnums.Items> SellItems = new Dictionary<string, ServerEnums.Items>{
            { "Angel", ServerEnums.Items.Fishingrod},
            { "Spitzhacke", ServerEnums.Items.Pickaxe},
            { "Dietrich", ServerEnums.Items.Lockpick },
            { "Erstehilfekasten", ServerEnums.Items.FirstAid},
            { "Werkezugkasten", ServerEnums.Items.Toolbox},
            { "Benzin", ServerEnums.Items.PatrolTank },
            { "Wurm", ServerEnums.Items.Wurm },
            { "Made", ServerEnums.Items.Made },
            { "Apfel", ServerEnums.Items.Apple },
            { "Gps", ServerEnums.Items.GPS },
            { "Hausschlüssel", ServerEnums.Items.NewHouseKey },
            { "Hausschloss", ServerEnums.Items.Houselock },
            { "Fahrzeugschlüssel", ServerEnums.Items.NewVehicleKey},
            { "Kaffe", ServerEnums.Items.Cafe},
            { "Energy", ServerEnums.Items.Energy },
            { "Bier", ServerEnums.Items.Beer },
            { "HotDog", ServerEnums.Items.Hotdog },
            { "Pizza", ServerEnums.Items.Pizza },
            { "Zigaretten", ServerEnums.Items.Cigarrets }
        };
        public static void ShowShopHud(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s => s.Ped != null && s.Ped.x == x);
            if (store == null) return;
            if (store.Owned == 0)
            {
                player.Notification(ServerEnums.Notify.Info,"Derzeit haben wir keine Produkte");
                return;
            }
            player.Emit("ShowStoreItems", store.Id);
            for (int i = 0; i < store.SellProducts.Length; i++)
            {
                string product = SellItems.FirstOrDefault(x=> x.Value == (ServerEnums.Items)store.SellProducts[i]).Key;
                if (product == default) continue;
                player.Emit("AddShowShop", i, product, store.Products_Price[i]);
            }
        }
        public static void ShowOwnerHud(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(s=> s.X == x);
            if (store == null) return;
            if(store.Owned == 0)
            {
                player.Emit("ShowStore247Buy",store.Name, store.SellPrice, store.Id);
                return;
            }
            if (player.SocialClubId != store.Owned) return;
            player.Emit("ShowStore247Owner", store.Name,store.Konto, store.Id, store.Eat, store.Products);
        }

        public static void LoadShopBlips(MyPlayer.Player player)
        {
            foreach(Store_247 shop in SQL.Store.StoreList.Store247ServerList)
            {
                if (shop.Ped == null) continue;
                int color = 1;
                if (shop.Owned != 0 && shop.SellPrice == 0) color = 2;
                player.Emit("CreateBlip", shop.Ped.x, shop.Ped.y, shop.Ped.z, 628,color,1f,true,shop.Name);
            }
        }
    }
}
