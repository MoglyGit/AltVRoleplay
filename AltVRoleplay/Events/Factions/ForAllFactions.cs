
using AltV.Net;

namespace AltVRoleplay.Events.Factions
{
    public class ForAllFactions : IScript
    {
        [ClientEvent("factionDuty")]
        public static void SetGarbageDuty(MyPlayer.Player player, int factionid)
        {
            if (!player.LoggedIn) return;
            if (factionid == 0) return;
            if (player.Faction != factionid) return;
            string text;
            if (player.Duty == 0)
            {
                player.Duty = 1;
                text = "Du hast dich eingestempelt";
            }
            else
            {
                player.Duty = 0;
                text = "Du hast dich ausgestempelt";
            }
            bool duty = player.Duty == 0 ? false : true;
            SQL.Factions.DutyHistory.FactionDutyHistory.CreateFactionDutyHistory(factionid, player.SocialClubId, duty);
            player.Notification(ServerEnums.Notify.Info, text);
        }
    }
}
