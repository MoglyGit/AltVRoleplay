
namespace AltVRoleplay.MyPlayer
{
    public class OfflinePlayer
    {
        public string FullName { get; set; }
        public int Money { get; set; }
        public int Bank { get; set; }
        public int AdminLevel { get; set; }
        public byte Sex { get; set; }
        public int Faction { get; set; }
        public OfflinePlayer(string name, int money, int bank, int alevel, int faction)
        {
            FullName = name;
            Money = money;
            Bank = bank;
            AdminLevel = alevel;
            Faction = faction;
        }
    }
}
