using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltVRoleplay.Appartments;
using System.Numerics;

namespace AltVRoleplay.Events.Factions
{
    public class GarbageEvetns : IScript
    {
        [ClientEvent("tryTakeGarbage")]
        public static void TryTakingGarbage(MyPlayer.Player player, int id)
        {
            if (!player.LoggedIn) return;
            if (player.Faction != (int)ServerEnums.Fraktions.Garbage) return;
            if (player.Duty == 0) return;
            Appartment? a = AppartmentList.AppartmentServerList.Find(x => x.id == id);
            if (a == null) { player.Emit("clsoeApartmentView"); return; }
            if (a.id != player.Dimension && player.Position.Distance(new Position(a.x, a.y, a.z)) > 2) { player.Emit("clsoeApartmentView"); return; }
            if (a.Trash <= 4) { player.Emit("clsoeApartmentView"); player.Notification(ServerEnums.Notify.Warning, "Nicht Genug Müll hier"); return; }
            if (player.HasData("Trash")) { player.Emit("clsoeApartmentView"); player.Notification(ServerEnums.Notify.Warning, "Du kannst nicht noch mehr Müll nehmen"); return; }
            if (player.HasattachedObject(ServerEnums.PlayerAttachedSlots.Right_Hand)) { player.Notification(ServerEnums.Notify.Warning, "Rechte Hand ist nicht Frei"); return; }
            player.SetData("Trash", a.Trash);
            a.Trash = 0;
            player.Emit("clsoeApartmentView");
            player.Notification(ServerEnums.Notify.Info,"Du hast den Müll geholt");
            player.AttachObjectToPlayer(ServerEnums.PlayerAttachedSlots.Right_Hand, "prop_rub_binbag_01", 6286, 0, new Position(0.45f, -0.2f, 0), new Rotation(0.5f, -1.7f, -0.2f), false, false);
        }

        [ClientEvent("behindTrash")]
        public static void BehindTrashCar(MyPlayer.Player player, IVehicle veh, float x, float y, float z)
        {
            MyVehicle.MyVehicle vehicle = (MyVehicle.MyVehicle)veh;
            Server.Log(vehicle.Id+"|"+vehicle.FactionId);
            if (vehicle.Model != Alt.Hash("trash") && vehicle.Model != Alt.Hash("trash2")) return;
            if (!player.LoggedIn) return;
            if (player.Position.Distance(new Position(x,y,z)) > 2) return;
            if (player.Faction != (int)ServerEnums.Fraktions.Garbage) return;
            if (!player.HasData("Trash")) return;
            if (player.Duty == 0) return;
            player.GetData("Trash", out float playervolume);
            if (vehicle.HasData("Trash"))
            {
                vehicle.GetData("Trash", out float volume);
                if (volume + playervolume > 10000)
                {
                    player.Notification(ServerEnums.Notify.Warning, "Der Müll passt nicht mehr rein.");
                    return;
                }
                volume += playervolume;
                player.Notification(ServerEnums.Notify.Info, "Müll (" + volume.ToString("0.00") + "/10000)");
                vehicle.SetData("Trash", volume);
            }
            else
            {
                player.Notification(ServerEnums.Notify.Info, "Müll (" + playervolume.ToString("0.00") + "/10000)");
                vehicle.SetData("Trash", playervolume);
            }
            player.DeleteData("Trash");
            player.DetachObjectFromPlayer(ServerEnums.PlayerAttachedSlots.Right_Hand);
        }

    }
}
