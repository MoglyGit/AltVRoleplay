using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class Cloth
    {
        public int id { get; set; }
        public int drawable { get; set; }
        public int texture { get; set; }
        public int sex { get; set; }
        public int componente { get; set; }
        public Cloth(int componente, int drawable, int texture, int sex)
        {
            id = 0;
            this.drawable = drawable;
            this.componente = componente;
            this.texture = texture;
            this.sex = sex;
        }

        public int CreateCloth()
        {
            id = Database.CreateCloth(this);
            ClothList.AddItem(this);
            Items i = new Items();
            i.Clothes = id;
            i.Description = "Modell: "+ drawable+" | " +(sex==0 ? "Mann": "Frau");
            switch(componente)
            {
                case 1:
                    i.Objhash = -915071241;
                    break;
                case 4:
                    i.Objhash = -1157632529;
                    break;
                case 6:
                    i.Objhash = 1682675077;
                    break;
                case 8:
                    i.Objhash = 578126062;
                    break;
                case 11:
                    i.Objhash = -1256588656;
                    break;
            }
            i.CreateItem(ServerEnums.Items.Cloth);
            return i.Id;
        }
    }
}
