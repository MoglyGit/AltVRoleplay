using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.MyPlayer
{
    public class Player : AltV.Net.Elements.Entities.Player
    {
        public int PlayerID { get; set; } 
        public bool LoggedIn { get; set; }
        public String PlayerName { get; set; }
        public long Money { get; set; }
        public byte AdminLevel{ get; set; }
        public Player(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            LoggedIn = false;
            AdminLevel = 0;
            Money = 0;
            PlayerName = "";
        }
    }
}
