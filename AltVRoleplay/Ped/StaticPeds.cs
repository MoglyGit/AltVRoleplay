using AltV.Net.EntitySync;
using AltV.Net.Data;

namespace AltVRoleplay.Ped
{
    public class StaticPeds
    {
        public static List<PedEntity> Bankmann = new List<PedEntity>();
        public static List<PedEntity> Gunmann = new List<PedEntity>();
        public static List<PedEntity> Ankauf = new List<PedEntity>();

        public static void LoadBankmann()
        {
            CreateBankmann(-351.2835f, -51.32308f, 49.027832f,-25.0f);
            CreateBankmann(247.64725f, 225.05934f, 106.28357f, 155.0f,3);
            CreateBankmann(149.4989f, -1042.1274f, 29.364136f, -25.0f);

            CreateBankmann(-1212.0527f, -332.1099f, 37.772217f, 10.0f);
            CreateBankmann(-112.27252f, 6471.178f, 31.621948f, 145.0f);
            CreateBankmann(1175.0374f, 2708.2944f, 38.07544f, -180.0f);
            CreateBankmann(-2961.0857f, 482.9934f, 15.682007f, 90.0f);
            CreateBankmann(313.74066f, -280.52307f, 54.150146f, -25.0f);

            CreateGunmann(-331.84616f, 6084.8174f, 31.453491f, 215f);
            CreateGunmann(1692.2902f, 3761.1296f, 34.6886f, 215f);
            CreateGunmann(-1119.0593f, 2699.7363f, 18.546509f, 215f);
            CreateGunmann(-3173.6572f, 1088.255f, 20.838135f, -125.0f);
            CreateGunmann(-1304.1099f, -394.8f, 36.693726f, 72.0f);
            CreateGunmann(253.87253f, -50.67692f, 69.93848f, 72.0f);
            CreateGunmann(-662.2681f, -933.4813f, 21.81543f, -180.0f);
            CreateGunmann(842.4791f, -1035.3231f, 28.18457f, 0.0f);
            CreateGunmann(2567.9473f, 292.5099f, 108.726685f, 0.0f);

            CreateFishmann(-815.6044f, -1346.5714f, 5.134033f, 45.0f);
            CreateFishmann(1894.0483f, 3715.1736f, 32.750977f, 100.0f);

            CreateIllegalMan(-13.674725f, 6480.6064f, 31.4198f, -110.0f);
            CreateIllegalMan(1701.0857f, 4857.587f, 42.01831f, -90.0f);
            CreateIllegalMan(2.043956f, -1225.6088f, 29.279907f, 180.0f);

            PedEntity ped = new PedEntity("MP_M_WareMech_01", 0, 0, new Position(-484.95825f, -1730.7429f, 19.54065f), 50, 0);
            ped.CreateTextLabel("Ich tausche Eisenerz gegen Eisen\n3 zu 1", 1f, 2, ServerEnums.TextLabelEvent.IronChange);
            /*CreateAnkauf(838.83954f, 2176.2988f, 52.279907f, -90.0f);
            CreateAnkauf(-114.843956f, -967.12085f, 27.27478f, 0.0f);*/
        }

        public static void CreateIllegalMan(float x, float y, float z, float r, float keyrange = 2, int streamrange = 50, int dim = 0)
        {
            PedEntity fishman = new PedEntity("s_m_y_dealer_01", 0, r, new Position(x, y, z), streamrange, dim);
            fishman.CreateTextLabel("Mach schnell zeig her", 1f, keyrange, ServerEnums.TextLabelEvent.SellIllegal);
            //Bankmann.Add(bankmann);
        }
        public static void CreateFishmann(float x, float y, float z, float r, float keyrange = 2, int streamrange = 50, int dim = 0)
        {
            PedEntity fishman = new PedEntity("ig_old_man2", 0, r, new Position(x, y, z), streamrange, dim);
            fishman.CreateTextLabel("Petri Heil\nWas hast du schönes?", 1f, keyrange, ServerEnums.TextLabelEvent.SellFishes);
            //Bankmann.Add(bankmann);
        }

        public static void CreateBankmann(float x, float y, float z,float r,float keyrange=2, int streamrange=50,int dim=0)
        {
            PedEntity bankmann = new PedEntity("ig_bankman", 0, r, new Position(x,y,z), streamrange, dim);
            bankmann.CreateTextLabel("Guten Tag\nWie kann man behilflichsein?", 1f, keyrange, ServerEnums.TextLabelEvent.OpenFleecaBank);
            Bankmann.Add(bankmann);
        }

        public static void CreateGunmann(float x, float y, float z, float r, float keyrange = 2, int streamrange = 50, int dim = 0)
        {
            PedEntity gunmann = new PedEntity("S_M_Y_AmmuCity_01", 0, r, new Position(x, y, z), streamrange, dim);
            gunmann.CreateTextLabel("Willkommen\nSchauen Sie sich ruhig um", 1f, keyrange, ServerEnums.TextLabelEvent.OpenWeaponShop);
            Gunmann.Add(gunmann);
        }

        public static void CreateWoodAnkauf(float x, float y, float z, float r,int course, int storage, int id, float keyrange = 2, int streamrange = 50, int dim = 0)
        {
            PedEntity ankauf = new PedEntity("s_m_y_construct_01", 0, r, new Position(x, y, z), streamrange, dim);
            ankauf.Storage = storage;
            ankauf.AnKaufKurs = course;
            ankauf.Db_Id = id;
            ankauf.Type = 1;
            ankauf.CreateTextLabel("Für ein verarbeitetes Holz\nGebe ich "+ course+"$", 1f, keyrange, ServerEnums.TextLabelEvent.WoodSell);
            Ankauf.Add(ankauf);
        }
        public static void CreateIronAnkauf(float x, float y, float z, float r, int course, int storage, int id, float keyrange = 2, int streamrange = 50, int dim = 0)
        {
            PedEntity ankauf = new PedEntity("S_M_M_Trucker_01", 0, r, new Position(x, y, z), streamrange, dim);
            ankauf.Storage = storage;
            ankauf.AnKaufKurs = course;
            ankauf.Db_Id = id;
            ankauf.Type = 2;
            ankauf.CreateTextLabel("Für ein verarbeitetes Eisen\nGebe ich " + course + "$", 1f, keyrange, ServerEnums.TextLabelEvent.IronSell);
            Ankauf.Add(ankauf);
        }

        public static void UpdateAnkaufPed(PedEntity? ped)
        {
            if (ped == null) return;
            if (ped.Storage < 1)
            {
                ped.Storage += 100;
                ped.AnKaufKurs -= 1;
                if (ped.TextLabel == null) return;
                ped.TextLabel.SetText("Für ein verarbeitetes Holz\nGebe ich " + ped.AnKaufKurs + "$");
                UpdateAnkaufPed(ped);
                return;
            }
            if (ped.Storage > 200)
            {
                if(ped.Type == 1 && ped.AnKaufKurs >= 20)
                {
                    ped.Storage = 100;
                    return;
                }
                if (ped.Type == 2 && ped.AnKaufKurs >= 80)
                {
                    ped.Storage = 100;
                    return;
                }
                ped.AnKaufKurs += 1;
                ped.Storage -= 100;
                if (ped.TextLabel == null) return;
                ped.TextLabel.SetText("Für ein verarbeitetes Holz\nGebe ich " + ped.AnKaufKurs + "$");
                UpdateAnkaufPed(ped);
                return;
            }
        }
    }
}
