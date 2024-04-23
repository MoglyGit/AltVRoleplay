using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Muellspace
{
    public class MuellList
    {
        public static List<Muell> MuellServerList = new List<Muell>();
        public static void AddItem(Muell item)
        {
            MuellServerList.Add(item);
        }
        public static void RemoveItem(Muell item)
        {
            MuellServerList.Remove(item);
        }
    }
}
