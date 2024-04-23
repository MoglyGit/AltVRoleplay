
using AltV.Net.Data;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Inventory;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace AltVRoleplay.SQL.Firma.CarDealer
{
    public class CarDealerSQL
    {
        public static void DeleteContract(CarDealerContract c)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "DELETE FROM firmen_cardealer_contract WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", c.SqlId);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                CreateContractInfoAll(c.FirmaId, c.OrderdByName, AltV.Net.Alt.GetVehicleModelInfo(c.Modell).Title, c.Price);
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim CarDealer Contract löschen: " + e.ToString());
            }
        }

        public static void CreateContractInfoAll(int firmId, string name, string model, int price)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen_cardealer_all (firmenid, vehname, price, name) " +
                        "VALUES (@fid, @model, @price, @name)";

                cmd.Parameters.AddWithValue("@fid", firmId);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim CarDealer Contract Info erstellen: " + e.ToString());
            }
        }
        public static void CreateContract(Class.Firma firma,string name, uint model, int price, int pr, int pg, int pb, int sr, int sg, int sb)
        {
            try
            {
                MySqlConnection newconnection = new MySqlConnection(Database.connectionString);
                newconnection.Open();
                DateTime abholen = DateTime.Now.AddMinutes(1);
                MySqlCommand cmd = newconnection.CreateCommand();
                cmd.CommandText = "INSERT INTO firmen_cardealer_contract (firmenid, model, p_r, p_g, p_b, s_r, s_g, s_b, delivery,price, name) " +
                        "VALUES (@fid, @model, @pr, @pg,@pb,@sr,@sg,@sb,@deliver, @price, @name)";

                cmd.Parameters.AddWithValue("@fid", firma.Id);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@pr", pr);
                cmd.Parameters.AddWithValue("@pg", pg);
                cmd.Parameters.AddWithValue("@pb", pb);
                cmd.Parameters.AddWithValue("@sr", sr);
                cmd.Parameters.AddWithValue("@sg", sg);
                cmd.Parameters.AddWithValue("@sb", sb);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@deliver", abholen);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                newconnection.Close();
                newconnection.Dispose();
                CarDealerContract contract = new((int)cmd.LastInsertedId, firma.Id,price,model,pr,pg,pb,sr,sg,sb, abholen, name);
                CarDealerContractList.carDealerContractServerList.Add(contract);
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim CarDealer Contract erstellen: " + e.ToString());
            }
        }

        public static void LoadAllCarDealerContracts()
        {
            try
            {
                MySqlConnection newconenction = new MySqlConnection(Database.connectionString);
                newconenction.Open();
                MySqlCommand cmd = newconenction.CreateCommand();
                cmd.CommandText = "SELECT * FROM firmen_cardealer_contract";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        int firmaid = reader.GetInt32("firmenid");
                        int price = reader.GetInt32("price");
                        uint model = reader.GetUInt32("model");
                        int pr = reader.GetInt32("p_r");
                        int pg = reader.GetInt32("p_g");
                        int pb = reader.GetInt32("p_b");
                        int sr = reader.GetInt32("s_r");
                        int sg = reader.GetInt32("s_g");
                        int sb = reader.GetInt32("s_b");
                        string name = reader.GetString("name");
                        DateTime abholen = reader.GetDateTime("delivery");
                        CarDealerContract contract = new(id, firmaid, price, model, pr, pg, pb, sr, sg, sb, abholen, name);
                        CarDealerContractList.carDealerContractServerList.Add(contract);
                    }
                }
                newconenction.Close();
                newconenction.Dispose();
            }
            catch (Exception e)
            {
                Server.Log("Fehler beim Cardealer Contracts Laden: " + e.ToString());
            }
        }
    }
}
