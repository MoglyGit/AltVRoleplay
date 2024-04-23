using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net;
using AltV.Net.Data;
using AltVRoleplay.Text;
using System.Timers;

namespace AltVRoleplay.Autohaus
{
    public class AutohausCar
    {
        public string name { get; set; }
        public int price { get; set; }
        public float[] pos = new float[3];
        public float[] rot = new float[3];
        public ServerEnums.CarHouse carhouse { get; set; }
        public IVehicle? Veh { get; set; }
        public TextLabel? info { get; set; }
        public System.Timers.Timer RespawnTimer { get; set; }
        public int maxSpeed { get; set; }
        public AutohausCar(string name, int price, ServerEnums.CarHouse ch,int mSpeed, float pos_x, float pos_y, float pos_z, float r_x, float r_y, float r_z)
        {
            this.name = name;
            this.price = price;
            carhouse = ch;
            pos[0] = pos_x;
            pos[1] = pos_y;
            pos[2] = pos_z;
            rot[0] = r_x;
            rot[1] = r_y;
            rot[2] = r_z;
            maxSpeed = mSpeed;

            RespawnTimer = new System.Timers.Timer(1000*60*30);
            RespawnTimer.Elapsed += RespwanCar;
            Veh = null;
            CreateAutohausCar();
        }
        public void CreateAutohausCar()
        {
            Veh = Alt.CreateVehicle(Alt.Hash(name), new Position(pos[0], pos[1], pos[2]), new Rotation(rot[0], rot[1], rot[2]));
            Veh.Frozen = true;
            Veh.LockState = VehicleLockState.Locked;
            Random rnd = new Random();
            Veh.PrimaryColorRgb = new Rgba((byte)rnd.Next(254), (byte)rnd.Next(254), (byte)rnd.Next(254), 0);
            Veh.SecondaryColorRgb = new Rgba((byte)rnd.Next(254), (byte)rnd.Next(254), (byte)rnd.Next(254), 0);
            Veh.NumberplateText = "Sell";
            info = new TextLabel("Fahrzeug: " + name.ToUpper() + "\nPreis: " + price + "$\nNutze: E Taste zum kaufen", new System.Numerics.Vector3(pos[0], pos[1], pos[2]), 5, 0, 2.0f, (int)ServerEnums.TextLabelEvent.CarHouse_CarBuy);
        }
        public void RespwanCar(System.Object? source, ElapsedEventArgs? e)
        {
            if (Veh == null) return;
            if(!Veh.Exists)CreateAutohausCar();
            RespawnTimer.Stop();
        }
    }
}
