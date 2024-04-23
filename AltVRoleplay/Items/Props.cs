using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class Props
    {
        public int id { get; set; }
        public int drawable { get; set; }
        public int texture { get; set; }
        public int sex { get; set; }
        public int componente { get; set; }
        public Props(int componente, int drawable, int texture, int sex)
        {
            id = 0;
            this.drawable = drawable;
            this.componente = componente;
            this.texture = texture;
            this.sex = sex;
        }

        public int CreateProp()
        {
            id = Database.CreateProp(this);
            PropList.AddItem(this);
            Items i = new Items();
            i.Prop = id;
            i.Description = "Modell: " + drawable + " | " + (sex == 0 ? "Mann" : "Frau");
            i.Objhash = -1870936557;
            switch (componente)
            {
                case 0:
                    i.Objhash = -1870936557;
                    break;
                case 1:
                    i.Objhash = -1703594174;
                    break;
                case 2:
                    i.Objhash = -14292445;
                    break;
                case 6:
                    i.Objhash = 1169295068;
                    break;
                case 7:
                    i.Objhash = 419222340;
                    break;
            }
            i.CreateItem(ServerEnums.Items.Prop);
            return i.Id;
        }
    }
}
