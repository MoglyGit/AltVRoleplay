using AltV.Net.EntitySync;
using AltVRoleplay.Text;
using AltV.Net.Data;

namespace AltVRoleplay.Ped
{
    public class PedEntity
    {
        public IEntity? entity = null;
        public TextLabel? TextLabel = null;
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public int dimension { get; set; }
        public int AnKaufKurs { get; set; }
        public int Storage { get; set; }
        public int Db_Id { get; set; }
        public int Type { get; set; }
        public PedEntity(string model,int interaction,float facing, Position pos, int range, int dim)
        { 
            entity = AltEntitySync.CreateEntity((ulong)ServerEnums.Entitys.Ped, pos, dim, (uint)range);
            entity.SetData("model", model);
            entity.SetData("interaction", interaction);
            entity.SetData("r", facing);
            x = pos.X;
            y = pos.Y;
            z = pos.Z;
            dimension = dim;
            AnKaufKurs = 1;
            Storage = 1000;
            Db_Id = -1;
            Type = 0;
        }
        public Position GetPosition()
        {
            return new Position(x,y,z);
        }

        public void CreateTextLabel(string text, float offset_z, float keyrange, ServerEnums.TextLabelEvent textlabelEvent)
        {
            if (TextLabel != null) return;
            TextLabel = new TextLabel(text,new Position(x,y,z+offset_z), 5, 0, keyrange, (int)textlabelEvent);
        }

        public void Remove()
        {
            if(entity!=null)AltEntitySync.RemoveEntity(entity);
            if(TextLabel !=null)TextLabel.Remove();
            entity = null;
        }
    }
}
