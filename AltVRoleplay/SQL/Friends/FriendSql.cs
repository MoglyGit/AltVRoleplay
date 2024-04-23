
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.Friends
{
    public class FriendSql
    {
        public static void AddFriend(MyPlayer.Player player, ulong friendSocialClubId)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO friends (player, friend) VALUES (@p, @f)";

                cmd.Parameters.AddWithValue("@p", player.SocialClubId);
                cmd.Parameters.AddWithValue("@f", friendSocialClubId);

                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Freund hinzufügen: " + e.ToString());
            }
        }
        public static void RemoveFriend(MyPlayer.Player player, ulong friendSocialClubId)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM friends WHERE friend=@f AND player=@p";

                cmd.Parameters.AddWithValue("@p", player.SocialClubId);
                cmd.Parameters.AddWithValue("@f", friendSocialClubId);

                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Freund deleten: " + e.ToString());
            }
        }
        public static void LoadPlayerFriends(MyPlayer.Player player)
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM friends WHERE player="+player.SocialClubId;
                List<ulong> friends = new List<ulong>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        friends.Add(reader.GetUInt64("friend"));
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
                player.SetSyncedMetaData("FriendList", friends);
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Friends Laden: " + e.ToString());
            }
        }
    }
}
