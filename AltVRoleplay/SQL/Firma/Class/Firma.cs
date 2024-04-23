
using AltV.Net.Data;
using AltVRoleplay.SQL.Inventory;
using AltVRoleplay.SQL.Store;
using AltVRoleplay.Text;
using Mysqlx.Crud;
using System.Xml.Linq;

namespace AltVRoleplay.SQL.Firma.Class
{
    public class Firma
    {
        public int Id { get; set; }
        public TextLabel? TextLabel { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Info { get; set; }
        public ulong Owner_Id { get; set; }
        public string Owner_Name { get; set; }
        public int Products { get; set; }
        public int FirmenType { get; set; }
        public int Price { get; set; }
        public int Konto { get; set; }
        public int KontoNr { get; set; }
        public Firma(float x, float y, float z)
        {
            Id = -1;
            X = x;
            Y = y;
            Z = z;
            Info = "";
            Owner_Id = 0;
            Owner_Name = "";
            Products = 0;
            FirmenType = (int)ServerEnums.Firmen.None;
            Price = 0;
            Konto = 0;
            KontoNr = 0;
        }
        public void Init()
        {
            string gs;
            if (Owner_Name == "")
            {
                string typename = FirmenNameHandler.GetFirmenTypeToName((ServerEnums.Firmen)FirmenType);
                gs = "Grundstück\n" + typename + "\nPreis\n" + Price+"$";
            }
            else
            {
                gs = Info + "\nBesitzer: " + Owner_Name;
            }
            CreateTextLabel(gs, 0, 2, ServerEnums.TextLabelEvent.FirmaMenu);
        }
        public void SetPostion(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
            Z = pos.Z;
        }
        public Position GetPosition()
        {
            return new Position(X, Y, Z);
        }
        public void CreateTextLabel(string text, float offset_z, float keyrange, ServerEnums.TextLabelEvent textlabelEvent)
        {
            if (TextLabel != null) return;
            TextLabel = new TextLabel(text, new Position(X, Y, Z + offset_z), 5, 0, keyrange, (int)textlabelEvent);
        }
        public void Remove()
        {
            TextLabel?.Remove();
            TextLabel = null;
            FirmaList.RemoveFirma(this);
            Id = -1;
        }

        public void Create()
        {
            Id = FirmaSql.CreateFirma(this);
            FirmaList.AddFirma(this);
            Init();
        }
        public void Update()
        {
            if (TextLabel != null)
            {
                string s;
                if (Info != "") s = Info;
                else s = FirmenNameHandler.GetFirmenTypeToName((ServerEnums.Firmen)FirmenType);
                if (Price > 0 && Owner_Id != 0) TextLabel.SetText(s + "\nBesitzer: " + Owner_Name + "\nZu Verkaufen");
                else TextLabel.SetText(s + "\nBesitzer: " + Owner_Name);
            }
        }
        public void Save()
        {
            FirmaSql.UpdateFirma(this);
        }
    }
}
