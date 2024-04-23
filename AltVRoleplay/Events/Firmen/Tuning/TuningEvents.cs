
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using Newtonsoft.Json;

namespace AltVRoleplay.Events.Firmen.Tuning
{
    internal class TuningEvents : IScript
    {
        [ClientEvent("UseNos")]
        public static void UseNos(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            if (veh.NosCharges == 0) return;
            if (!veh.EngineOn) return;
            if (veh.UseNos()) player.Notification(ServerEnums.Notify.Check, "Nos aktiviert");
            else player.Notification(ServerEnums.Notify.Warning, "Nos füllt sich noch");
        }
        [ClientEvent("ResetTuningVehicle")]
        public static void ResetTuningVehicle(MyPlayer.Player player, MyVehicle.MyVehicle veh)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
        }
        [ClientEvent("SyncTuning")]
        public static void SyncTuning(MyPlayer.Player player, MyVehicle.MyVehicle veh, string tuningparts, string pcol, string seccol, bool hasNeon, string neonCol,byte tireType, int tireCol, bool addNos, bool chip)
        {
            if (!player.LoggedIn) return;
            if (veh == null) return;
            short[]? tuning = JsonConvert.DeserializeObject<short[]>(tuningparts);
            byte[]? pCol = JsonConvert.DeserializeObject<byte[]>(pcol);
            byte[]? secCol = JsonConvert.DeserializeObject<byte[]>(seccol);
            byte[]? neonColort = JsonConvert.DeserializeObject<byte[]>(neonCol);
            if (pCol == null || secCol == null || tuning == null || neonColort == null)
            {
                player.Notification(ServerEnums.Notify.Warning, "Teile konnten nicht eingebaut werden");
                return;
            }
            veh.PrimaryColorRgb = new Rgba(pCol[0], pCol[1], pCol[2], 255);
            veh.SecondaryColorRgb = new Rgba(secCol[0], secCol[1], secCol[2], 255);
            for(byte i =0; i<tuning.Length;i++)
            {
                tuning[i] += 1;
                veh.SetMod(i, (byte)tuning[i]);
            }
            veh.SetNeonActive(hasNeon, hasNeon, hasNeon, hasNeon);
            if(hasNeon) veh.NeonColor = new Rgba(neonColort[0], neonColort[1], neonColort[2], 255);
            veh.SetWheels(tireType, (byte)tuning[23]);
            veh.WheelColor = (byte)tireCol;
            if(addNos) veh.SetNosCharges(5);
            if(chip) veh.SetChipSpeed(20);
            else veh.SetChipSpeed(0);
            player.Notification(ServerEnums.Notify.Check,"Teile eingebaut");
            veh.Save();
        }
    }
}
