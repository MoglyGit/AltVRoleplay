using AltV.Net;
using AltV.Net.Data;
using System.Xml.Linq;

namespace AltVRoleplay
{
    public class ServerMethods
    {
        public static void ChangeBlipName(float x, float y, string oldname, string newname)
        {
            foreach (MyPlayer.Player p in Alt.GetAllPlayers())
            {
                if (!p.LoggedIn) continue;
                p.Emit("ChangeBlipName", x,y, oldname,newname);
            }
        }
        public static bool HasOpen(MyPlayer.Player player, int am, int pm)
        {
            if (Server.h() > pm|| Server.h() < am)
            {
                player.Notification(ServerEnums.Notify.Info, Message.notOpen);
                return false;
            }
            return true;
        }
        public static bool IsJobClosed(MyPlayer.Player player, int am, int pm)
        {
            if (Server.h() > pm || Server.h() < am)
            {
                player.Notification(ServerEnums.Notify.Info, "Arbeitszeit ist zu ende");
                player.StopMinijob();
                return true;
            }
            return false;
        }

        public static MyVehicle.MyVehicle? CreateVehicle(string model, Position pos, Rotation rot)
        {
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)Alt.CreateVehicle(Alt.Hash(model),pos,rot);
            if (veh == null) return null;
            veh.VehName = model.ToLower();
            veh.Sync();
            return veh;
        }
        public static MyVehicle.MyVehicle CreateVehicle(AltV.Net.Enums.VehicleModel model, Position pos, Rotation rot)
        {
            MyVehicle.MyVehicle veh = (MyVehicle.MyVehicle)Alt.CreateVehicle(model, pos, rot);
            veh.Sync();
            return veh;
        }

        public static string GetEyeColor(int eyeCol)
        {
            string eye = "Blau";
            int id = eyeCol - 1;
            switch (id)
            {
                case 0:
                    eye = "Dunkelgruen";
                    break;
                case 1:
                    eye = "Hellblau";
                    break;
                case 2:
                    eye = "Dunkelblau";
                    break;
                case 3:
                    eye = "Hellbraun";
                    break;
                case 4:
                    eye = "Dunkelbraun";
                    break;
                case 5:
                    eye = "Gruenrot";
                    break;
                case 6:
                    eye = "Dunkelgrau";
                    break;
                case 7:
                    eye = "Hellgrau";
                    break;
                case 8:
                    eye = "Rosa";
                    break;
                case 9:
                    eye = "Gelb";
                    break;
                case 10:
                    eye = "Lila";
                    break;
                case 11:
                    eye = "Schwarz";
                    break;
                case 12:
                    eye = "Graueringe";
                    break;
                case 13:
                    eye = "Gelbrot";
                    break;
            }
            return eye;
        }
    }
}
