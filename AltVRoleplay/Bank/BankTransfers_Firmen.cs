
namespace AltVRoleplay.Bank
{
    public class BankTransfers_Firmen
    {
        public int Money { get; set; }
        public int FirmenId { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public BankTransfers_Firmen(int firmenId, int money, string name, string reason)
        {
            Money = money;
            FirmenId = firmenId;
            Name = name;
            Reason = reason;
            Date = DateTime.Now;
        }
        public void Create()
        {
            Database.CreateBankTransfer_Firmen(this);
            BankTransfersList_Firmen.AddBankTransfer(this);
        }
    }
}
