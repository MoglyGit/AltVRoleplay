using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class Perso
    {
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Age { get; set; }
        public string Adress { get; set; }
        public int Height { get; set; }
        public int Eyecolor { get; set; }
        public int Searched { get; set; }
        public ulong Socialclubid { get; set; }

        public Perso(string f, string l, string add, string age, int height, int ec, ulong sc)
        {
            id = 0;
            Fname = f;
            Lname = l;
            Age = age;
            Adress = add;
            Height = height;
            Eyecolor = ec;
            Socialclubid = sc;
            Searched = 0;
        }
        public string GetEyeColor()
        {
            return ServerMethods.GetEyeColor(Eyecolor);
        }
        public void CreatePerso()
        {
            foreach (Perso p in PersoList.PersoServerList)
            {
                if (p.Socialclubid == Socialclubid) p.Searched = 1;
            }
            PersoList.AddPerso(this);
        }
    }
}
