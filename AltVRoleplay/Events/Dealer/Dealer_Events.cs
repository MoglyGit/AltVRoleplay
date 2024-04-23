
using AltV.Net;

namespace AltVRoleplay.Events.Dealer
{
    public class Dealer_Events : IScript
    {
        [ClientEvent("sellDealerItems")]
        public static void SellDealerItemsFromPlayer(MyPlayer.Player player, int itemClientId)
        {
            if (!player.LoggedIn) return;
            int money = 0;
            switch (itemClientId)
            {
                case 1:
                    money = Dealer_Handler.SellItem(player, ServerEnums.Items.Dolphin, 3500, true);
                    money += Dealer_Handler.SellItem(player, ServerEnums.Items.Shark, 4000, true);
                    GiveDealerMoney(player,money);
                    break;
                case 2:
                    money = Dealer_Handler.SellItem(player, ServerEnums.Items.Perso, 200);
                    GiveDealerMoney(player, money);
                    break;
                case 3:
                    money = Dealer_Handler.SellItem(player, ServerEnums.Items.DrivingLicense, 400);
                    GiveDealerMoney(player, money);
                    break;
                case 4://Weed
                    
                    break;
                case 5://Kokain

                    break;
                case 6://LSD

                    break;
            }
        }

        public static void GiveDealerMoney(MyPlayer.Player player, int money)
        {
            if(money == 0)
            {
                player.Notification(ServerEnums.Notify.Warning,"Davon hast du nichts dabei");
                return;
            }
            player.Notification(ServerEnums.Notify.Check, "Sachen verkauft +"+money);
            player.GiveMoney(money);
        }
    }
}
