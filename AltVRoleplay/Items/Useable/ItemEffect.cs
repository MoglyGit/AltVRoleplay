
using AltVRoleplay.Events.Fishing;
using AltVRoleplay.Events.IronFarm;

namespace AltVRoleplay.Items.Useable
{
    public class ItemEffect
    {
        public static void ActivateItemEffect(MyPlayer.Player player, Items item)
        {
            switch (item.Serveritem)
            {
                case ServerEnums.Items.Apple:
                    player.AddHunger(-4);
                    break;
                case ServerEnums.Items.Hotdog:
                    player.AddHunger(-8);
                    player.AddHappy(1);
                    break;
                case ServerEnums.Items.Pizza:
                    player.AddHunger(-10);
                    player.AddHappy(1);
                    break;
                case ServerEnums.Items.Beer:
                    player.AddThirst(-10);
                    player.AddHunger(-2);
                    player.AddHarn(3);
                    player.AddHappy(2);
                    break;
                case ServerEnums.Items.Cafe:
                    player.AddThirst(-10);
                    break;
                case ServerEnums.Items.Energy:
                    player.AddThirst(-12);
                    player.AddHarn(1);
                    player.AddHappy(3);
                    break;
                case ServerEnums.Items.PatrolTank:
                    if(item.Mass > 0.1f)
                    {
                        MyVehicle.MyVehicle? closestPatrolVehicle = player.GetClosestVehicle();
                        if (closestPatrolVehicle == null)
                        {
                            player.Notification(ServerEnums.Notify.Warning, "Kein Fahrzeug in der Nähe");
                            return;
                        }
                        float patrolFillInt = item.Mass-0.1f;
                        closestPatrolVehicle.SetFill(closestPatrolVehicle.GetFill()+ patrolFillInt);
                        item.Mass = 0.1f;
                        item.Description = "Benzinkanister Leer";
                        item.SaveItem();
                        player.Notification(ServerEnums.Notify.Check, "Fahrzeug aufgefüllt");
                    }
                    else
                    {
                        //abfrage ob tankstelle
                        item.Mass = 4.1f;
                        item.Description = "Benzinkanister";
                        item.SaveItem();
                    }
                    player.Emit("closeInventory");
                    return;
                case ServerEnums.Items.NewVehicleKey:
                    MyVehicle.MyVehicle? veh = player.GetClosestVehicle();
                    if (veh == null)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Kein Fahrzeug in der Nähe");
                        return;
                    }
                    if(veh.OwnerSocialclubId != player.SocialClubId)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Du bist nicht der Besitzer des Farhezuges");
                        return;
                    }
                    item.Vehkey = veh.Dbid;
                    item.Description = "Fahrzeugschlüssel";
                    item.Serveritem = ServerEnums.Items.VehicleKey;
                    item.SaveItem();
                    player.Notification(ServerEnums.Notify.Check, "Schlüssel angepasst");
                    player.Emit("closeInventory");
                    return;
                case ServerEnums.Items.NewHouseKey:
                    Appartments.Appartment? app = Appartments.AppartmentList.AppartmentServerList.Find(x=> x.owned == player.SocialClubId && player.Position.Distance(new AltV.Net.Data.Position(x.x,x.y,x.z)) < 5);
                    if (app == null)
                    {
                        player.Notification(ServerEnums.Notify.Warning,"Kein/e Haus/Wohnung von dir in der Nähe");
                        return;
                    }
                    if (app != null)
                    {
                        item.Housekey = app.id;
                        item.Description = "Wohnungsschlüssel";
                        item.Serveritem = ServerEnums.Items.AppartmentKey;
                        item.SaveItem();
                        player.Notification(ServerEnums.Notify.Check,"Schlüssel angepasst");
                    }
                    player.Emit("closeInventory");
                    return;
                case ServerEnums.Items.Houselock:
                    Appartments.Appartment? appLock = Appartments.AppartmentList.AppartmentServerList.Find(x => x.owned == player.SocialClubId && player.Position.Distance(new AltV.Net.Data.Position(x.x, x.y, x.z)) < 5);
                    if (appLock == null)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Kein/e Haus/Wohnung von dir in der Nähe");
                        return;
                    }
                    if (appLock != null)
                    {
                        foreach(Items listItem in ItemList.ItemsList)
                        {
                            if(listItem.Housekey == appLock.id)
                            {
                                listItem.Housekey = 0;
                                listItem.SaveItem();
                            }
                        }
                        player.Notification(ServerEnums.Notify.Check, "Schloss gewechselt");
                    }
                    break;
                case ServerEnums.Items.FirstAid:
                    if(player.Health > 100)
                    {
                        player.Notification(ServerEnums.Notify.Warning,"Du bist soweit stabil");
                        return;
                    }
                    player.Health += 20;
                    player.Notification(ServerEnums.Notify.Check, "" + item.Description + " benutzt");
                    break;
                case ServerEnums.Items.Cigarrets:
                    player.Health += 2;
                    player.Notification(ServerEnums.Notify.Check, "" + item.Description + " benutzt");
                    item.Mass -= 0.01f;
                    player.Emit("closeInventory");
                    if (item.Mass <= 0)
                    {
                        item.Remove();
                        return;
                    }
                    item.SaveItem();
                    return;
                case ServerEnums.Items.Toolbox:
                    MyVehicle.MyVehicle? closestVeh = player.GetClosestVehicle();
                    if (closestVeh == null)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Kein Fahrzeug in der nähe");
                        return;
                    }
                    if (!closestVeh.MotorDamage)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Das Fahrzeug hat kein Motorschaden");
                        return;
                    }
                    player.SetProgress(15, (int)ServerEnums.ProgressEvent.Toolbox, "Repariere...");
                    player.SetData("ToolboxVeh", closestVeh);
                    player.SetData("ToolBox", item);
                    player.Emit("closeInventory");
                    return;
            }
            player.Emit("closeInventory");
            item.Amount -= 1;
            if(item.Amount <= 0)
            {
                item.Remove();
                return;
            }
            item.SaveItem();
        }

        public static void EquipItem(MyPlayer.Player player, Items item)
        {
            switch (item.Serveritem)
            {
                case ServerEnums.Items.Fishingrod:
                    FishingInventoryHandler.EquipFishingRod(player);
                    break;
                case ServerEnums.Items.Wurm:
                    FishingInventoryHandler.EuqipKoeder(player, item);
                    break;
                case ServerEnums.Items.Made:
                    FishingInventoryHandler.EuqipKoeder(player, item);
                    break;
                case ServerEnums.Items.Fish:
                    FishingInventoryHandler.EuqipKoeder(player, item);
                    break;
                case ServerEnums.Items.TropicalFish:
                    FishingInventoryHandler.EuqipKoeder(player, item);
                    break;
                case ServerEnums.Items.KugelFish:
                    FishingInventoryHandler.EuqipKoeder(player, item);
                    break;
                case ServerEnums.Items.Pickaxe:
                    IronFarmHandler.EquipPickAxe(player);
                    break;
            }
        }
    }
}
