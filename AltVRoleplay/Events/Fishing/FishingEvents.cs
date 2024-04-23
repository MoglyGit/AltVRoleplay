using AltV.Net;
using AltV.Net.Data;
using AltVRoleplay.Items;

namespace AltVRoleplay.Events.Fishing
{
    public class FishingEvents : IScript
    {
        [ClientEvent("FishHitter")]
        public static void PlayerHittetFish(MyPlayer.Player player, int type, int deep)
        {
            if (!player.LoggedIn) return;
            Random rnd = new Random();
            float mass = 100;
            ServerEnums.Items itemType = ServerEnums.Items.Fish;
            if (deep == 0) mass = (float)rnd.NextDouble() * 200 + 100;
            if (deep == 1) mass = (float)rnd.NextDouble() * 300 + 200;
            if (deep == 2) mass = (float)rnd.NextDouble() * 400 + 300;
            if (deep == 3) mass = (float)rnd.NextDouble() * 500 + 400;
            switch (type)
            {
                case 1:
                    itemType = ServerEnums.Items.KugelFish;
                    mass += (float)rnd.NextDouble() * 100;
                    break;
                case 2:
                    itemType = ServerEnums.Items.TropicalFish;
                    mass += (float)rnd.NextDouble() * 200;
                    break;
                case 3:
                    itemType = ServerEnums.Items.Kraken;
                    mass += (float)rnd.NextDouble() * 300;
                    break;
                case 4:
                    itemType = ServerEnums.Items.Dolphin;
                    mass += (float)rnd.NextDouble() * 400 + 7000;
                    break;
                case 5:
                    itemType = ServerEnums.Items.Shark;
                    mass += (float)rnd.NextDouble() * 500 + 9000;
                    break;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                item.CreateItem(itemType);
                mass /= 1000;
                item.Mass = mass;
                item.SaveItem();
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.Notification(ServerEnums.Notify.Info,"Fish erhalten");
                return;
            }
            player.Notification(ServerEnums.Notify.Warning,"Du hast kein Platz im Inventar");
        }
        [ClientEvent("RemoveKoeder")]
        public static void TryRemoveKoeader(MyPlayer.Player player)
        {
            player.GetData("Koeder", out Items.Items? item);
            if (item == null)return;
            item.Amount -= 1;
            if (item.Amount <= 0)
            {
                player.RemoveItemFromInv(item.Id);
                item.Remove();
                player.DeleteData("Koeder");
            }
        }
        [ClientEvent("TryFishing")]
        public static void TryFishing(MyPlayer.Player player)
        {
            if (player.IsInVehicle) return;
            if (!player.HasData("HasFishingRod")) return;
            if (!player.HasData("Koeder"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast keinen Köder");
                return;
            }
            player.GetData("Koeder",out Items.Items? item);
            if (item == null || !ItemList.ItemsList.Exists(x=> x.Id == item.Id))
            {
                player.Notification(ServerEnums.Notify.Warning, "Setz den Köder neu");
                return;
            }
            int type = 0;
            int typeChance = 10;
            int amount = 1;
            switch(item.Serveritem)
            {
                case ServerEnums.Items.Wurm:
                    typeChance += 10;
                    break;
                case ServerEnums.Items.Made:
                    amount += 1;
                    break;
                case ServerEnums.Items.TropicalFish:
                    amount += 1;
                    typeChance += 20;
                    break;
                case ServerEnums.Items.KugelFish:
                    amount += 2;
                    typeChance += 10;
                    break;
                case ServerEnums.Items.Fish:
                    amount += 1;
                    typeChance += 10;
                    break;
            }
            Random rnd = new Random();
            type = rnd.Next(0, 6);
            string info = "";
            if(player.Position.Distance(new Position(4863.059f, -1769.288f, 0.61828613f)) <= 200 || player.Position.Distance(new Position(-2800.2725f, 7648.378f, -0.72961426f)) <= 200)
            {
                info = "Du angelst im Delfin gebiet";
                amount += 2;
                if (item.Serveritem == ServerEnums.Items.KugelFish)
                {
                    type = 4;
                    typeChance += 30;
                }
                else
                {
                    type = 3;
                    typeChance += 35;
                }
            }
            else if (player.Position.Distance(new Position(-3376.8f, -1683.0593f, -1.5552979f)) <= 200 || player.Position.Distance(new Position(5660.993f, 6806.518f, -1.2182617f)) <= 200)
            {
                amount += 2;
                info = "Du angelst im Hai gebiet";
                if (item.Serveritem == ServerEnums.Items.TropicalFish)
                {
                    type = 5;
                    typeChance += 30;
                }
                else
                {
                    type = 3;
                    typeChance += 35;
                }
            }
            else if (player.Position.Distance(new Position(368.9934f, 3969.5078f, 30.89746f)) <= 200 || player.Position.Distance(new Position(468.87033f, -4588.7866f, 0.4835205f)) <= 200)
            {
                amount += 2;
                info = "Du angelst im Tropischen gebiet";
                type = 2;
                typeChance += 60;
            }
            else if (player.Position.Distance(new Position(2095.912f, 4295.3276f, 30.324585f)) <= 200 || player.Position.Distance(new Position(5296.615f, 3085.1077f, -1.4710693f)) <= 200)
            {
                amount += 2;
                info = "Du angelst im Kugelfisch gebiet";
                type = 2;
                typeChance += 60;
            }
            if (amount > 4)amount = 4;
            if(info != "")player.Notification(ServerEnums.Notify.Check,info);
            player.Emit("StartFishing", amount, type, typeChance);
        }
        [ClientEvent("PlayFishingAnimation")]
        public static void PlayAnimation(MyPlayer.Player player, bool state)
        {
            if (!player.HasData("HasFishingRod")) return;
            if (state)
            {
                player.BlockAnimationMenu(true);
                player.PlayAnimation("amb@world_human_stand_fishing@idle_a", "idle_c", 8, 8, -1, 1, 0, true, true, true);
                player.Notification(ServerEnums.Notify.Info, "Angel ausgeworfen");
            }
            else
            {
                player.BlockAnimationMenu(false);
                player.PlayAnimation("amb@world_human_stand_fishing@idle_a", "idle_c", 8, 1, 1000, 0, 0, true, true, true);
                player.Notification(ServerEnums.Notify.Info, "Angel eingeholt");
            }
        }
    }
}
