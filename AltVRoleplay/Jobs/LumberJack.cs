using AltV.Net;
using AltVRoleplay.Items;
using AltVRoleplay.Ped;

namespace AltVRoleplay.Jobs
{
    public class LumberJack
    {
        static readonly int am= 8;
        static readonly int pm = 18;
        public static void CheckLumberJackArea(MyPlayer.Player player)
        {
            if (player.MiniJob != (int)ServerEnums.MiniJobs.LumberJack) return;
            if (ServerMethods.IsJobClosed(player, am, pm)) return;
            if (!(player.Position.X < -208.04836f && player.Position.X > -912.567f && player.Position.Y > 4810.2856f && player.Position.Y < 5773.2134f))
            {
                player.WarnLeavingArea();
                return;
            }
        }
        public static void StartJob(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            if (player.MiniJob == (int)ServerEnums.MiniJobs.LumberJack)
            {
                player.Notification(ServerEnums.Notify.Info,"Job beendet");
                player.StopMinijob();
                return;
            }
            if (player.MiniJob != (int)ServerEnums.MiniJobs.None)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist noch in einem Job unterwegs");
                return;
            }
            if (player.KraftLevel < 2)
            {
                player.Notification(ServerEnums.Notify.Warning, "Dein Kraftlevel ist zu niedrig für diesen Job");
                return;
            }
            player.Notification(ServerEnums.Notify.Info, "Du kannst nun Holzhacken gehen");
            player.GiveWeapon(Alt.Hash("weapon_hatchet"), 1, true);
            player.MiniJob = (int)ServerEnums.MiniJobs.LumberJack;
        }

        public static void ProcessingWood(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            //hat Lizenz einfügen
            if (player.MiniJob != (int)ServerEnums.MiniJobs.LumberJack) return;
            if (!ServerMethods.HasOpen(player, am, pm)) return;
            int[] inv = player.Inv;
            int proctime = 1;
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
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.Wood);
                            if (itemb != null)
                            {
                                proctime += itemb.Amount;
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == ServerEnums.Items.Wood);
                if (item != null)
                {
                    proctime += item.Amount;
                }
            }
            if (proctime == 1)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast nichts zum verarbeiten");
                return;
            }
            if (!player.SetProgress(proctime / 2, (int)ServerEnums.ProgressEvent.ProcessingWood, "Holz wird verarbeitet...")) return;
        }
        public static void GiveProcessedWood(MyPlayer.Player player)
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
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.Wood);
                            if (itemb != null)
                            {
                                itemb.Serveritem = ServerEnums.Items.ProcessedWood;
                                itemb.Amount = itemb.Amount * 2 / 3;
                                itemb.Mass = 0.1f;
                                itemb.Description = "Verarbeitetes Holz";
                                itemb.SaveItem();
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == ServerEnums.Items.Wood);
                if (item != null)
                {
                    item.Serveritem = ServerEnums.Items.ProcessedWood;
                    item.Amount = item.Amount * 2 / 3;
                    item.Mass = 0.1f;
                    item.Description = "Verarbeitetes Holz";
                    item.SaveItem();
                }
            }
        }

        public static void SellWood(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (!player.HasData("SellWoodPed")) return;
            //hat Lizenz einfügen
            player.GetData("SellWoodPed", out PedEntity? ped);
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
                            Items.Items? itemb = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.ProcessedWood);
                            if (itemb != null)
                            {
                                money += course * itemb.Amount;
                                itemb.Remove();
                                back.Inv[a] = 0;
                            }
                        }
                    }
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == inv[i] && x.Serveritem == ServerEnums.Items.ProcessedWood);
                if (item != null)
                {
                    money += course * item.Amount;
                    item.Remove();
                    inv[i] = 0;
                }
            }
            if(money == 0)
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
