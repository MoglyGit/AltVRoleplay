
namespace AltVRoleplay.SQL.Firma.Class
{
    public class FirmaWorker
    {
        public ulong SocialClubId { get; set; }
        public int Gehalt {  get; set; }
        public int Rank { get; set; }
        public FirmaWorker(ulong scid, int rank, int gehalt) 
        {
            SocialClubId = scid;
            Gehalt = gehalt;
            Rank = rank;
        }
    }
}
