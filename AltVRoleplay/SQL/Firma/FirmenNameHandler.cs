
namespace AltVRoleplay.SQL.Firma
{
    public class FirmenNameHandler
    {
        public static string GetFirmenTypeToName(ServerEnums.Firmen firma)
        {
            switch(firma)
            {
                case ServerEnums.Firmen.None:
                    return "Unbekannte Firma";
                case ServerEnums.Firmen.Tuner:
                    return "Tuner";
                case ServerEnums.Firmen.Mechanic:
                    return "Mechaniker";
                case ServerEnums.Firmen.Drivingschool:
                    return "Fahrschule";
                case ServerEnums.Firmen.Taxi:
                    return "Personentransport";
                case ServerEnums.Firmen.Logistik:
                    return "Logistik";
                case ServerEnums.Firmen.CarDealer:
                    return "Autohaus";
            }
            return "Unbekannte Firma";
        }

        public static int GetFirmenTypeSprite(ServerEnums.Firmen firma)
        {
            switch (firma)
            {
                case ServerEnums.Firmen.None:
                    return -1;
                case ServerEnums.Firmen.Tuner:
                    return 488;
                case ServerEnums.Firmen.Mechanic:
                    return 402;
                case ServerEnums.Firmen.Drivingschool:
                    return 498;
                case ServerEnums.Firmen.Taxi:
                    return 56;
                case ServerEnums.Firmen.Logistik:
                    return 477;
                case ServerEnums.Firmen.CarDealer:
                    return 225;
            }
            return -1;
        }

        public static void LoadFirmenBlips(MyPlayer.Player player)
        {
            foreach (Class.Firma firma in FirmaList.FirmaServerList)
            {
                int color = 1;
                if (firma.Owner_Id != 0 && firma.Price == 0) color = 4;
                int sprite = GetFirmenTypeSprite((ServerEnums.Firmen)firma.FirmenType);
                if (sprite == -1) continue;
                string info;
                if (firma.Info != "") info = firma.Info;
                else info = GetFirmenTypeToName((ServerEnums.Firmen)firma.FirmenType);
                player.Emit("CreateBlip", firma.X, firma.Y, firma.Z, sprite, color, 1f, true, info);
            }
        }
    }
}
