using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltVRoleplay.MyPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay
{
    class Server : Resource
    {
        public override void OnStart()
        {          
            Log("Server wurde gestartet");
        }

        public override void OnStop()
        {
            Alt.Log("Server wurde beendet");
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new MyPlayerFactory();
        }

        public static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
