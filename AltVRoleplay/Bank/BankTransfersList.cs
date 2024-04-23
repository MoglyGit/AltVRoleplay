namespace AltVRoleplay.Bank
{
    public class BankTransfersList
    {
        public static List<BankTransfers> BankTransfersServerList = new List<BankTransfers>();
        public static void AddBankTransfer(BankTransfers item)
        {
            BankTransfersServerList.Add(item);
        }
    }
}
