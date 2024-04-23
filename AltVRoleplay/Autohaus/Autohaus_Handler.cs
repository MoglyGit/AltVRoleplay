using AltV.Net;
using AltV.Net.Data;
using AltVRoleplay.Items;
using AltVRoleplay.MyVehicle;

namespace AltVRoleplay.Autohaus
{
    internal class Autohaus_Handler : IScript
    {
        public static void LoadCars()
        {


            //sandyshores
            ServerAdd(new AutohausCar("surfer2", 5000, ServerEnums.CarHouse.Sandy,27, 1379.2219f, 3617.6309f, 34.654907f, 0.014298847f, -0.014187238f, 2.3523853f));
            ServerAdd(new AutohausCar("ratbike", 3000, ServerEnums.CarHouse.Sandy,28, 1369.411f, 3614.0176f, 34.351685f, -0.12122539f, 0.06595202f, -2.2246377f));
            ServerAdd(new AutohausCar("voodoo2", 4000, ServerEnums.CarHouse.Sandy,25, 1377.178f, 3621.7847f, 34.351685f, -0.003983f, -0.0006030552f, 2.3612955f));
            ServerAdd(new AutohausCar("emperor2", 4500, ServerEnums.CarHouse.Sandy,22, 1364.4f, 3617.6704f, 34.385376f, -0.00016698493f, 0.0009625875f, -1.227265f));
            ServerAdd(new AutohausCar("tornado4", 2400, ServerEnums.CarHouse.Sandy,29, 1354.9187f, 3615.0461f, 34.57068f, -0.00016698493f, 0.0009625875f, -1.227265f));
            ServerAdd(new AutohausCar("tornado3", 3900, ServerEnums.CarHouse.Sandy,27, 1353.2175f, 3619.5298f, 34.469604f, -0.06044874f, -0.025471272f, -1.6340448f));

            //BlaineCounty
            ServerAdd(new AutohausCar("asbo", 14000, ServerEnums.CarHouse.BlaineCounty, -1, -201.85056f, 6202.009f, 30.86377f, 0.011765021f, 0.0006754304f, 0.12928468f));
            ServerAdd(new AutohausCar("blista", 14800, ServerEnums.CarHouse.BlaineCounty, -1, -206.0044f, 6198.778f, 31.30188f, 0.0020424244f, 0.0007754304f, 0.08223607f));
            ServerAdd(new AutohausCar("dilettante", 15000, ServerEnums.CarHouse.BlaineCounty, -1, -211.08131f, 6193.609f, 30.98169f, -0.0034863628f, 0.00050487247f, 0.10713727f));
            ServerAdd(new AutohausCar("panto", 13500, ServerEnums.CarHouse.BlaineCounty, -1, -215.47253f, 6189.297f, 30.813232f, -0.0025737681f, 0.0045890175f, 0.21250361f));
            ServerAdd(new AutohausCar("youga", 16000, ServerEnums.CarHouse.BlaineCounty, -1, -214.93187f, 6214.655f, 30.98169f, 0.0019357105f, 0.0010128252f, -1.5340066f));

            //Motorrad
            ServerAdd(new AutohausCar("enduro", 11200, ServerEnums.CarHouse.Bike, -1, -166.1934f, -1426.6813f, 30.594116f, 0.027220411f, -0.17683661f, 2.1608334f));
            ServerAdd(new AutohausCar("faggio", 1300, ServerEnums.CarHouse.Bike, 15, -168.64615f, -1423.6879f, 30.594116f, 0.05010771f, -0.18835229f, 2.149732f));
            ServerAdd(new AutohausCar("bati", 16000, ServerEnums.CarHouse.Bike, -1, -167.1956f, -1437.4286f, 30.594116f, 0.003110404f, -0.1810257f, 0.91029125f));
            ServerAdd(new AutohausCar("bagger",12500, ServerEnums.CarHouse.Bike, -1, -170.03076f, -1440.2241f, 30.762695f, -0.010066134f, -0.15400438f, 0.80903554f));

            //Boat
            ServerAdd(new AutohausCar("marquis", 80000, ServerEnums.CarHouse.Boat, -1, -733.9912f, -1379.2087f, 0.3824463f, -0.018280338f, 0.0084592225f, 2.4809566f));
            ServerAdd(new AutohausCar("seashark", 12000, ServerEnums.CarHouse.Boat, -1, -719.789f, -1322.5582f, -0.072509766f, -0.06225021f, -0.083783425f, -2.3176827f));
            ServerAdd(new AutohausCar("seashark3", 18000, ServerEnums.CarHouse.Boat, -1, -722.189f, -1327.266f, -0.08935547f, -0.060460493f, -0.0787233f, -2.2182596f));
            ServerAdd(new AutohausCar("dinghy2", 20000, ServerEnums.CarHouse.Boat, -1, -732.23737f, -1333.6615f, 0.11279297f, -0.02952404f, -0.036146358f, -2.257323f));
            ServerAdd(new AutohausCar("dinghy", 25000, ServerEnums.CarHouse.Boat, -1, -738.778f, -1339.8462f, 0.11279297f, -0.029799089f, -0.035919983f, -2.2725906f));
            ServerAdd(new AutohausCar("suntrap", 30000, ServerEnums.CarHouse.Boat, -1, -744.6462f, -1347.3231f, 0.4161377f, -0.03928777f, -0.04572652f, -2.2955883f));
            ServerAdd(new AutohausCar("tropic", 40000, ServerEnums.CarHouse.Boat, -1, -750.356f, -1353.9429f, 0.29821777f, -0.018718326f, -0.023410155f, -2.2556305f));
            ServerAdd(new AutohausCar("speeder", 50000, ServerEnums.CarHouse.Boat, -1, -756.03955f, -1361.2087f, 0.06225586f, -0.011128184f, -0.0072642034f, -2.2981496f));
            ServerAdd(new AutohausCar("jetmax", 60000, ServerEnums.CarHouse.Boat, -1, -761.5912f, -1367.6967f, 0.28137207f, 0.0055699036f, 0.021858765f, -2.2432644f));
        }
        private static void ServerAdd(AutohausCar car)
        {
            AutohausList.AddAutohausCar(car);
        }
        public static void BuyCar(MyPlayer.Player player, AutohausCar car)
        {
            if (!player.LoggedIn) return;
            if (car.Veh == null) return;
            if (!car.Veh.Exists) return;
            if(car.price > player.Money)
            {
                player.Notification(ServerEnums.Notify.Warning, Message.notEnoughMoney);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] == -1 && place[1] == -1)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast kein Platz im Inventar");
                return;
            }
            player.GiveMoney(-car.price);
            car.RespawnTimer.Start();
            car.Veh.Destroy();
            if(car.info != null)car.info.Remove();
            CreatePlayerCar(player, car);
        }

        private static void CreatePlayerCar(MyPlayer.Player player, AutohausCar car)
        {
            if (car.Veh == null) return;
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle(car.name, car.Veh.Position, car.Veh.Rotation);
            if (veh == null)
            {
                player.Notification(ServerEnums.Notify.Danger, "Fehler beim kaufen!");
                return;
            }
            veh.PrimaryColorRgb = car.Veh.PrimaryColorRgb;
            veh.SecondaryColorRgb = car.Veh.SecondaryColorRgb;
            veh.OwnerSocialclubId = player.SocialClubId;
            veh.OwnerName = player.GetFullName();

            veh.ScriptMaxSpeed = car.maxSpeed;
            veh.VehName = car.name.ToLower();
            veh.EngineOn = false;
            veh.Price = car.price;
            veh.Dbid = Database.CreateVehicle(veh);
            veh.ManualEngineControl = true;
            veh.EngineOn = false;
            switch (car.carhouse)
            {
                case ServerEnums.CarHouse.Sandy:
                    Random rnd =new Random();
                    veh.SetRange(500000*1000+rnd.Next(1,200000)*1000);
                    veh.SetFill(veh.FillMax / 3);
                    break;
                default:
                    veh.SetRange(0);
                    veh.SetFill(veh.FillMax);
                    break;
            }
            player.Notification(ServerEnums.Notify.Check, "Fahrzeug erfolgreich gekauft");
            VehList.AddDbVehicle(veh);

            int[] place = player.GetFreeInvPlace();
            Items.Items item = new Items.Items();
            item.CreateVehicleKey(veh);
            if (place[0] != -1) player.PlaceItemInInv(place[0], item);
            else if (place[1] != -1)
            {
                Backpack? back = player.GetPlayerBackPack();
                if (back != null)
                {
                    back.AddItem(place[1], item.Id);
                }
            }
            //player.PlaceItemInInv(place, item.Id);
            return;
        }
    }
}
