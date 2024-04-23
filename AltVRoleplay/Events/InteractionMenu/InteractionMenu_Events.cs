using AltV.Net;
using AltVRoleplay.Events.Player;
using AltVRoleplay.MyPlayer;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Firma.Class;

namespace AltVRoleplay.Events.InteractionMenu
{
    public class InteractionMenu_Events : IScript
    {
        [ClientEvent("GetPlayerMenuInfos")]
        public static void GetPlayerMenuInfos(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            int showFirma = 0;
            if(FirmaList.FirmaServerList.Find(x=> x.Id == player.Firma && player.Position.Distance(x.GetPosition()) < 50) != null)showFirma = player.Firma;
            player.Emit("SetPlayerMenu", player.Faction, player.Faction_Rank, showFirma, (int)player.Firma_Rank);
        }
        [ClientEvent("InvadePlayerInFirma")]
        public static void InvadePlayerInFirma(MyPlayer.Player player, int pId)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = GetPlayer.GetPlayerById(pId);
            if (!InteractionCheck(player, target)) return;
            if (target == null) return;
            if(target.Firma != 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Spieler ist schon in einer Firma");
                return;
            }
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            FirmaWorkerSql.SetFirmaWorker(firma, target.SocialClubId, ServerEnums.FirmenRanks.Praktikant,100);
            player.Notification(ServerEnums.Notify.Check, "Spieler erfolgreich eingestellt");
            target.Notification(ServerEnums.Notify.Check, "Du wurdest eingestellt");
        }
        [ClientEvent("GetPlayerBodyInfos")]
        public static void GetPlayerBodyInfos(MyPlayer.Player player, int pId)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = GetPlayer.GetPlayerById(pId);
            if (!InteractionCheck(player, target)) return;
            if (target == null) return;
            if (target.GetClothes(1).Drawable != 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Spieler hat eine Maske auf");
                return;
            }
            player.Emit("PlayerBodyInfos", target.Height, ServerMethods.GetEyeColor(target.EyeColor));
        }

        [ClientEvent("AddPlayerFriend")]
        public static void AddPlayerFriend(MyPlayer.Player player, int pId, bool add)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = GetPlayer.GetPlayerById(pId);
            if (!InteractionCheck(player, target)) return;
            if (target == null) return;
            if (add)
            {
                target.AddFriend(player.SocialClubId);
                target.Notification(ServerEnums.Notify.Info, player.GetFullName() + " ist nun dein Freund");
                player.Notification(ServerEnums.Notify.Check, "Freundschaft verkündet");
                return;
            }
            target.RemoveFriend(player.SocialClubId);
            target.Notification(ServerEnums.Notify.Info, player.GetFullName() + " will kein Kontakt mehr");
            player.Notification(ServerEnums.Notify.Check, "Freundschaft gekündet");
        }

        [ClientEvent("GivePlayerMoneyFromPlayer")]
        public static void GivePlayerMoneyFromPlayer(MyPlayer.Player player, int pId, int money)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = GetPlayer.GetPlayerById(pId);
            if (!InteractionCheck(player, target)) return;
            if (target == null) return;
            if (money <= 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Mindestens 1$");
                return;
            }
            if(player.Money < money)
            {
                player.Notification(ServerEnums.Notify.Warning, "Soviel Geld hast du nicht dabei");
                return;
            }
            player.GiveMoney(-money);
            target.GiveMoney(money);
        }
        [ClientEvent("GetPlayerSearch")]
        public static void GetPlayerSearch(MyPlayer.Player player, int pId)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = GetPlayer.GetPlayerById(pId);
            if (!InteractionCheck(player, target)) return;
            if (target == null) return;
            if(target.HasData("InventoryGetSearched"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Spieler wird gerade durchsucht");
                return;
            }
            if(!(target.CurrentAnimationDict == 3496457595 && target.CurrentAnimationName == 2182080971) && !(target.CurrentAnimationDict == 1570672695 && target.CurrentAnimationName == 3079504400))
            {
                player.Notification(ServerEnums.Notify.Warning, "Spieler kann sich noch bewegen");
                return;
            }
            player.Emit("openInventory", (int)ServerEnums.OtherInventoryTypes.TargetPlayer, target.Inv.Length);
            player.SetData("SearchedPlayerInv", target);
            target.SetData("InventoryGetSearched", player);
            target.BlockInventory(true);
        }

        [ClientEvent("getTargetPlayerItems")]
        public static void GetTargetPlayerItems(MyPlayer.Player player)
        {
            if (!player.HasData("SearchedPlayerInv")) return;
            player.GetData("SearchedPlayerInv", out MyPlayer.Player targetPlayer);
            if(!InteractionCheck(player, targetPlayer))return;
            if (targetPlayer == null || !targetPlayer.LoggedIn) { player.Notification(ServerEnums.Notify.Warning, "Fehler beim Durchsuchen"); return; }
            if(!targetPlayer.HasData("InventoryGetSearched")) { player.Notification(ServerEnums.Notify.Warning, "Fehler beim Durchsuchen"); return; }
            player.GetData("InventoryGetSearched", out MyPlayer.Player checkP);
            if(checkP.SocialClubId != player.SocialClubId) { player.Notification(ServerEnums.Notify.Warning, "Fehler beim Durchsuchen"); return; }
            float actuallMass = PlayerInv_Handler.LoadOtherInv(player, targetPlayer.Inv);
            player.Emit("addOtherHud", targetPlayer.GetMaxInvWieght(), actuallMass.ToString("0.00"));
        }
        [ClientEvent("closeTargetPlayerInv")]
        public static void CloseTargetPlayerInv(MyPlayer.Player player)
        {
            if (!player.HasData("SearchedPlayerInv")) return;
            player.GetData("SearchedPlayerInv", out MyPlayer.Player targetPlayer);
            if (!targetPlayer.HasData("InventoryGetSearched"))  return;
            targetPlayer.GetData("InventoryGetSearched", out MyPlayer.Player checkP);
            player.DeleteData("SearchedPlayerInv");
            if(checkP.SocialClubId == player.SocialClubId)
            {
                targetPlayer.DeleteData("InventoryGetSearched");
            }
        }
        [ClientEvent("PlayAnimation")]
        public static void PlayAnimation(MyPlayer.Player player, string dic, string name, int blendin, int blendout,int flag, bool locked, bool invBlock)
        {
            if (player.IsAnimationMenuBlocked()) return;
            if (invBlock) player.BlockInventory(true);
            player.PlayAnimation(dic, name, blendin, blendout, -1, flag, 0, locked, locked, locked);
            player.Notification(ServerEnums.Notify.Info, "Animation spielt ab");
            Server.Log("Dic: "+player.CurrentAnimationDict+ " | anim: "+player.CurrentAnimationName);
        }
        [ClientEvent("StoppPlayAnimation")]
        public static void StoppPlayAnimation(MyPlayer.Player player, string dic, string name, bool invBlock)
        {
            if (player.IsAnimationMenuBlocked()) return;
            if (invBlock) player.BlockInventory(false);
            player.PlayAnimation(dic, name, 8, 1, 1000, 0, 0, true, true, true);
            player.Notification(ServerEnums.Notify.Info, "Animation gestoppt");
        }

        public static bool InteractionCheck(MyPlayer.Player player, MyPlayer.Player? target)
        {
            if (target == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Spieler nicht gefunden");
                int showFirma = 0;
                if (FirmaList.FirmaServerList.Find(x => x.Id == player.Firma && player.Position.Distance(x.GetPosition()) < 50) != null) showFirma = player.Firma;
                player.Emit("ShowInteractMenu", player.Faction, player.Faction_Rank, showFirma, (int)player.Firma_Rank);
                return false;
            }
            if (target.Position.Distance(player.Position) > 3)
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Spieler ist zu weit entfernt");
                return false;
            }
            return true;
        }
    }
}
