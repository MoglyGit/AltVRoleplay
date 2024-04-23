using AltVRoleplay.SQL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class Backpack : IInventory
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        public int[] Inv { get; set; }
        public float MaxWeight { get; set; }
        public MyPlayer.Player? UsedBy { get; set; }

        public Backpack(int size)
        {
            /*if (size == 3) { inv = new int[24]; }
            else if (size == 2) { inv = new int[16]; }
            else { inv = new int[8]; }*/
            UsedBy = null;
            Inv = new int[24];
            Id = 0;
            Amount = 0;
            this.Size = size;
            MaxWeight = 5 * size;
        }

        public int CreateBackpack()
        {
            Id = Database.CreateBackpack(this);
            BackpackList.AddItem(this);
            Items i = new Items();
            i.CreateBackpack(Id, Size);
            return i.Id;
        }

        public float GetBackpackMass()
        {
            float actuallMass = 0;
            for (int i = 0; i < Inv.Length; i++)
            {
                Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i]);
                if (item == null) continue;
                actuallMass += item.Mass * item.Amount;
            }
            return actuallMass;
        }

        public int GetFreeBackpackPlace()
        {
            float weight = GetBackpackMass();
            float max = MaxWeight;
            if (weight > max) return -1;
            for (int i = 0; i < Inv.Length; i++)
            {
                if (Inv[i] != 0 && Inv[i] != -1) continue;
                return i;
            }
            return -1;
        }

        public void AddItem(int place, int id)
        {
            Inv[place] = id;
        }
        public void AddItem(Items? item)
        {
            if (item == null) return;
            int place = GetFreeBackpackPlace();
            Inv[place] = item.Id;
        }
    }
}
