using AltV.Net.Data;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Inventory;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace AltVRoleplay.SQL.Firma
{
    public class FirmaWorkerSql
    {
        public static void SetFirmaWorker(Class.Firma firma, ulong scid, ServerEnums.FirmenRanks rank, int gehalt=500)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen_worker (socialclubid, firmenid, rang, gehalt) " +
                        "VALUES (@scid, @firma, @rank, @gehalt) ON DUPLICATE KEY UPDATE firmenid=@firma, rang=@rank, gehalt=@gehalt";

                cmd.Parameters.AddWithValue("@scid", scid);
                cmd.Parameters.AddWithValue("@firma", firma.Id);
                cmd.Parameters.AddWithValue("@rank", (int)rank);
                cmd.Parameters.AddWithValue("@gehalt", gehalt);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen_worker erstellen: " + e.ToString());
            }
        }
        public static void SetFirmaWorker(Class.Firma firma, ulong scid, int gehalt)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen_worker (socialclubid, firmenid, rang, gehalt) " +
                        "VALUES (@scid, @firma, @rank, @gehalt) ON DUPLICATE KEY UPDATE firmenid=@firma, gehalt=@gehalt";

                cmd.Parameters.AddWithValue("@scid", scid);
                cmd.Parameters.AddWithValue("@firma", firma.Id);
                cmd.Parameters.AddWithValue("@rank", (int)ServerEnums.FirmenRanks.Praktikant);
                cmd.Parameters.AddWithValue("@gehalt", gehalt);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen_worker erstellen: " + e.ToString());
            }
        }
        public static void SetFirmaWorker(Class.Firma firma, ulong scid, ServerEnums.FirmenRanks rank)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen_worker (socialclubid, firmenid, rang, gehalt) " +
                        "VALUES (@scid, @firma, @rank, @gehalt) ON DUPLICATE KEY UPDATE firmenid=@firma, rang=@rank";

                cmd.Parameters.AddWithValue("@scid", scid);
                cmd.Parameters.AddWithValue("@firma", firma.Id);
                cmd.Parameters.AddWithValue("@rank", (int)rank);
                cmd.Parameters.AddWithValue("@gehalt", 500);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen_worker erstellen: " + e.ToString());
            }
        }
        public static void RemoveWorkerFromFirma(Class.Firma firma, ulong scid)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM firmen_worker WHERE socialclubid=@scid AND firmenid = @fid";

                cmd.Parameters.AddWithValue("@scid", scid);
                cmd.Parameters.AddWithValue("@fid", firma.Id);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Firmen_worker removen: " + e.ToString());
            }
        }

        public static void LoadFirma(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM firmen_worker WHERE socialclubid=@name LIMIT 1";

                cmd.Parameters.AddWithValue("@name", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        player.Firma = reader.GetInt32("firmenid");
                        player.Firma_Rank = (ServerEnums.FirmenRanks)reader.GetInt32("rang");
                        player.FirmaGehalt = reader.GetInt32("gehalt");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Player Firma laden: " + e.ToString());
            }
        }

        public static List<FirmaWorker>? GetAllFirmenWorker(int firmenid)
        {
            List<FirmaWorker> workerList = new List<FirmaWorker>();
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM firmen_worker WHERE firmenid=@id";
                cmd.Parameters.AddWithValue("@id", firmenid);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workerList.Add(new FirmaWorker((ulong)reader.GetInt64("socialclubid"), reader.GetInt32("rang"), reader.GetInt32("gehalt")));
                    }
                }
                newconnection.Close();
                newconnection.Dispose();
                return workerList;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Player Firma laden: " + e.ToString());
            }
            return null;
        }
    }
}
