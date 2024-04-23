using AltV.Net;
using AltV.Net.Data;
using AltVRoleplay.Items;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.EntitySync;
using AltVRoleplay.Events.Fishing;
using AltVRoleplay.Items.Useable;

namespace AltVRoleplay.Events.Player
{
    public class PedEvents : IScript
    {

        [ClientEvent("AddGroundHudItem")]
        public static void AddGroundHudItem(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            GroundItems? ground = GroundList.GroundServerList.Find(x => x.id == id);
            if (ground == null) return;
            if (ground.dimension != player.Dimension) return;
            if (player.Position.Distance(new Position(ground.x, ground.y, ground.z)) <= 4f)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == ground.id);
                if (item == null) return;
                string src = GetSource(item);
                int type = GetType(player, item);
                if (type == 1)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null) return;
                    player.Emit("addGround", ground.id, item.Description, type, src, back.GetBackpackMass(), item.Mass, item.MaxAmount);
                }
                else player.Emit("addGround", ground.id, item.Description, type, src, item.Amount, item.Mass, item.MaxAmount);
            }
        }
        [ClientEvent("equipPlayerItem")]
        public static void EquipPlayerItem(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) return;
            ItemEffect.EquipItem(player, item);
        }
        [ClientEvent("usePlayerItem")]
        public static void UsePlayerItem(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) return;
            ItemEffect.ActivateItemEffect(player, item);
        }
        [ClientEvent("showDrive")]
        public static void ShowDrive(MyPlayer.Player player, int id)
        {
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) return;
            DrivingLicense? p = DrivingLicenseList.DrivingLicenseServerList.Find(x => x.id == item.Drivinglicense);
            if (p == null) return;
            player.Emit("showDrive", p.Owner, p.Socialclubid, p.id, p.Car, p.Bike);
        }
        [ClientEvent("showPlayerDrive")]
        public static void ShowPlayerDrive(MyPlayer.Player player, int targetid, int id)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = MyPlayer.GetPlayer.GetPlayerById(targetid);
            if (target == null) return;
            if (!target.LoggedIn) return;
            if (player.Position.Distance(target.Position) > 5) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) return;
            DrivingLicense? p = DrivingLicenseList.DrivingLicenseServerList.Find(x => x.id == item.Drivinglicense);
            if (p == null) return;
            target.Emit("showDrive", p.Owner, p.Socialclubid, p.id, p.Car, p.Bike);
            player.SendChatMessage("Du zeigst deinen Führerschein");
        }
        [ClientEvent("showPerso")]
        public static void ShowPerso(MyPlayer.Player player, int id)
        {
            Items.Items? item = ItemList.ItemsList.Find(x=>x.Id == id);
            if (item == null) return;
            Perso? p = PersoList.PersoServerList.Find(x=>x.id==item.Perso);
            if (p == null) return;
            player.Emit("showPerso",p.Fname,p.Lname,p.Age,p.Height,p.GetEyeColor(),p.Adress,"L"+p.id+"S"+p.Socialclubid);
        }
        [ClientEvent("showPlayerPerso")]
        public static void ShowPlayerPerso(MyPlayer.Player player,int targetid, int id)
        {
            if (!player.LoggedIn) return;
            MyPlayer.Player? target = MyPlayer.GetPlayer.GetPlayerById(targetid);
            if (target == null) return;
            if (!target.LoggedIn) return;
            if (player.Position.Distance(target.Position) > 5) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) return;
            Perso? p = PersoList.PersoServerList.Find(x => x.id == item.Perso);
            if (p == null) return;
            target.Emit("showPerso", p.Fname, p.Lname, p.Age, p.Height, p.GetEyeColor(), p.Adress, "L" + p.id + "S" + p.Socialclubid);
            player.SendChatMessage("Du zeigst deinen Personalasuweis");
        }
        [ClientEvent("calculateMuni")]
        public static void CalculateInvMuni(MyPlayer.Player player)
        {
            player.SaveInvMuni();
        }
        [ClientEvent("remvoePlayerBackPack")]
        public static void RemovePlayerBackpack(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.GetClothes(5).Drawable != 0) player.SetClothes(5, 0, 0, 0);
        }
        [ClientEvent("getCloth")]
        public static void GetInvCloth(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == player.Mask);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addCloth", item.Id, item.Description, type, 1, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Top);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addCloth", item.Id, item.Description, type, 2, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Under);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addCloth", item.Id, item.Description, type, 3, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Legs);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addCloth", item.Id, item.Description, type, 4, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Shoes);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addCloth", item.Id, item.Description, type, 5, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Acces);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addCloth", item.Id, item.Description, type, 6, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Hat);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addProp", item.Id, item.Description, type, 0, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Glasses);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addProp", item.Id, item.Description, type, 1, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Ears);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addProp", item.Id, item.Description, type, 2, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Watches);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addProp", item.Id, item.Description, type, 3, src, item.Amount, item.Mass, item.MaxAmount);
            }
            item = ItemList.ItemsList.Find(x => x.Id == player.Bracelet);
            if (item != null)
            {
                string src = GetSource(item);
                int type = GetType(player, item);
                player.Emit("addProp", item.Id, item.Description, type, 4, src, item.Amount, item.Mass, item.MaxAmount);
            }
            player.Emit("ShowInventory",true);
        }
        [ClientEvent("getInvItems")]
        public static void GetInvItems(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            float actuallMass = 0;
            for (int i=0; i< player.Inv.Length; i++)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == player.Inv[i]);
                if (item == null) continue;
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addInv", item.Id, item.Description, type, i, src, item.Amount, item.Mass, item.MaxAmount);
                actuallMass += item.Mass * item.Amount;
            }
            float max = player.GetMaxInvWieght();
            player.Emit("setWeight", actuallMass.ToString("0.00"), max);
        }
        [ClientEvent("getBackpackitems")]
        public static void GetBackpackitems(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == id);
            if (itemBack == null) { player.SendChatMessage("Fehler im BackpackLoad, bitte einmal reconnecten!"); return; }
            Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
            if (back == null) { player.SendChatMessage("Fehler im BackpackLoad, bitte einmal reconnecten!"); return; }
            float actuallMass = 0;
            for (int i = 0; i < back.Inv.Length; i++)
            {
                if (back.Inv[i] == 0 || back.Inv[i] == -1) continue;
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == back.Inv[i]);
                if (item == null) continue;
                string src = GetSource(item);
                int type = GetType(player,item);
                player.Emit("addBack", item.Id, item.Description, type, i, src, back.Size, item.Amount, item.Mass, item.MaxAmount);
                actuallMass += item.Mass * item.Amount;
            }
            player.Emit("addBackHud", back.Size, actuallMass.ToString("0.00"));
            player.GiveBackpack();
        }
        [ClientEvent("AddGroundItem")]
        public static void AddGroundItem(MyPlayer.Player player, int id, string slot, int backpack)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) {player.Emit("RemoveHudItem", id); return; }

            bool isOnGround = false;
            GroundItems? exists = GroundList.GroundServerList.Find(x => x.id == id);
            if (exists != null)
            {
                isOnGround = true;
                exists.x = player.Position.X;
                exists.y = player.Position.Y;
                exists.z = player.Position.Z;
                if(exists.entity != null) exists.entity.Position = player.Position;
            }
            else
            {
                GroundItems g = new GroundItems();
                g.id = id;
                g.x = player.Position.X;
                g.y = player.Position.Y;
                g.z = player.Position.Z;
                g.dimension = player.Dimension;
                g.CreateGroundItem();
            }
            FishingInventoryHandler.IsItemActualKoeder(player, item);
            if (item.Serveritem == ServerEnums.Items.Fishingrod) FishingInventoryHandler.UnEquipFishingRod(player);
            if (item.Serveritem == ServerEnums.Items.Pickaxe) IronFarm.IronFarmHandler.UnEquipPickAxe(player);
            if (item.Serveritem == ServerEnums.Items.GPS) player.Emit("SetRadar", false);
            if(item.Backpack != 0 && !isOnGround)
            {
                FishingInventoryHandler.UnEquipFishingRod(player);
                IronFarm.IronFarmHandler.UnEquipPickAxe(player);
                player.Notification(ServerEnums.Notify.Info, "Alles Unequipt");
            }

            if (slot.Contains("cloth"))
            {
                int d = GetIntFromString(slot);
                if (d == -1) return;
                if (d == 1){ player.SetClothes(1, 0, 0, 0); player.Mask = -1; }
                if (d == 2) { player.Top = -1; player.SetClothes(11, 15, 0, 0); player.SetClothes(3, 15, 0, 0); }
                if (d == 3) { player.Under = -1; player.SetClothes(8, 15, 0, 0); player.SetClothes(3, 15, 0, 0); }
                if (d == 4) { player.Legs = -1; player.SetClothes(4, 14, 0, 0); }
                if (d == 5) { player.Shoes = -1; if (player.Sex == 1) { player.SetClothes(6, 35, 0, 0); } else { player.SetClothes(6, 34, 0, 0); } }
                if (d == 6) { player.Acces = -1; player.SetClothes(7, 0, 0, 0); }
                return;
            }
            if (slot.Contains("pop"))
            {
                int d = GetIntFromString(slot);
                if (d == -1) return;
                if (d == 0) { player.ClearProps(0); player.Hat = -1; }
                if (d == 1) { player.ClearProps(1); player.Glasses = -1; }
                if (d == 2) { player.ClearProps(2); player.Ears = -1; }
                if (d == 3) { player.ClearProps(6); player.Watches = -1; player.DeleteSyncedMetaData("WearingWatch"); }
                if (d == 4) { player.ClearProps(7); player.Bracelet = -1; }
                return;
            }
            if (slot.Contains("inv"))
            {
                int d = GetIntFromString(slot);
                if (d == -1) return;
                player.Inv[d] = -1;
                float mass = item.Mass * item.Amount;
                player.Emit("AddWeightBackpackAndPlayer", mass.ToString("-0.00"), "0");
                player.GiveBackpack();
                if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                return;
            }
            if (slot.Contains("backl"))
            {
                Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                if (itemBack == null) { player.SendChatMessage("Fehler im Backpack, bitte einmal reconnecten!"); return; }
                Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                if (back == null) { player.SendChatMessage("Fehler im Backpack, bitte einmal reconnecten!"); return; }
                int d = GetIntFromString(slot);
                if (d == -1) return;
                back.Inv[d] = -1;
                float mass = item.Mass * item.Amount;
                player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("-0.00"));
                if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                return;
            }
            if (slot.Contains("other"))
            {
                int d = GetIntFromString(slot);
                if (d == -1) return;

                int[] otherInv = new int[1];
                if (player.GetOtherInv(ref otherInv))
                {
                    otherInv[d] = -1;
                    float mass = 0;
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null)
                        mass = item.Mass * item.Amount;
                    else
                        mass = back.GetBackpackMass();
                    player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), "0");

                    player.GiveBackpack();
                    if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                    return;
                }
                return;
            }
        }
        [ClientEvent("RemoveGroundItem")]
        public static void RemoveGroundItem(MyPlayer.Player player, int id, string slot,int backpack)
        {
            if (!player.LoggedIn) return;
            GroundItems? g = GroundList.GroundServerList.Find(x=> x.id == id);
            if (g == null)
            {
                player.SendChatMessage("Das Item liegt nicht mehr auf dem Boden");
                player.Emit("RemoveHudItem", id);
                return;
            }
            else
            {
                if (player.Position.Distance(new Position(g.x,g.y,g.z)) >= 5)
                {
                    player.SendChatMessage("Du bist zu weit vom Item entfernt");
                    player.Emit("RemoveHudItem", id);
                    return;
                }
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
                if (item == null) { player.Emit("RemoveHudItem", id); return; }
                if (item.Serveritem == ServerEnums.Items.GPS) player.Emit("SetRadar", true);
                GroundList.GroundServerList.Remove(g);
                if (g.entity != null) AltEntitySync.RemoveEntity(g.entity);

                if (slot.Contains("cloth"))
                {
                    int d = GetIntFromString(slot);
                    if (d == -1) return;
                    Items.Cloth? cloth = ClothList.ClothServerList.Find(x=> x.id == item.Clothes);
                    if (cloth == null) return;
                    if (d == 1) player.Mask = id;
                    if (d == 2) player.Top = id;
                    if (d == 3) player.Under = id;
                    if (d == 4) player.Legs = id;
                    if (d == 5) player.Shoes = id;
                    if (d == 6) player.Acces = id;
                    player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                    return;
                }
                if (slot.Contains("pop"))
                {
                    int d = GetIntFromString(slot);
                    if (d == -1) return;
                    Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                    if (prop == null) return;
                    if (d == 0) player.Hat = id;
                    if (d == 1) player.Glasses = id;
                    if (d == 2) player.Ears = id;
                    if (d == 3)
                    {
                        player.Watches = id;
                        player.SetSyncedMetaData("WearingWatch", 1);
                    }
                    if (d == 4) player.Bracelet = id;
                    player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                    return;
                }
                if (slot.Contains("inv"))
                {
                    int d = GetIntFromString(slot);
                    if (d == -1) return;
                    player.Inv[d] = id;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), "0");
                    if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                    return;
                }
                if (slot.Contains("backl"))
                {
                    Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                    if (itemBack == null) { player.SendChatMessage("Fehler im Backpack, bitte einmal reconnecten!"); return; }
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                    if (back == null) { player.SendChatMessage("Fehler im Backpack, bitte einmal reconnecten!"); return; }
                    int d = GetIntFromString(slot);
                    if (d == -1) return;
                    back.Inv[d] = id;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("0.00"));
                    if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                    return;
                }
                if(slot.Contains("other"))
                {
                    int d = GetIntFromString(slot);
                    if (d == -1) return;
                    int[] otherInv = new int[1];
                    if (player.GetOtherInv(ref otherInv))
                    {
                        otherInv[d] = id;
                        float mass = 0;
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                        if (back == null)
                            mass = item.Mass * item.Amount;
                        else
                            mass = back.GetBackpackMass();
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), "0");
                        if ((item.Weapons != "-1" && item.Weapons != "0") || item.Munitype != -1 || item.Backpack != 0) player.GiveInvWeapons();
                        return;
                    }
                    return;
                }
            }

        }

        [ClientEvent("renameItem")]
        public static void RenameItemInfo(MyPlayer.Player player, int id, string newName) 
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) { player.Emit("RemoveHudItem", id); return; }
            if (newName == null || newName.Trim().Length < 3) return;
            item.Description = newName;
            item.SaveItem();
        }

        [ClientEvent("splitItem")]
        public static void SplitItem(MyPlayer.Player player, int id, int amount, string slot)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) { player.Emit("RemoveHudItem", id); return; }
            if(item.Amount - amount <= 0 || amount <= 0)
            {
                player.SendChatMessage("So viel hast du davon nicht mehr");
                return;
            }
            if (slot.Contains("boden"))
            {
                Items.Items newitem = new Items.Items(item, amount);
                item.Amount -= amount;
                item.SaveItem();
                GroundItems g = new GroundItems();
                g.id = newitem.Id;
                g.x = player.Position.X;
                g.y = player.Position.Y;
                g.z = player.Position.Z;
                g.dimension = player.Dimension;
                g.CreateGroundItem();
                string src = GetSource(newitem);
                int type = GetType(player, newitem);
                player.Emit("addGround", g.id, newitem.Description, type, src, newitem.Amount, newitem.Mass, newitem.MaxAmount);
                player.Emit("UpdateSplitItemAmount", item.Amount, item.Mass);
                foreach(MyPlayer.Player p in Alt.GetAllPlayers())
                {
                    if (!p.LoggedIn) continue;
                    if (p.Position.Distance(player.Position) > 10) continue;
                    p.Emit("UpdateItemAmount",item.Id, item.Amount, item.Mass);
                }
            }
            else if (slot.Contains("other"))
            {
                int[] otherInv = new int[1];
                if (!player.GetOtherInv(ref otherInv)) return;
                for(int i=0; i< otherInv.Length; i++)
                {
                    if (otherInv[i] != 0 && otherInv[i] != -1) continue;
                    Items.Items newitem = new Items.Items(item, amount);
                    item.Amount -= amount;
                    item.SaveItem();
                    otherInv[i] = newitem.Id;
                    string src = GetSource(newitem);
                    int type = GetType(player, newitem);
                    player.Emit("addOther", newitem.Id, newitem.Description, type, i, src, newitem.Amount, newitem.Mass, newitem.MaxAmount);
                    player.Emit("UpdateSplitItemAmount", item.Amount, item.Mass);
                    return;
                }
                return;
            }
            else if (slot.Contains("backl"))
            {
                Backpack? back = player.GetPlayerBackPack();
                if (back == null) return;
                int place = back.GetFreeBackpackPlace();
                if (place == -1) return;
                Items.Items newitem = new Items.Items(item, amount);
                item.Amount -= amount;
                item.SaveItem();
                back.AddItem(place, newitem.Id);
                if (newitem.Munitype != -1) player.GiveInvWeapons();
                string src = GetSource(newitem);
                int type = GetType(player, newitem);
                player.Emit("addBack", newitem.Id, newitem.Description, type, place, src, back.Size, newitem.Amount, newitem.Mass, newitem.MaxAmount);
                player.Emit("UpdateSplitItemAmount", item.Amount, item.Mass);
                return;
            }
            else
            {
                int[] place = player.GetFreeInvPlace();
                if (place[0] != -1)
                {
                    Items.Items newitem = new Items.Items(item, amount);
                    item.Amount -= amount;
                    item.SaveItem();
                    player.PlaceItemInInv(place[0], newitem);
                    if (newitem.Munitype != -1) player.GiveInvWeapons();
                    string src = GetSource(newitem);
                    int type = GetType(player, newitem);
                    player.Emit("addInv", newitem.Id, newitem.Description, type, place[0], src, newitem.Amount, newitem.Mass, newitem.MaxAmount);
                    player.Emit("UpdateSplitItemAmount", item.Amount, item.Mass);
                    return;
                }
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }

        [ClientEvent("stackInvItem")]
        public static void ItemStack(MyPlayer.Player player, int id, int amount, int removeitem, bool ground, string endslot, string startslot)
        {
            if (!player.LoggedIn) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) { player.Emit("RemoveHudItem", id); return; }
            Items.Items? stackitem = ItemList.ItemsList.Find(x => x.Id == removeitem);
            if (stackitem == null) { player.Emit("RemoveHudItem", removeitem); return; }
            if (item == stackitem) return;
            if (ground)
            {
                GroundItems? g = GroundList.GroundServerList.Find(x => x.id == removeitem);
                if (g == null)
                {
                    player.SendChatMessage("Das Item liegt nicht mehr auf dem Boden");
                    player.Emit("RemoveHudItem", id);
                    return;
                }
                else
                {
                    if (player.Position.Distance(new Position(g.x, g.y, g.z)) > 3)
                    {
                        player.SendChatMessage("Du bist zu weit vom Item entfernt");
                        player.Emit("RemoveHudItem", id);
                        return;
                    }
                    GroundList.GroundServerList.Remove(g);
                    if (g.entity != null) AltEntitySync.RemoveEntity(g.entity);
                }
            }
            else player.RemoveItemFromInv(removeitem);
            item.Amount = amount;
            item.SaveItem();
            stackitem.Remove();
            if(item.Munitype != -1)player.GiveInvWeapons();
            float mass = item.Mass * stackitem.Amount;
            if (ground)
            {
                if(endslot.Contains("back"))
                {
                    player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("0.00"));
                    return;
                }
                if (endslot.Contains("inv"))
                {
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), "0");
                    return;
                }
                if (endslot.Contains("other"))
                {
                    player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), "0");
                    return;
                }
            }
            if (startslot.Contains("inv") && endslot.Contains("back"))
            {
                player.Emit("AddWeightBackpackAndPlayer", mass.ToString("-0.00"), mass.ToString("0.00"));
                return;
            }
            if (startslot.Contains("back") && endslot.Contains("inv"))
            {
                player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), mass.ToString("-0.00"));
                return;
            }
            if (startslot.Contains("other") && endslot.Contains("inv"))
            {
                player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), mass.ToString("0.00"));
                return;
            }
            if (endslot.Contains("other") && startslot.Contains("inv"))
            {
                player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), mass.ToString("-0.00"));
                return;
            }
            if (startslot.Contains("other") && endslot.Contains("back"))
            {
                player.Emit("AddWeightOtherAndBack", mass.ToString("-0.00"), mass.ToString("0.00"));
                return;
            }
            if (endslot.Contains("other") && startslot.Contains("back"))
            {
                player.Emit("AddWeightOtherAndBack", mass.ToString("0.00"), mass.ToString("-0.00"));
                return;
            }
        }
        [ClientEvent("itemmoveinv")]
        public static void Itemmoveinv(MyPlayer.Player player, int id, string start, string end, int backpack)
        {
            if (!player.LoggedIn) return;
            int e = GetIntFromString(end);
            if (e == -1) return;
            int d = GetIntFromString(start);
            if (d == -1) return;
            Items.Items? item = ItemList.ItemsList.Find(x => x.Id == id);
            if (item == null) {player.Emit("RemoveHudItem", id); return; }
            if (start.Contains("pop"))
            {
                if (d == 0) { player.ClearProps(0); player.Hat = -1; }
                if (d == 1) { player.ClearProps(1); player.Glasses = -1; }
                if (d == 2) { player.ClearProps(2); player.Ears = -1; }
                if (d == 3) { player.ClearProps(6); player.Watches = -1; player.DeleteSyncedMetaData("WearingWatch"); }
                if (d == 4) { player.ClearProps(7); player.Bracelet = -1; }
                if (end.Contains("inv"))
                {
                    player.Inv[e] = id;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), "0");
                    return;
                }
                else if (end.Contains("back"))
                {
                    Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                    if (itemBack != null)
                    {
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                        if (back != null)
                        {
                            back.Inv[e] = id;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("0.00"));
                            return;
                        }
                    }
                }
                else if (end.Contains("other"))
                {
                    int[] otherInv = new int[1];
                    if (player.GetOtherInv(ref otherInv))
                    {
                        otherInv[e] = id;
                        float mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), "0");
                        return;
                    }
                }
            }
            if (end.Contains("pop"))
            {
                Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                if (prop == null) return;
                if (e == 0) player.Hat = id;
                if (e == 1) player.Glasses = id;
                if (e == 2) player.Ears = id;
                if (e == 3)
                {
                    player.Watches = id;
                    player.SetSyncedMetaData("WearingWatch", 1);
                }
                if (e == 4) player.Bracelet = id;
                player.SetProps((byte)prop.componente, (ushort)prop.drawable, (byte)prop.texture);
                if (start.Contains("inv"))
                {
                    player.Inv[d] = -1;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("-0.00"), "0");
                    return;
                }
                else if (start.Contains("back"))
                {
                    Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                    if (itemBack != null)
                    {
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                        if (back != null)
                        {
                            back.Inv[d] = -1;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("-0.00"));
                            return;
                        }
                    }
                }
                else if (start.Contains("other"))
                {
                    int[] otherInv = new int[1];
                    if (player.GetOtherInv(ref otherInv))
                    {
                        otherInv[d] = -1;
                        float mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), "0");
                        return;
                    }
                }
            }

            if (start.Contains("cloth"))
            {
                if (d == 1) { player.SetClothes(1, 0, 0, 0); player.Mask = -1; }
                if (d == 2) { player.Top = -1; player.SetClothes(11, 15, 0, 0); player.SetClothes(3, 15, 0, 0); }
                if (d == 3) { player.Under = -1; player.SetClothes(8, 15, 0, 0); player.SetClothes(3, 15, 0, 0); }
                if (d == 4) { player.Legs = -1; player.SetClothes(4, 14, 0, 0); }
                if (d == 5) { player.Shoes = -1; if (player.Sex == 1) { player.SetClothes(6, 35, 0, 0); } else { player.SetClothes(6, 34, 0, 0); } }
                if (d == 6) { player.Acces = -1; player.SetClothes(7, 0, 0, 0); }
                if (end.Contains("inv"))
                {
                    player.Inv[e] = id;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), "0");
                    return;
                }
                else if (end.Contains("back"))
                {
                    Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                    if (itemBack != null)
                    {
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                        if (back != null)
                        {
                            back.Inv[e] = id;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("0.00"));
                            return;
                        }
                    }
                }
                else if (end.Contains("other"))
                {
                    int[] otherInv = new int[1];
                    if (player.GetOtherInv(ref otherInv))
                    {
                        otherInv[e] = id;
                        float mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), "0");
                        return;
                    }
                }
            }
            if (end.Contains("cloth"))
            {
                if (e == 1) player.Mask = id;
                if (e == 2) player.Top = id;
                if (e == 3) player.Under = id;
                if (e == 4) player.Legs = id;
                if (e == 5) player.Shoes = id;
                if (e == 6) player.Acces = id;
                Items.Cloth? cloth = ClothList.ClothServerList.Find(x=> x.id == item.Clothes);
                if (cloth == null) return;
                player.SetClothes((byte)cloth.componente, (ushort)cloth.drawable, (byte)cloth.texture, 0);
                if (start.Contains("inv"))
                {
                    player.Inv[d] = -1;
                    float mass = item.Mass * item.Amount;
                    player.Emit("AddWeightBackpackAndPlayer", mass.ToString("-0.00"), "0");
                    return;
                }
                else if (start.Contains("back"))
                {
                    Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                    if (itemBack != null)
                    {
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                        if (back != null)
                        {
                            back.Inv[d] = -1;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", "0", mass.ToString("-0.00"));
                            return;
                        }
                    }
                }
                else if (start.Contains("other"))
                {
                    int[] otherInv = new int[1];
                    if (player.GetOtherInv(ref otherInv))
                    {
                        otherInv[d] = -1;
                        float mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), "0");
                        return;
                    }
                }
            }

            if (end.Contains("inv") && start.Contains("inv"))
            {
                if (player.Inv[d] == id && (player.Inv[e] == 0 || player.Inv[e] == -1))
                {
                    player.Inv[e] = id;
                    player.Inv[d] = -1;
                    return;
                }
            }
            else if(end.Contains("other") && start.Contains("other"))
            {
                int[] otherInv = new int[1];
                if (player.GetOtherInv(ref otherInv))
                {
                    otherInv[d] = 0;
                    otherInv[e] = id;
                    return;
                }
            }
            else if (start.Contains("other") && end.Contains("inv"))
            {
                int[] otherInv = new int[1];
                if (player.GetOtherInv(ref otherInv))
                {
                    otherInv[d] = 0;
                    player.Inv[e] = id;
                    float mass = 0;
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null)
                    {
                        mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), mass.ToString("0.00"));
                    }
                    else
                    {
                        mass = back.GetBackpackMass();
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("-0.00"), "0");
                    }
                    player.GiveBackpack();
                    return;
                }
            }
            else if (end.Contains("other") && start.Contains("inv"))
            {
                int[] otherInv = new int[1];
                if (player.GetOtherInv(ref otherInv))
                {
                    otherInv[e] = id;
                    player.Inv[d] = 0;
                    float mass = 0;
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null)
                    {
                        mass = item.Mass * item.Amount;
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), mass.ToString("-0.00"));
                    }
                    else
                    {
                        mass = back.GetBackpackMass();
                        player.Emit("AddWeightOtherAndPlayer", mass.ToString("0.00"), "0");
                    }
                    player.GiveBackpack();
                    return;
                }
            }
            else if (end.Contains("back") || start.Contains("back"))
            {
                Items.Items? itemBack = ItemList.ItemsList.Find(x => x.Id == backpack);
                if (itemBack != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == itemBack.Backpack);
                    if (back != null)
                    {
                        if (end.Contains("back") && start.Contains("back"))
                        {
                            back.Inv[d] = 0;
                            back.Inv[e] = id;
                            return;
                        }
                        if (end.Contains("inv") && start.Contains("back"))
                        {
                            back.Inv[d] = 0;
                            player.Inv[e] = id;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", mass.ToString("0.00"), mass.ToString("-0.00"));
                            return;
                        }
                        if (end.Contains("back") && start.Contains("inv"))
                        {
                            back.Inv[e] = id;
                            player.Inv[d] = 0;
                            float mass = item.Mass * item.Amount;
                            player.Emit("AddWeightBackpackAndPlayer", mass.ToString("-0.00"), mass.ToString("0.00"));
                            return;
                        }
                        if (end.Contains("other") && start.Contains("back"))
                        {
                            int[] otherInv = new int[1];
                            if (player.GetOtherInv(ref otherInv))
                            {
                                otherInv[e] = id;
                                back.Inv[d] = 0;
                                float mass = 0;
                                player.Emit("AddWeightOtherAndBack", mass.ToString("0.00"), mass.ToString("-0.00"));
                                return;
                            }
                        }
                        if (start.Contains("other") && end.Contains("back"))
                        {
                            int[] otherInv = new int[1];
                            if (player.GetOtherInv(ref otherInv))
                            {
                                otherInv[d] = 0;
                                back.Inv[e] = id;
                                float mass = item.Mass * item.Amount;
                                player.Emit("AddWeightOtherAndBack", mass.ToString("-0.00"), mass.ToString("0.00"));
                                return;
                            }
                        }
                    }
                }
            }
            player.Notification(ServerEnums.Notify.Danger,"Inventar Fehler!");
            player.Emit("closeInventory");

        }
        public static int GetIntFromString(string a)
        {
            string b = string.Empty;
            int val = -1;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);
            return val;
        }

        public static string GetSource(Items.Items item)
        {
            string src = "images/error.png";
            switch(item.Serveritem)
            {
                case ServerEnums.Items.NewHouseKey:
                    return "images/housekey.png";
                case ServerEnums.Items.Cigarrets:
                    return "images/cigarrets.png";
                case ServerEnums.Items.Pizza:
                    return "images/pizza.png";
                case ServerEnums.Items.Hotdog:
                    return "images/hotdog.png";
                case ServerEnums.Items.Beer:
                    return "images/beer.png";
                case ServerEnums.Items.Energy:
                    return "images/energy.png";
                case ServerEnums.Items.Cafe:
                    return "images/cafe.png";
                case ServerEnums.Items.Houselock:
                    return "images/houseschloss.png";
                case ServerEnums.Items.Apple:
                    return "images/apple.png";
                case ServerEnums.Items.PatrolTank:
                    return "images/petroltank.png";
                case ServerEnums.Items.Toolbox:
                    return "images/toolbox.png";
                case ServerEnums.Items.FirstAid:
                    return "images/firstaid.png";
                case ServerEnums.Items.Lockpick:
                    return "images/lockpick.png";
                case ServerEnums.Items.Pickaxe:
                    return "images/pickaxe.png";
                case ServerEnums.Items.Kraken:
                    return "images/kraken.png";
                case ServerEnums.Items.Shark:
                    return "images/shark.png";
                case ServerEnums.Items.Dolphin:
                    return "images/dolphin.png";
                case ServerEnums.Items.TropicalFish:
                    return "images/tropicalfish.png";
                case ServerEnums.Items.KugelFish:
                    return "images/kugelfish.png";
                case ServerEnums.Items.Fish:
                    return "images/fish.png";
                case ServerEnums.Items.Wurm:
                    return "images/wurm.png";
                case ServerEnums.Items.Made:
                    return "images/maden.png";
                case ServerEnums.Items.Fishingrod:
                    return "images/fishingrod.png";
                case ServerEnums.Items.ProcessedMetall:
                    return "images/proceediron.png";
                case ServerEnums.Items.Metall:
                    return "images/iron.png";
                case ServerEnums.Items.ProcessedWood:
                    return "images/procwood.png";
                case ServerEnums.Items.Wood:
                    return "images/wood.png";
                case ServerEnums.Items.GPS:
                    return "images/gps.png";
                case ServerEnums.Items.Muni:
                    return "images/m" + item.Munitype + ".png";
                case ServerEnums.Items.Weapon:
                    return "images/p" + WeaponInfo.GetWeaponType(item.Weapons) + ".png";
                case ServerEnums.Items.Prop:
                    Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                    if (prop == null) return src;
                    //uint ped = prop.sex == 0 ? 1885233650 : 2627665880;
                    //src = "clothes/" + prop.componente + "_" + prop.drawable + "_" + prop.texture + "_" + ped + "_" + "1.png";
                    if (prop.componente == 0) src = "images/hat.png";
                    if (prop.componente == 1) src = "images/glasses.png";
                    if (prop.componente == 2) src = "images/ears.png";
                    if (prop.componente == 6) src = "images/watch.png";
                    if (prop.componente == 7) src = "images/bracelet.png";
                    return src;
                case ServerEnums.Items.Cloth:
                    Items.Cloth? cloth = ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                    if (cloth == null) return src;
                    //uint ped = cloth.sex == 0 ? 1885233650 : 2627665880;
                    //src = "clothes/" + cloth.componente+"_"+cloth.drawable+"_"+cloth.texture+"_"+ped+"_"+"0.png"; Server.Log(src);
                    if (cloth.componente == 1) src = "images/mask.png";
                    if (cloth.componente == 4) src = "images/hose.png";
                    if (cloth.componente == 6) src = "images/schuhe.png";
                    if (cloth.componente == 8) src = "images/under.png";
                    if (cloth.componente == 11) src = "images/top.png";
                    if (cloth.componente == 7) src = "images/acces.png";
                    return src;
                case ServerEnums.Items.Backpack:
                    Items.Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back == null) return src;
                    if (back.Size == 1) src = "images/backpack.png";
                    if (back.Size == 2) src = "images/backpack2.png";
                    return src;
                case ServerEnums.Items.VehicleKey:
                    return "images/vehkey.png";
                case ServerEnums.Items.NewVehicleKey:
                    return "images/vehkey.png";
                case ServerEnums.Items.AppartmentKey:
                    return "images/housekey.png";
                case ServerEnums.Items.Perso:
                    return "images/perso.png";
                case ServerEnums.Items.DrivingLicense:
                    return "images/drive.png";
                default:
                    return "images/error.png";
            }
        }
        public static int GetType(MyPlayer.Player player,Items.Items item)
        {
            switch(item.Serveritem)
            {
                case ServerEnums.Items.Backpack:
                    return 1;
                case ServerEnums.Items.VehicleKey:
                    return 2;
                case ServerEnums.Items.AppartmentKey:
                    return 3;
                case ServerEnums.Items.Cloth:
                    Items.Cloth? cloth = ClothList.ClothServerList.Find(x => x.id == item.Clothes);
                    if (cloth == null) return 0;//notfound
                    if (player.Sex != cloth.sex) return 0;
                    if (cloth.componente == 1) return 5; // mask
                    if (cloth.componente == 4) return 6;//hose
                    if (cloth.componente == 6) return 7;//schuhe
                    if (cloth.componente == 8) return 8;//under
                    if (cloth.componente == 11) return 9;//top
                    if (cloth.componente == 7) return 19;//acces
                    return 0;
                case ServerEnums.Items.Prop:
                    Props? prop = PropList.PropServerList.Find(x => x.id == item.Prop);
                    if (prop == null) return 0;//notfound
                    if (player.Sex != prop.sex) return 0;
                    if (prop.componente == 0) return 10; // hut
                    if (prop.componente == 1) return 11;//glasses
                    if (prop.componente == 2) return 12;//ears
                    if (prop.componente == 6) return 13;//watch
                    if (prop.componente == 7) return 14;//brac
                    return 0;
                case ServerEnums.Items.Weapon:
                    return 15;
                case ServerEnums.Items.Perso:
                    return 16;
                case ServerEnums.Items.DrivingLicense:
                    return 17;
                case ServerEnums.Items.GPS:
                    return 18;
                case ServerEnums.Items.Muni:
                    return 20 + item.Munitype;//mach bei 30 weiter
                case ServerEnums.Items.Wood:
                    return 30;
                case ServerEnums.Items.ProcessedWood:
                    return 31;
                case ServerEnums.Items.Metall:
                    return 32;
                case ServerEnums.Items.ProcessedMetall:
                    return 33;
                case ServerEnums.Items.Fishingrod:
                    return 33;
                case ServerEnums.Items.Wurm:
                    return 34;
                case ServerEnums.Items.Made:
                    return 35;
                case ServerEnums.Items.Apple:
                    return 36;
                case ServerEnums.Items.Beer:
                    return 37;
                case ServerEnums.Items.Energy:
                    return 38;
                case ServerEnums.Items.Cafe:
                    return 39;
                case ServerEnums.Items.Pickaxe:
                    return 40;
                case ServerEnums.Items.PatrolTank:
                    return 41;
                case ServerEnums.Items.NewHouseKey:
                    return 42;
                case ServerEnums.Items.Lockpick:
                    return 43;
                case ServerEnums.Items.Cigarrets:
                    return 44;
                case ServerEnums.Items.Pizza:
                    return 45;
                case ServerEnums.Items.Hotdog:
                    return 46;
                case ServerEnums.Items.Houselock:
                    return 47;
                case ServerEnums.Items.Toolbox:
                    return 48;
                case ServerEnums.Items.FirstAid:
                    return 49;
                case ServerEnums.Items.Fish:
                    return 50;
                case ServerEnums.Items.TropicalFish:
                    return 51;
                case ServerEnums.Items.KugelFish:
                    return 52;
                case ServerEnums.Items.NewVehicleKey:
                    return 53;
                default:
                    return 0;
            }
        }
        [ClientEvent("getGroundItems")]
        public static void GetGroundItems(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            foreach (GroundItems ground in GroundList.GroundServerList)
            {
                if (ground.dimension != player.Dimension) continue;
                if(player.Position.Distance(new Position(ground.x,ground.y,ground.z)) <= 4f)
                {
                    Items.Items? item = ItemList.ItemsList.Find(x => x.Id == ground.id);
                    if (item == null) continue;
                    string src = GetSource(item);
                    int type = GetType(player,item);
                    if (type == 1)
                    {
                        Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                        if (back == null) continue;
                        player.Emit("addGround", ground.id, item.Description, type, src, back.GetBackpackMass(), item.Mass, item.MaxAmount);
                    }
                    else player.Emit("addGround", ground.id, item.Description,type, src, item.Amount, item.Mass, item.MaxAmount);
                }
            }
        }

        [ClientEvent("RemovePlayerCLoth")]
        public static void RemovePlayerCLoth(MyPlayer.Player player, string s)
        {
            if (!player.LoggedIn) return;
            byte comp;
            if (!byte.TryParse(s, out comp)) return;
            switch(comp)
            {
                case 1:
                    player.SetClothes(1, 0, 0, 0);
                    break;
                case 4:
                    if (player.Sex == 0) player.SetClothes(4, 21, 0, 0);
                    else player.SetClothes(4, 62, 0, 0);
                    break;
                case 6:
                    if (player.Sex == 0) player.SetClothes(6, 34, 0, 0);
                    else player.SetClothes(6, 35, 0, 0);
                    break;
                case 8:
                    if (player.Sex == 0) player.SetClothes(8, 15, 0, 0);
                    else player.SetClothes(8, 15, 0, 0);
                    break;
                case 11:
                    player.SetClothes(3, 15, 0, 0);
                    if (player.Sex == 0) player.SetClothes(11, 15, 0, 0);
                    else player.SetClothes(11, 15, 0, 0);
                    break;
            }
        }
    }
}
