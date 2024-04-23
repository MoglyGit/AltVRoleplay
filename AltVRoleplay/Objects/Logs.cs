using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltVRoleplay.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Objects
{
    public class Logs
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public TextLabel? TextLabel { get; set; }
        public Objects.Object Object { get; set; }
        public int Health { get; set; }
        public bool interarction = true;
        public Logs(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            Random rnd = new Random();
            Health = 20+rnd.Next(1,80);
            TextLabel = new TextLabel("Schlag dir etwas Holz ab", new Position(x, y, z), 20, 0,2f);
            Object = new Object(Alt.Hash("prop_logpile_04"), 0, 200, X, Y, Z, 0, 0, 90f, true);
            ObjectLists.AddLog(this);
            interarction = true;
        }
        public void Remove()
        {
            if (Object.Exists) Object.Destroy();
            if (TextLabel != null) TextLabel.Remove();
            TextLabel = null;
            X = 0;
            Y = 0;
            Z = 0;
            ObjectLists.RemoveLog(this);
            interarction=false;
        }
    }
}
