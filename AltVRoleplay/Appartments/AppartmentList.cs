using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Appartments
{
    public class AppartmentList
    {
        public static List<Appartment> AppartmentServerList = new List<Appartment>();
        public static void AddAppartment(Appartment appartment)
        {
            AppartmentServerList.Add(appartment);
        }
        public static void RemoveAppartment(Appartment appartment)
        {
            AppartmentServerList.Remove(appartment);
        }
    }
}
