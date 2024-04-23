using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class PropList
    {
        public static List<Props> PropServerList = new List<Props>();
        public static void AddItem(Props item)
        {
            PropServerList.Add(item);
        }
    }
}
