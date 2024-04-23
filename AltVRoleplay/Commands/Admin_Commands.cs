using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Client;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.Items;
using AltVRoleplay.MyVehicle;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.LTD_Gas.Class;
using AltVRoleplay.SQL.Store.Class;
using System.Text;
using Alt = AltV.Net.Alt;

namespace AltVRoleplay
{
    public class Admin_Commands : IScript
    {
        [Command("cam")]
        public static void CMD_FREECAM(MyPlayer.Player player)
        {
            Alt.Emit("freecam:Toggle", player);
        }
        [Command("delvehdb")]
        public static void CMD_DelVeh(MyPlayer.Player player)
        {
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            veh.RemoveFromGame();
            //livery =2 => Medic palmov
        }
        [Command("liferty")]
        public static void CMD_lifTuning(MyPlayer.Player player, byte cat, byte id)
        {
            if (!player.IsInVehicle) return;
            IVehicle veh = player.Vehicle;
            if (cat == 1) veh.Livery = id;
            else veh.RoofLivery = id;
            //livery =2 => Medic palmov
        }
        [Command("scolor")]
        public static void CMD_SColor(MyPlayer.Player player, byte r, byte g, byte b)
        {
            if (!player.IsInVehicle) return;
            IVehicle veh = player.Vehicle;
            veh.ModKit = 1;
            veh.SecondaryColorRgb = new Rgba(r, g, b, 255);
        }
        [Command("wheel")]
        public static void CMD_Wheel(MyPlayer.Player player, byte type, byte id)
        {
            if (!player.IsInVehicle) return;
            IVehicle veh = player.Vehicle;
            //veh.ModKit = 1;
            veh.SetWheels(type, id);
        }
        [Command("tuning")]
        public static void CMD_Tuning(MyPlayer.Player player, byte cat, byte id)
        {
            if (!player.IsInVehicle) return;
            IVehicle veh = player.Vehicle;
            //veh.ModKit = 1;
            veh.SetMod(cat, id);
        }
        [Command("speed")]
        public static void CMD_Mods(MyPlayer.Player player, int x)
        {
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            //veh.ModKit = 1;
            veh.SetChipSpeed(x);
            Server.Log(""+veh.DoesWheelHasTire(0) +""+ veh.DoesWheelHasTire(1) + "" + veh.DoesWheelHasTire(2) + "" + veh.DoesWheelHasTire(3));
        }
        [Command("veh")]
        public static void CMD_Car(MyPlayer.Player player, string vehicleName, byte r=0, byte g=0, byte b=0, int database = 0)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle(vehicleName, new Position(player.Position.X, player.Position.Y, player.Position.Z + 1.0f), player.Rotation);
            if (veh == null)
            {
                player.SendChatMessage("{FF0000}Das Fahrzeug konnte nicht erstellt werden!");
                return;
            }
            veh.VehName = vehicleName;
            player.SendChatMessage("Das Fahrzeug " + vehicleName + " wurde erfolgrich gespawnnt!");
            veh.PrimaryColorRgb = new Rgba(r, g, b, 0);

            player.SetIntoVehicle(veh, 1);
            veh.SetRange(0);
            veh.VehName = vehicleName.ToLower();
            veh.EngineOn = true;
            if (database==1)
            {
                veh.Dbid = Database.CreateVehicle(veh);
                player.SendChatMessage("Und in der Datenbank eingetragen");
                veh.NumberplateText = "LS" + veh.Dbid;
                VehList.AddDbVehicle(veh);
                return;
            }
            veh.NumberplateText = "Admin";
            return;
        }
        [Command("gps")]
        public static void CMD_BACKPACK(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                item.CreateItem(ServerEnums.Items.GPS);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir ein Gps gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("createbackpack")]
        public static void CMD_BACKPACK(MyPlayer.Player player, int size)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            Backpack b = new Backpack(size);

            int itemid = b.CreateBackpack();
            GroundItems ground = new GroundItems();
            ground.x = player.Position.X;
            ground.y = player.Position.Y;
            ground.z = player.Position.Z;
            ground.id = itemid;
            ground.CreateGroundItem();
        }
        [Command("givevehkey")]
        public static void CMD_ADUTY(MyPlayer.Player player, int key)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            { 
                MyVehicle.MyVehicle? veh = VehList.VehicleServerList.Find(x => x.Dbid == key);
                if (veh == null) { player.SendChatMessage("Fahrzeug mit der Id nicht gefuden"); return; }
                Items.Items item = new();
                item.CreateVehicleKey(veh);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir ein Fahrzeugschlüssel gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("freezeme")]
        public static void CMD_Freezeme(MyPlayer.Player player, bool freeze=true)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.Emit("freezeMe", freeze);
            player.SendChatMessage("Du hast dich gefreezt");
        }
        [Command("deleteappartment")]
        public static void CMD_DeleteAppartment(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            Appartment? a = player.GetClosestAppartment();
            if (a != null) a.DeleteAppartment();
        }
        [Command("createltdped")]
        public static void CMD_CreateLTDPed(MyPlayer.Player player, int id, float r)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            LTDGasStation? store = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == id);
            if (store == null) return;
            if (player.Position.Distance(store.GetPosition()) > 50)
            {
                player.Notification(ServerEnums.Notify.Danger, "Der Laden ist zu weit weg!");
                return;
            }
            SQL.LTD_Gas.LTDSQL.CreateStorePed_LTD(store, player.Position.X, player.Position.Y, player.Position.Z, r);
        }
        [Command("createltd")]
        public static void CMD_CreateLTD(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            LTDGasStation store = new LTDGasStation(player.Position.X, player.Position.Y, player.Position.Z);
            store.Create();
        }
        [Command("create247ped")]
        public static void CMD_CreateStore(MyPlayer.Player player, int id, float r)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            Store_247? store = SQL.Store.StoreList.Store247ServerList.Find(x => x.Id == id);
            if (store == null) return;
            if(player.Position.Distance(store.GetPosition()) > 50)
            {
                player.Notification(ServerEnums.Notify.Danger, "Der Laden ist zu weit weg!");
                return;
            }
            SQL.Store.StoreSql.CreateStorePed_247(store,player.Position.X,player.Position.Y,player.Position.Z, r);
        }
        [Command("create247")]
        public static void CMD_CreateStore(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            Store_247 store = new Store_247(player.Position.X, player.Position.Y, player.Position.Z);
            store.Create();
        }
        [Command("createfirma")]
        public static void CMD_CreateFirma(MyPlayer.Player player, int type)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            Firma firma = new Firma(player.Position.X, player.Position.Y, player.Position.Z);
            firma.FirmenType = type;
            firma.Create();
        }
        [Command("createapartment")]
        public static void CMD_CreateApartment(MyPlayer.Player player, int interrior, int rent, string name)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (player.Dimension != 0) return;
            name = name.Replace("_"," ");
            player.Emit("CreateAppartment", player.Position, interrior, rent, name);
        }
        [Command("giveperso")]
        public static void CMD_CreatePerso(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Perso p = new Perso(player.Fname, player.Lname, "Adress", player.Age, player.Height, player.EyeColor, player.SocialClubId);
                p.id = Database.CreatePerso(p);
                p.CreatePerso();
                Items.Items item = new Items.Items();
                item.CreatePerso(player, p);
                if (place[0] != -1)player.PlaceItemInInv(place[0], item);
                else if(place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Perso erstellt");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("weather")]
        public static void CMD_WEATHER(MyPlayer.Player player, int wid, float time)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.Emit("setWeather", wid, time);
            player.SendChatMessage("wetter: "+wid);
        }
        [Command("aduty")]
        public static void CMD_Aduty(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if(player.HasSyncedMetaData("Aduty"))
            {
                player.DeleteSyncedMetaData("Aduty");
                return;
            }
            player.SetSyncedMetaData("Aduty",1);
        }
        [Command("time")]
        public static void CMD_TIME(MyPlayer.Player player, byte time)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            Server.serverDate = Server.serverDate.AddHours(time);
            Server.SyncWorldTime();
        }
        [Command("givemoney")]
        public static void CMD_TIME(MyPlayer.Player player, long amount)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.GiveMoney(amount);
        }
        [Command("port")]
        public static void CMDPORT(MyPlayer.Player player, int x=0, int y=0,int z=0)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.Position = new Position(player.Position.X+x,player.Position.Y+y,player.Position.Z+z);
        }
        [Command("gotoveh")]
        public static void CMD_GOTO(MyPlayer.Player player, int id)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (id >= Alt.GetAllVehicles().Count) return; 
            IVehicle veh = Alt.GetAllVehicles().ElementAt(id);
            player.Position = veh.Position;
            player.Dimension = veh.Dimension;
        }

        [Command("gotowaypoint")]
        public static void CMD_GOTO(MyPlayer.Player player)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.Emit("triggerTP");
        }
        [Command("maxspeed")]
        public static void CMDMAXSPEED(MyPlayer.Player player, int speed)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (!player.IsInVehicle) return;
            // 10 = 35 kmh => 20 = 70km/h
            player.Vehicle.ScriptMaxSpeed = speed;
        }
        [Command("vehdmg")]
        public static void CMDVEHDMG(MyPlayer.Player player, int dmg)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            if (!player.IsInVehicle) return;
            player.Vehicle.EngineHealth = dmg;
            player.Vehicle.BodyHealth = (uint)dmg;
        }
        [Command("goto")]
        public static void CMD_GOTO(MyPlayer.Player player, float x, float y, float z)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.SetPosition(x, y, z+0.1f);
        }
        [Command("getkey")]
        public static void CMD_FactionVeh(MyPlayer.Player player)
        {
            if (!player.IsInVehicle) return;
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                MyVehicle.MyVehicle? veh = VehList.VehicleServerList.Find(x => x.Id == player.Vehicle.Id);
                if (veh == null) { player.SendChatMessage("Fahrzeug nicht gefunden"); return; }
                if (veh.Dbid == -1) return;
                if (veh.FactionId != player.Faction || player.Faction_Rank != 999) return;
                Items.Items item = new();
                item.CreateVehicleKey(veh);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir ein Fahrzeugschlüssel gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("setfactionveh")]
        public static void CMD_FactionVeh(MyPlayer.Player player, int id)
        {
            if (!player.IsInVehicle) return;
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)player.Vehicle;
            if (veh.Dbid == -1) return;
            veh.FactionId = id;
            veh.OwnerName = "Fraktion";
            veh.Save();
        }
        [Command("faction")]
        public static void CMD_Faction(MyPlayer.Player player, int id)
        {
            player.Faction = id;
            player.Faction_Rank = 999;
        }
        [Command("setgmbh")]
        public static void CMD_GMBH(MyPlayer.Player player, int id)
        {
            player.Firma = id;
            player.Firma_Rank = ServerEnums.FirmenRanks.Owner;

        }
        [Command("made")]
        public static void cmd_made(MyPlayer.Player player)
        {
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                item.CreateItem(ServerEnums.Items.Made, 5);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir eine Angel gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("wurm")]
        public static void CMD_WURM(MyPlayer.Player player)
        {
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                item.CreateItem(ServerEnums.Items.Wurm, 5);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir eine Angel gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }

        [Command("angel")]
        public static void CMD_ITEM(MyPlayer.Player player)
        {
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new();
                item.CreateItem(ServerEnums.Items.Fishingrod);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.SendChatMessage("Du hast dir eine Angel gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("open")]
        public static void CMD_OPEN(MyPlayer.Player player)
        {
            MyVehicle.MyVehicle? veh = player.GetClosestVehicle();
            if (veh == null) return;
            veh.LockState = VehicleLockState.Unlocked;
        }
        [Command("fishing")]
        public static void CMD_FISHing(MyPlayer.Player player, int type)
        {
            player.Emit("StartFishing", 4, type, 100);
        }
        [Command("kraft")]
        public static void CMD_KRAFT(MyPlayer.Player player, int level)
        {
            player.KraftLevel = level;
        }
        [Command("animation")]
        public static void CMD_ANIM(MyPlayer.Player player, string dic, string name, float x, float y, int time, int flag, float b)
        {
            player.PlayAnimation(dic, name, x, y, time, flag, b, true, true, true);
        }
        [Command("object")]
        public static void CMD_TestObj(MyPlayer.Player player, string name, float x, float y, float z, float r, float p, float yaw)
        {
            /*x = player.Position.X + x;
            y = player.Position.Y + y;
            z = player.Position.Z + z;*/
            IObject obj = Alt.CreateObject(Alt.Hash(name), player.Position, player.Rotation);
            IVehicle trailer = Alt.CreateVehicle("armytrailer", player.Position, player.Rotation);
            obj.AttachToEntity(trailer, 0, 0, new Position(x, y, z), new Rotation(r, p, yaw), true,false);
        }
        [Command("pedmodel")]
        public static void CMD_PEDMODEL(MyPlayer.Player player, string name)
        {
            //player.Model = Alt.Hash(name);
            IPed d =Alt.CreatePed("a_c_dolphin", player.Position, player.Rotation);
        }
        [Command("test")]
        public static void CMD_Test(MyPlayer.Player player, string prop)
        {
            
        }
        [Command("attachplayer")]
        public static void CMD_APlayer(MyPlayer.Player player,string name,ushort bone, float x, float y, float z , float r, float p, float ya)
        {
            if(player.HasData("attachedObj"))
            {
                player.GetData("attachedObj", out IObject oba);
                oba.Destroy();
            }
            IObject ob = Alt.CreateObject(name, player.Position, new Rotation(0, 0, 0));
            ob.SetNetworkOwner(player);
            ob.AttachToEntity(player, bone, 0, new Position(x,y,z), new Rotation(r,p,ya), false, false);
            //Pickaxt /test prop_tool_pickaxe 0,1 -0,3 -0,21 -1 0 0
            player.SetData("attachedObj",ob);
        }
        [Command("vehattach")]
        public static void CMD_attach(MyPlayer.Player player, ushort bone , float x,float y, float z, float r, float p, float ya)
        {
            if (!player.IsInVehicle) return;
            IVehicle trailer = Alt.CreateVehicle("boattrailer",player.Position, player.Rotation);
            player.SetPosition(player.Position.X,player.Position.Y+2,player.Position.Z);
            IVehicle veh = player.Vehicle;
            veh.AttachToEntity(trailer, bone, 0, new Position(x, y, z), new Rotation(r, p, ya), true, false);
            //vehattach 0 0 -2 0,5 0 0 0 JEtmax
            //vehattach 0 0 -2 0,5 0 0 0 speeder
            //vehattach 0 0 -1 0,3 0 0 0 dinghy
            //vehattach 0 0 -1 0,5 0 0 0 tropic
            //vehattach 0 0 -0,3 0,5 0 0 0 suntrap
        }
        [Command("setcloth")]
        public static void CMD_DTest(MyPlayer.Player player, byte index, ushort id, byte text)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.SetClothes(index, id, text, 0);
        }

        [Command("cloth")]
        public static void CMD_Test(MyPlayer.Player player, byte index, ushort id, byte text, int sex)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            { 
                Items.Cloth cloth = new Items.Cloth(index, id, text, sex);
                int itemid = cloth.CreateCloth();
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == itemid);
                if (item == null) return;
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], itemid);
                    }
                }
                player.SendChatMessage("Du hast dir ein Kleidungsstück gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
            player.SendChatMessage("Testcommand");
        }
        [Command("prop")]
        public static void CMD_PROP(MyPlayer.Player player, byte index, ushort id, byte text, int sex)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Props cloth = new Props(index, id, text, sex);
                int itemid = cloth.CreateProp();
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == itemid);
                if (item == null) return;
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], itemid);
                    }
                }
                player.SendChatMessage("Du hast dir ein Kleidungsstück gegeben");
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("giveweapon")]
        public static void CMD_WEAPON(MyPlayer.Player player, string name)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            player.GiveWeapon(Alt.Hash(name),200,true);
        }
        [Command("weapon")]
        public static void CMD_WEAPON(MyPlayer.Player player, int weapon)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            { 
                Items.Items item = new Items.Items();
                item.CreateWepon((ServerEnums.Weapons)weapon);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.GiveInvWeapons();
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }
        [Command("muni")]
        public static void CMD_MUNI(MyPlayer.Player player,int munitype)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Moderator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            int[] place = player.GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new Items.Items();
                item.CreateMuni((ServerEnums.Muni)munitype);
                if (place[0] != -1) player.PlaceItemInInv(place[0], item);
                else if (place[1] != -1)
                {
                    Backpack? back = player.GetPlayerBackPack();
                    if (back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                player.GiveInvWeapons();
                return;
            }
            player.SendChatMessage("Du hast kein Platz im Inventar");
        }

        [Command("savepos")]
        public static void CMD_SavePosition(MyPlayer.Player player, string msg)
        {
            if (!player.IsSplielerAdmin((int)MyPlayer.Player.AdminRanks.Administrator))
            {
                player.SendChatMessage(Message.notAdmin);
                return;
            }
            string path = @"Z:\AltV Server\savedpostion.txt";
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle v = player.Vehicle;
                        string str = "new Position(" + v.Position.X + "f? " + v.Position.Y + "f? " + v.Position.Z + "f)? new Rotation(" + v.Rotation.Roll + "f?"+v.Rotation.Pitch+"f?"+v.Rotation.Yaw+"f) || " + msg;
                        str = str.Replace(',', '.');
                        str = str.Replace('?', ',');
                        sw.WriteLine(str);
                    }
                    else
                    {
                        string str = "new Position(" + player.Position.X + "f? " + player.Position.Y + "f? " + player.Position.Z + "f)? new Rotation(" + player.Rotation.Roll + "f?" + player.Rotation.Pitch + "f?" + player.Rotation.Yaw + "f) || " + msg;
                        //string str = "Gravels.Add(new Gravel(" + player.Position.X + "f? " + player.Position.Y + "f? " + player.Position.Z + "f));";
                        str = str.Replace(',', '.');
                        str = str.Replace('?', ',');
                        sw.WriteLine(str);
                    }
                }
            }
            else
            {
                try
                {
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("Postion\n");// lässt oben als Info Palyer stehen
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception e)
                {
                    Server.Log("The deletion failed: "+ e.Message);
                }
            }

        }
    }
}