using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Data;
using AltVRoleplay.MyVehicle;
using AltVRoleplay.Voice;
using AltV.Net.Client.Elements.Entities;
using AltVRoleplay.Text;
using TextLabel = AltVRoleplay.Text.TextLabel;
using AltVRoleplay.Events.InteractionMenu;
using AltVRoleplay.SQL.LTD_Gas.Class;

namespace AltVRoleplay.Events.Player
{
    public class PlayerEvents: IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public static void OnPlayerConnect(MyPlayer.Player player, string reason)
        {
            Server.Log($"Der Spieler {player.Name}:{player.SocialClubId} hat den Server betreten");
            player.Emit("ResetRoute");
            //Login/reg page
            if (Database.ExistAccount(player))
            {
                player.Emit("LoginHud");
            }
            else
            {
                player.Emit("RegisterHud");
            }
        }
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public static void OnPlayerDisconnect(MyPlayer.Player player, string reason)
        {
            Server.Log($"Spieler {player.Name} hat den Server verlassen - Grund: {reason}");
            Channels.RemovePlayerGlobalVoice(player);
            if (!player.LoggedIn) return;

            InteractionMenu_Events.CloseTargetPlayerInv(player);

            DisconnectInfo disconnectInfo = new DisconnectInfo("Spieler (ID:" + player.Id+") ausgeloggt\nGrund: "+ reason,player);
            StaticTextLabel.DisconnectInfoList.Add(disconnectInfo);

            player.SaveInvMuni();
            player.Save();
            player.Money = 0;
            if (player.MiniJobPed != null) player.MiniJobPed.Remove();
            if (player.MiniJobCar != null) player.MiniJobCar.Destroy();
            if (player.schoolcar != null)player.schoolcar.Destroy();
            if (player.pTimer != null) { player.pTimer.Stop(); player.pTimer.Dispose(); }
            if (player.RentedVehicle != null) player.UnrentVehilce();
            if (player.HasData("tree"))
            {
                player.GetData("tree", out Objects.Tree tree);
                tree.interaction = true;
                player.DeleteData("tree");
            }
            player.DeleteData("Gravel");
            player.DeleteData("Checkpoint");
            if (player.HasData("LTD:PAYMENT") && player.HasData("LTD:ID"))
            {
                player.GetData("LTD:PAYMENT", out int pay);
                if (pay > 0)
                {
                    player.GetData("LTD:ID", out int id);
                    LTDGasStation? ltdStolen = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == id);
                    if (ltdStolen != null) player.CreateCrime(2, pay, "Tankstellen Rechnung nicht bezahlt", 1, 3 * 60, "Tankstelle: " + ltdStolen.Name);
                }
                player.DeleteData("LTD:PAYMENT");
                player.DeleteData("LTD:ID");
            }
            for (int i= 0; i< Enum.GetNames(typeof(ServerEnums.PlayerAttachedSlots)).Length; i++)
            {
                player.DetachObjectFromPlayer((ServerEnums.PlayerAttachedSlots)i);
            }
        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public static void OnPlayerLeaveVehicle(MyVehicle.MyVehicle vehicle, MyPlayer.Player player, byte seat)
        {
            if (!player.LoggedIn) return;
            if (seat == 1)
            {
                player.Emit("HideTacho");
            }
            if(player.schoolcar != null)
            {
                if (vehicle == (MyVehicle.MyVehicle)player.schoolcar)
                {
                    vehicle.Destroy();
                    player.Emit("Examreset");
                    player.Notification(ServerEnums.Notify.Danger, "Fahrprüfung nicht bestanden");
                    player.schoolcar = null;
                    return;
                }
            }
            if(player.MiniJobCar != null)
            {
                if(vehicle == player.MiniJobCar)
                {
                    player.Notification(ServerEnums.Notify.Info, "Job beendet");
                    player.StopMinijob();
                }
                player.DeleteData("Gravel");
            }
        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public static void OnPlayerEnterVehicle(MyVehicle.MyVehicle vehicle, MyPlayer.Player player, byte seat)
        {
            if (!player.LoggedIn) return;
            if(seat == 1)
            {
                int[] stats = VehList.GetInfosFromModel(vehicle.Model);
                player.Emit("ShowTacho", stats[1]);
            }
        }

        [ScriptEvent(ScriptEventType.PlayerChangeVehicleSeat)]
        public static void OnPlayerChangeVehicleSeat(MyVehicle.MyVehicle vehicle, MyPlayer.Player player, byte oldSeat, byte newSeat)
        {
            if (!player.LoggedIn) return;
            player.SendChatMessage("Change Seat:" + newSeat);
            if (newSeat == 1)
            {
                int[] stats = VehList.GetInfosFromModel(vehicle.Model);
                player.Emit("ShowTacho", stats[1]);
                return;
            }
            if(oldSeat == 1)
            {
                player.Emit("HideTacho");
                return;
            }
        }
        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public void OnPlayerDamage(MyPlayer.Player player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            // ...
        }

        [ScriptEvent(ScriptEventType.Checkpoint)]
        public void OnCheckpoint(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            // ...
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public void OnPlayerDead(MyPlayer.Player player, IEntity killer, uint weapon)
        {
            player.SetPosition(player.Position.X, player.Position.Y, player.Position.Z);
            player.Health = player.MaxHealth;
        }

        public static void OnWeaponDamage(MyPlayer.Player player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
        {
            Server.Log("dmg: "+target.Type +" | "+target.Id);
            if (target.Type == BaseObjectType.Object) Objects.DamageTaken.ObjectDamage(player,target,weapon,damage);
        }
    }
}
