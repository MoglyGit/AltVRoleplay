using MySql.Data.MySqlClient;
namespace AltVRoleplay.SQL.Inventory
{
    public class VehInvSql
    {
        public static void LoadVehFrontInv(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM vehicle_handschuh WHERE id=" + veh.Dbid;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veh.FrontInv[reader.GetInt32("slot")] = reader.GetInt32("itemid");
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim VehicleFrontInv Laden: " + e.ToString());
            }
        }
        public static void SaveVehFrontInv(MyVehicle.MyVehicle veh)
        {
            if (veh.Dbid == -1) return;
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();

                for (int i = 0; i < veh.FrontInv.Length; i++)
                {
                    if (veh.FrontInv[i] == 0 || veh.FrontInv[i] == -1)
                    {
                        cmd.CommandText = "DELETE FROM vehicle_handschuh WHERE id=@id AND slot=@slot";
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
                        cmd.Parameters.AddWithValue("@slot", i);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO vehicle_handschuh (id,itemid, slot) VALUES (@id,@itemid, @slot) ON DUPLICATE KEY UPDATE itemid=@itemid";
                        cmd.Parameters.AddWithValue("@itemid", veh.FrontInv[i]);
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
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
                Server.Log("Fehler beim VehFrontInv Speichern: " + e.ToString());
            }
        }
        public static void LoadVehInv(MyVehicle.MyVehicle veh)
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM vehicle_inv WHERE id="+veh.Dbid;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veh.Inv[reader.GetInt32("slot")] = reader.GetInt32("itemid");
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim VehicleInv Laden: " + e.ToString());
            }
        }
        public static void SaveVehInv(MyVehicle.MyVehicle veh)
        {
            if (veh.Dbid == -1) return;
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();

                for (int i = 0; i < veh.Inv.Length; i++)
                {
                    if (veh.Inv[i] == 0 || veh.Inv[i] == -1)
                    {
                        cmd.CommandText = "DELETE FROM vehicle_inv WHERE id=@id AND slot=@slot";
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
                        cmd.Parameters.AddWithValue("@slot", i);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO vehicle_inv (id,itemid, slot) VALUES (@id,@itemid, @slot) ON DUPLICATE KEY UPDATE itemid=@itemid";
                        cmd.Parameters.AddWithValue("@itemid", veh.Inv[i]);
                        cmd.Parameters.AddWithValue("@id", veh.Dbid);
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
                Server.Log("Fehler beim VehInv Speichern: " + e.ToString());
            }
        }
    }
}
