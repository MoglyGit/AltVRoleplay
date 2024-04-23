using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltVRoleplay.SQL;
using AltVRoleplay.Events.CreatePed;
using MySql.Data.MySqlClient;
using AltVRoleplay.Items;
using AltVRoleplay.MyVehicle;
using AltVRoleplay.Appartments;
using AltVRoleplay.JS_Objects;
using AltVRoleplay.Bank;
using AltVRoleplay.SQL.Friends;
using AltVRoleplay.Events.Shop247;
using AltVRoleplay.Voice;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.MyPlayer;
using AltVRoleplay.Events.LTDGas;

namespace AltVRoleplay
{
    class Database : Server
    {
        private static readonly string server;
        private static readonly string database;
        private static readonly string uid;
        private static readonly string password;
        public readonly static string connectionString;

        static Database()
        {
            string path = @"";//path festlegen bsp: @"C:\AltV Server\sqlconnection.txt"
            if (!File.Exists(path))
            {
                Server.Log("Keine sqlconnection.txt gefunden");
                Thread.Sleep(2000);
                Environment.Exit(0);
                return;
            }
            string[] readText = File.ReadAllLines(path);
            server = readText[0];
            uid = readText[1];
            password = readText[2];
            database = readText[3];
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            Initialize();
        }
        private static void Initialize()
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Server.Log("Keine Verbindung zur Datenbank!");
                        break;

                    case 1045:
                        Server.Log("Falscher Username/Password!");
                        break;
                }
                Thread.Sleep(2000);
                Environment.Exit(0);
                return;
            }
            Server.Log("MYSQL Verbindung wurde aufgebaut.");
            connection.Close();
            connection.Dispose();
        }

        //vehicles
        public static void DeleteVehicle(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM vehicles WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM vehicleWheels WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM vehicleWheelsHealth WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM vehicleWheelsHealth WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.ExecuteNonQuery();

                VehList.RemoveVehicle(veh);
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item erstellen: " + e.ToString());
            }
        }
        public static int CreateVehicle(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO vehicles (vehicleName, x, y, z, r_roll, r_pitch, r_yaw, vehlock, color_r, color_g, color_b, color_r2, color_g2, color_b2, fill, price, plate, ownersocialclub, ownername, engineon, maxspeed, factionid) VALUES (@vehName, @x, @y, @z, @r_r, @r_p, @r_y, @l, @cr, @cg, @cb, @cr2, @cg2, @cb2, @fill, @price, @plate, @os, @on,0,@maxSpeed ,@fid)";

                cmd.Parameters.AddWithValue("@vehName", veh.VehName);
                cmd.Parameters.AddWithValue("@x", veh.Position.X);
                cmd.Parameters.AddWithValue("@y", veh.Position.Y);
                cmd.Parameters.AddWithValue("@z", veh.Position.Z);
                cmd.Parameters.AddWithValue("@r_r", veh.Rotation.Roll);
                cmd.Parameters.AddWithValue("@r_p", veh.Rotation.Pitch);
                cmd.Parameters.AddWithValue("@r_y", veh.Rotation.Yaw);
                cmd.Parameters.AddWithValue("@l", 2);
                cmd.Parameters.AddWithValue("@price", veh.Price);
                cmd.Parameters.AddWithValue("@plate", veh.NumberplateText);
                cmd.Parameters.AddWithValue("@os", veh.OwnerSocialclubId);
                cmd.Parameters.AddWithValue("@on", veh.OwnerName);

                cmd.Parameters.AddWithValue("@cr", veh.PrimaryColorRgb.R);
                cmd.Parameters.AddWithValue("@cg", veh.PrimaryColorRgb.G);
                cmd.Parameters.AddWithValue("@cb", veh.PrimaryColorRgb.B);
                cmd.Parameters.AddWithValue("@cr2", veh.SecondaryColorRgb.R);
                cmd.Parameters.AddWithValue("@cg2", veh.SecondaryColorRgb.G);
                cmd.Parameters.AddWithValue("@cb2", veh.SecondaryColorRgb.B);

                cmd.Parameters.AddWithValue("@fill", veh.FillMax);
                cmd.Parameters.AddWithValue("@maxSpeed", veh.ScriptMaxSpeed);
                cmd.Parameters.AddWithValue("@fid", veh.FactionId);

                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Fahrzeug erstellen: " + e.ToString());
                return -1;
            }
        }

        public static void SaveVehicle(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE vehicles SET x=@x, y=@y, z=@z, r_yaw=@r_yaw,r_roll=@r_roll, r_pitch=@r_pitch, vehlock=@l, color_r=@cr, color_g=@cg, color_b=@cb, color_r2=@cr2, color_g2=@cg2, color_b2=@cb2, fill=@fill, plate=@plate, engineon=@engine, rangestand=@range, lockstate=@lock, factionid=@fid, ownername=@oname," +
                    "death=@death, motordamage=@motordamage, enginehealth=@enginehealth, bodyhealth=@bodyhealth, anchoractive=@anchor, tuev=@tuev, " +
                    "noscharges=@nosc, chip=@chip WHERE id=@id";
                cmd.Parameters.AddWithValue("@death", veh.Death);
                cmd.Parameters.AddWithValue("@motordamage", veh.MotorDamage);
                cmd.Parameters.AddWithValue("@enginehealth", veh.EngineHealth);
                cmd.Parameters.AddWithValue("@bodyhealth", veh.BodyHealth);

                cmd.Parameters.AddWithValue("@x", veh.Position.X);
                cmd.Parameters.AddWithValue("@y", veh.Position.Y);
                cmd.Parameters.AddWithValue("@z", veh.Position.Z);
                cmd.Parameters.AddWithValue("@r_yaw", veh.Rotation.Yaw);
                cmd.Parameters.AddWithValue("@r_roll", veh.Rotation.Roll);
                cmd.Parameters.AddWithValue("@r_pitch", veh.Rotation.Pitch);
                cmd.Parameters.AddWithValue("@l", veh.LockState);

                cmd.Parameters.AddWithValue("@cr", veh.PrimaryColorRgb.R);
                cmd.Parameters.AddWithValue("@cg", veh.PrimaryColorRgb.G);
                cmd.Parameters.AddWithValue("@cb", veh.PrimaryColorRgb.B);
                cmd.Parameters.AddWithValue("@cr2", veh.SecondaryColorRgb.R);
                cmd.Parameters.AddWithValue("@cg2", veh.SecondaryColorRgb.G);
                cmd.Parameters.AddWithValue("@cb2", veh.SecondaryColorRgb.B);

                cmd.Parameters.AddWithValue("@engine",veh.EngineOn ? 1 : 0);

                cmd.Parameters.AddWithValue("@fill", veh.GetFill());
                cmd.Parameters.AddWithValue("@range", veh.Range);
                cmd.Parameters.AddWithValue("@plate", veh.NumberplateText);
                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.Parameters.AddWithValue("@lock", (int)veh.LockState);
                cmd.Parameters.AddWithValue("@fid", veh.FactionId);
                cmd.Parameters.AddWithValue("@oname", veh.OwnerName);
                cmd.Parameters.AddWithValue("@tuev", veh.Tuev);
                cmd.Parameters.AddWithValue("@anchor", veh.HasSyncedMetaData("BoatAnchor") ? 1 : 0);
                cmd.Parameters.AddWithValue("@nosc", veh.NosCharges);
                int speed = 0;
                if(veh.HasSyncedMetaData("SpeedBoost"))
                {
                    veh.GetSyncedMetaData("SpeedBoost", out int x);
                    speed = x;
                }
                cmd.Parameters.AddWithValue("@chip", speed);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                SQL.Inventory.VehInvSql.SaveVehInv(veh);
                SQL.Inventory.VehInvSql.SaveVehFrontInv(veh);
                SQL.Tuning.VehicleMods.SaveVehicleMods(veh);
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Vehicle Speichern: " + e.ToString());
            }
        }
        public static void LoadVehicles()
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM vehicles";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        float[] posistion = new float[6];
                        string vehName = "";
                        posistion[0] = reader.GetFloat("x");
                        posistion[1] = reader.GetFloat("y");
                        posistion[2] = reader.GetFloat("z");
                        posistion[3] = reader.GetFloat("r_roll");
                        posistion[4] = reader.GetFloat("r_pitch");
                        posistion[5] = reader.GetFloat("r_yaw");
                        vehName = reader.GetString("vehicleName");
                        MyVehicle.MyVehicle? veh = ServerMethods.CreateVehicle(vehName, new Position(posistion[0], posistion[1], posistion[2]), new Rotation(posistion[3], posistion[4], posistion[5]));
                        if (veh == null) return;
                        veh.OwnerSocialclubId = (ulong)reader.GetInt64("ownersocialclub");
                        veh.OwnerName = reader.GetString("ownername");
                        veh.Price = veh.Dbid = reader.GetInt32("price");
                        veh.Lock((VehicleLockState)reader.GetInt16("vehlock"));
                        veh.VehName = vehName;
                        veh.PrimaryColorRgb = new Rgba((byte)reader.GetInt32("color_r"), (byte)reader.GetInt32("color_g"), (byte)reader.GetInt32("color_b"), 0);
                        veh.SecondaryColorRgb = new Rgba((byte)reader.GetInt32("color_r2"), (byte)reader.GetInt32("color_g2"), (byte)reader.GetInt32("color_b2"), 0);
                        veh.NumberplateText = reader.GetString("plate");
                        veh.SetRange(reader.GetInt32("rangestand"));
                        veh.SetFill(reader.GetFloat("fill"));
                        veh.Dbid = reader.GetInt32("id");
                        veh.EngineOn = reader.GetInt32("engineon") == 1;
                        veh.FactionId = reader.GetInt32("factionid");
                        veh.Lock((VehicleLockState)reader.GetByte("lockstate"));
                        veh.ScriptMaxSpeed = reader.GetInt32("maxspeed");
                        veh.BodyHealth = (uint)reader.GetInt32("bodyhealth");
                        veh.EngineHealth = reader.GetInt32("enginehealth");
                        veh.NosCharges = reader.GetInt32("noscharges");
                        veh.SetNosCharges(veh.NosCharges);
                        veh.Death = reader.GetBoolean("death");
                        veh.MotorDamage = reader.GetBoolean("motordamage");
                        veh.Tuev = reader.GetDateTime("tuev");
                        if (reader.GetBoolean("anchoractive")) veh.SetSyncedMetaData("BoatAnchor", 1);
                        veh.SetChipSpeed(reader.GetInt32("chip"));
                        SQL.Inventory.VehInvSql.LoadVehInv(veh);
                        SQL.Inventory.VehInvSql.LoadVehFrontInv(veh);
                        SQL.Tuning.VehicleMods.LoadVehicleMods(veh);
                        VehList.AddDbVehicle(veh);                       
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Fahrzeug Laden: " + e.ToString());
            }
        }
        //farms
        //Items
        public static int CreateItem(Items.Items item)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO items (businesskey, vehkey, weapons, housekeys, backpack, clothes, prop, amount, description, munitype, objhash, perso, drivinglicense, serveritem, mass, maxamount) " +
                    "VALUES (@bussinesskey, @vehkey, @weapons, @housekey, @backpack, @clothes,@prop, @amount, @des, @muni, @objhash, @perso, @driv, @serveritem, @mass, @maxamount)";

                cmd.Parameters.AddWithValue("@bussinesskey", item.Businesskey);
                cmd.Parameters.AddWithValue("@vehkey", item.Vehkey);
                cmd.Parameters.AddWithValue("@weapons", item.Weapons);
                cmd.Parameters.AddWithValue("@housekey", item.Housekey);
                cmd.Parameters.AddWithValue("@backpack", item.Backpack);
                cmd.Parameters.AddWithValue("@clothes", item.Clothes);
                cmd.Parameters.AddWithValue("@prop", item.Prop);
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@des", item.Description);
                cmd.Parameters.AddWithValue("@muni", item.Munitype);
                cmd.Parameters.AddWithValue("@objhash", item.Objhash);
                cmd.Parameters.AddWithValue("@perso", item.Perso);
                cmd.Parameters.AddWithValue("@driv", item.Drivinglicense);
                cmd.Parameters.AddWithValue("@serveritem", item.Serveritem);
                cmd.Parameters.AddWithValue("@mass", item.Mass);
                cmd.Parameters.AddWithValue("@maxamount", item.MaxAmount);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item erstellen: " + e.ToString());
                return -1;
            }
        }
        public static void DeleteItem(Items.Items item)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM items WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
                    
                Items.ItemList.ItemsList.Remove(item);
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item erstellen: " + e.ToString());
            }
        }
        public static void SaveItem(Items.Items item)
        {
            if(item.Amount <= 0)
            {
                item.Remove();
                return;
            }
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE items SET amount=@amount,mass=@mass,serveritem=@serveritem, description=@des WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@mass", item.Mass);
                cmd.Parameters.AddWithValue("@serveritem", item.Serveritem);
                cmd.Parameters.AddWithValue("@des", item.Description);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item erstellen: " + e.ToString());
            }
        }
        public static void SaveServerTime()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE server SET  Year=@y, Month=@m, Day=@d, Hour=@h, Minute=@mi, Second=@s WHERE id=0";

                cmd.Parameters.AddWithValue("@y", Server.serverDate.Year);
                cmd.Parameters.AddWithValue("@m", Server.serverDate.Month);
                cmd.Parameters.AddWithValue("@d", Server.serverDate.Day);
                cmd.Parameters.AddWithValue("@h", Server.serverDate.Hour);
                cmd.Parameters.AddWithValue("@mi", Server.serverDate.Minute);
                cmd.Parameters.AddWithValue("@s", Server.serverDate.Second);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Server zeit speichern: " + e.ToString());
            }
        }

        public static void LoadServerTime()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM server";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        serverDate = new DateTime(reader.GetInt32("Year"), reader.GetInt32("Month"), reader.GetInt32("Day"), reader.GetInt32("Hour"), reader.GetInt32("Minute"), reader.GetInt32("Second"));
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item Laden: " + e.ToString());
            }
        }

        public static void LoadItems()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM items";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Items.Items item = new Items.Items
                        {
                            Id = reader.GetInt32("id"),
                            Housekey = reader.GetInt32("housekeys"),
                            Businesskey = reader.GetInt32("businesskey"),
                            Vehkey = reader.GetInt32("vehkey"),
                            Weapons = reader.GetString("weapons"),
                            Backpack = reader.GetInt32("backpack"),
                            Clothes = reader.GetInt32("clothes"),
                            Prop = reader.GetInt32("prop"),
                            Amount = reader.GetInt32("amount"),
                            Objhash = reader.GetInt32("objhash"),
                            Munitype = reader.GetInt32("munitype"),
                            Perso = reader.GetInt32("perso"),
                            Drivinglicense = reader.GetInt32("drivinglicense"),
                            Description = reader.GetString("description"),
                            Serveritem = (ServerEnums.Items)reader.GetInt32("serveritem"),
                            Mass = reader.GetFloat("mass"),
                            MaxAmount = reader.GetInt32("maxamount")
                        };
                        ItemList.AddItem(item);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Item Laden: " + e.ToString());
            }
        }
        public static void LoadProps()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM props";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Props item = new Props(reader.GetInt32("componente"), reader.GetInt32("drawable"), reader.GetInt32("texture"), reader.GetInt32("sex"));
                        item.id = reader.GetInt32("id");
                        PropList.AddItem(item);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Props Laden: " + e.ToString());
            }
        }
        public static int CreateProp(Props prop)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO props (componente, drawable, texture, sex) " +
                        "VALUES (@comp, @draw, @text, @sex)";

                cmd.Parameters.AddWithValue("@comp", prop.componente);
                cmd.Parameters.AddWithValue("@draw", prop.drawable);
                cmd.Parameters.AddWithValue("@text", prop.texture);
                cmd.Parameters.AddWithValue("@sex", prop.sex);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim backpack erstellen: " + e.ToString());
                return -1;
            }
        }

        public static void LoadClothes()
        {
            try 
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM clothes";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Items.Cloth item = new Items.Cloth(reader.GetInt32("componente"), reader.GetInt32("drawable"), reader.GetInt32("texture"), reader.GetInt32("sex"));
                        item.id = reader.GetInt32("id");
                        ClothList.AddItem(item);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Kleidung Laden: " + e.ToString());
            }
        }
        public static int CreateCloth(Items.Cloth c)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO clothes (componente, drawable, texture, sex) " +
                        "VALUES (@comp, @draw, @text, @sex)";

                cmd.Parameters.AddWithValue("@comp", c.componente);
                cmd.Parameters.AddWithValue("@draw", c.drawable);
                cmd.Parameters.AddWithValue("@text", c.texture);
                cmd.Parameters.AddWithValue("@sex", c.sex);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim backpack erstellen: " + e.ToString());
                return -1;
            }
        }

        public static void SaveBackPack(Backpack back)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE backpack SET item0=@i0, item1=@i1, item2=@i2, item3=@i3, item4=@i4, item5=@i5, item6=@i6, item7=@i7, item8=@i8,item9=@i9, item10=@i10, item11=@i11, item12=@i12, item13=@i13, item14=@i14, item15=@i15, item16=@i16, item17=@i17, item18=@i18 , item19=@i19, item20=@i20, item21=@i21, item22=@i22, item23=@i23 " +
                "WHERE id=@id";
                for(int i =0; i< back.Inv.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@i"+i, back.Inv[i]);
                }
                for (int i = back.Inv.Length; i < 24; i++)
                {
                    cmd.Parameters.AddWithValue("@i" + i, 0);
                }
                cmd.Parameters.AddWithValue("@id", back.Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim backpack Speichern: " + e.ToString());
            }
        }

        public static void LoadBackpack()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM backpack";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Backpack item = new Backpack(reader.GetInt32("size"));
                        for(int i=0; i< item.Inv.Length; i++)
                        {
                            item.Inv[i] = reader.GetInt32("item" + i);
                        }
                        item.Amount = reader.GetInt32("amount");
                        item.Size = reader.GetInt32("size");
                        item.Id = reader.GetInt32("id");
                        BackpackList.AddItem(item);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim backpack Speichern: " + e.ToString());
            }
        }

        public static int CreateBackpack(Backpack backpack)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO backpack (amount, size) " +
                        "VALUES (@amount, @size)";

                cmd.Parameters.AddWithValue("@amount", backpack.Amount);
                cmd.Parameters.AddWithValue("@size", backpack.Size);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim backpack erstellen: " + e.ToString());
                return -1;
            }
        }
        //banktransfers
        public static void CreateBankTransfer_Firmen(BankTransfers_Firmen banktransfer)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO banktransfers_firmen (firmenid, money, reason, date, name) " +
                        "VALUES (@fid,@money,@r,@d,@n)";

                cmd.Parameters.AddWithValue("@fid", banktransfer.FirmenId);
                cmd.Parameters.AddWithValue("@money", banktransfer.Money);
                cmd.Parameters.AddWithValue("@r", banktransfer.Reason);
                cmd.Parameters.AddWithValue("@d", banktransfer.Date);
                cmd.Parameters.AddWithValue("@n", banktransfer.Name);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankTransferFrimen erstellen: " + e.ToString());
            }
        }
        public static void LoadFirmenBankTransfers()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM banktransfers_firmen";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BankTransfers_Firmen bt = new BankTransfers_Firmen(reader.GetInt32("firmenid"), reader.GetInt32("money"), reader.GetString("name"), reader.GetString("reason"));
                        bt.Date = reader.GetDateTime("date");
                        BankTransfersList_Firmen.AddBankTransfer(bt);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankTransferFrimen Laden: " + e.ToString());
            }
        }
        public static void CreateBankTransfer(BankTransfers banktransfer)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO banktransfers (socialclubid, money, reason, date, name) " +
                        "VALUES (@sc,@money,@r,@d,@n)";

                cmd.Parameters.AddWithValue("@sc", banktransfer.Socialclubid);
                cmd.Parameters.AddWithValue("@money", banktransfer.Money);
                cmd.Parameters.AddWithValue("@r", banktransfer.Reason);
                DateTime now = Server.serverDate;
                string date = "" + (now.Day<10?"0"+now.Day:now.Day) + "." + (now.Month < 10 ? "0"+now.Month : now.Month) + "." + now.Year + "(" + (Server.h() < 10 ? "0" + Server.h() : Server.h()) + ":" + (Server.m() < 10 ? "0" + Server.m() : Server.m()) + ":" + (Server.s() < 10 ? "0" + Server.s() : Server.s()) + ")";
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@n", banktransfer.Name);
                cmd.ExecuteNonQuery();
                banktransfer.Date = date;
                newconnection.Close();
                newconnection.Dispose();
                return;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankTransfer erstellen: " + e.ToString());
            }
        }
        public static void LoadBankTransfers()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM banktransfers";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BankTransfers bt = new BankTransfers((ulong)reader.GetInt64("socialclubid"), reader.GetInt32("money"), reader.GetString("name"), reader.GetString("reason"));
                        bt.Date = reader.GetString("date");
                        BankTransfersList.AddBankTransfer(bt);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankTransfer Laden: " + e.ToString());
            }
        }
        public static bool SendBankAccountMoney(ulong sc,int type, int money)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE accounts SET bank=bank+@bank WHERE socialclubid=@id AND banktype=@btype";
                cmd.Parameters.AddWithValue("@id", sc);
                cmd.Parameters.AddWithValue("@bank", money);
                cmd.Parameters.AddWithValue("@btype", type);
                int count = cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();

                if (count > 0) return true;
                else return false;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankAccount Senden Speichern: " + e.ToString());
            }
            return false;
        }
        public static string GetPlayerNameFromDB(ulong sc)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT fname, lname FROM accounts WHERE socialclubid=@name LIMIT 1";

                cmd.Parameters.AddWithValue("@name", sc);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString("fname")+" "+ reader.GetString("lname");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim BankAccount Senden Speichern: " + e.ToString());
            }
            return "Unknown";
        }
        //Perso
        public static int CreatePerso(Perso p)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO perso (vname, nname, age, adress, height, eyecolor, socialclubid, searched) " +
                        "VALUES (@v,@n,@a,@ad,@h,@e,@sc, 0)";

                cmd.Parameters.AddWithValue("@v", p.Fname);
                cmd.Parameters.AddWithValue("@n", p.Lname);
                cmd.Parameters.AddWithValue("@a", p.Age);
                cmd.Parameters.AddWithValue("@ad", p.Adress);
                cmd.Parameters.AddWithValue("@h", p.Height);
                cmd.Parameters.AddWithValue("@e", p.Eyecolor);
                cmd.Parameters.AddWithValue("@sc", p.Socialclubid);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Perso erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void LoadPersos()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM perso";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Perso perso = new Perso(reader.GetString("vname"), reader.GetString("nname"), reader.GetString("adress"), reader.GetString("age"), reader.GetInt32("height"), reader.GetInt32("eyecolor"), (ulong)reader.GetInt32("socialclubid"));
                        perso.id = reader.GetInt32("id");
                        perso.Searched = reader.GetInt32("searched");
                        PersoList.AddPerso(perso);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Perso Laden: " + e.ToString());
            }
        }
        public static void SavePersos(Perso p)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE perso SET searched=@searched WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@searched", p.Searched);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Perso Speichern: " + e.ToString());
            }
        }
        //Drivinglicenses
        public static int CreateDrivingLicense(DrivingLicense p)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO drivinglicenses (owner,car,bike, socialclubid, searched) " +
                        "VALUES (@owner,@car,@bike,@sc, 0)";

                cmd.Parameters.AddWithValue("@owner", p.Owner);
                cmd.Parameters.AddWithValue("@car", p.Car);
                cmd.Parameters.AddWithValue("@bike", p.Bike);
                cmd.Parameters.AddWithValue("@sc", p.Socialclubid);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Perso erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void LoadDrivingLicenses()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM drivinglicenses";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DrivingLicense driving = new DrivingLicense();
                        driving.id = reader.GetInt32("id");
                        driving.Searched = reader.GetInt32("searched");
                        driving.Car = reader.GetInt32("car");
                        driving.Bike = reader.GetInt32("bike");
                        driving.Owner = reader.GetString("owner");
                        driving.Socialclubid = (ulong)reader.GetInt64("socialclubid");
                        driving.CreateDrivingLicense();
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim DrivingLicenses laden: " + e.ToString());
            }
        }
        public static void SaveDrivingLicense(DrivingLicense d)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE drivinglicenses SET searched=@searched, bike=@bike, car=@car WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", d.id);
                cmd.Parameters.AddWithValue("@searched", d.Searched);
                cmd.Parameters.AddWithValue("@car", d.Car);
                cmd.Parameters.AddWithValue("@bike", d.Bike);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim DrivingLicenses Saven: " + e.ToString());
            }
        }
        //Appartments
        public static int CreateAppartment(Appartment appartment)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO appartment (posx, posy, posz, interrior, rent, name, owner, owned, mintime, open, trash) " +
                        "VALUES (@x, @y, @z, @int, @rent, @name, @owner, @owned,@mintime, 1, 0)";

                cmd.Parameters.AddWithValue("@x", appartment.x);
                cmd.Parameters.AddWithValue("@y", appartment.y);
                cmd.Parameters.AddWithValue("@z", appartment.z);
                cmd.Parameters.AddWithValue("@int", appartment.interrior);
                cmd.Parameters.AddWithValue("@owner", appartment.owner);
                cmd.Parameters.AddWithValue("@owned", appartment.owned);
                cmd.Parameters.AddWithValue("@name", appartment.name);
                cmd.Parameters.AddWithValue("@rent", appartment.rent);
                cmd.Parameters.AddWithValue("@mintime", appartment.MinRentTime);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Appartment erstellen: " + e.ToString());
            }
            return -1;
        }

        public static void LoadAppartments()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM appartment";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appartment appartment = new Appartment(reader.GetFloat("posx"), reader.GetFloat("posy"), reader.GetFloat("posz"), reader.GetInt32("interrior"), reader.GetInt32("rent"), reader.GetString("name"));
                        appartment.id = reader.GetInt32("id");
                        appartment.owned = (ulong)reader.GetInt64("owned");
                        appartment.owner = reader.GetString("owner");
                        appartment.Lock = reader.GetInt32("open");
                        appartment.MinRentTime = reader.GetInt32("mintime");
                        appartment.Trash = reader.GetFloat("trash");
                        appartment.CreateAppartment();
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Apartment Laden: " + e.ToString());
            }
        }
        public static void SaveAppartment(Appartment a)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE appartment SET owner=@owner, owned=@owned, open=@open, mintime=@mintime, trash=@trash WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", a.id);
                cmd.Parameters.AddWithValue("@owned", a.owned);
                cmd.Parameters.AddWithValue("@owner", a.owner);
                cmd.Parameters.AddWithValue("@open", a.Lock);
                cmd.Parameters.AddWithValue("@mintime", a.MinRentTime);
                cmd.Parameters.AddWithValue("@trash", a.Trash);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Apartment Speichern: " + e.ToString());
            }
        }
        public static void DeleteAppartment(Appartment a)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM appartment WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", a.id);
                cmd.ExecuteReader();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Apartment deleten: " + e.ToString());
            }
        }
            //grounditems
        public static void CreateGroundItem(GroundItems ground)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO grounditems (id, x, y, z, dimension) " +
                        "VALUES (@id, @x, @y, @z, @virt)";

                cmd.Parameters.AddWithValue("@id", ground.id);
                cmd.Parameters.AddWithValue("@x", ground.x);
                cmd.Parameters.AddWithValue("@y", ground.y);
                cmd.Parameters.AddWithValue("@z", ground.z);
                cmd.Parameters.AddWithValue("@virt", ground.dimension);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim GroundItem erstellen: " + e.ToString());
            }
        }
        public static void LoadGroundItems()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM grounditems";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GroundItems item = new GroundItems();
                        item.id = reader.GetInt32("id");
                        item.x = reader.GetFloat("x");
                        item.y = reader.GetFloat("y");
                        item.z = reader.GetFloat("z");
                        item.dimension = reader.GetInt32("dimension");
                        item.CreateGroundItem();
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim GroundItems laden: " + e.ToString());
            }
        }
        public static void SaveGroundItems()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM grounditems";
                cmd.ExecuteReader();
                newconnection.Close();
                newconnection.Dispose();
                foreach (GroundItems ground in GroundList.GroundServerList)
                {
                    CreateGroundItem(ground);
                }
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim GroundItem Speichern: " + e.ToString());
            }
        }
        //Insert statement

        public static bool ExistAccount(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = new($"SELECT * FROM accounts WHERE socialclubid=@name LIMIT 1", newconnection);
                cmd.Parameters.AddWithValue("@name", player.SocialClubId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        newconnection.Close();
                        newconnection.Dispose();
                        return true;
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
                return false;

            }
            catch (Exception e)
            {
                Server.Log("Fehler beim ExistAccount: " + e.ToString());
            }
            return false;
        }

        public static int CreateAccount(MyPlayer.Player player, string pwd)
        {
            string saltedPw = BCrypt.HashPassword(pwd, BCrypt.GenerateSalt());
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO accounts (password, socialclubid) VALUES (@password, @name)";

                cmd.Parameters.AddWithValue("@password", saltedPw);
                cmd.Parameters.AddWithValue("@name", player.SocialClubId);
                cmd.ExecuteNonQuery();
                    
                player.Emit("LoginComplete");
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch(Exception e)
            {
                Server.Log("Fehler beim Account erstellen: " + e.ToString());
                return -1;
            }
        }
        public static void SaveAccountInventory(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();

                for (int i = 0; i < player.Inv.Length; i++)
                {
                    if (player.Inv[i] == 0 || player.Inv[i] == -1)
                    {
                        cmd.CommandText = "DELETE FROM inventory WHERE socialclubid=@social AND slot=@slot";
                        cmd.Parameters.AddWithValue("@social", player.SocialClubId);
                        cmd.Parameters.AddWithValue("@slot", i);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO inventory (socialclubid,itemid, slot) VALUES (@social,@itemid, @slot) ON DUPLICATE KEY UPDATE itemid=@itemid";
                        cmd.Parameters.AddWithValue("@itemid", player.Inv[i]);
                        cmd.Parameters.AddWithValue("@social", player.SocialClubId);
                        cmd.Parameters.AddWithValue("@slot", i);
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Inventory Speichern: " + e.ToString());
            }
        }
        public static void LoadAccountInventory(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM inventory WHERE socialclubid=@social";
                cmd.Parameters.AddWithValue("@social", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int i = reader.GetInt32("slot");
                        player.Inv[i] = reader.GetInt32("itemid");
                        Items.Items? item = ItemList.ItemsList.Find(x => x.Id == player.Inv[i]);
                        if (item == null)
                        {
                            player.Inv[i] = 0;
                            continue;
                        }
                        if (item.Serveritem == ServerEnums.Items.GPS) player.Emit("SetRadar", true);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
                player.GiveBackpack();
                player.GiveInvWeapons();
                player.LoggedIn = true;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Inventory Laden: " + e.ToString());
            }
        }


        public static void LoadAccount(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM accounts WHERE socialclubid=@name LIMIT 1";

                cmd.Parameters.AddWithValue("@name", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        player.Sex = reader.GetByte("sex");

                        if (player.Sex == 3)
                        {
                            PedEvents.CreateChar(player);
                            
                            return;
                        }
                        player.Emit("SetRadar", false);

                        player.JobMoney[(int)ServerEnums.MiniJobs.Lieferant] = reader.GetInt32("pizzajob");
                        player.JobMoney[(int)ServerEnums.MiniJobs.Mower] = reader.GetInt32("mowerjob");
                        player.JobMoney[(int)ServerEnums.MiniJobs.Gravel] = reader.GetInt32("graveljob");
                        player.JobMoney[(int)ServerEnums.MiniJobs.LumberJack] = reader.GetInt32("lumberjob");
                        player.Duty = reader.GetInt32("duty");
                        player.Faction = reader.GetInt32("faction");
                        player.Faction_Rank = reader.GetInt32("rank");
                        player.BergBauCd = reader.GetInt32("bergbaucd");
                        player.BergBau = reader.GetInt32("bergbau");

                        player.KraftLevel = reader.GetInt32("kraftlevel");
                        player.KraftSkill = reader.GetInt32("kraftskill");

                        player.AdminLevel = reader.GetByte("adminlevel");
                        player.Money = reader.GetInt32("money");
                        player.Age = reader.GetString("age");
                        player.Height = reader.GetInt32("height");
                        player.Lname = reader.GetString("lname");
                        player.Fname = reader.GetString("fname");
                        if (player.Sex == 0) player.Model = (uint)PedModel.FreemodeMale01;
                        if(player.Sex == 1) player.Model = (uint)PedModel.FreemodeFemale01;

                        player.Spawn(new Position(reader.GetFloat("x"), reader.GetFloat("y"), reader.GetFloat("z")), 0);
                        player.Rotation = new Rotation(roll: 0, pitch: 0, yaw: reader.GetFloat("r"));
                        player.Dimension = reader.GetInt32("dimension");

                        //face
                        DataSet.LoadHead(player, reader.GetString("head"));
                        DataSet.LoadFace(player, reader.GetString("face"));
                        DataSet.LoadOverlay(player, reader.GetString("overlay"));
                        player.SetClothes(2,(byte)reader.GetInt32("hair"),0,0);
                        player.HairColor = reader.GetByte("haircolor");
                        player.HairHighlightColor = reader.GetByte("hairtint");
                        player.SetEyeColor((ushort)reader.GetInt32("eyecolor"));
                        player.Armor = (ushort)reader.GetInt32("armour");
                        player.Health = (ushort)reader.GetInt32("health");
                        player.Mask = reader.GetInt32("mask");
                        player.Top = reader.GetInt32("top");
                        player.Under = reader.GetInt32("under");
                        player.Legs = reader.GetInt32("legs");
                        player.Shoes = reader.GetInt32("shoes");
                        player.Acces = reader.GetInt32("acces");

                        DataSet.LoadClothes(player);

                        player.Hat = reader.GetInt32("hats");
                        player.Glasses = reader.GetInt32("glasses");
                        player.Ears = reader.GetInt32("ears");
                        player.Watches = reader.GetInt32("watches");
                        player.Bracelet = reader.GetInt32("bracelets");

                        DataSet.LoadProps(player);

                        player.SetClothes(3, (ushort)reader.GetInt32("torso"), 0, 0);

                        player.SetMoney(player.Money);
                        player.DrivingTheoryWait = reader.GetInt32("drivingtheorywait");
                        player.DrivingTheory = reader.GetInt32("drivingtheory");
                        player.DrivingLicense = reader.GetInt32("drivinglicens");
                        player.DrivingPickup = reader.GetInt32("drivingpickup");
                        player.Bank = reader.GetInt32("bank");
                        player.BankType = reader.GetInt32("banktype");
                        player.Kredit = reader.GetInt32("kredit");
                        player.KreditPayBack = reader.GetInt32("kreditpayback");
                        player.PayDay = reader.GetInt32("payday");
                        player.PayDayMoney = reader.GetInt32("paydaymoney");

                        player.Hunger = reader.GetInt32("thirst");
                        player.Thirst = reader.GetInt32("hunger");
                        player.Harn = reader.GetInt32("harn");
                        player.Happy = reader.GetInt32("happy");

                        player.SetWeather(Server.weatherid);
                        player.Emit("setTime", Server.h(), Server.m(), Server.s());
                        player.SetAllSyncedDataOnSpawn();
                        FirmaWorkerSql.LoadFirma(player);
                        Shop247Handler.LoadShopBlips(player);
                        LTDGasstation_Handler.LoadLTDBlips(player);
                        FirmenNameHandler.LoadFirmenBlips(player);
                        Channels.AddPlayerGlobalVoice(player);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
                LoadAccountInventory(player);
                FriendSql.LoadPlayerFriends(player);
                player.Emit("LoginComplete");
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Spieler Laden: " + e.ToString());
            }
        }

        public static async Task SaveAccount(MyPlayer.Player player)
        {
            try
            {
                if (!player.LoggedIn) return;
                SaveAccountInventory(player);
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE accounts SET health=@health," +
                " armour=@armour, paydaymoney=@paydaymoney, payday=@payday, kreditpayback=@kreditpayback, kredit=@kredit, bank=@bank, banktype=@banktype, age=@age, fname=@fname, lname=@lname, height=@height, adminlevel=@alvl, money=@money, x=@x, y=@y, z=@z, r=@r, " +
                "sex=@sex, dimension=@dim, head=@head, face=@face, haircolor=@haircolor, hairtint=@hairtint,eyecolor=@eyecolor, overlay=@overlay ,";

                cmd.CommandText += "mask=@mask, top=@top, under=@under, legs=@legs, shoes=@shoes, acces=@acces, hair=@hair, torso=@torso ," +
                "hats=@hat, ears=@ear, glasses=@glasses, watches=@watch, bracelets=@brace, drivingtheory=@driv, drivingtheorywait=@drivwait, drivinglicens=@drivlic, drivingpickup=@drivpic, " +
                "kraftlevel=@kraftlevel, kraftskill=@kraftskill, bergbau=@bergbau, bergbaucd=@bergbaucd, faction=@faction, rank=@factionrank, duty=@duty, " +
                "pizzajob=@pizzajob, mowerjob=@mowerjob, graveljob=@graveljob, lumberjob=@lumberjob, thirst=@thirst, hunger=@hunger, harn=@harn, happy=@happy" +
                " WHERE socialclubid=@id";

                cmd.Parameters.AddWithValue("@thirst", player.Thirst);
                cmd.Parameters.AddWithValue("@hunger", player.Hunger);
                cmd.Parameters.AddWithValue("@harn", player.Harn);
                cmd.Parameters.AddWithValue("@happy", player.Happy);

                cmd.Parameters.AddWithValue("@pizzajob", player.JobMoney[(int)ServerEnums.MiniJobs.Lieferant]);
                cmd.Parameters.AddWithValue("@mowerjob", player.JobMoney[(int)ServerEnums.MiniJobs.Mower]);
                cmd.Parameters.AddWithValue("@graveljob", player.JobMoney[(int)ServerEnums.MiniJobs.Gravel]);
                cmd.Parameters.AddWithValue("@lumberjob", player.JobMoney[(int)ServerEnums.MiniJobs.LumberJack]);

                cmd.Parameters.AddWithValue("@duty", player.Duty);
                cmd.Parameters.AddWithValue("@faction", player.Faction);
                cmd.Parameters.AddWithValue("@factionrank", player.Faction_Rank);

                cmd.Parameters.AddWithValue("@bergbaucd", player.BergBauCd);
                cmd.Parameters.AddWithValue("@bergbau", player.BergBau);
                cmd.Parameters.AddWithValue("@kraftlevel", player.KraftLevel);
                cmd.Parameters.AddWithValue("@kraftskill", player.KraftSkill);

                cmd.Parameters.AddWithValue("@paydaymoney", player.PayDayMoney);
                cmd.Parameters.AddWithValue("@payday", player.PayDay);
                cmd.Parameters.AddWithValue("@kreditpayback", player.KreditPayBack);
                cmd.Parameters.AddWithValue("@kredit", player.Kredit);
                cmd.Parameters.AddWithValue("@banktype", player.BankType);
                cmd.Parameters.AddWithValue("@bank", player.Bank);
                cmd.Parameters.AddWithValue("@drivpic", player.DrivingPickup);
                cmd.Parameters.AddWithValue("@drivlic", player.DrivingLicense);
                cmd.Parameters.AddWithValue("@hat", player.Hat);
                cmd.Parameters.AddWithValue("@ear", player.Ears);
                cmd.Parameters.AddWithValue("@age", player.Age);
                cmd.Parameters.AddWithValue("@glasses", player.Glasses);
                cmd.Parameters.AddWithValue("@watch", player.Watches);
                cmd.Parameters.AddWithValue("@brace", player.Bracelet);
                cmd.Parameters.AddWithValue("@alvl", player.AdminLevel);
                cmd.Parameters.AddWithValue("@money", player.Money);

                if (player.HasData("CarDealerTp"))
                {
                    player.GetData("CarDealerTp", out Position pos);
                    cmd.Parameters.AddWithValue("@x", (float)pos.X);
                    cmd.Parameters.AddWithValue("@y", (float)pos.Y);
                    cmd.Parameters.AddWithValue("@z", (float)pos.Z + 0.1f);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@x", (float)player.Position.X);
                    cmd.Parameters.AddWithValue("@y", (float)player.Position.Y);
                    cmd.Parameters.AddWithValue("@z", (float)player.Position.Z + 0.1f);
                }

                cmd.Parameters.AddWithValue("@r", (float)player.Rotation.Yaw);
                cmd.Parameters.AddWithValue("@sex", (byte)player.Sex);
                cmd.Parameters.AddWithValue("@id", player.SocialClubId);
                cmd.Parameters.AddWithValue("@dim", player.Dimension);
                cmd.Parameters.AddWithValue("@haircolor", player.HairColor);
                cmd.Parameters.AddWithValue("@hairtint", player.HairHighlightColor);
                cmd.Parameters.AddWithValue("@eyecolor", player.EyeColor);
                cmd.Parameters.AddWithValue("@height", player.Height);
                cmd.Parameters.AddWithValue("@fname", player.Fname);
                cmd.Parameters.AddWithValue("@lname", player.Lname);
                cmd.Parameters.AddWithValue("@health", player.Health);
                cmd.Parameters.AddWithValue("@armour", player.Armor);
                cmd.Parameters.AddWithValue("@driv", player.DrivingTheory);
                cmd.Parameters.AddWithValue("@drivwait", player.DrivingTheoryWait);
                cmd.Parameters.AddWithValue("@mask", player.Mask);
                cmd.Parameters.AddWithValue("@top", player.Top);
                cmd.Parameters.AddWithValue("@under", player.Under);
                cmd.Parameters.AddWithValue("@legs", player.Legs);
                cmd.Parameters.AddWithValue("@shoes", player.Shoes);
                cmd.Parameters.AddWithValue("@acces", player.Acces);
                cmd.Parameters.AddWithValue("@hair", player.GetClothes(2).Drawable);
                cmd.Parameters.AddWithValue("@torso", player.GetClothes(3).Drawable);

                HeadBlendData head = player.HeadBlendData;
                string s = "" + head.ShapeFirstID + "|" + head.ShapeSecondID + "|" + head.ShapeThirdID + "|" + head.SkinFirstID + "|" + head.SkinSecondID + "|" + head.SkinThirdID + "|" + head.ShapeMix + "|" + head.SkinMix + "|" + head.ThirdMix + "|";
                s = s.Replace(",", ".");
                cmd.Parameters.AddWithValue("@head", s);

                string face = "";
                for (byte i = 0; i <= 19; i++)
                {
                    face += player.GetFaceFeatureScale(i) + "|";
                }
                face = face.Replace(",",".");
                cmd.Parameters.AddWithValue("@face", face);

                face = "";
                for (byte i = 0; i <= 19; i++)
                {
                    face += player.GetHeadOverlay(i).Index + "|"+ player.GetHeadOverlay(i).Opacity + "|"+ player.GetHeadOverlay(i).ColorType + "|" + player.GetHeadOverlay(i).ColorIndex + "|"+ player.GetHeadOverlay(i).SecondColorIndex + "|";
                }
                face = face.Replace(",", ".");
                cmd.Parameters.AddWithValue("@overlay", face);
                await cmd.ExecuteNonQueryAsync();

                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Spieler Speichern: " + e.ToString());
            }
        }
        public static List<MdcPlayer> GetDBPlayersByName(string fname, string lname)
        {
            List<MdcPlayer> mdcPlayer = new List<MdcPlayer> ();
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT * FROM accounts WHERE LOWER(fname)=LOWER(@f) AND LOWER(lname)=LOWER(@l)";
                cmd.Parameters.AddWithValue("@f", fname);
                cmd.Parameters.AddWithValue("@l", lname);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ulong sc = (ulong)reader.GetInt64("socialclubid");
                        Perso? p = PersoList.PersoServerList.Find(x => x.Socialclubid == sc && x.Searched == 0);
                        if (p!=null)mdcPlayer.Add(new MdcPlayer(reader.GetString("Fname"), reader.GetString("Lname"),sc, reader.GetString("age"), "Police Department" ,p.Adress, p.id));
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim GetDBPlayersByName: " + e.ToString());
            }
            return mdcPlayer;
        }

        public static OfflinePlayer? GetDBPlayerBySocialClubId(ulong scid)
        {
            OfflinePlayer? oP = null;
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM accounts WHERE socialclubid=@sc LIMIT 1";
                cmd.Parameters.AddWithValue("@sc", scid);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string[] name = { reader.GetString("lname"), reader.GetString("fname") };
                        int money = reader.GetInt32("money");
                        int bank = reader.GetInt32("bank");
                        int alevel = reader.GetInt32("adminlevel");
                        int faction = reader.GetInt32("faction");
                        oP = new OfflinePlayer(name[0]+ name[1],money,bank, alevel, faction);
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim GetDBPlayerBySocialClubId: " + e.ToString());
            }
            return oP;
        }

        public static bool PasswordCheck(MyPlayer.Player player, string passwordinput)
        {
            try
            {
                string pwd = "";
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT password FROM accounts WHERE socialclubid=@name LIMIT 1";
                cmd.Parameters.AddWithValue("@name", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        pwd = reader.GetString("password");
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
                if (BCrypt.CheckPassword(passwordinput, pwd)) return true;
                return false;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim PasswordCheck: " + e.ToString());
            }
            return false;
        }

        //
        public static int CreateCrime(Crime c)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO crimes (type, verbrechen, gesucht, knasttime, cost, date, socialclubid, pname) VALUES (@type, @crime, @wanted, @time, @cost, @date, @sc, @pname)";

                cmd.Parameters.AddWithValue("@crime", c.Grund);
                cmd.Parameters.AddWithValue("@wanted", c.Gesucht);
                cmd.Parameters.AddWithValue("@time", c.Knastzeit);
                cmd.Parameters.AddWithValue("@type", c.Type);
                cmd.Parameters.AddWithValue("@cost", c.Kosten);
                DateTime now = Server.serverDate;
                string date = "" + (now.Day < 10 ? "0" + now.Day : now.Day) + "." + (now.Month < 10 ? "0" + now.Month : now.Month) + "." + now.Year + "(" + (Server.h() < 10 ? "0" + Server.h() : Server.h()) + ":" + (Server.m() < 10 ? "0" + Server.m() : Server.m()) + ":" + (Server.s() < 10 ? "0" + Server.s() : Server.s()) + ")";
                cmd.Parameters.AddWithValue("@date", date);
                c.Datum = date;
                cmd.Parameters.AddWithValue("@sc", c.Socialclubid);
                cmd.Parameters.AddWithValue("@pname", c.PoliceName);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Crime erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void LoadCrimes()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM crimes";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Crime c = new Crime((ulong)reader.GetInt64("socialclubid"), reader.GetInt32("type"), reader.GetInt32("cost"), reader.GetString("verbrechen"), reader.GetInt32("gesucht"), reader.GetInt32("knasttime"),reader.GetString("pname"));
                        c.id = reader.GetInt32("crimeid");
                        c.Datum = reader.GetString("date");
                        c.CreateCrime();
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Crime Laden: " + e.ToString());
            }
        }
    }
}
