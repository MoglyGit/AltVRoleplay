
namespace AltVRoleplay.SQL.Firma.Class
{
    public class CarDealerContract
    {
        public int SqlId { get; set; }
        public int FirmaId { get; set; }
        public int Price { get; set; }
        public int P_R {  get; set; }
        public int P_G { get; set; }
        public int P_B { get; set; }
        public int S_R { get; set; }
        public int S_G { get; set; }
        public int S_B { get; set; }
        public uint Modell { get; set; }
        public DateTime Delivery {  get; set; }
        public string OrderdByName { get; set; }
        public CarDealerContract(int sqlid, int fid, int price, uint model, int pr, int pg, int pb, int sr, int sg, int sb, DateTime delivery, string orderName) { 
            FirmaId = fid;
            Price = price;
            Modell = model;
            P_R = pr;
            P_G = pg;
            P_B = pb;
            S_R = sr;
            S_G = sg;
            S_B = sb;
            SqlId = sqlid;
            Delivery = delivery;
            OrderdByName = orderName;
        }
        public void Delete()
        {
            CarDealer.CarDealerSQL.DeleteContract(this);
            FirmaId = -1;
            SqlId = -1;
            CarDealerContractList.carDealerContractServerList.Remove(this);
        }
    }

    public class CarDealerContractList
    {
        public static List<CarDealerContract> carDealerContractServerList = new List<CarDealerContract>();
    }
}
