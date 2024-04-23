using AltVRoleplay.SQL.Store;
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.LTD_Gas
{
    public class LTDSQL
    {
        public static int CreateLTD(Class.LTDGasStation store)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO gasstation (x,y,z,konto,open,products,name, owner, owned, ped_x, ped_y, ped_z, ped_r, sellprice) " +
                        "VALUES (@x, @y, @z, 0, 1, 1000, 'Tankstelle', '', 0, 0,0,0,0,0)";

                cmd.Parameters.AddWithValue("@x", store.X);
                cmd.Parameters.AddWithValue("@y", store.Y);
                cmd.Parameters.AddWithValue("@z", store.Z);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Tankstelle erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void UpdateLTD(Class.LTDGasStation store)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                string pro = "";
                for (int i = 0; i < store.FillPrice.Length; i++)
                {
                    pro += ", f" + (i) + " = @f" + (i);
                }
                cmd.CommandText = "UPDATE gasstation SET owned = @sc, owner=@owner, sellprice=@price, name=@name, konto=@konto, products=@pro " + pro +
                        " WHERE id = @id";
                cmd.Parameters.AddWithValue("@sc", store.Owned);
                cmd.Parameters.AddWithValue("@owner", store.Owner);
                cmd.Parameters.AddWithValue("@name", store.Name);
                cmd.Parameters.AddWithValue("@price", store.SellPrice);
                cmd.Parameters.AddWithValue("@konto", store.Konto);
                cmd.Parameters.AddWithValue("@pro", store.Products);
                for (int i = 0; i < store.FillPrice.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@f" + (i), store.FillPrice[i]);
                }
                cmd.Parameters.AddWithValue("@id", store.Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Tankstelle update: " + e.ToString());
            }
        }
        public static int CreateStorePed_LTD(Class.LTDGasStation store, float x, float y, float z, float r)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE gasstation SET ped_x = @x, ped_y=@y, ped_z=@z, ped_r=@r " +
                        "WHERE id = @id";

                cmd.Parameters.AddWithValue("@x", x);
                cmd.Parameters.AddWithValue("@y", y);
                cmd.Parameters.AddWithValue("@z", z);
                cmd.Parameters.AddWithValue("@r", r);
                cmd.Parameters.AddWithValue("@id", store.Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                store.CreateSellerEntity(x, y, z, r);
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Tankstellen Ped erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void LoadAllLTD()
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM gasstation";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Class.LTDGasStation store = new(reader.GetFloat("x"), reader.GetFloat("y"), reader.GetFloat("z"));
                        store.Id = reader.GetInt32("id");
                        store.Konto = reader.GetInt32("konto");
                        store.Name = reader.GetString("name");
                        store.Open = reader.GetInt32("open");
                        store.Products = reader.GetInt32("products");
                        store.Owned = (ulong)reader.GetInt64("owned");
                        store.Owner = reader.GetString("owner");
                        store.SellPrice = reader.GetInt32("sellprice");
                        if (reader.GetFloat("ped_x") != 0) store.CreateSellerEntity(reader.GetFloat("ped_x"), reader.GetFloat("ped_y"), reader.GetFloat("ped_z"), reader.GetFloat("ped_r"));
                        for (int i = 0; i < store.FillPrice.Length; i++)
                        {
                            store.FillPrice[i] = reader.GetInt32("f"+i);
                        }

                        store.Init();
                        LTDList.AddStore(store);
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim LTD Laden: " + e.ToString());
            }
        }

    }
}
