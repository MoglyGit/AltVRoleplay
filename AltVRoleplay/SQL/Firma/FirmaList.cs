
namespace AltVRoleplay.SQL.Firma
{
    public class FirmaList
    {
        public static List<Class.Firma> FirmaServerList = new List<Class.Firma>();
        public static void AddFirma(Class.Firma firma)
        {
            FirmaServerList.Add(firma);
        }
        public static void RemoveFirma(Class.Firma firma)
        {
            FirmaServerList.Remove(firma);
        }
    }
}
