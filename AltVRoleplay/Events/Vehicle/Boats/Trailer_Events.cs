
using AltV.Net;
using AltV.Net.Data;

namespace AltVRoleplay.Events.Vehicle.Boats
{
    public class Trailer_Events : IScript
    {
        [ClientEvent("slipBoat")]
        public static void SlipBoat(MyPlayer.Player player, MyVehicle.MyVehicle trailer, float behindTrailer_x, float behindTrailer_y)
        {
            if (trailer == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Versuch es nochmal");
                return;
            }
            string text = "Boot Trailer...";
            if (trailer.Attached == null)
            {
                MyVehicle.MyVehicle? boat = player.GetClosestBoat(new Position(behindTrailer_x, behindTrailer_y, trailer.Position.Z));
                if (boat == null)
                {
                    player.Notification(ServerEnums.Notify.Warning, "Kein Boot in der nähe");
                    return;
                }
                player.SetData("BoatBoatTry", boat);
                text = "Lade auf...";
            }
            else
            {
                player.SetData("BoatBoatTry", trailer.Attached);
                text = "Lade ab";
            }
            player.SetData("BoatTrailerTry",trailer);
            player.SetProgress(4, (int)ServerEnums.ProgressEvent.BoatTrailer, text);
        }
        [ClientEvent("UnloadBoat")]
        public static void UnLoadBoatFromTrailer(MyPlayer.Player player, float x, float y, float z)
        {
            if (!player.HasData("BoatOnTrailer")) return;
            player.GetData("BoatOnTrailer", out MyVehicle.MyVehicle boat);
            if (boat == null) return;
            if (boat.AttachedTo != null)
            {
                boat.Detach();
                boat.SetPosition(x,y,z);
                player.Notification(ServerEnums.Notify.Check, "Boat abgelassen");
            }
            DeleteBoatTrymeta(player);
        }
        [ClientEvent("LoadBoat")]
        public static void LoadBoatFromTrailer(MyPlayer.Player player)
        {
            if (!player.HasData("BoatOnTrailer")) return;
            if (!player.HasData("BoatOnTrailerPos")) return;
            if (!player.HasData("BoatTrailer")) return;
            player.GetData("BoatOnTrailer", out MyVehicle.MyVehicle boat);
            if (boat == null) return;
            if (boat.AttachedTo == null)
            {
                player.GetData("BoatOnTrailerPos",out Position pos);
                player.GetData("BoatTrailer", out MyVehicle.MyVehicle trailer);
                boat.AttachToEntity(trailer, 0, 0, pos, new Rotation(0, 0, 0), true, false);
                player.Notification(ServerEnums.Notify.Check, "Boat aufgeladen");

                player.DeleteData("BoatTrailer");
                player.DeleteData("BoatOnTrailerPos");
                player.DeleteData("BoatOnTrailer");
            }
            DeleteBoatTrymeta(player);
        }

        [ClientEvent("BoatLoadFailed")]
        public static void FailedBoatLoading(MyPlayer.Player player)
        {
            player.Notification(ServerEnums.Notify.Danger, "Das Boot kann hier nicht Ab/aufgeladen werden");
            DeleteBoatTrymeta(player);
        }

        public static void DeleteBoatTrymeta(MyPlayer.Player player)
        {
            player.DeleteData("BoatTrailer");
            player.DeleteData("BoatOnTrailerPos");
            player.DeleteData("BoatOnTrailer");
            player.DeleteData("BoatOnTrailer");
            player.DeleteData("BoatBoatTry");
            player.DeleteData("BoatTrailerTry");
        }
    }
}
