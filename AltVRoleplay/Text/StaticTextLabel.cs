using AltV.Net.EntitySync;

namespace AltVRoleplay.Text
{
    public static class StaticTextLabel
    {
        public static List<DisconnectInfo> DisconnectInfoList = new List<DisconnectInfo>();
        public static void LoadText()
        {
            CreateText("Führerscheinabholen\nnutze E Taste", new AltV.Net.Data.Position(-551.53845f, -212.25494f, 37.63733f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GetDrivingLicense);
            CreateText("Fahrschule\nPKW oder Motorrad\nnutze E Taste", new AltV.Net.Data.Position(-67.898895f, -205.7011f, 45.80957f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.DrivingSchool);
            CreateText("Personalausweis Beantragen(250$)\nnutze E Taste", new AltV.Net.Data.Position(-534.05273f, -202.21977f, 37.63733f), 15, 0, 1,(int)ServerEnums.TextLabelEvent.GetPerso);
            CreateText("Firma Gründen\nnutze E Taste", new AltV.Net.Data.Position(-523.7934f, -205.85934f, 37.63733f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.CreateFirma);

            CreateText("Untersuchen\nnutze E Taste", new AltV.Net.Data.Position(1842.5011f, 2565.9165f, 45.135498f), 15, 0,2, (int)ServerEnums.TextLabelEvent.RatBike);
            CreateText("Fahrradverleih\nFahrradmieten(50$ für 1h)\nnutze E Taste", new AltV.Net.Data.Position(-1234.7472f, -1450.3385f, 4.2747803f), 15, 0,1, (int)ServerEnums.TextLabelEvent.BikeRent);
            CreateText("E-Rollerverleih\nE-Rollermieten(150$ für 1h)\nnutze E Taste", new AltV.Net.Data.Position(-1091.5253f, -2595.1648f, 13.811768f), 15, 0,1, (int)ServerEnums.TextLabelEvent.EBikeRent);
            //Autoanmeldung
            CreateText("Fahrzeug anmeldung\nnutze E Taste", new AltV.Net.Data.Position(-554.16266f, -223.7143f, 37.63733f), 15,0,1,(int)ServerEnums.TextLabelEvent.CarRegister);
            //Autoankauf
            CreateText("Autoankauf\nNutze E Taste", new AltV.Net.Data.Position(1540.0747f, 6336.158f, 24.073242f), 15, 0, 3, (int)ServerEnums.TextLabelEvent.CarSell);
            CreateText("Autoankauf\nNutze E Taste", new AltV.Net.Data.Position(383.52527f, 3562.1143f, 33.307007f), 15, 0, 3, (int)ServerEnums.TextLabelEvent.CarSell);
            CreateText("Autoankauf\nNutze E Taste", new AltV.Net.Data.Position(1219.5165f, -3204.633f, 5.6226807f), 15, 0, 3, (int)ServerEnums.TextLabelEvent.CarSell);
            //mini-Jobs
            CreateText("Minijob-Gärtner\n8:00-16:00\nnutze E Taste", new AltV.Net.Data.Position(-1348.5626f, 142.72089f, 56.424927f), 15, 0,1, (int)ServerEnums.TextLabelEvent.MiniJobGolf);
            CreateText("Minijob-Lieferant\n12:00-00:00\nnutze E Taste", new AltV.Net.Data.Position(-138.40878f, -257.19562f, 43.585327f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.MiniJobLieferant);
            //Job
            CreateText("Holzfäller\n8:00-18:00\nnutze E Taste", new AltV.Net.Data.Position(-567.9429f, 5253.389f, 70.47766f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.WoodJob);
            CreateText("Holz Verarbeiter\n8:00-18:00\nnutze E Taste", new AltV.Net.Data.Position(-552.6857f, 5348.769f, 74.74072f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.WoodProcessing);

            CreateText("Kies Sammeln\n10:00-16:00\nnutze E Taste", new AltV.Net.Data.Position(2949.7847f, 2748.1714f, 43.45056f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GravelSpawnDozer);
            CreateText("Kies transportieren\n10:00-16:00\nnutze E Taste", new AltV.Net.Data.Position(2954.3867f, 2735.8682f, 44.29309f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GravelSpawnDump);

            //factions
            //Garbage
            CreateText("Mülldeponie\nnutze E Taste", new AltV.Net.Data.Position(51.65275f, 6485.987f, 31.4198f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GarbageStart);
            CreateText("Mülldeponie\nnutze E Taste", new AltV.Net.Data.Position(-355.12088f, -1513.7406f, 27.712769f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GarbageStart);
            CreateText("Mülldeponie\nnutze E Taste", new AltV.Net.Data.Position(-344.2945f, -1563.1912f, 25.218994f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.GarbageUnload);

            //Iron Farming
            CreateText("Mine Arbeitszeit\n 9:00-19:00", new AltV.Net.Data.Position(-596.3472f, 2088.8308f, 131.40662f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.None);
            CreateText("Steinwand\nnutze E Taste", new AltV.Net.Data.Position(-484.7868f, 1893.3759f, 120.049805f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.IronMine);
            CreateText("Steinwand\nnutze E Taste", new AltV.Net.Data.Position(-491.48572f, 1895.5912f, 120.252075f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.IronMine);
            CreateText("Steinwand\nnutze E Taste", new AltV.Net.Data.Position(-498.778f, 1892.2682f, 120.926025f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.IronMine);
            CreateText("Steinwand\nnutze E Taste", new AltV.Net.Data.Position(-506.4923f, 1894.8264f, 121.364136f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.IronMine);
            //School
            CreateText("Schulung Steinbruch\n8:00-10:00\nnutze E Taste", new AltV.Net.Data.Position(-1578.9626f, 184.61539f, 58.85132f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.SchoolBergbau);
            //CarDealer abholung
            CreateText("Fahrzeug Abholung\nAutohaus\nnutze E Taste", new AltV.Net.Data.Position(993.0593f, -2978.9934f, 5.892334f), 15, 0, 1, (int)ServerEnums.TextLabelEvent.CarDealerGetList);


        }
        public static void CreateText(string text, AltV.Net.Data.Position pos, int stremrange, int dim, float keyrange = 0, int eventType = 0)
        {
            IEntity entity = AltEntitySync.CreateEntity((ulong)ServerEnums.Entitys.Text, pos, dim, (uint)stremrange);
            entity.SetData("text", text);
            entity.SetData("keyrange", "" + keyrange);
            entity.SetData("eventType", "" + eventType);
        }
    }
}
