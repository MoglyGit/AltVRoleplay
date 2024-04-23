
using AltV.Net;
using AltV.Net.Data;

namespace AltVRoleplay.Events.Vehicle.Flatbed
{
    internal class FlatBed_Events : IScript
    {
        [ClientEvent("SetFlatBedLoadedvehiclePlace")]
        public static void PositionForCars(MyPlayer.Player player, float dist, float height)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("FlatBed")) return;
            player.GetData("FlatBed", out MyVehicle.MyVehicle flatbed);
            if (flatbed == null) return;
            if (flatbed.HasData("LoadedVehicle")) return;
            if (!flatbed.HasData("TryLoadVehicle")) return;
            flatbed.GetData("TryLoadVehicle", out MyVehicle.MyVehicle loadedVeh);
            flatbed.DeleteData("TryLoadVehicle");
            player.DeleteData("FlatBed");
            float y = -dist +0.2f;
            float z = height + 0.4f;
            if(y < -3f)
            {
                player.Notification(ServerEnums.Notify.Warning,"Das Fahrzeug ist zu lang!");
                return;
            }
            Server.Log("y: "+y +" | z: "+z);
            loadedVeh.AttachToEntity(flatbed, 0, 0, new Position(0, y, z), new Rotation(0, 0, 0), true, false);
            flatbed.SetData("LoadedVehicle", loadedVeh);
        }
        [ClientEvent("UnLoadFlatBed")]
        public static void UnLoadFlatBad(MyPlayer.Player player, float x, float y, float z)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("FlatBed")) return;
            player.GetData("FlatBed", out MyVehicle.MyVehicle flatbed);
            if (flatbed == null) return;
            player.Emit("getFlatBedDropPos", flatbed);
            if (!flatbed.HasData("LoadedVehicle")) return;
            flatbed.GetData("LoadedVehicle", out MyVehicle.MyVehicle loadedVeh);
            loadedVeh.Detach();
            loadedVeh.SetPosition(x, y, z+0.5f);
            loadedVeh.Rotation = flatbed.Rotation;
            flatbed.DeleteData("LoadedVehicle");
            flatbed.DeleteData("TryLoadVehicle");
            player.DeleteData("FlatBed");
        }

        [ClientEvent("loadOnFlatBed")]
        public static void loadOnFlat(MyPlayer.Player player, MyVehicle.MyVehicle flatbed, float behindTrailer_x, float behindTrailer_y)
        {
            if (flatbed == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Versuch es nochmal");
                return;
            }
            if(flatbed.Position.Distance(player.Position) > 1.9f)
            {
                player.Notification(ServerEnums.Notify.Warning, "Du bist zu weit weg");
                return;
            }
            if (flatbed.HasData("LoadedVehicle"))
            {
                flatbed.GetData("LoadedVehicle", out MyVehicle.MyVehicle loadedVeh);
                if(loadedVeh == null)
                {
                    flatbed.DeleteData("LoadedVehicle");
                    player.Notification(ServerEnums.Notify.Warning, "Fahrzeug nicht gefunden");
                    return;
                }
                player.SetData("FlatBed", flatbed);
                player.SetProgress(5, (int)ServerEnums.ProgressEvent.UnLoadFlatbed, "Lade Fahrzeug ab...");
            }
            else
            {
                if (flatbed.HasData("TryLoadVehicle"))
                {
                    player.Notification(ServerEnums.Notify.Warning, "Ein Fahrzeug wird schon geladen");
                    return;
                }
                foreach (MyVehicle.MyVehicle veh in Alt.GetAllVehicles().Cast<MyVehicle.MyVehicle>())
                {
                    if (veh == null) continue;
                    if (Alt.GetVehicleModelInfo(veh.Model).Type != VehicleModelType.AUTOMOBILE) continue;
                    if (veh.Position.Distance(new Position(behindTrailer_x, behindTrailer_y, flatbed.Position.Z))>4)continue;
                    flatbed.SetData("TryLoadVehicle", veh);
                    player.SetData("FlatBed", flatbed);
                    player.SetProgress(5, (int)ServerEnums.ProgressEvent.LoadFlatbed, "Lade Fahrzeug auf...");
                    return;
                }
                player.Notification(ServerEnums.Notify.Warning, "Kein Fahrzeug gefunden");
            }
        }
    }
}
