using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class GroundList
    {
        public static List<GroundItems> GroundServerList = new List<GroundItems>();
        public static void AddItem(GroundItems item)
        {
            GroundServerList.Add(item);
        }
    }
}
