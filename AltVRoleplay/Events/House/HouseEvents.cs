using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltV.Net.Data;
using AltVRoleplay.Items;

namespace AltVRoleplay.Events.House
{
    public class HouseEvents : IScript
    { 
        [ClientEvent("tryLockingApartment")]
        public static void TryLockingApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (a.id != player.Dimension && player.Position.Distance(new Position(a.x, a.y, a.z)) > 2) { player.Emit("clsoeApartmentView"); return; }
            if (player.HasHouseKey(a.id))
            {
                if (a.Lock == 0)
                {
                    a.Lock = 1;
                    player.Notification(ServerEnums.Notify.Check, "Abgeschlossen");
                    player.Emit("Sound", "DoorLockSound");
                }
                else
                {
                    a.Lock = 0;
                    player.Notification(ServerEnums.Notify.Check,"Aufgeschlossen");
                    player.Emit("Sound", "DoorUnLockSound");
                }
                return;
            }
        }
        [ClientEvent("unrentApartment")]
        public static void UnrentApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (player.Position.Distance(new Position(a.x, a.y, a.z)) > 2) { player.Emit("clsoeApartmentView"); return; }
            if (a.owned != player.SocialClubId) { player.Emit("clsoeApartmentView"); return; }
            if(a.MinRentTime > 0)
            {
                //player.Emit("ApartmentInfo", "Die mindest Vertragslaufzeit beträgt noch "+a.MinRentTime+" PayDay/s");
                player.Notification(ServerEnums.Notify.Danger, "Vertragslaufzeit beträgt noch "+a.MinRentTime+" PayDay/s");
                return;
            }
            if (a.Trash >= 100) { player.Notification(ServerEnums.Notify.Danger, "Der Müll muss noch abgeholt werden"); return; }
            player.RemoveHouseKey(id);
            a.Reset();
            player.Emit("clsoeApartmentView");
            player.Save();
        }
        [ClientEvent("ringByApartment")]
        public static void RingByApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            player.Emit("Sound", "DoorBell");
            player.Notification(ServerEnums.Notify.Info, "Klingel betätigt");
            foreach (MyPlayer.Player p in Alt.GetAllPlayers())
            {
                if (!p.LoggedIn) continue;
                if (p.Dimension != a.id) continue;
                p.Notification(ServerEnums.Notify.Info, "Es klingelt an der Haustür");
                p.Emit("Sound", "DoorBell");
            }
        }
        [ClientEvent("tryLeaveApartment")]
        public static void TryLeaveApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (a.id != player.Dimension) { player.Emit("clsoeApartmentView"); return; }
            if (a.Lock == 1) { player.Notification(ServerEnums.Notify.Danger, "Apartment ist abgeschlossen"); return; }
            player.Position = new Position(a.x, a.y, a.z);
            player.Dimension = 0;
            player.LastInterriorSwap = 5;
            player.Emit("clsoeApartmentView");
        }
        [ClientEvent("tryEnterApartment")]
        public static void TryEnterApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (player.Position.Distance(new Position(a.x, a.y, a.z)) > 2) { player.Emit("clsoeApartmentView"); return; }
            if (a.owned == 0) { player.Emit("clsoeApartmentView"); return; }
            if (a.Lock == 1) { player.Notification(ServerEnums.Notify.Danger, "Apartment ist abgeschlossen"); return; }
            if (a.Trash >= 200) { player.Notification(ServerEnums.Notify.Danger, "Apartment ist zu voll gemüllt"); return; }
            HouseInterrior.SetInterrior(player, a.interrior, a.id);
            player.LastInterriorSwap = 5;
            player.Emit("clsoeApartmentView");
        }
        [ClientEvent("tryRentApartment")]
        public static void TryRentApartment(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            if(player.BankType == 0)
            {
                player.Notification(ServerEnums.Notify.Danger, "Du hast kein Bankkonto");
                return;
            }
            Appartment? a = AppartmentList.AppartmentServerList.Find(x=>x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (player.Position.Distance(new Position(a.x, a.y, a.z)) > 2) { player.Emit("clsoeApartmentView"); return; }
            if (a.owned != 0) { player.Emit("clsoeApartmentView");  return; }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new Items.Items();
                item.CreateAppartmentKey(a);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                a.owned = player.SocialClubId;
                a.owner = "" + player.Fname + " " + player.Lname;
                a.Update();
                player.Notification(ServerEnums.Notify.Check, "Apartment gemietet");
                player.Emit("clsoeApartmentView");
                a.Save();
                player.Save();
                return;
            }
            player.SendChatMessage("Du kannst den Schlüssel nicht entgegen nehmen, mach Platz im Inventar");
        }
        [ClientEvent("showApartmentHud")]
        public static void ShowApartmentHud(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            if (player.LastInterriorSwap != 0) return;
            if (player.Dimension == 0)
            {
                Appartment? a = player.GetClosestAppartment();
                if (a == null) return;
                if (a.x == x)
                {
                    bool haskey = player.HasHouseKey(a.id);
                    if (a.owned == player.SocialClubId)
                    {
                        player.Emit("ShowApartment", 2, haskey, a.id);
                    }
                    else if(a.owned != 0)
                    {
                        player.Emit("ShowApartment", 1, haskey, a.id);
                    }
                    else
                    {
                        player.Emit("ShowApartment",0, haskey, a.id, a.rent);
                    }
                    if(player.Faction == (int)ServerEnums.Fraktions.Garbage && player.Duty == 1 && !player.HasData("Trash"))player.Emit("ShowGarbage");
                }
            }
            else
            {
                Appartment? a = AppartmentList.AppartmentServerList.Find(x=>x.id == player.Dimension);
                if (a == null) return;
                if(a.x_out == x)
                {
                    bool haskey = player.HasHouseKey(a.id);
                    player.Emit("ShowApartment", 3, haskey, a.id);
                }
            }
        }
    }
}
