
namespace AltVRoleplay.SQL.Inventory
{
    public class WardrobeList
    {
        public static List<Wardrobe> WardrobeServerList = new List<Wardrobe>();
        public static void AddWardrobe(Wardrobe wardrobe)
        {
            WardrobeServerList.Add(wardrobe);
        }
        public static void RemoveWardrobe(Wardrobe wardrobe)
        {
            WardrobeServerList.Remove(wardrobe);
        }
    }
}
