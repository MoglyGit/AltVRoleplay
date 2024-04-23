using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltVRoleplay.Ped;
using AltVRoleplay.Text;

namespace AltVRoleplay.SQL.LTD_Gas.Class
{
    public class LTDGasStation
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Konto { get; set; }
        public int Open { get; set; }
        public int Products { get; set; }
        public int[] FillPrice { get; set; }
        public TextLabel? TextLabel { get; set; }
        public PedEntity? Ped { get; set; }
        public string Name { get; set; }
        public ulong Owned { get; set; }
        public string Owner { get; set; }
        public int SellPrice { get; set; }
        public LTDGasStation(float x, float y, float z)
        {
            FillPrice = new int[4];
            Id = 0;
            X = x;
            Y = y;
            Z = z;
            Konto = 0;
            Open = 0;
            Products = 0;
            TextLabel = null;
            Ped = null;
            Name = "Tankstelle\nBesitzer: Niemand";
            Owned = 0;
            Owner = "";
            SellPrice = 0;
        }
        public void Save()
        {
            LTDSQL.UpdateLTD(this);
        }
        public void Update()
        {
            if (TextLabel != null)
            {
                if (SellPrice > 0 && Owned != 0) TextLabel.SetText(Name + "\nBesitzer: " + Owner + "\nZu Verkaufen");
                else TextLabel.SetText(Name + "\nBesitzer: " + Owner);
            }
        }
        public void Create()
        {
            Id = LTDSQL.CreateLTD(this);
            LTDList.AddStore(this);
            Init();
        }
        public void CreateSellerEntity(float x, float y, float z, float r)
        {
            if (Ped == null)
            {
                Ped = new PedEntity("IG_JimmyBoston_02", 0, r, new Position(x, y, z), 25, 0);
                Ped.CreateTextLabel("Welche Nummer?\nNutze E", 1, 2, ServerEnums.TextLabelEvent.LTDGas);
                return;
            }
            Ped.Remove();
            Ped = new PedEntity("IG_JimmyBoston_02", (int)ServerEnums.TextLabelEvent.LTDGas, r, new Position(x, y, z), 25, 0);
            Ped.CreateTextLabel("Welche Nummer?\nNutze E", 1, 2, ServerEnums.TextLabelEvent.LTDGas);
        }
        public void Init()
        {
            if (TextLabel == null) TextLabel = new TextLabel(Name, new Position(X, Y, Z), 5, 0, 2, (int)ServerEnums.TextLabelEvent.ShopOwner);
            if (Owned == 0) TextLabel.SetText(Name + "\nZu Verkaufen");
        }
        public Position GetPosition()
        {
            return new Position(X, Y, Z);
        }
    }
}
