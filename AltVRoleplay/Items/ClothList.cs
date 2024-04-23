using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class ClothList
    {
        public static List<Cloth> ClothServerList = new List<Cloth>();
        public static void AddItem(Cloth item)
        {
            ClothServerList.Add(item);
        }
    }
}
