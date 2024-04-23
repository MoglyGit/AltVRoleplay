using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace AltVRoleplay.SQL.Tuning
{
    public class VehicleMods
    {
        public static void LoadVehicleMods(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM vehicleMods WHERE id=" + veh.Dbid;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veh.SetMod(reader.GetByte("type"), reader.GetByte("value"));
                    }
                }

                cmd.CommandText = "SELECT * FROM vehicleNeon WHERE id=" + veh.Dbid;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        veh.SetNeonActive(true, true, true, true);
                        veh.NeonColor = new AltV.Net.Data.Rgba((byte)reader.GetInt32("R"), (byte)reader.GetInt32("G"), (byte)reader.GetInt32("B"),255);
                    }
                }
                
                cmd.CommandText = "SELECT * FROM vehicleWheels WHERE id=" + veh.Dbid;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        veh.SetWheels((byte)reader.GetInt32("type"), (byte)reader.GetInt32("value"));
                        veh.WheelColor = (byte)reader.GetInt32("color");
                    }
                }

                cmd.CommandText = "SELECT * FROM vehicleWheelsHealth WHERE id=" + veh.Dbid;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veh.SetWheelHasTire((byte)reader.GetInt32("wheel"), false);
                    }
                }

                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim VehicleTuning Laden: " + e.ToString());
            }
        }
        public static void SaveVehicleMods(MyVehicle.MyVehicle veh)
        {
            if (veh.Dbid == -1) return;
            try
            {
                bool hasMods = false;
                for (byte i = 0; i < 50; i++)
                {
                    if (veh.GetMod(i) == 0) continue;
                    hasMods = true;
                    break;
                }
                if (!hasMods) return;
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();

                cmd.CommandText = "INSERT INTO vehicleWheels (id,type, value, color) VALUES (@id,@type, @val,@col) ON DUPLICATE KEY UPDATE type=@type, value=@val, color=@col";
                cmd.Parameters.AddWithValue("@type", veh.WheelType);
                cmd.Parameters.AddWithValue("@val", veh.WheelVariation);
                cmd.Parameters.AddWithValue("@col", veh.WheelColor);
                cmd.Parameters.AddWithValue("@id", veh.Dbid);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                bool[] neon = new bool[4];
                if (veh.IsNeonActive)
                {
                    cmd.CommandText = "INSERT INTO vehicleNeon (id,R, G, B) VALUES (@id,@r,@g,@b) ON DUPLICATE KEY UPDATE R=@r, G=@g, B=@b";
                    cmd.Parameters.AddWithValue("@r", veh.NeonColor.R);
                    cmd.Parameters.AddWithValue("@g", veh.NeonColor.G);
                    cmd.Parameters.AddWithValue("@b", veh.NeonColor.B);
                    cmd.Parameters.AddWithValue("@id", veh.Dbid);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM vehicleNeon WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", veh.Dbid);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                for(byte i = 0; i<veh.WheelsCount; i++)
                {
                    if(veh.DoesWheelHasTire(i))
                    {
                        cmd.CommandText = "DELETE FROM vehicleWheelsHealth WHERE id=@id AND wheel=@wheel";
                        cmd.Parameters.AddWithValue("@wheel", i);
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        continue;
                    }
                    cmd.CommandText = "INSERT IGNORE INTO vehicleWheelsHealth (id,wheel) VALUES (@id,@wheel)";
                    cmd.Parameters.AddWithValue("@wheel", i);
                    cmd.Parameters.AddWithValue("@id", veh.Dbid);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                for (byte i = 0; i < 50; i++)
                {
                    byte mod = veh.GetMod(i);
                    if (mod == 0)
                    {
                        cmd.CommandText = "DELETE FROM vehicleMods WHERE id=@id AND type=@type";
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
                        cmd.Parameters.AddWithValue("@type", i);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO vehicleMods (id,type, value) VALUES (@id,@type, @value) ON DUPLICATE KEY UPDATE value=@value";
                        cmd.Parameters.AddWithValue("@value", mod);
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
                        cmd.Parameters.AddWithValue("@type", i);
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim VehicleMods Speichern: " + e.ToString());
            }
        }
    }
}
