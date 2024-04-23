using AltV.Net.Data;
using AltVRoleplay.SQL.Inventory;
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.Firma
{
    public class FirmaSql
    {
        public static int CreateFirma(Class.Firma firma)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen (pos_x,pos_y,pos_z,type, kontonr) " +
                        "VALUES (@x, @y, @z, @type,@kontonr)";

                cmd.Parameters.AddWithValue("@x", firma.X);
                cmd.Parameters.AddWithValue("@y", firma.Y);
                cmd.Parameters.AddWithValue("@z", firma.Z);
                cmd.Parameters.AddWithValue("@type", firma.FirmenType);
                Random rnd = new Random();
                firma.KontoNr = rnd.Next(100000, 999999);
                cmd.Parameters.AddWithValue("@kontonr", firma.KontoNr);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen erstellen: " + e.ToString());
            }
            return -1;
        }

        public static void LoadAllFirmen()
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM firmen";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Class.Firma firma = new(reader.GetFloat("pos_x"), reader.GetFloat("pos_y"), reader.GetFloat("pos_z"));
                        firma.Id = reader.GetInt32("id");
                        firma.Owner_Name = reader.GetString("owner_name");
                        firma.Owner_Id = (ulong)reader.GetInt64("owner_id");
                        firma.Info = reader.GetString("info");
                        firma.Products = reader.GetInt32("products");
                        firma.FirmenType = reader.GetInt32("type");
                        firma.Price = reader.GetInt32("price");
                        firma.Konto = reader.GetInt32("konto");
                        firma.KontoNr = reader.GetInt32("kontonr");

                        firma.Init();

                        FirmaList.AddFirma(firma);
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen Laden: " + e.ToString());
            }
        }
        public static void UpdateFirma(Class.Firma firma)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE firmen SET owner_id=@sc, owner_name=@owner, price=@price, info=@name, konto=@konto, products=@pro WHERE id = @id";
                cmd.Parameters.AddWithValue("@sc", firma.Owner_Id);
                cmd.Parameters.AddWithValue("@owner", firma.Owner_Name);
                cmd.Parameters.AddWithValue("@name", firma.Info);
                cmd.Parameters.AddWithValue("@price", firma.Price);
                cmd.Parameters.AddWithValue("@konto", firma.Konto);
                cmd.Parameters.AddWithValue("@pro", firma.Products);
                cmd.Parameters.AddWithValue("@id", firma.Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen update: " + e.ToString());
            }
        }
    }
}
