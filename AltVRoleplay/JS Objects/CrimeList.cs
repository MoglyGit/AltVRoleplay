using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.JS_Objects
{
    public class CrimeList
    {
        public static List<Crime> CrimeServerList = new List<Crime>();
        public static void AddCrime(Crime item)
        {
            CrimeServerList.Add(item);
        }
    }
}
