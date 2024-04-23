using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Bank;
using AltVRoleplay.MyPlayer;
using AltVRoleplay.Ped;

namespace AltVRoleplay.Events.Bank
{
    public class BankEvents : IScript
    {
        [ClientEvent("openFleecaBank")]
        public static void OpenBankMenu(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            PedEntity? ped = StaticPeds.Bankmann.Find(p => p.TextLabel != null && p.TextLabel.x == x);
            if (ped == null) return;
            if (player.BankType == 1)
            {
                string s = "FB-" + player.SocialClubId.ToString();
                player.Emit("ShowFleecaBank", player.Bank, s,0);
                return;
            }
            player.Emit("ShowFleecaBankNew");
        }
        [ClientEvent("createBank")]
        public static void CreateBankType(MyPlayer.Player player,int start, int type)
        {
            if (!player.LoggedIn) return;
            if(player.BankType != 0)
            {
                player.SendChatMessage("Du bist schon bei einer anderen Bank Kunde");
                return;
            }
            player.BankType = type;
            player.BankTransfer(500,"Fleeca Bank","Willkommens Bonus");
            player.SendChatMessage("Bank Konto erstellt");
            player.Save();
        }
        [ClientEvent("BankAccountInfoFleeca")]
        public static void BankAccountInfo(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.BankType != 1)
            {
                player.Emit("closeFleecaBank");
                player.SendChatMessage("Fehler im System");
                return;
            }
            for(int i= BankTransfersList.BankTransfersServerList.Count-1; i>=0;i--)
            {
                if (BankTransfersList.BankTransfersServerList[i].Socialclubid != player.SocialClubId) continue;
                player.Emit("createBankTransfer", BankTransfersList.BankTransfersServerList[i].Money, BankTransfersList.BankTransfersServerList[i].Name, BankTransfersList.BankTransfersServerList[i].Reason, BankTransfersList.BankTransfersServerList[i].Date);
            }
        }
        [ClientEvent("einzahlen")]
        public static void Einzahlen(MyPlayer.Player player, int money)
        {
            if (!player.LoggedIn) return;
            if (player.BankType == 0)
            {
                player.SendChatMessage("Fehler im System");
                return;
            }
            if (money < 0) return;
            if (money > player.Money)
            {
                player.Emit("bankError", "So viel Geld hast du nicht dabei");
                return;
            }
            player.GiveMoney(-money);
            player.BankTransfer(money,player.GetFullName(),"Einzahlung");
            player.Emit("updateBank",player.Bank);
        }
        [ClientEvent("auszahlen")]
        public static void Auszahlen(MyPlayer.Player player, int money, int atm)
        {
            if (!player.LoggedIn) return;
            if (player.BankType == 0)
            {
                player.SendChatMessage("Fehler im System");
                return;
            }
            if (money < 0) return;
            if (money > player.Bank)
            {
                player.Emit("bankError", "So viel Geld hast du nicht auf dem Konto");
                return;
            }
            player.GiveMoney(money);
            player.BankTransfer(-money, player.GetFullName(), "Auszahlung");
            if(atm==1 && player.BankType==1) player.BankTransfer(-(int)Math.Round(money*0.1f,MidpointRounding.AwayFromZero), player.GetFullName(), "Fleeca Bank auszahlungs gebühr am ATM");
            player.Emit("updateBank", player.Bank);
        }
        [ClientEvent("openATM")]
        public static void OpenAtm(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.BankType == 0)
            {
                return;
            }
            if (player.BankType == 1)
            {
                string s = "FB-" + player.SocialClubId.ToString();
                player.Emit("ShowFleecaBank", player.Bank, s, 1);
                return;
            }
        }
        [ClientEvent("ueberweisungFirma")]
        public static void UeberweisungFirma(MyPlayer.Player player, string empf, int money, string reason)
        {
            if (!player.LoggedIn) return;
            SQL.Firma.Class.Firma? firma = SQL.Firma.FirmaList.FirmaServerList.Find(x => x.Id == player.Firma);
            if (firma == null)
            {
                player.Emit("closeFirmenKonto"); 
                return;
            }
            if (money <= 0)
            {
                player.Emit("bankFirmenError", "Der Betrag muss mindestens 1$ sein!");
                return;
            }
            if (money > firma.Konto)
            {
                player.Emit("bankFirmenError", "So viel Geld hat die Firma nicht auf dem Konto");
                return;
            }
            string bank = "";
            bank += empf[0];
            bank += empf[1];
            string scst = "";
            for (int i = 3; i < empf.Length; i++)
            {
                scst += empf[i];
            }
            ulong sc = Convert.ToUInt64(scst);
            switch (bank)
            {
                case "FB":
                    MyPlayer.Player? target = GetPlayer.GetPlayerBySocialclubId(sc);
                    if (target != null)
                    {
                        if (target.BankType != 1) break;
                        player.Emit("closeFirmenKonto");
                        target.BankTransfer(money, player.GetFullName(), reason);
                        firma.Konto -= money;
                        BankTransfers_Firmen ba = new BankTransfers_Firmen(firma.Id, -money, target.GetFullName(), reason);
                        ba.Create();
                        firma.Save();
                        return;
                    }
                    if (!Database.SendBankAccountMoney(sc, 1, money)) break;
                    player.Emit("closeFirmenKonto");
                    BankTransfers_Firmen bax = new BankTransfers_Firmen(firma.Id, -money, Database.GetPlayerNameFromDB(sc), reason);
                    bax.Create();
                    firma.Save();
                    BankTransfers bf = new BankTransfers(sc, money, "Firma: " + firma.Info, reason);
                    bf.Create();
                    player.Notification(ServerEnums.Notify.Check,"Überweisung getätigt");
                    return;
                case "MA":
                    SQL.Firma.Class.Firma? firmaTarget = SQL.Firma.FirmaList.FirmaServerList.Find(x => "" + x.KontoNr + "" + x.Id == scst);
                    if (firmaTarget == null) break;
                    if (firmaTarget.Id == firma.Id) break;
                    player.Emit("closeFirmenKonto");
                    firmaTarget.Konto += money;
                    BankTransfers_Firmen bass = new BankTransfers_Firmen(firmaTarget.Id, money, "Firma: " + firmaTarget.Info, reason);
                    bass.Create();
                    firma.Konto -= money;
                    BankTransfers_Firmen bas = new BankTransfers_Firmen(firma.Id, -money, "Firma: " + firma.Info, reason);
                    bas.Create();
                    firma.Save();
                    firmaTarget.Save();
                    player.Notification(ServerEnums.Notify.Check, "Überweisung getätigt");
                    return;
            }
            player.Emit("bankFirmenError", "Die IBAN existiert nicht!");
        }
        [ClientEvent("ueberweisung")]
        public static void Ueberweisung(MyPlayer.Player player, string empf, int money, string reason)
        {
            if (!player.LoggedIn) return;
            if (money <= 0)
            {
                player.Emit("bankError", "Der Betrag muss mindestens 1$ sein!"); 
                return;
            }
            if (money > player.Bank)
            {
                player.Emit("bankError", "So viel Geld hast du nicht auf dem Konto");
                return;
            }
            string bank = "";
            bank += empf[0];
            bank += empf[1];
            string scst = "";
            for(int i=3;i<empf.Length;i++)
            {
                scst += empf[i];
            }
            ulong sc = Convert.ToUInt64(scst);
            switch (bank)
            {
                case "FB":
                    if (sc == player.SocialClubId) break;
                    MyPlayer.Player? target = GetPlayer.GetPlayerBySocialclubId(sc);
                    if(target != null)
                    {
                        if (target.BankType != 1) break;
                        target.BankTransfer(money,player.GetFullName(),reason);
                        player.BankTransfer(-money, target.GetFullName(), reason);
                        player.Emit("updateBank2", player.Bank);
                        return;
                    }
                    if (!Database.SendBankAccountMoney(sc, 1, money))break;
                    player.BankTransfer(-money, Database.GetPlayerNameFromDB(sc), reason);
                    BankTransfers bf = new BankTransfers(sc, money, player.GetFullName(), reason);
                    bf.Create();
                    player.Emit("updateBank2", player.Bank);
                    return;
                case "MA":
                    SQL.Firma.Class.Firma? firma = SQL.Firma.FirmaList.FirmaServerList.Find(x => "" + x.KontoNr + "" + x.Id == scst);
                    if (firma == null) break;
                    player.BankTransfer(-money, "Firma: "+firma.Info, reason);
                    firma.Konto += money;
                    BankTransfers_Firmen ba = new BankTransfers_Firmen(firma.Id,money, player.GetFullName(), reason);
                    ba.Create();
                    firma.Save();
                    player.Emit("updateBank2", player.Bank);
                    return;
            }
            player.Emit("bankError", "Die IBAN existiert nicht!");
        }
        [ClientEvent("giveKredit")]
        public static void GiveKredi(MyPlayer.Player player, int money)
        {
            if (!player.LoggedIn) return;
            if(player.Kredit > 0)
            {
                player.Emit("bankError", "Du zahlst noch einen Kredit ab! ("+player.Kredit + " PayDays verbleibend)");
                return;
            }
            player.Kredit = 10;
            int kredit = (int)Math.Round(money * 1.20f, MidpointRounding.AwayFromZero);
            player.KreditPayBack = (int)Math.Round(kredit * 0.10f, MidpointRounding.AwayFromZero);
            if (player.KreditPayBack <= 0) player.KreditPayBack = 1;
            player.BankTransfer(money, "FleecaBank", "Kredit");
            player.Save();
            player.Emit("updateBank2", player.Bank);
        }
    }
}
