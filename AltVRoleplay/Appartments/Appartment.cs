using AltV.Net.EntitySync;
using AltV.Net.Data;
using AltVRoleplay.Events.House;
using AltVRoleplay.Text;

namespace AltVRoleplay.Appartments
{
    public class Appartment
    {
        public int id { get; set; }
        public float x_out { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public int interrior { get; set; }
        public string name { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public ulong owned { get; set; }
        public TextLabel? entity_in { get; set; }
        public TextLabel? entity_out { get; set; }
        public int Lock { get; set; }
        public int MinRentTime { get; set; }
        public float Trash { get; set; }
        public Appartment(float x, float y, float z, int interrior, int rent, string name)
        {
            MinRentTime = 3;
            id = 0;
            this.x = x;
            this.y = y;
            this.z = z;
            this.interrior = interrior;
            owned = 0;
            this.name = name;
            this.rent = rent;
            owner = "";
            entity_in = null;
            entity_out = null;
            x_out = 0;
            Lock = 1;
            Trash = 0;
        }

        public void AddTrash()
        {
            if (owned == 0) return;
            if (Trash > 200) return;
            Random rnd = new Random();
            Trash += 1 + (float)rnd.NextDouble()*5;
            Server.Log("Trash add "+ id);
        }

        public void DeleteAppartment()
        {
            AppartmentList.RemoveAppartment(this);
            if(entity_in!=null) entity_in.Remove();
            if(entity_out!=null)entity_out.Remove();
            Database.DeleteAppartment(this);
        }

        public void CreateAppartment()
        {
            AppartmentList.AddAppartment(this);
            entity_in = new TextLabel("Ausgang\nNutze: E taste", new System.Numerics.Vector3(x, y, z), 5, 0,1.3f, (int)ServerEnums.TextLabelEvent.ShowApartmentHud);
            Position pos = HouseInterrior.GetInterriorPositionText(interrior);
            x_out = pos.X;
            entity_out = new TextLabel(name+"\nAusgang", pos, 5, id,1.3f, (int)ServerEnums.TextLabelEvent.ShowApartmentHud);
            Update();
        }

        public void Save()
        {
            Database.SaveAppartment(this);
        }

        public void Update()
        {
            if (entity_in == null) return;
            if (owned == 0) entity_in.SetText(name + "\n" + rent + " $\nNutze: /rentroom");
            else entity_in.SetText(name + "\n" + "Mieter: " + owner);
        }

        public void Reset()
        {
            owned = 0;
            owner = "";
            MinRentTime = 3;
            Trash = 0;
            Save();
            foreach(Items.Items i in Items.ItemList.ItemsList)
            {
                if (i.Housekey != id) continue;
                i.Housekey = 1;
                i.SaveItem();
            }
            Update();
        }
    }
}
