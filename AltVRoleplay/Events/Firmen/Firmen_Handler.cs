
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Firma.Class;

namespace AltVRoleplay.Events.Firmen
{
    public class Firmen_Handler
    {
        public static void ShowOwnerHud(MyPlayer.Player player, float x)
        {
            if (!player.LoggedIn) return;
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.X == x);
            if (firma == null) return;
            if (firma.Owner_Id == 0)
            {
                player.Emit("ShowFirmenBuy", FirmenNameHandler.GetFirmenTypeToName((ServerEnums.Firmen)firma.FirmenType), firma.Price, firma.Id);
                return;
            }
            if (player.SocialClubId != firma.Owner_Id) return;
            //player.Emit("ShowStore247Owner", store.Name, store.Konto, store.Id, store.Eat, store.Products);
        }
    }
}
