using AltV.Net.Data;
using AltVRoleplay.Text;
namespace AltVRoleplay
{
    public class ServerLists
    {
        private static int Gravel;
        private static TextLabel? GraveltextLabel;
        public static void LoadServerLists()
        {
            Gravel = 0;
            GraveltextLabel = new TextLabel("Kies:\n0/1000\nNutze E zum Einladen",new Position(2948.8616f, 2790.4087f, 45.87256f),40,0,10,(int)ServerEnums.TextLabelEvent.GravelDump);
        }
        public static bool AddGravel(int amount)
        {
            if (Gravel >= 1000) return false;
            Gravel += amount;
            if(Gravel >= 1000) Gravel = 1000;
            if (GraveltextLabel != null) GraveltextLabel.SetText("Kies:\n"+Gravel+"/1000");
            return true;
        }
        public static int GetGravel()
        {
            return Gravel;
        }
    }
}
