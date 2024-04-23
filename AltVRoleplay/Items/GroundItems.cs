using AltV.Net;
using AltV.Net.EntitySync;
using AltVRoleplay.Items;

namespace AltVRoleplay
{
    public class GroundItems
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public int dimension { get; set; }

        public IEntity? entity { get; set; }
        public GroundItems()
        {
            id = 0;
            x = 0;
            y = 0;
            z = 0;
            entity = null;
            dimension = 0;
        }

        public void CreateGroundItem()
        {
            GroundList.AddItem(this);
            Random rnd = new Random();
            double rx = rnd.NextDouble()*(rnd.Next(2) == 0 ? 1 : -1) * rnd.Next(1,3);
            double ry = rnd.NextDouble()* (rnd.Next(2) == 0 ? 1 : -1) * rnd.Next(1,3);
            entity = AltEntitySync.CreateEntity((ulong)ServerEnums.Entitys.ItemObject, new System.Numerics.Vector3(x+(float)rx,y+(float)ry,z), dimension, 20);
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item != null) { entity.SetData("obj", item.Objhash); entity.SetData("invhudid", item.Id); }
        }
    }
}