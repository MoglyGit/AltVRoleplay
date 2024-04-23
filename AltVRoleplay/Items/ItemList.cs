using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class ItemList
    {
        public static List<Items> ItemsList = new List<Items>();
        public static void AddItem(Items item)
        {
            ItemsList.Add(item);
        }
        public static void RemoveItem(Items item)
        {
            ItemsList.Remove(item);
        }
    }
}
