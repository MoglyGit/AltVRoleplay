using AltV.Net.Data;

namespace AltVRoleplay.Events.Vehicle.Flatbed
{
    public class FlatBed_Handler
    {
        public static void LoadVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("FlatBed")) return;
            player.GetData("FlatBed", out MyVehicle.MyVehicle flatbed);
            if (flatbed == null) return;
            if (flatbed.HasData("LoadedVehicle"))return;
            if (!flatbed.HasData("TryLoadVehicle")) return;
            flatbed.GetData("TryLoadVehicle", out MyVehicle.MyVehicle loadedVeh);
            player.Emit("getFrontDistance", loadedVeh);
        }

        public static void UnLoadVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("FlatBed")) return;
            player.GetData("FlatBed", out MyVehicle.MyVehicle flatbed);
            if (flatbed == null) return;
            player.Emit("getFlatBedDropPos", flatbed);
        }
    }
}
