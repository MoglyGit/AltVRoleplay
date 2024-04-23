using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Autohaus
{
    public class AutohausList
    {
        public static List<AutohausCar> AutohausServerList = new List<AutohausCar>();
        public static void AddAutohausCar(AutohausCar car)
        {
            AutohausServerList.Add(car);
        }
        public static void RemoveAppartment(AutohausCar car)
        {
            AutohausServerList.Remove(car);
        }
        public static AutohausCar? FindAutohausCarByPosX(float x)
        {
            return AutohausServerList.Find(car => car.info != null && car.info.x == x);
        }
    }
}
