using AltV.Net;
using AltV.Net.Elements.Entities;
using AltVRoleplay.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Events.RouteCheckpoint
{
    public class Checkpoint : IScript
    {
        [ClientEvent("EnterRouteCheckpoint")]
        public static void EnterRouteCheckpoint(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("Checkpoint")) return;
            player.GetData("Checkpoint", out int cevent);
            switch (cevent)
            {
                case (int)ServerEnums.CheckpointEvent.MinijobPizza:
                    MinijobPizza(player);
                    break;
                case (int)ServerEnums.CheckpointEvent.GravelDump:
                    GravelWorker.GravelDumpUnload(player);
                    break;
            }
        }

        public static void MinijobPizza(MyPlayer.Player player)
        {
            if (player.MiniJob == (int)ServerEnums.MiniJobs.Lieferant)
            {
                Random rnd = new Random();
                if (player.MiniJobPed != null)
                {
                    player.MiniJobPed.Remove();
                    player.MiniJobPed = null;
                    player.SetRoute(12, -138.18462f, -253.23956f, 43.046143f, ServerEnums.CheckpointEvent.MinijobPizza);
                    player.Notification(ServerEnums.Notify.Check, "Bestellung geliefert, fahre wieder zurück.");
                    int amount = 25;
                    player.PayDayMoney += amount;
                    player.JobMoney[(int)ServerEnums.MiniJobs.Lieferant] += amount;
                    int money = 1 + rnd.Next(5);
                    player.Notification(ServerEnums.Notify.Check, "Trinkgeld: " + money + "$");
                    player.GiveMoney(money);
                }
                else
                {
                    int money = 20 + rnd.Next(20);
                    player.Notification(ServerEnums.Notify.Check, "Payday: " + money + "$");
                    player.StopMinijob();
                }
            }
        }
    }
}
