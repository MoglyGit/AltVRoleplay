using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class DrivingLicenseList
    {
        public static List<DrivingLicense> DrivingLicenseServerList = new List<DrivingLicense>();
        public static void AddDrivingLicense(DrivingLicense p)
        {
            DrivingLicenseServerList.Add(p);
        }
    }
}
