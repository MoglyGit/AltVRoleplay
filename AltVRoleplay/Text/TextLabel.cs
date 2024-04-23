using AltV.Net;
using AltV.Net.EntitySync;

namespace AltVRoleplay.Text
{
    public class TextLabel
    {
        public IEntity? entity = null;
        public float x { get; set; }
        public TextLabel(string text, AltV.Net.Data.Position pos, int stremrange, int dim,float keyrange=0, int eventType=0)
        { 
            entity = AltEntitySync.CreateEntity((ulong)ServerEnums.Entitys.Text, pos, dim, (uint)stremrange);
            entity.SetData("text", text);
            entity.SetData("keyrange", "" + keyrange);
            entity.SetData("eventType",""+eventType);
            x = pos.X;
        }
        public void SetEventType(int eventType, float keyrange)
        {
            if (entity == null) return;
            entity.SetData("eventType", "" + eventType);
            entity.SetData("keyrange", "" + keyrange);
        }
        public void SetText(string text)
        {
            if (entity == null) return;
            entity.SetData("text", text);
        }
        public void Remove()
        {
            if (entity == null) return;
            AltEntitySync.RemoveEntity(entity);
            entity = null;
        }
    }
}
