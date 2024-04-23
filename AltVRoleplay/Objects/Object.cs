using AltV.Net.Data;
using AltV.Net.EntitySync;

namespace AltVRoleplay.Objects
{
    public class Object
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Roll { get; set; }
        public float Pitch { get; set; }
        public float Yaw { get; set; }
        public IEntity Entity { get; set; }
        public uint Model { get; set; }
        public bool Exists { get; set; }

        public Object(uint model,int dimension,uint range, float x, float y, float z, float roll, float pitch, float yaw, bool onground=false)
        {
            X = x;
            Y = y;
            Z = z;
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
            Model = model;
            Entity = AltEntitySync.CreateEntity((ulong)ServerEnums.Entitys.Object, new System.Numerics.Vector3(x,y,z), dimension, range);
            Entity.SetData("obj", model);
            Entity.SetData("onground", onground);
            Entity.SetData("roll", roll);
            Entity.SetData("pitch", pitch);
            Entity.SetData("yaw", yaw);
            Exists = true;
        }

        public void SetPosition(float x, float y, float z, bool onground=false)
        {
            if (!Entity.Exists) return;
            Entity.Position = new System.Numerics.Vector3(x, y, z);
            Entity.SetData("onground", onground);
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
            if (!Entity.Exists) return;
            Entity.SetData("roll", roll);
            Entity.SetData("pitch", pitch);
            Entity.SetData("yaw", yaw);
            Yaw = yaw;
            Roll = roll;
            Pitch = pitch;
        }

        public void Destroy()
        {
            AltEntitySync.RemoveEntity(Entity);
            Exists = false;
        }
    }
}
