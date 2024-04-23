using AltV.Net;
using AltV.Net.EntitySync;
using AltVRoleplay.Items;
using AltVRoleplay.Objects;

namespace AltVRoleplay.Events.Entitys
{
    public class EntityEvents : IScript
    {
        [ClientEvent("ObjectDamagedWithVehicle")]
        public static void ObjectDamagedWithVehicle(MyPlayer.Player player, ulong entityId)
        {
            if (!player.LoggedIn) return;
            Objects.Gravel? gravel = ObjectLists.GravelServerList.Find(x => x.Object != null && x.Object.Entity.Id == entityId);
            if (gravel == null) return;
            if (!gravel.Object.Exists) return;
            if (!player.IsInVehicle) return;
            if (player.Vehicle.Model != Alt.Hash("bulldozer")) return;
            Random rnd = new Random();
            if (!ServerLists.AddGravel(5 + rnd.Next(3, 12)))
            {
                player.Notification(ServerEnums.Notify.Warning,"Der Gravelstand ist voll!");
                return;
            }
            if (player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Gravel] + player.BergBau * 50)
            {
                player.Notification(ServerEnums.Notify.Warning, "Genug gearbeitet");
                player.StopMinijob();
                return;
            }
            gravel.Remove();
            int money = 10 + rnd.Next(1, 11) + player.BergBau * 10;
            player.PayDayMoney += money;
            player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] += money;
            player.Notification(ServerEnums.Notify.Info, "Payday +"+money);
            return;
 
        }
        [ClientEvent("ObjectDamaged")]
        public static void ObjectDamaged(MyPlayer.Player player, ulong entityId)
        {
            if (!player.LoggedIn) return;
            Objects.Tree? tree = ObjectLists.TreeServerList.Find(x => x.Object != null && x.Object.Entity.Id == entityId);
            if (tree != null)
            {
                if (!tree.interaction) return;
                if (!tree.Object.Exists) return;
                if (player.CurrentWeapon != Alt.Hash("weapon_hatchet")) return;
                tree.Health -= 1 + 2 * player.KraftLevel;
                player.AddSkill(ServerEnums.SkillType.Kraft, 1);
                if (tree.Health > 0) return;
                tree.Fall();
                return;
            }
            Logs? log = ObjectLists.LogServerList.Find(x => x.Object != null && x.Object.Entity.Id == entityId);
            if (log != null)
            {
                if (player.CurrentWeapon != Alt.Hash("weapon_hatchet")) return;
                int[] place = player.GetFreeInvPlace();
                if (place[0] != -1 || place[1] != -1)
                {
                    Items.Items item = new();
                    item.CreateItem(ServerEnums.Items.Wood, 5);
                    if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                    else if (place[1] != -1)
                    {
                        Backpack? back = player.GetPlayerBackPack();
                        if (back != null)
                        {
                            back.AddItem(place[1], item.Id);
                        }
                    }
                    log.Health -= 5;
                    if (log.Health <= 0) log.Remove();
                    player.Notification(ServerEnums.Notify.Info, "Holz gehackt");
                    return;
                }
                player.Notification(ServerEnums.Notify.Warning, Message.notEnougInvPlace);
                return;
            }
        }
    }
}
