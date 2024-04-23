using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Muellspace
{
    public class Muell
    {
        public DateTime time { get; set; }
        public Vector3 pos { get; set; }
        public Muell()
        {
            time = DateTime.Now.AddMinutes(10);
        }
    }
}
