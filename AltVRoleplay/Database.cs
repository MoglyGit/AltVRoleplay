using AltV.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay
{
    class Database : Server
    {
        private static MySqlConnection connection = default!;
        private static readonly string server;
        private static readonly string database;
        private static readonly string uid;
        private static readonly string password;

        static Database()
        {
            server = "93.90.205.242";
            uid = "xXMogly1Xx";
            password = "Mogly2000!";
            database = "GtaV";
            Initialize();
        }

        private static void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            if (!OpenConnection())
            {
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
                return;
            }
            CloseConnection();
            Server.Log("MYSQL Verbindung wurde aufgebaut.");
        }
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
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
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Server.Log(ex.Message);
                return false;
            }
        }
        //Insert statement

        public static bool ExistAccount(MyPlayer.Player player)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM accounts WHERE socialclubid=@name LIMIT 1", connection);
                cmd.Parameters.AddWithValue("@name", player.SocialClubId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        CloseConnection();
                        return true;
                    }
                }
                CloseConnection();
                return false;

            }
            return false;
        }

        public static int CreateAccount(MyPlayer.Player player, string pwd)
        {
            string saltedPw = BCrypt.HashPassword(password, BCrypt.GenerateSalt());
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO accounts (password, socialclubid) VALUES (@password, @name)";

                    cmd.Parameters.AddWithValue("@password", saltedPw);
                    cmd.Parameters.AddWithValue("@name", player.SocialClubId);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return (int)cmd.LastInsertedId;
                }
                return -1;
            }
            catch(Exception e)
            {
                Server.Log("Fehler beim Account erstellen: " + e.ToString());
                return -1;
            }
        }

        public static void LoadAccount(MyPlayer.Player player)
        {
            if(OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM accounts WHERE socialclubid=@name LIMIT 1";

                cmd.Parameters.AddWithValue("@name", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        player.PlayerID = reader.GetInt32("id");
                        player.AdminLevel = reader.GetByte("adminlevel");
                        player.Money = reader.GetInt32("money");
                    }
                }
                CloseConnection();
            }
        }

        public static void SaveAccount(MyPlayer.Player player)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE accounts SET adminlevel=@alvl, money=@money WHERE id=@id";

                cmd.Parameters.AddWithValue("@adminlvl", player.AdminLevel);
                cmd.Parameters.AddWithValue("@money", player.Money);
                cmd.Parameters.AddWithValue("@id", player.PlayerID);
                CloseConnection();
            }
        }

        public static bool PasswordCheck(MyPlayer.Player player, string passwordinput)
        {
            if (OpenConnection())
            {
                string password = "";
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT password FROM accounts WHERE socialclubid=@name LIMIT 1";
                cmd.Parameters.AddWithValue("@name", player.SocialClubId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        password = reader.GetString("password");
                    }
                }
                CloseConnection();
                if(BCrypt.CheckPassword(passwordinput, password)) return true;
                return false;
            }
            return false;
        }
    }
}
