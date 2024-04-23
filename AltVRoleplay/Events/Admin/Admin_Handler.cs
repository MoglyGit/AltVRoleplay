
using AltVRoleplay.MyPlayer;
using AltVRoleplay.Text;

namespace AltVRoleplay.Events.Admin
{
    public class Admin_Handler
    {
        public static void ShowDisconenctedPlayer(MyPlayer.Player player, float x)
        {
            if (!player.IsSplielerAdmin((int)ServerEnums.AdminRanks.Supporter)) return;
            foreach(DisconnectInfo dc in StaticTextLabel.DisconnectInfoList)
            {
                if (dc.TextLabel == null) continue;
                if (dc.TextLabel.x!= x)continue;
                OfflinePlayer? oP = Database.GetDBPlayerBySocialClubId(dc.SocialClubId);
                if(oP == null)
                {
                    player.Notification(ServerEnums.Notify.Warning, "Kein eintrag gefunden");
                    return;
                }
                player.Notification(ServerEnums.Notify.Info,"Name: "+oP.FullName);
                player.Notification(ServerEnums.Notify.Info, "Admin: " + oP.AdminLevel);
                break;
            }
        }
    }
}
