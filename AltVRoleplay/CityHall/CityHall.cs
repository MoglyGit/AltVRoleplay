using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.Items;
using AltVRoleplay.MyVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.CityHall
{
    public class CityHall : IScript
    {
        [ClientEvent("RegisterPlayerCar")]
        public static void RegisterPlayerCar(MyPlayer.Player player, int price, int dbid)
        {
            if (!player.LoggedIn) return;
            if(player.Money < price)
            {
                player.Notification(ServerEnums.Notify.Danger, Message.notEnoughMoney);
                return;
            }
            Server.Log(""+dbid);
            MyVehicle.MyVehicle? veh = VehList.Findbydbid(dbid);
            if(veh == null)
            {
                player.Notification(ServerEnums.Notify.Danger, "Ein Fehler ist aufgetreten, versuch es erneut");
                return;
            }
            veh.NumberplateText = "LS" + veh.Dbid;
            player.GiveMoney(-price);
            veh.Save();
            player.Notification(ServerEnums.Notify.Check, "Das Fahrzeug ist nun angemeldet");
        }
        [ClientEvent("PickupLicense")]
        public static void DrivingCreation(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasOwnPerso())
            {
                player.SendChatMessage(Message.noOwnPerso);
                return;
            }
            if (player.DrivingPickup == 1)
            {
                int[] place = player.GetFreeInvPlace();
                if (place[0] != -1 || place[1] != -1)
                {
                    DrivingLicense p = new DrivingLicense();
                    p.Car = player.DrivingLicense;
                    p.Owner = "" + player.Fname + " " + player.Lname;
                    p.Socialclubid = player.SocialClubId;
                    p.id = Database.CreateDrivingLicense(p);
                    p.CreateDrivingLicense();
                    Items.Items item = new Items.Items();
                    item.CreateDrivingLicense(player, p);
                    if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                    else if (place[1] != -1)
                    {
                        Backpack? back = player.GetPlayerBackPack();
                        if (back != null)
                        {
                            back.AddItem(place[1], item.Id);
                        }
                    }
                    player.SendChatMessage("Du hast deinen neuen Führerschein erhalten");
                    player.DrivingPickup = 2;
                    return;
                }
                player.SendChatMessage("Du hast kein Platz im Inventar");
                return;
            }
            else if(player.DrivingPickup == 2) //Verloren melden
            {
                return;
            }
            player.SendChatMessage("Du musst erst einen Führerschein machen um ihn abzuholen!");
        }
        [ClientEvent("PersoCreation")]
        public static void PersoCreation(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if(player.HasOwnPerso())
            {
                player.SendChatMessage("Du hast schon ein aktuellen Personalausweis");
                return;
            }
            if(player.PersoWait >= 2)
            {
                player.SendChatMessage("Dein Ausweis wird noch fertiggestellt");
                return;
            }
            if(player.Money < 250)
            {
                player.SendChatMessage(Message.notEnoughMoney);
                return;
            }
            Appartment? a = AppartmentList.AppartmentServerList.Find(x=> x.owned == player.SocialClubId);
            if (a == null)
            {
                player.SendChatMessage(Message.noStreet);
                return;
            }
            if (player.PersoWait == 0)
            {
                player.PersoWait = 60*5;
                player.SendChatMessage("Du hast dir einen Ausweis beantragt, es wird ca. 5min Dauern");
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Perso p = new Perso(player.Fname, player.Lname, a.name, player.Age, player.Height, player.EyeColor, player.SocialClubId);
                p.id = Database.CreatePerso(p);
                p.CreatePerso();
                Items.Items item = new Items.Items();
                item.CreatePerso(player, p);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast deinen Ausweis erhalten");
                player.GiveMoney(-250);
                player.PersoWait = 0;
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
    }
}
