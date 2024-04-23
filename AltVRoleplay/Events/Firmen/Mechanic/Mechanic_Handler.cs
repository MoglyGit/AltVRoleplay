
using AltVRoleplay.Items;
using AltVRoleplay.SQL.Firma.Class;

namespace AltVRoleplay.Events.Firmen.Mechanic
{
    public class Mechanic_Handler
    {
        public static void RepariVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("Mechanic:Repair")) return;
            player.GetData("Mechanic:Repair",out MyVehicle.MyVehicle veh);
            player.DeleteData("Mechanic:Repair");
            if (veh == null) return;
            Firma? firma = player.GetFirma();
            if (firma == null) return;
            if(firma.Products <= 80)
            {
                player.Notification(ServerEnums.Notify.Warning, "Keine Produkte in der Firma");
                return;
            }
            firma.Products -= 80;
            veh.Repair();
            uint addHealth = 250;
            uint addEngineHealth = 150;
            if (veh.BodyHealth + addHealth < 1000) veh.BodyHealth += addHealth;
            else veh.BodyHealth = 1000;
            if (veh.EngineHealth + addEngineHealth < 1000) veh.BodyHealth += addEngineHealth;
            else
            {
                veh.EngineHealth = 1000;
            }
            if(veh.EngineHealth >= 750 && veh.MotorDamage) veh.MotorDamage = false;
            if (veh.BodyHealth >= 1000 && veh.EngineHealth >= 1000 && veh.Death) veh.Death = false;
        }
        public static void TuevVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("Mechanic:Tuev")) return;
            player.GetData("Mechanic:Tuev", out MyVehicle.MyVehicle veh);
            player.DeleteData("Mechanic:Tuev");
            if (veh == null) return;
            Firma? firma = player.GetFirma();
            if (firma == null) return;
            if (firma.Products <= 150)
            {
                player.Notification(ServerEnums.Notify.Warning, "Keine Produkte in der Firma");
                return;
            }
            if (veh.BodyHealth <= 990 || veh.EngineHealth <= 990)
            {
                player.Notification(ServerEnums.Notify.Warning,"Fahrzeug hat den Tüv nicht bestanden");
                return;
            }
            if (veh.Death || veh.MotorDamage)
            {
                player.Notification(ServerEnums.Notify.Warning, "Fahrzeug hat den Tüv nicht bestanden");
                return;
            }
            Random rnd = new Random();
            if (veh.Range > 9000 && rnd.Next(100) <= 20)
            {
                player.Notification(ServerEnums.Notify.Warning, "Fahrzeug hat den Tüv nicht bestanden");
                return;
            }
            veh.Tuev = DateTime.Now.AddDays(21);
            player.Notification(ServerEnums.Notify.Check, "Fahrzeug hat den Tüv bestanden");
            firma.Products -= 150;
        }
        public static void ChangeLockVehicle(MyPlayer.Player player)
        {
            if (!player.LoggedIn) return;
            if (!player.HasData("Mechanic:ChangeLock")) return;
            player.GetData("Mechanic:ChangeLock", out MyVehicle.MyVehicle veh);
            player.DeleteData("Mechanic:ChangeLock");
            if (veh == null) return;
            Firma? firma = player.GetFirma();
            if (firma == null) return;
            if (firma.Products <= 0)
            {
                player.Notification(ServerEnums.Notify.Warning, "Keine Produkte in der Firma");
                return;
            }
            firma.Products -= 200;
            foreach (Items.Items listItem in ItemList.ItemsList)
            {
                if (listItem.Vehkey == veh.Dbid)
                {
                    listItem.Vehkey = 0;
                    listItem.SaveItem();
                }
            }
            player.Notification(ServerEnums.Notify.Check, "Fahrzeugschloss gewechselt");
        }
    }
}
