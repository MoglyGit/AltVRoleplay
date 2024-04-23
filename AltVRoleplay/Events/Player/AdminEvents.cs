using AltV.Net;
using AltVRoleplay.Appartments;
using AltVRoleplay.Events.House;

namespace AltVRoleplay.Events.Player
{
    public class AdminEvents : IScript
    {
        [ClientEvent("CreateAppartment")]
        public void CreateAppartment(MyPlayer.Player player,AltV.Net.Data.Position postion, int interior, int rent, string name)
        {
            Appartment appartment = new Appartment(postion.X, postion.Y, postion.Z, interior, rent, name);
            appartment.id = Database.CreateAppartment(appartment);
            appartment.CreateAppartment();
            SQL.Inventory.Wardrobe wardrobe = new SQL.Inventory.Wardrobe(HouseInterrior.GetInterriorWardrobeSlots(interior));
            wardrobe.SetPostion(HouseInterrior.GetInterriorWardrobePos(interior));
            wardrobe.Dimension = appartment.id;
            wardrobe.Create();
            player.Notification(ServerEnums.Notify.Check,"Appartment erstellt");
        }
    }
}
