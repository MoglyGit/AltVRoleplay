

namespace AltVRoleplay.SQL.LTD_Gas
{
    public class LTDList
    {
        public static List<Class.LTDGasStation> LTDServerList = new List<Class.LTDGasStation>();
        public static void AddStore(Class.LTDGasStation store)
        {
            LTDServerList.Add(store);
        }
    }
}
