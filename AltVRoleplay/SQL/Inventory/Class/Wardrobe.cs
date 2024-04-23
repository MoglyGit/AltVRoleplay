using AltVRoleplay.Text;
using AltV.Net.Data;

namespace AltVRoleplay.SQL.Inventory
{
    public class Wardrobe
    {
        public int Id { get; set; }
        public int[] Inv { get; set; }
        public float MaxWeight { get; set; }
        public TextLabel? TextLabel { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Dimension { get; set; }
        public MyPlayer.Player? UsedBy { get; set; }
        public Wardrobe(int slots)
        {
            UsedBy = null;
            Id = -1;
            Inv = new int[slots];
            Dimension = 0;
            MaxWeight = 0;
            X = 0;
            Y = 0;
            Z = 0;
        }
        public void Init()
        {
            CreateTextLabel("Schrank\nNutze E", 0, 2, ServerEnums.TextLabelEvent.Wardrobe);
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
            TextLabel = new TextLabel(text, new Position(X,Y,Z + offset_z), 5, Dimension, keyrange, (int)textlabelEvent);
        }
        public void Remove()
        {
            if (TextLabel != null) TextLabel.Remove();
            TextLabel = null;
            WardrobeList.RemoveWardrobe(this);
            Id = -1;
        }

        public void Create()
        {
            Id = WardrobeSql.CreateWardrobe(this);
            WardrobeList.AddWardrobe(this);
            Init();
        }
    }
}
