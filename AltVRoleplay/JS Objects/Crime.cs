using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.JS_Objects
{
    public class Crime
    {
        public int id { get; set; }
        public string Grund { get; set; }
        public int Gesucht { get; set; }
        public int Knastzeit { get; set; }
        public int Type { get; set; }
        public int Kosten { get; set; }
        public string Datum { get; set; }
        public ulong Socialclubid { get; set; }
        public string PoliceName { get; set; }
        public Crime(ulong sc, int type, int cost, string reason, int gesucht, int time, string officer)
        {
            Grund = reason;
            Gesucht = gesucht;
            Knastzeit = time;
            Type = type;
            Datum = "";
            Socialclubid = sc;
            Kosten = cost;
            PoliceName = officer;
        }
        public void CreateCrime()
        {
            CrimeList.AddCrime(this);
        }
    }
}
