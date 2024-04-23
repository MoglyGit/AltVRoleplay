using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Events.Licenses
{
    public class Driving : IScript
    {
        [ClientEvent("DrivingTheory")]
        public static void DrivingTheory(MyPlayer.Player player)
        {
            if(player.DrivingTheoryWait > 60)
            {
                player.SendChatMessage("Der nächste Kurs für dich ist in "+player.DrivingTheoryWait/60+" Minuten");
                return;
            }
            if (player.DrivingTheoryWait > 0)
            {
                player.SendChatMessage("Der nächste Kurs für dich ist in " + player.DrivingTheoryWait + " Sekunden");
                return;
            }
            if (player.DrivingTheory < 3)
            {
                if (!player.LoggedIn) return;
                if (player.IsInVehicle) return;
                player.DrivingTheory++;
                player.SendChatMessage("Du hast am Theory Unterricht Teilgenommen "+player.DrivingTheory +"/3");
                if(player.DrivingTheory<3) player.SendChatMessage("Der nächste Kurs für dich wäre in 10 Minuten");
                if (player.DrivingTheory >= 3) player.SendChatMessage("Du kannst die Prüfung in 10 Minuten absolvieren!");
                player.DrivingTheoryWait = 60*10;
                return;
            }
            else
            {
                player.Emit("showDrivingInfo");
            }
        }
        [ClientEvent("DrivingLicense")]
        public static void CreateDrivingExam(MyPlayer.Player player, int price)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            if(!player.HasOwnPerso())
            {
                player.SendChatMessage(Message.noOwnPerso);
                return;
            }
            if(player.Money < price)
            {
                player.SendChatMessage(Message.notEnoughMoney);
                return;
            }
            player.GiveMoney(-price);
            IVehicle veh = Alt.CreateVehicle(Alt.Hash("asterope"), new Position(-70.443954f, -211.85934f, 44.950195f),new Rotation(roll: -0.0007983728f, pitch: -0.0005630805f, yaw: 2.799325f));
            veh.PrimaryColorRgb = new Rgba(255, 255, 255, 0);
            player.SetIntoVehicle(veh, 1);
            veh.EngineOn = true;
            veh.LockState = VehicleLockState.Locked;
            player.schoolcar = veh;
            player.Emit("ExamOne", 0);
            player.SendChatMessage("[Info] Blinker werden mit den Pfeiltasten genutzt, Warnblinker Nach Unten und Innenbeleuchtung nach oben");
        }
        [ClientEvent("FailedDriving")]
        public static void FailedDriving(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.schoolcar != null) player.schoolcar.Destroy();
            player.schoolcar = null;
            player.SendChatMessage("Du hast die Fahrpürung nicht bestanden, da du einen falschen Weg gefahren bist!");
        }
        [ClientEvent("FailedDrivingAway")]
        public static void FailedDrivingAway(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.schoolcar != null) player.schoolcar.Destroy();
            player.schoolcar = null;
            player.SendChatMessage("Der Prüfer hat die Prüfung beendet! Da er nicht entführt werden möchte");
        }
        [ClientEvent("SendMessage")]
        public static void SendClientMessage(MyPlayer.Player player, string message)
        {
            if (!player.LoggedIn) return;
            player.SendChatMessage(message);
        }
        [ClientEvent("CheckCar")]
        public static void CheckingCar(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (player.schoolcar == null)
            {
                player.Emit("Examreset");
                return;
            }
            if(player.schoolcar.BodyHealth < 900)
            {
                player.schoolcar.Destroy();
                player.schoolcar = null;
                player.SendChatMessage("Prüfer: Das Fahrzeug hat zu viel scahden bekommen, Sie haben nicht Bestanden");
                return;
            }
            player.schoolcar.Destroy();
            player.schoolcar = null;
            player.SendChatMessage("Prüfer: Glückwunsch "+player.Fname+" " + player.Lname+" Sie haben bestanden. Holen Sie sich Ihren Führerschein im Police Department ab.");
            player.DrivingPickup = 1;
            player.DrivingLicense = 1;
        }
    }
}
