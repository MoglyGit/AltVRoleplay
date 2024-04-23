using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.MyVehicle;
using System.Timers;
using AltVRoleplay.Muellspace;
using AltVRoleplay.Events.House;
using System.Numerics;
using AltVRoleplay.Autohaus;
using AltV.Net.Data;
using AltVRoleplay.Jobs;
using AltVRoleplay.Ped;
using AltVRoleplay.Factions.Garbage;
using AltVRoleplay.Events.Fishing;
using AltVRoleplay.Events.Firmen;
using AltVRoleplay.Events.Firmen.CarDealer;
using AltVRoleplay.Events.Admin;
using AltVRoleplay.Events.LTDGas;

namespace AltVRoleplay.Events.KeyEvents
{
    public class KeyPressed : IScript
    {
        [ClientEvent("MuellOpen")]
        public static void MuellOpen(MyPlayer.Player player, Vector3 pos, int size)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            //Server.Log("ide: "+e);
            Muell? m = MuellList.MuellServerList.Find(x=> Math.Sqrt(Math.Pow((pos.X - x.pos.X), 2) + Math.Pow((pos.Y - x.pos.Y), 2)) <= 2);
            if(m!=null)
            {
                if(m.time < DateTime.Now)
                {
                    MuellEvent.Search(player,size);
                    m.time = DateTime.Now.AddMinutes(10);
                    return;
                }
                player.SendChatMessage("Die Mülltonne sieht Leer aus("+m.pos+")");
                return;
            }
            Muell muell = new Muell();
            muell.pos = pos;
            MuellList.AddItem(muell);
            MuellEvent.Search(player,size);
        }
        [ClientEvent("TextLabelAction")]
        public static void TextLabelAction(MyPlayer.Player player, int te, float x)
        {
            switch(te)
            {
                case (int)ServerEnums.TextLabelEvent.LTDGas:
                    LTDGasstation_Handler.ShowGasPayment(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.AdminDisconnectInfo:
                    Admin_Handler.ShowDisconenctedPlayer(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.CarDealerGetList:
                    CarDealer_Handler.GetOrderedCar(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.FirmaMenu:
                    Firmen_Handler.ShowOwnerHud(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.SellIllegal:
                    player.Emit("ShowDealerMenu");
                    break;
                case (int)ServerEnums.TextLabelEvent.SellFishes:
                    player.SetProgress(5, (int)ServerEnums.ProgressEvent.SellFishes, "Verkaufe alle Fishe");
                    break;
                case (int)ServerEnums.TextLabelEvent.Show247Shop:
                    Shop247.Shop247Handler.ShowShopHud(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.ShopOwner:
                    Shop247.Shop247Handler.ShowOwnerHud(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.Wardrobe:
                    Wardrobe.Wardrobe_Handler.OpendWardrobe(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.ShowApartmentHud:
                    HouseEvents.ShowApartmentHud(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.OpenFleecaBank:
                    Bank.BankEvents.OpenBankMenu(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.GetPerso:
                    CityHall.CityHall.PersoCreation(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.GetDrivingLicense:
                    CityHall.CityHall.DrivingCreation(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.MiniJobGolf:
                    Minijobs.Golf.MiniJobGolf.ShowMiniJobGolf(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.DrivingSchool:
                    Licenses.Driving.DrivingTheory(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.RatBike:
                    RatFirst(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.BikeRent:
                    FahrradVerleih(player,0);
                    break;
                case (int)ServerEnums.TextLabelEvent.EBikeRent:
                    EbikeVerleih(player,0);
                    break;
                case (int)ServerEnums.TextLabelEvent.MiniJobLieferant:
                    Minijobs.Lieferant.MiniJobLieferant.StartMiniJobLieferant(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.CarHouse_CarBuy:
                    AutohausCar? car = AutohausList.FindAutohausCarByPosX(x);
                    if (car == null) return;
                    Autohaus_Handler.BuyCar(player,car);
                    break;
                case (int)ServerEnums.TextLabelEvent.CarSell:
                    MyVehicleHandler.SellCar(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.CarRegister:
                    MyVehicleHandler.RegisterCar(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.OpenWeaponShop:
                    WeaponShop.WeaponShopEvents.ShowWeaponShop(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.TreeCut:
                    Tree.TreeEvents.CutTree(player, x);
                    break;
                case (int)ServerEnums.TextLabelEvent.WoodJob:
                    LumberJack.StartJob(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.WoodProcessing:
                    LumberJack.ProcessingWood(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.WoodSell:
                    PedEntity? ped = StaticPeds.Ankauf.Find(a=> a.TextLabel != null && a.TextLabel.x == x);
                    if (ped == null) return;
                    player.SetData("SellWoodPed", ped);
                    player.SetProgress(10, (int)ServerEnums.ProgressEvent.SellingWood,"Verkaufe...");
                    break;
                case (int)ServerEnums.TextLabelEvent.IronSell:
                    PedEntity? ped2 = StaticPeds.Ankauf.Find(a => a.TextLabel != null && a.TextLabel.x == x);
                    if (ped2 == null) return;
                    player.SetData("SellIronPed", ped2);
                    player.SetProgress(10, (int)ServerEnums.ProgressEvent.SellingIron, "Verkaufe...");
                    break;
                case (int)ServerEnums.TextLabelEvent.IronChange:
                    player.SetProgress(10, (int)ServerEnums.ProgressEvent.ChangeIron, "Tausche...");
                    break;
                case (int)ServerEnums.TextLabelEvent.GravelSpawnDozer:
                    GravelWorker.StartDozer(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.GravelSpawnDump:
                    GravelWorker.StartDump(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.GravelDump:
                    GravelWorker.LoadDump(player);
                    break;
                case (int)ServerEnums.TextLabelEvent.SchoolBergbau:
                    if (!ServerMethods.HasOpen(player, 8, 10)) return;
                    if (player.BergBau >= 10) return;
                    if(player.BergBauCd > 0)
                    {
                        player.Notification(ServerEnums.Notify.Info, "Der nächste Kurs für dich ist in "+player.BergBauCd/60+" Minuten machbar.");
                        return;
                    }
                    int costs = 300 + 320 * player.BergBau;
                    if (player.Money < costs)
                    {
                        player.Notification(ServerEnums.Notify.Warning, "Die Schulung kostet "+ costs);
                        return;
                    }
                    player.GiveMoney(-costs);
                    player.BergBauCd = 60 * 60 + player.BergBau * 60 * 60;
                    player.BergBau += 1;
                    player.Notification(ServerEnums.Notify.Info, "Du hast am Kurs: Steinbruch Chapter "+ player.BergBau + "/10 Teilgenommen");
                    break;
                case (int)ServerEnums.TextLabelEvent.GarbageStart:
                    if (player.Faction != (int)ServerEnums.Fraktions.Garbage) return;
                    player.Emit("ShowGarbageSide", player.Duty, (int)ServerEnums.Fraktions.Garbage);
                    break;
                case (int)ServerEnums.TextLabelEvent.GarbageUnload:
                    if (player.Faction != (int)ServerEnums.Fraktions.Garbage) return;
                    if (!player.IsInVehicle) return;
                    if (player.Duty == 0) return;
                    MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
                    if (veh == null) return;
                    if (veh.Model != Alt.Hash("trash") && veh.Model != Alt.Hash("trash2")) return;
                    if (!veh.HasData("Trash")) return;
                    if (!player.SetProgress(10, (int)ServerEnums.ProgressEvent.UnLoadGarbage, "Müllabladen")) return;
                    break;
                case (int)ServerEnums.TextLabelEvent.IronMine:
                    if (!player.LoggedIn) return;
                    if (player.IsInVehicle) return;
                    if (!player.HasData("HasPickAxe"))
                    {
                        player.Notification(ServerEnums.Notify.Warning,"Du hast keine Spitzhacke");
                        return;
                    }
                    player.Emit("IronFarming", player.KraftLevel);
                    break;
            }
        }

        [ClientEvent("BlinkerLeft")]
        public static void SetBlinkerLeft(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle? veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.SetSyncedMetaData("blinker", "1");
        }
        [ClientEvent("BlinkerRight")]
        public static void SetBlinkerRight(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.SetSyncedMetaData("blinker", "2");
        }
        [ClientEvent("Interrior")]
        public static void SetInterriorLight(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.SetSyncedMetaData("blinker", "64");
        }
        [ClientEvent("BlinkerBoth")]
        public static void SetBlinkerBoth(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.SetSyncedMetaData("blinker", "4");
        }
        [ClientEvent("BlinkerOut")]
        public static void SetBlinkerOut(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.SetSyncedMetaData("blinker", "0");
        }
        [ClientEvent("RentEbike")]
        public static void EbikeVerleih(MyPlayer.Player player, int where)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if (player.RentedVehicle != null)
            {
                player.SendChatMessage(Message.alwayRentingVeh);
                return;
            }
            if (player.Money < 150)
            {
                player.SendChatMessage(Message.notEnoughMoney);
                return;
            }
            player.GiveMoney(-150);
            player.SendChatMessage("Du hast dir ein E-Roller für 1h gemietet");
            player.RentedVehicle = GetEbike(where);
            if (player.RentedVehicle != null)
            {
                VehList.AddDbVehicle(player.RentedVehicle);
                player.SetIntoVehicle(player.RentedVehicle, 1);
                player.RentedVehicle.RentOwner = player.SocialClubId;
                player.RentTimer = new System.Timers.Timer();
                player.RentTimer.Elapsed += (sender, e) => RemoveRentedVehilce(sender, e, player, player.RentedVehicle);
                player.RentTimer.Interval = 1000 * 60 * 60;
                player.RentTimer.Start();
                player.RentedVehicle.ScriptMaxSpeed = 13;
                player.RentedVehicle.NumberplateText = "R-LSAIR";
                Random rnd = new Random();
                player.RentedVehicle.PrimaryColor = (byte)rnd.Next(255);
            }
        }
        [ClientEvent("RentBike")]
        public static void FahrradVerleih(MyPlayer.Player player, int where)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if(Server.h() < 9 || Server.h() > 20)
            {
                player.SendChatMessage(Message.notOpen);
                return;
            }
            if(player.RentedVehicle != null)
            {
                player.SendChatMessage(Message.alwayRentingVeh);
                return;
            }
            if(player.Money < 50)
            {
                player.SendChatMessage(Message.notEnoughMoney);
                return;
            }
            player.GiveMoney(-50);
            player.SendChatMessage("Du hast dir ein Fahrrad für 1h gemietet");
            player.RentedVehicle = GetBike(where);
            if (player.RentedVehicle != null)
            {
                VehList.AddDbVehicle(player.RentedVehicle);
                player.SetIntoVehicle(player.RentedVehicle, 1);
                player.RentedVehicle.RentOwner = player.SocialClubId;
                player.RentTimer = new System.Timers.Timer();
                player.RentTimer.Elapsed += (sender, e) => RemoveRentedVehilce(sender, e, player, player.RentedVehicle);
                player.RentTimer.Interval = 1000*60*60;
                player.RentTimer.Start();
            }
        }
        [ClientEvent("RentRat")]
        public static void RatFirst(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            int prison = 0;
            if(player.HasData("FirstPrison"))player.GetData("FirstPrison", out prison);
            if ( prison == 0)
            {
                player.SendChatMessage("Nur ein altes Motorrad");
                return;
            }
            if (player.RentedVehicle != null)
            {
                player.SendChatMessage(Message.alwayRentingVeh);
                return;
            }
            player.SendChatMessage("Du konntest das Motorrad erstmal zum laufen bringen... irgendwie...");
            player.RentedVehicle = GetRat();
            if (player.RentedVehicle != null)
            {
                VehList.AddDbVehicle(player.RentedVehicle);
                player.SetIntoVehicle(player.RentedVehicle, 1);
                player.RentedVehicle.RentOwner = player.SocialClubId;
                player.RentTimer = new System.Timers.Timer();
                player.RentTimer.Elapsed += (sender, e) => RemoveRat(sender, e, player, player.RentedVehicle);
                player.RentTimer.Interval = 1000 * 60 * 3;
                player.RentTimer.Start();
                player.RentedVehicle.EngineOn = true;
            }
        }
        private static void RemoveRat(System.Object? source, ElapsedEventArgs e, MyPlayer.Player player, IVehicle vehid)
        {
            if (player.Exists && vehid.Exists)
            {
                vehid.EngineHealth = -500;
                vehid.BodyHealth = 0;
                if (player.RentTimer != null) player.RentTimer.Dispose();
            }
        }
        private static void RemoveRentedVehilce(System.Object? source, ElapsedEventArgs e, MyPlayer.Player player, IVehicle vehid)
        {
            if(player.Exists && vehid.Exists)
            {
                player.SendChatMessage("Dein gemietetes Fahrzeug wurde abgeholt, da die Zeit um ist.");
                player.UnrentVehilce();
                if(player.RentTimer!=null)player.RentTimer.Dispose();
            }
        }

        public static MyVehicle.MyVehicle? GetBike(int where)
        {
            Random rnd = new Random();
            MyVehicle.MyVehicle? bike = null;
            switch (where)
            {
                case 0:
                    if (rnd.Next(2) > 0)
                    {
                        bike = ServerMethods.CreateVehicle(AltV.Net.Enums.VehicleModel.Cruiser, new Position(-1235.0769f, -1454.255f, 3.8198242f), new Rotation(-0.09708521f, 0.07993864f, -2.477136f));
                    }
                    else
                    {
                        bike = ServerMethods.CreateVehicle(AltV.Net.Enums.VehicleModel.Cruiser, new Position(-1230.3429f, -1450.8264f, 3.83667f), new Rotation(-0.06449518f, 0.043183025f, -2.5487745f));
                    }
                    break;
            }
            return bike;
        }

        public static MyVehicle.MyVehicle? GetEbike(int where)
        {
            Random rnd = new Random();
            Position pos = new Position(-1081.1736f, -2594.5583f, 13.104004f);
            Rotation rot = new Rotation(-0.14410482f, -0.009466354f, -2.087613f);
            switch (where)
            {
                case 0:
                    if (rnd.Next(2) > 0)
                    {
                        pos = new Position(-1083.4286f, -2598.3164f, 13.104004f);
                        rot = new Rotation(-0.20519185f, 0.04039991f, -2.1082733f);
                    }
                    break;
            }
            MyVehicle.MyVehicle? bike = ServerMethods.CreateVehicle("faggio", pos, rot);
            if (bike == null) return null;
            bike.VehName = "faggio";
            return bike;
        }

        public static MyVehicle.MyVehicle? GetRat()
        {
            Random rnd = new Random();
            MyVehicle.MyVehicle? bike;
            Position pos;
            Rotation rot;
            if (rnd.Next(2) > 0)
            {
                pos = new Position(1854.2505f, 2552.9011f, 45.135498f);
                rot = new Rotation(-0.08407178f,-0.026358137f,-1.5718902f);
            }
            else
            {
                pos = new Position(1855.5297f, 2564.2153f, 45.135498f);
                rot = new Rotation(-0.06970061f, -0.02995885f, -1.5249382f);
            }
            bike = ServerMethods.CreateVehicle("ratbike", pos, rot);
            return bike;
        }
    }
}
