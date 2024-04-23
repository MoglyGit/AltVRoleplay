using AltV.Net;

namespace AltVRoleplay.MyPlayer
{
    public class GetPlayer
    {
        public static Player? GetPlayerById(int id)
        {
            foreach(Player p in Alt.GetAllPlayers())
            {
                if (p.Id == id) return p;
            }
            return null;
        }
        public static Player? GetPlayerBySocialclubId(ulong sc)
        {
            foreach (Player p in Alt.GetAllPlayers())
            {
                if (p.SocialClubId == sc) return p;
            }
            return null;
        }
    }
}
