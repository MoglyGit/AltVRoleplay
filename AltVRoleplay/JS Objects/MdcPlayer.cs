using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.JS_Objects
{
    public class MdcPlayer
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public ulong Socialclubid { get; set; }
        public string Age { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public int Persoid { get; set; }
        public MdcPlayer(string fname, string lname, ulong sc, string age, string job, string addr, int pid)
        {
            Fname = fname;
            Lname = lname;
            Socialclubid = sc;
            Age = age;
            Job = job;
            Address = addr;
            Persoid = pid;
        }
    }
}
