using AltV.Net;
using AltVRoleplay.Bank;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Firma.Class;

namespace AltVRoleplay.Events.Firmen
{
    internal class Firmen_Events : IScript
    {
        [ClientEvent("ChangePlayerFirmenRank")]
        public static void ChangePlayerFirmenRank(MyPlayer.Player player, ulong scid, int rank)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            if (player.Firma_Rank != ServerEnums.FirmenRanks.Owner) return;
            MyPlayer.Player? target = MyPlayer.GetPlayer.GetPlayerBySocialclubId(scid);
            if (target != null)
            {
                if (target.Firma_Rank == ServerEnums.FirmenRanks.Owner) return;
                if (rank == -1)
                {
                    target.Firma = 0;
                    target.Firma_Rank = 0;
                }
                else
                {
                    target.Firma_Rank = (ServerEnums.FirmenRanks)rank;
                    target.Emit("closeWorkerHud");
                }
            }
            if (rank == -1)
                FirmaWorkerSql.RemoveWorkerFromFirma(firma, scid);
            else FirmaWorkerSql.SetFirmaWorker(firma, scid, (ServerEnums.FirmenRanks)rank);
            player.Emit("firmenSucces");
            player.Notification(ServerEnums.Notify.Check, "Rang geändert");

        }
        [ClientEvent("ChangePlayerFirmenGehalt")]
        public static void ChangePlayerFirmenGehalt(MyPlayer.Player player, ulong scid, int gehalt)
        {
            if (!player.LoggedIn) return;
            if (gehalt <= 0) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            if (player.Firma_Rank != ServerEnums.FirmenRanks.Owner) return;
            MyPlayer.Player? target = MyPlayer.GetPlayer.GetPlayerBySocialclubId(scid);
            if(target != null)
            {
                target.FirmaGehalt = gehalt;
            }
            FirmaWorkerSql.SetFirmaWorker(firma,scid, gehalt);
            player.Emit("firmenSucces");
            player.Notification(ServerEnums.Notify.Check, "Gehalt geändert");

        }
        [ClientEvent("getFirmenWorker")]
        public static void GetFirmenWorker(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            List<FirmaWorker>? workerList = FirmaWorkerSql.GetAllFirmenWorker(firma.Id);
            if (workerList == null) return;
            foreach(FirmaWorker worker in workerList)
            {
                player.Emit("addWorker",worker.SocialClubId, Database.GetPlayerNameFromDB(worker.SocialClubId),worker.Gehalt,worker.Rank);
            }
        }
        [ClientEvent("changeFirmenName")]
        public static void ChangeFirmenName(MyPlayer.Player player, string name)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            if (name.Trim() == "") return;
            if (firma.Owner_Id == player.SocialClubId)
            {
                string oldname;
                if (firma.Info != "") oldname = firma.Info;
                else oldname = FirmenNameHandler.GetFirmenTypeToName((ServerEnums.Firmen)firma.FirmenType);
                firma.Info = name;
                firma.Update();
                firma.Save();
                ServerMethods.ChangeBlipName(firma.X, firma.Y, oldname, firma.Info);
            }
        }
        [ClientEvent("getFirmenKontoTransfer")]
        public static void GetFirmenKontoInfo(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            if (firma.Owner_Id == player.SocialClubId || player.Firma_Rank >= ServerEnums.FirmenRanks.Manager)
            {
                string nr = "MA-"+firma.KontoNr + "" + firma.Id;
                player.Emit("firmenKontoNr",nr,firma.Konto);
                for (int i = BankTransfersList_Firmen.BankTransfersFirmenServerList.Count - 1; i >= 0; i--)
                {
                    if (BankTransfersList_Firmen.BankTransfersFirmenServerList[i].FirmenId != firma.Id) continue;
                    player.Emit("createFirmenBankTransfer", BankTransfersList_Firmen.BankTransfersFirmenServerList[i].Money, BankTransfersList_Firmen.BankTransfersFirmenServerList[i].Name, BankTransfersList_Firmen.BankTransfersFirmenServerList[i].Reason, BankTransfersList_Firmen.BankTransfersFirmenServerList[i].Date.ToString("dd.MM.yyyy HH:mm"));
                }
            }
        }
        [ClientEvent("openFirmenHud")]
        public static void OpenFirmaHud(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == player.Firma);
            if (firma == null || player.Position.Distance(firma.GetPosition()) > 60) return;
            if(firma.FirmenType == (int)ServerEnums.Firmen.CarDealer)
            {
                player.Emit("ShowCarDealerMenuOwner", firma.Info, (int)player.Firma_Rank);
            }
            if (firma.FirmenType == (int)ServerEnums.Firmen.Mechanic)
            {
                player.Emit("ShowMechanicMenuOwner", firma.Info, (int)player.Firma_Rank);
            }
            if (firma.FirmenType == (int)ServerEnums.Firmen.Tuner)
            {
                player.Emit("ShowMechanicMenuOwner", firma.Info, (int)player.Firma_Rank);
            }
        }

        [ClientEvent("BuyFirma")]
        public static void BuyFirma(MyPlayer.Player player, int price, int id)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == id);
            if (firma == null) return;
            if (firma.Owner_Id != 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Der Laden steht nicht zum Verkauf");
                return;
            }
            if (player.Position.Distance(firma.GetPosition()) > 5)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit Weg");
                return;
            }
            if (player.Bank < price)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast nicht genug Geld auf deinem Konto");
                return;
            }
            firma.Owner_Id = player.SocialClubId;
            firma.Owner_Name = player.GetFullName();
            firma.Price = 0;
            player.BankTransfer(-price, FirmenNameHandler.GetFirmenTypeToName((ServerEnums.Firmen)firma.FirmenType), "Firma Gekauft");
            firma.Update();
            firma.Save();
            FirmaWorkerSql.SetFirmaWorker(firma, player.SocialClubId, ServerEnums.FirmenRanks.Owner);
            player.Firma = firma.Id;
            player.Firma_Rank = ServerEnums.FirmenRanks.Owner;
        }
    }
}
