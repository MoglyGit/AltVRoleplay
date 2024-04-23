using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.Autohaus;
using AltVRoleplay.Events.House;
using AltVRoleplay.Items;
using AltVRoleplay.MyPlayer;
using AltVRoleplay.MyVehicle;
using AltVRoleplay.Objects.Static;
using AltVRoleplay.Ped;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Firma.CarDealer;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Inventory;
using AltVRoleplay.SQL.LTD_Gas;
using AltVRoleplay.SQL.Peds;
using AltVRoleplay.SQL.Store;
using AltVRoleplay.Text;
using System.Timers;

namespace AltVRoleplay
{
    class Server : Resource
    {
        public static uint weatherid = 0;
        public static DateTime serverDate;
        private static bool timerstart = true;
        private static System.Timers.Timer aTimer = new System.Timers.Timer(1000);

        public static float CarSellCourse = 3 / 10;
        public override void OnStart()
        {
            Alt.Log("Server wurde gestartet");
            //Static
            HouseInterrior.LoadAppartments();
            ServerMoney.Load();
            Database.LoadVehicles();
            Database.LoadItems();
            Database.LoadBackpack();
            Database.LoadClothes();
            Database.LoadProps();
            Database.LoadServerTime();

            //Entity
            AltEntitySync.Init(1, (threadId) => 100, (threadId) => false,
               (threadCount, repository) => new ServerEventNetworkLayer(threadCount, repository),
               (entity, threadCount) => (entity.Id % threadCount),
               (entityId, entityType, threadCount) => (entityId % threadCount),
               (threadId) => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 300),
               new IdProvider());
            //Trains.LoadTrains();
            IVehicle ratbike = Alt.CreateVehicle(Alt.Hash("ratbike"), new AltV.Net.Data.Position(1842.5011f, 2565.9165f, 45.135498f), new AltV.Net.Data.Rotation(-0.0673313f, 0.057857197f, -2.591315f));
            ratbike.Frozen = true;

            PedSql.LoadServerPedsBuy();
            Database.LoadGroundItems();
            Database.LoadAppartments();
            Database.LoadPersos();
            Database.LoadDrivingLicenses();
            Database.LoadCrimes();
            StaticTextLabel.LoadText();
            StaticPeds.LoadBankmann();
            Database.LoadBankTransfers();
            Database.LoadFirmenBankTransfers();
            Autohaus_Handler.LoadCars();
            WardrobeSql.LoadAllWardrobes();
            StoreSql.LoadAllStores247();
            LTDSQL.LoadAllLTD();
            FirmaSql.LoadAllFirmen();
            CarDealerSQL.LoadAllCarDealerContracts();

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += SetWorldTime;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            System.Timers.Timer bTimer = new System.Timers.Timer(1000 * 60 * 30);
            // Hook up the Elapsed event for the timer. 
            bTimer.Elapsed += SetWorldWeather;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
            SetWorldWeather(null, null);

            System.Timers.Timer cTimer = new System.Timers.Timer(1000 * 60 * 50);
            // Hook up the Elapsed event for the timer. 
            cTimer.Elapsed += SetServerCourses;
            cTimer.AutoReset = true;
            cTimer.Enabled = true;
            Alt.OnWeaponDamage += (player, target, weapon, damage, offset, bodyPart) =>
            {
                Events.Player.PlayerEvents.OnWeaponDamage((MyPlayer.Player)player, target, weapon, damage, offset, bodyPart);
                return true; // false will cancel the damage sync
            };
            //Static Objects
            ServerTrees.LoadServerTrees();
            ServerLists.LoadServerLists();
            ServerGravel.LoadServerGravel();
            ServerMiningLights.LoadLights();
        }

        public override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            SaveDatabase();
            Alt.Log("Server wurde beendet");
        }

        private static void SaveDatabase()
        {
            Alt.Log("Saving Players...");
            foreach (MyPlayer.Player player in Alt.GetAllPlayers())
            {
                if (!player.LoggedIn) continue;
                player.SaveInvMuni();
                player.Save();
            }
            Alt.Log("Players saved");
            Alt.Log("Saving Backpacks...");
            foreach (Backpack back in BackpackList.BackpackServerList)
            {
                Database.SaveBackPack(back);
            }
            Alt.Log("Backpacks saved");
            Alt.Log("Saving GroundItems");
            Database.SaveGroundItems();
            Alt.Log("GroundItems saved");
            Alt.Log("Saving Appartments...");
            foreach (Appartment a in AppartmentList.AppartmentServerList)
            {
                Database.SaveAppartment(a);
            }
            Alt.Log("Appartments saved");
            Alt.Log("Saving Persos...");
            foreach (Perso p in PersoList.PersoServerList)
            {
                Database.SavePersos(p);
            }
            Alt.Log("Persos saved");
            Alt.Log("Saving Drivinglicenses...");
            foreach (DrivingLicense d in DrivingLicenseList.DrivingLicenseServerList)
            {
                Database.SaveDrivingLicense(d);
            }
            Alt.Log("Drivinglicenses saved");
            Alt.Log("Saving Vehicles...");
            foreach (MyVehicle.MyVehicle veh in VehList.VehicleServerList)
            {
                Database.SaveVehicle(veh);
            }
            Alt.Log("Vehicles saved");
            Alt.Log("Saving ServerTime...");
            Database.SaveServerTime();
            Alt.Log("ServerTime saved");
            Alt.Log("Saving holzankauf...");
            foreach (PedEntity ped in StaticPeds.Ankauf)
            {
                PedSql.SaveServerPedsBuy(ped);
            }
            Alt.Log("Holzankauf saved");
            Alt.Log("Saving Wardrobes...");
            foreach (Wardrobe w in WardrobeList.WardrobeServerList)
            {
                WardrobeSql.SaveWardrobe(w);
            }
            Alt.Log("Wardrobes saved");
            Alt.Log("Saving Firmen...");
            foreach (Firma firma in FirmaList.FirmaServerList)
            {
                firma.Save();
            }
            Alt.Log("Firmen saved");
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new MyVehicleFactory();
        }
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new MyPlayerFactory();
        }

        public static void Log(string s)
        {
            Console.WriteLine(s);

        }
        //Server courses
        public static void SetServerCourses(System.Object? source, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            CarSellCourse = rnd.Next(1, 9) / 10;
            foreach (PedEntity ped in StaticPeds.Ankauf)
            {
                ped.Storage += rnd.Next(50, 300);
                StaticPeds.UpdateAnkaufPed(ped);
            }
        }
        //WorldTime
        public static void SetWorldTime(System.Object? source, ElapsedEventArgs e)
        {
            serverDate = DateTime.Now;
            if(serverDate.Hour > 18 || serverDate.Hour < 9)
            {
                if (ServerMiningLights.Streamed) ServerMiningLights.DeleteLights();
            }
            else
            {
                if (!ServerMiningLights.Streamed) ServerMiningLights.LoadLights();
            }
            foreach(DisconnectInfo dc in StaticTextLabel.DisconnectInfoList)
            {
                if (dc.Expire > serverDate) continue;
                dc.Remove();
            }
            
        }
        //Weather
        public static void SetWorldWeather(System.Object? source, ElapsedEventArgs? e)
        {
            Random rnd = new Random();
            weatherid = (uint)rnd.Next(2,9);
            foreach(MyPlayer.Player player in Alt.GetAllPlayers())
            {
                if (!player.LoggedIn || player.Sex == 3) continue;
                player.Emit("setTime", serverDate.Hour, serverDate.Minute, serverDate.Second);
                player.Emit("setWeather", weatherid, 20);
                player.SendChatMessage("Wetter: "+weatherid+" Datum: "+Server.serverDate.ToString());
            }

            foreach(Appartment appartment in AppartmentList.AppartmentServerList)
            {
                appartment.AddTrash();
            }

            if(!timerstart) SaveDatabase();
            if(timerstart) timerstart = false;

        }

        public static void SyncWorldTime()
        {
            foreach (MyPlayer.Player player in Alt.GetAllPlayers())
            {
                if (!player.LoggedIn || player.Sex == 3) continue;
                player.Emit("setTime", serverDate.Hour, serverDate.Minute, serverDate.Second);
                player.SendChatMessage("zeit wurde auf: "+ serverDate.Hour+":"+ serverDate.Minute+":"+ serverDate.Second +" gesetzt");
            }
        }

        public static string GetServerTime()
        {
            string h = ""+serverDate.Hour;
            string m = "" + serverDate.Minute;
            string s = "" + serverDate.Second;
            if (serverDate.Hour < 10) h = "0" + serverDate.Hour;
            if (serverDate.Minute < 10) m = "0" + serverDate.Minute;
            if (serverDate.Second < 10) s = "0" + serverDate.Second;
            return h+":"+ m+":"+ s;
        }

        public static string GetServerDate()
        {
            string d = "" + serverDate.Day;
            string m = "" + serverDate.Month;
            if (serverDate.Day < 10) d = "0" + serverDate.Day;
            if (serverDate.Month < 10) m = "0" + serverDate.Month;
            return d + "." + m + "." + serverDate.Year;
        }

        public static int h()
        {
            return serverDate.Hour;
        }
        public static int m()
        {
            return serverDate.Minute;
        }
        public static int s()
        {
            return serverDate.Second;
        }
    }
}
