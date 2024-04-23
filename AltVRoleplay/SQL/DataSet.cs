using AltVRoleplay.Items;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.SQL
{
    class DataSet
    {
        public static void LoadProps(MyPlayer.Player player)
        {
            Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == player.Hat);
            if (item != null)
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop != null)
                {
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Glasses);
            if (item != null)
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop != null)
                {
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Ears);
            if (item != null)
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop != null)
                {
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Watches);
            if (item != null)
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop != null)
                {
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                    player.SetSyncedMetaData("WearingWatch", 1);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Bracelet);
            if (item != null)
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop != null)
                {
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                }
            }
        }

        public static void LoadHead(MyPlayer.Player player, string head)
        {
            byte comp = 0;
            string[] id = new string[9];
            foreach (char c in head)
            {
                if (c != '|')
                {
                    id[comp] += c;
                }
                else
                {
                    comp += 1;
                }
            }
            player.SetHeadBlendData((ushort)Convert.ToInt32(id[0]), (ushort)Convert.ToInt32(id[1]), (ushort)Convert.ToInt32(id[2]), (ushort)Convert.ToInt32(id[3]), (ushort)Convert.ToInt32(id[4]), (ushort)Convert.ToInt32(id[5]), float.Parse(id[6], CultureInfo.InvariantCulture.NumberFormat), float.Parse(id[7], CultureInfo.InvariantCulture.NumberFormat), float.Parse(id[8], CultureInfo.InvariantCulture.NumberFormat));
        }

        public static void LoadFace(MyPlayer.Player player, string face)
        {
            int pointer = 0;
            byte comp = 0;
            string id = "";
            foreach (char c in face)
            {
                if (c != '|')
                {
                    id += c;
                }
                else
                {
                    pointer++;
                    if (pointer == 1)
                    {
                        player.SetFaceFeature(comp, float.Parse(id, CultureInfo.InvariantCulture.NumberFormat));
                        comp += 1;
                        pointer = 0;
                        id = "";
                    }
                }
            }
        }

        //Clothes
        public static void LoadClothes(MyPlayer.Player player)
        {
            player.SetClothes(11, 15, 0, 0);
            player.SetClothes(3, 15, 0, 0);
            player.SetClothes(1, 0, 0, 0);
            player.SetClothes(8, 15, 0, 0);
            if (player.Sex == 1) player.SetClothes(4, 19, 0, 0);
            else player.SetClothes(4, 21, 0, 0);
            if (player.Sex == 1) player.SetClothes(6, 35, 0, 0);
            else player.SetClothes(6, 34, 0, 0);
            Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == player.Mask);
            if(item!=null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x=> x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Top);
            if (item != null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Under);
            if (item != null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Legs);
            if (item != null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Shoes);
            if (item != null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
            item = Items.ItemList.ItemsList.Find(x => x.Id == player.Acces);
            if (item != null)
            {
                Items.Cloth? cloth = Items.ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                if (cloth != null)
                {
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                }
            }
        }

        public static void LoadOverlay(MyPlayer.Player player, string overlay)
        {
            int pointer = 0;
            byte comp = 0;
            string[] id = new string[5];
            foreach (char c in overlay)
            {
                if (c != '|')
                {
                    id[pointer] += c;
                }
                else
                {
                    pointer++;
                    if (pointer == 5)
                    {
                        player.SetHeadOverlay(comp, Convert.ToByte(id[0]), float.Parse(id[1], CultureInfo.InvariantCulture.NumberFormat));
                        player.SetHeadOverlayColor(comp, Convert.ToByte(id[2]), Convert.ToByte(id[3]), Convert.ToByte(id[4]));
                        comp += 1;
                        pointer = 0;
                        id[0] = "";
                        id[1] = "";
                        id[2] = "";
                        id[3] = "";
                        id[4] = "";
                    }
                }
            }
        }
    }
}
