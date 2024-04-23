namespace AltVRoleplay.Items
{
    public class BackpackList
    {
        public static List<Backpack> BackpackServerList = new List<Backpack>();
        public static void AddItem(Backpack item)
        {
            BackpackServerList.Add(item);
        }
    }
}
