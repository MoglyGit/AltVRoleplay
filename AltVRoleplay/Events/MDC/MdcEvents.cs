using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.JS_Objects;

namespace AltVRoleplay.Events.MDC
{
    public class MdcEvents : IScript
    {

        [ClientEvent("mdcPersonSearch")]
        public static void mdcPersonSearch(MyPlayer.Player player, string person)
        {
            string vor = "", nach="";
            bool f = true;
            foreach(char c in person)
            {
                if (c == ' ')
                {
                    f = false;
                    continue;
                }
                if(f)
                {
                    vor += c;
                }
                else
                {
                    nach += c;
                }
            }
            player.mdcPlayer = Database.GetDBPlayersByName(vor, nach);
            foreach(MdcPlayer mplayer in player.mdcPlayer)
            {
                player.Emit("dbPlayer",mplayer.Fname, mplayer.Lname, mplayer.Socialclubid, mplayer.Persoid);
            }
        }
        [ClientEvent("getPlayerInfos")]
        public static void getPlayerInfos(MyPlayer.Player player, ulong sc)
        {
            if (player.mdcPlayer == null) return;
            MdcPlayer? target = player.mdcPlayer.Find(x => x.Socialclubid == sc);
            if (target == null) return;
            player.Emit("setMdcPlayerInfo", (target.Fname + " " + target.Lname), target.Age, target.Job, target.Address);
            player.Emit("clearCrimeDiv");
            for (int x=CrimeList.CrimeServerList.Count-1; x > 0; x--)
            {
                Crime c = CrimeList.CrimeServerList[x];
                if (c.Socialclubid != sc) continue;
                string s = "Anmerkung";
                if (c.Type == 1) s = "Verwarnung";
                if (c.Type == 2) s = "Verbrechen";
                player.Emit("createCrimeInfo", c.Datum, s, c.Grund, c.PoliceName, c.Kosten);
            }
        }
        [ClientEvent("createMdcCrime")]
        public static void createMdcCrime(MyPlayer.Player player, int type, int cost, string crime, int want, int time, ulong sc)
        {
            if (player.mdcPlayer == null) return;
            MdcPlayer? target = player.mdcPlayer.Find(x => x.Socialclubid == sc);
            if (target == null) return;
            Crime c = new Crime(sc, type, cost, crime, want, time, player.Fname+" "+player.Lname);
            c.id = Database.CreateCrime(c);
            c.CreateCrime();
            getPlayerInfos(player, sc);
        }
        [ClientEvent("getPlayerOpenWanteds")]
        public static void getPlayerOpenWanteds(MyPlayer.Player player, ulong sc)
        {
            if (player.mdcPlayer == null) return;
            MdcPlayer? target = player.mdcPlayer.Find(x => x.Socialclubid == sc);
            if (target == null) return;
            player.Emit("clearCrimeDiv");
            for (int x = CrimeList.CrimeServerList.Count - 1; x > 0; x--)
            {
                Crime c = CrimeList.CrimeServerList[x];
                if (c.Socialclubid != sc) continue;
                if (c.Type != 2) continue;
                if (c.Gesucht != 1) continue;
                player.Emit("createCrimeInfo", c.Datum, "Verbrechen", c.Grund, c.PoliceName, c.Kosten);
            }
        }
        [ClientEvent("getPlayerOpenTickets")]
        public static void getPlayerOpenTickets(MyPlayer.Player player, ulong sc)
        {
            if (player.mdcPlayer == null) return;
            MdcPlayer? target = player.mdcPlayer.Find(x => x.Socialclubid == sc);
            if (target == null) return;
            player.Emit("clearCrimeDiv");
            for (int x = CrimeList.CrimeServerList.Count - 1; x > 0; x--)
            {
                Crime c = CrimeList.CrimeServerList[x];
                if (c.Socialclubid != sc) continue;
                if (c.Type != 1) continue;
                if (c.Gesucht != 1) continue;
                player.Emit("createCrimeInfo", c.Datum, "Verwarnung", c.Grund, c.PoliceName, c.Kosten);
            }
        }
        [ClientEvent("getPlayerAnschriften")]
        public static void getPlayerAnschriften(MyPlayer.Player player, ulong sc)
        {
            if (player.mdcPlayer == null) return;
            MdcPlayer? target = player.mdcPlayer.Find(x => x.Socialclubid == sc);
            if (target == null) return;
            player.Emit("clearCrimeDiv");
            foreach(Appartment a in AppartmentList.AppartmentServerList)
            {
                if (a.owned != sc) continue;
                player.Emit("createCrimeInfo", "", "Apartment", a.name, "", "");
            }
        }
    }
}
