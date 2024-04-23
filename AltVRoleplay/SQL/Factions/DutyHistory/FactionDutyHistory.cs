
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.Factions.DutyHistory
{
    public class FactionDutyHistory
    {
        public static int CreateFactionDutyHistory(int factionid, ulong playerScId, bool duty)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO faction_duty_history (factionid, accountid, datum, state) VALUES (@f, @a, @d, @s)";

                string date = Server.GetServerDate()+" ("+Server.GetServerTime()+")";
                int state = duty ? 1 : 0;
                cmd.Parameters.AddWithValue("@f", factionid);
                cmd.Parameters.AddWithValue("@a", playerScId);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@s", state);

                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim history erstellen: " + e.ToString());
            }
            return -1;
        }
    }
}
