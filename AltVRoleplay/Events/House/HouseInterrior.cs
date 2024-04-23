using AltV.Net.Data;

namespace AltVRoleplay.Events.House
{
    public class HouseInterrior
    {
        public static List<Position> AppartmentPosition = new List<Position>();
        public static List<Rotation> AppartmentRotation = new List<Rotation>();
        public static List<Position> AppartmentTextPosition = new List<Position>();
        public static List<Position> AppartmentWardrobePosition = new List<Position>();
        public static List<int> AppartmentWardrobeSlots = new List<int>();
        public enum HouseInterriorType 
        {
            Motel

        }
        public static void LoadAppartments()
        {
            //Motel
            AppartmentPosition.Add(new Position(151.49011f, -1007.3011f, -99.01465f));
            AppartmentRotation.Add(new Rotation(0,0, -0.2968434f));
            AppartmentTextPosition.Add(new Position(151.34506f, -1008.0659f, -99.01465f));
            AppartmentWardrobePosition.Add(new Position(151.76703f, -1001.53845f, -99.01465f));
            AppartmentWardrobeSlots.Add(10);
            //new
        }
        public static Position GetInterriorWardrobePos(int id)
        {
            return AppartmentWardrobePosition[id];
        }
        public static int GetInterriorWardrobeSlots(int id)
        {
            return AppartmentWardrobeSlots[id];
        }
        public static Position GetInterriorPositionText(int id)
        {
            return AppartmentTextPosition[id];
        }
        public static Position GetInterriorPosition(int id)
        {
            return AppartmentPosition[id];
        }
        public static void SetInterrior(MyPlayer.Player player, int interrior, int dimension)
        {
            player.Position = AppartmentPosition[interrior];
            player.Rotation = AppartmentRotation[interrior];
            player.Dimension = dimension;
        }
    }
}
