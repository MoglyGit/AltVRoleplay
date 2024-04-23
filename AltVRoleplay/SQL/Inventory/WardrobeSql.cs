
using AltV.Net.Data;
using AltVRoleplay.Items;
using MySql.Data.MySqlClient;

namespace AltVRoleplay.SQL.Inventory
{
    public class WardrobeSql
    {
        public static int CreateWardrobe(Wardrobe w)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO wardrobe (x,y,z,dimension,size) " +
                        "VALUES (@x, @y, @z, @dim, @size)";

                cmd.Parameters.AddWithValue("@x", w.X);
                cmd.Parameters.AddWithValue("@y", w.Y);
                cmd.Parameters.AddWithValue("@z", w.Z);
                cmd.Parameters.AddWithValue("@dim", w.Dimension);
                cmd.Parameters.AddWithValue("@size", w.Inv.Length);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Wardrobe erstellen: " + e.ToString());
            }
            return -1;
        }
        public static void LoadAllWardrobes()
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM wardrobe";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int slots = reader.GetInt32("size");
                        Wardrobe w = new (slots);
                        w.Id = reader.GetInt32("id");
                        w.SetPostion(new Position(reader.GetFloat("x"), reader.GetFloat("y"), reader.GetFloat("z")));
                        w.MaxWeight = slots*0.5f;
                        w.Dimension = reader.GetInt32("dimension");
                        w.Init();
                        WardrobeList.AddWardrobe(w);
                        LoadWardropeInventory(w);
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Wardrobe Laden: " + e.ToString());
            }
        }
        public static void LoadWardropeInventory(Wardrobe w)
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM Wardrobe_Inv WHERE Id = "+w.Id;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int i = reader.GetInt32("Slot");
                        w.Inv[i] = reader.GetInt32("ItemId");
                        Items.Items? item = ItemList.ItemsList.Find(x => x.Id == w.Inv[i]);
                        if (item == null)
                        {
                            w.Inv[i] = 0;
                            continue;
                        }
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Wardrobe Inv Laden: " + e.ToString());
            }
        }
        public static void SaveWardrobe(Wardrobe w)
        {
            if (w.Id == -1) return;
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();

                for (int i = 0; i < w.Inv.Length; i++)
                {
                    if (w.Inv[i] == 0 || w.Inv[i] == -1)
                    {
                        cmd.CommandText = "DELETE FROM Wardrobe_Inv WHERE Id=@id AND Slot=@slot";
                        cmd.Parameters.AddWithValue("@id", w.Id);
                        cmd.Parameters.AddWithValue("@slot", i);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Wardrobe_Inv (Id,ItemId, Slot) VALUES (@id,@itemid, @slot) ON DUPLICATE KEY UPDATE itemid=@itemid";
                        cmd.Parameters.AddWithValue("@itemid", w.Inv[i]);
                        cmd.Parameters.AddWithValue("@id", w.Id);
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
    }
}
