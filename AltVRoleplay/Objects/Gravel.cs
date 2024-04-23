
using AltV.Net.Data;
using AltVRoleplay.Text;

namespace AltVRoleplay.Objects
{
    public class Gravel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Objects.Object Object { get; set; }
        public int Health { get; set; }
        public Gravel(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            Health = 1;
            ObjectLists.AddGravel(this);
            Object = new Object(196166568, 0, 50, X, Y, Z - 1.7f, 0, 0, 0);
        }
        public void Respawn()
        {
            Health = 1;
            ObjectLists.AddGravel(this);
            Object = new Object(196166568, 0, 50, X, Y, Z - 1.7f, 0, 0, 0);
        }
        public void Remove()
        {
            if (Object.Exists) Object.Destroy();
            /*
             * Falls ringenommen, funktioneirt Respawn nicht mehr wegen = Koordinaten
            X = 0;
            Y = 0;
            Z = 0;*/
            ObjectLists.RemoveGravel(this);
        }
    }
}
