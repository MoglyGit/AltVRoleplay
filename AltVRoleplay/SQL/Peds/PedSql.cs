using AltVRoleplay.Ped;
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.Peds
{
    public class PedSql
    {
        public static void LoadServerPedsBuy()
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM ped_ankauf";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        float x = reader.GetFloat("x");
                        float y = reader.GetFloat("y");
                        float z = reader.GetFloat("z");
                        float r = reader.GetFloat("r");
                        int course = reader.GetInt32("course");
                        int storage = reader.GetInt32("storage");
                        int id = reader.GetInt32("id");
                        if (reader.GetInt32("type") == 1)
                        {
                            StaticPeds.CreateWoodAnkauf(x, y, z, r, course, storage, id);
                        }
                        if (reader.GetInt32("type") == 2)
                        {
                            StaticPeds.CreateIronAnkauf(x, y, z, r, course, storage, id);
                        }
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Peds_Buy Laden: " + e.ToString());
            }
        }
        public static void SaveServerPedsBuy(PedEntity? ped)
        {
            if (ped == null) return;
            if (ped.Db_Id == -1) return;
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "UPDATE ped_ankauf SET  course=@y, storage=@s WHERE id=@id";

                cmd.Parameters.AddWithValue("@y", ped.AnKaufKurs);
                cmd.Parameters.AddWithValue("@s", ped.Storage);
                cmd.Parameters.AddWithValue("@id", ped.Db_Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Server zeit speichern: " + e.ToString());
            }
        }
    }
}
