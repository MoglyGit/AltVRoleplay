using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class DrivingLicense
    {
        public string Owner { get; set; }
        public int Car { get; set; }
        public int Bike { get; set; }
        public int id { get; set; }
        public ulong Socialclubid { get; set; }
        public int Searched { get; set; }
        public DrivingLicense()
        {
            Owner = "";
            Car = 0;
            Bike = 0;
            id = 0;
            Socialclubid = 0;
            Searched = 0;
        }
        public void CreateDrivingLicense()
        {
            foreach (DrivingLicense p in DrivingLicenseList.DrivingLicenseServerList)
            {
                if (p.Socialclubid == Socialclubid) p.Searched = 1;
            }
            DrivingLicenseList.AddDrivingLicense(this);
        }
    }
}
