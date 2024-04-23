
namespace AltVRoleplay.Bank
{
    public class BankTransfers
    {
        public int Money { get; set; }
        public ulong Socialclubid { get; set; }
        public string Reason { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public BankTransfers(ulong socialclubid, int money, string name, string reason)
        {
            Money = money;
            Socialclubid = socialclubid;
            Name = name;
            Reason = reason;
            Date = "";
        }
        public void Create()
        {
            Database.CreateBankTransfer(this);
            BankTransfersList.AddBankTransfer(this);
        }
    }
}
