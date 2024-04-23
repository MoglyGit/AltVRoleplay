using AltV.Net;
using AltV.Net.Elements.Entities;

namespace AltVRoleplay.Events.Vehicle
{
    public class VehicleEvents : IScript
    {
        
        [ScriptEvent(ScriptEventType.VehicleDestroy)]
        public static void OnVehicleDestroy(MyVehicle.MyVehicle vehicle)
        {
            if (vehicle.RentOwner != 0)
            {
                vehicle.Destroy();
                return;
            }
            Server.Log("Veh: destroy");
            vehicle.Death = true;
        }
        [ScriptEvent(ScriptEventType.VehicleDamage)]
        public static void OnVehicleDamage(MyVehicle.MyVehicle target, IEntity attacker, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weapon)
        {
            Server.Log("Damge: "+engineHealthDamage + " | Health: "+ target.EngineHealth);
            if((engineHealthDamage > 60 && !target.MotorDamage) && !target.Death)
            {
                target.EngineOn = false;
                target.MotorDamage = true;
                MyPlayer.Player driver = (MyPlayer.Player)target.Driver;
                if (driver == null) return;
                driver.Notification(ServerEnums.Notify.Danger, "Motorschaden");
            }
            if(target.EngineHealth < 100 && !target.Death)
            {
                target.Death = true;
                target.EngineOn = false;
                target.MotorDamage = true;
                MyPlayer.Player driver = (MyPlayer.Player)target.Driver;
                if (driver == null) return;
                driver.Notification(ServerEnums.Notify.Danger, "Fahrzeug ist kaputt");
            }
        }
        //client
        [ClientEvent("VehicleRange")]
        public static void AddVehicleRange(MyPlayer.Player player, MyVehicle.MyVehicle vehicle, int range, int speed, float rpm, int gear)
        {
            if (!player.LoggedIn) return;
            if (vehicle == null) return;
            if (player.Vehicle.Id != vehicle.Id) return;
            if (!vehicle.HasSyncedMetaData("Range"))return;
            vehicle.SetRange(vehicle.Range + range);
            float f = (range * 0.001f + 0.002f * speed + gear * rpm * 0.02f) / 2;
            vehicle.AddFill(-f);
        }
    }
}
