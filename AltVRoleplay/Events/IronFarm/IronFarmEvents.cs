using AltV.Net;
using AltVRoleplay.Items;
using AltVRoleplay.Ped;

namespace AltVRoleplay.Events.IronFarm
{
    public class IronFarmEvents : IScript
    {
        [ClientEvent("GivePlayerIron")]
        public static void GivePlayerIron(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            int points = 2;
            player.AddSkill(ServerEnums.SkillType.Kraft, points);
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                Random rnd = new Random();
                item.CreateItem(ServerEnums.Items.Metall, 2+rnd.Next(1,3));
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.Notification(ServerEnums.Notify.Info, "Eisenerz abgebaut");
                return;
            }
            player.Notification(ServerEnums.Notify.Warning, Message.notEnougInvPlace);
        }
        [ClientEvent("PickAxeAnimation")]
        public static void PlayPickAxeAnimation(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            player.PlayAnimation("amb@world_human_hammering@male@idle_a", "idle_a",1,1,2,0,0,true,true,true);
        }

        public static void ChangeIron(MyPlayer.Player player)
        {
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
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.Metall);
                            if (itemb != null)
                            {
                                itemb.Serveritem = ServerEnums.Items.ProcessedMetall;
                                itemb.Amount = itemb.Amount * 1 / 3;
                                itemb.Mass = 0.2f;
                                itemb.Description = "Verarbeitetes Eisen";
                                itemb.SaveItem();
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == ServerEnums.Items.Metall);
                if (item != null)
                {
                    item.Serveritem = ServerEnums.Items.ProcessedMetall;
                    item.Amount = item.Amount * 1 / 3;
                    item.Mass = 0.2f;
                    item.Description = "Verarbeitetes Eisen";
                    item.SaveItem();
                }
            }
        }
        public static void SellIron(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (!player.HasData("SellIronPed")) return;
            //hat Lizenz einfügen
            player.GetData("SellIronPed", out PedEntity? ped);
            if (ped == null) return;
            int money = 0;
            int course = ped.AnKaufKurs;
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
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.ProcessedMetall);
                            if (itemb != null)
                            {
                                money += course * itemb.Amount;
                                itemb.Remove();
                                back.Inv[a] = 0;
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == ServerEnums.Items.ProcessedMetall);
                if (item != null)
                {
                    money += course * item.Amount;
                    item.Remove();
                    inv[i] = 0;
                }
            }
            if (money == 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast nichts zum verkaufen");
                return;
            }
            ped.Storage -= (int)(money / course);
            StaticPeds.UpdateAnkaufPed(ped);
            player.GiveMoney(money);
        }
    }
}
