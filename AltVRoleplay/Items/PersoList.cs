using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class PersoList
    {
        public static List<Perso> PersoServerList = new List<Perso>();
        public static void AddPerso(Perso p)
        {
            PersoServerList.Add(p);
        }
    }
}
