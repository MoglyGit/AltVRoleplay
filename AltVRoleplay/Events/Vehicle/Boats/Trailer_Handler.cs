using AltV.Net;
using AltV.Net.Data;

namespace AltVRoleplay.Events.Boats
{
    public class Trailer_Handler
    {
        public static Dictionary<uint, Position> boatsAllowdTrailed = new Dictionary<uint, Position>(){
            {Alt.Hash("speeder"), new Position(0, -2 ,0.5f)},
            {Alt.Hash("jetmax"), new Position(0, -2,0.5f)},
            {Alt.Hash("dinghy"), new Position(0 ,-1, 0.3f)},
            {Alt.Hash("tropic"), new Position(0, -1 ,0.5f)},
            {Alt.Hash("suntrap"), new Position(0, -0.3f, 0.5f)}
        };

        public static void SlipBoat(MyPlayer.Player player)
        {
            if(!player.HasData("BoatTrailerTry") || !player.HasData("BoatBoatTry"))
            {
                player.Notification(ServerEnums.Notify.Warning, "Fehler beim Auf/Abladen");
                return;
            }
            player.GetData("BoatTrailerTry", out MyVehicle.MyVehicle trailer);
            player.GetData("BoatBoatTry", out MyVehicle.MyVehicle boat);
            if (boat == null || trailer == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Versuch es nochmal");
                return;
            }
            if (boat.AttachedTo != null)
            {
                player.Emit("isTrailerInWater", trailer, true);
                player.SetData("BoatOnTrailer", boat);
                return;
            }
            if (boatsAllowdTrailed.TryGetValue(boat.Model, out Position pos))
            {
                float tYaw = trailer.Rotation.Yaw;
                float bYaw = boat.Rotation.Yaw;
                if (bYaw + 0.3f <= tYaw || bYaw - 0.3f > tYaw)
                {
                    player.Notification(ServerEnums.Notify.Warning, "Das Boot ist zu schräg");
                    return;
                }
                player.Emit("isTrailerInWater", trailer, false);
                player.SetData("BoatOnTrailer", boat);
                player.SetData("BoatTrailer", trailer);
                player.SetData("BoatOnTrailerPos", pos);
                return;
            }
            player.Notification(ServerEnums.Notify.Warning, "Der Anhänger passt nicht");
        }
    }
}
