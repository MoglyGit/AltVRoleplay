
namespace AltVRoleplay.SQL.Store
{
    public class StoreList
    {
        public static List<Class.Store_247> Store247ServerList = new List<Class.Store_247>();
        public static void AddStore(Class.Store_247 store)
        {
            Store247ServerList.Add(store);
        }
        public static void RemoveStore(Class.Store_247 store)
        {
            Store247ServerList.Remove(store);
        }
    }
}
