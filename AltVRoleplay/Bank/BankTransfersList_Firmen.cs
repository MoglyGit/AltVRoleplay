
namespace AltVRoleplay.Bank
{
    public class BankTransfersList_Firmen
    {
        public static List<BankTransfers_Firmen> BankTransfersFirmenServerList = new List<BankTransfers_Firmen>();
        public static void AddBankTransfer(BankTransfers_Firmen item)
        {
            BankTransfersFirmenServerList.Add(item);
        }
    }
}
