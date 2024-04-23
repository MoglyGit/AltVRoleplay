
using AltVRoleplay.SQL.LTD_Gas.Class;

namespace AltVRoleplay.Events.LTDGas
{
    public class LTDGasstation_Handler
    {
        public static void LoadLTDBlips(MyPlayer.Player player)
        {
            foreach (LTDGasStation shop in SQL.LTD_Gas.LTDList.LTDServerList)
            {
                if (shop.Ped == null) continue;
                int color = 1;
                if (shop.Owned != 0 && shop.SellPrice == 0) color = 2;
                player.Emit("CreateBlip", shop.Ped.x, shop.Ped.y, shop.Ped.z, 361, color, 1f, true, shop.Name);
            }
        }

        public static void ShowGasPayment(MyPlayer.Player player)
        {
            if (!player.HasData("LTD:PAYMENT") || !player.HasData("LTD:ID"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Du hast keine offene Rechnung");
                return;
            }
            player.GetData("LTD:ID", out int id);
            player.GetData("LTD:PAYMENT", out int pay);
            player.Emit("ShowgasPaying",pay, id);
        }
    }
}
