using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.MyVehicle
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, IntPtr vehiclePointer, uint id)
        {
            return new MyVehicle(core, vehiclePointer, id);
        }
    }
}
