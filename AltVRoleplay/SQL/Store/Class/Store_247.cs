
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltVRoleplay.Ped;
using AltVRoleplay.Text;

namespace AltVRoleplay.SQL.Store.Class
{
    public class Store_247
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Konto { get; set; }
        public int Open { get; set; }
        public int Products { get; set; }
        public int Eat { get; set; }
        public TextLabel? TextLabel { get; set; }
        public PedEntity? Ped { get; set; }
        public string Name { get; set; }
        public ulong Owned { get; set; }
        public string Owner { get; set; }
        public int SellPrice { get; set; }
        public int[] SellProducts { get; set; }
        public int[] Products_Price { get; set; }
        public Store_247(float x, float y, float z)
        {
            SellProducts = new int[6];
            Products_Price = new int[6];
            Id = 0;
            X = x;
            Y = y;
            Z = z;
            Konto = 0;
            Open = 0;
            Products = 0;
            Eat = 0;
            TextLabel = null;
            Ped = null;
            Name = "24/7\nBesitzer: Niemand";
            Owned = 0;
            Owner = "";
            SellPrice = 0;
        }
        public void Save()
        {
            StoreSql.UpdateStore247(this);
        }
        public void Update()
        {
            if (TextLabel != null)
            {
                if (SellPrice > 0 && Owned != 0) TextLabel.SetText(Name + "\nBesitzer: " + Owner+"\nZu Verkaufen");
                else TextLabel.SetText(Name + "\nBesitzer: " + Owner);
            }
        }
        public void Create()
        {
            Id = StoreSql.CreateStore_247(this);
            StoreList.AddStore(this);
            Init();
        }
        public void CreateSellerEntity(float x, float y, float z, float r)
        {
            if (Ped == null)
            {
                Ped = new PedEntity("mp_m_shopkeep_01", 0, r, new Position(x, y, z), 25, 0);
                Ped.CreateTextLabel("Schau dich ruhig um\nNutze E", 1, 2, ServerEnums.TextLabelEvent.Show247Shop);
                return;
            }
            Ped.Remove(); 
            Ped = new PedEntity("mp_m_shopkeep_01", (int)ServerEnums.TextLabelEvent.Show247Shop, r, new Position(x, y, z), 25, 0);
            Ped.CreateTextLabel("Schau dich ruhig um\nNutze E", 1, 2, ServerEnums.TextLabelEvent.Show247Shop);
        }
        public void Init()
        {
            if (TextLabel == null) TextLabel = new TextLabel(Name, new Position(X, Y, Z), 5, 0, 2, (int)ServerEnums.TextLabelEvent.ShopOwner);
            if (Owned == 0) TextLabel.SetText(Name+"\nZu Verkaufen");
        }
        public Position GetPosition()
        {
            return new Position(X, Y, Z);
        }
    }
}
