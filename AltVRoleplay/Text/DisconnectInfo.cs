using AltV.Net.Data;

namespace AltVRoleplay.Text
{
    public class DisconnectInfo
    {
        public TextLabel? TextLabel {  get; set; }
        public ulong SocialClubId { get; set; }
        public uint Id { get; set; }
        public DateTime Expire {  get; set; }

        public DisconnectInfo(string info, MyPlayer.Player player) 
        {
            TextLabel = new TextLabel(info, player.Position, 10, player.Dimension, 2, (int)ServerEnums.TextLabelEvent.AdminDisconnectInfo);
            SocialClubId = player.SocialClubId;
            Id = player.Id;
            Expire = DateTime.Now.AddMinutes(5);
        }

        public void AdminInfo()
        {
            TextLabel?.SetText("Spieler ("+SocialClubId+")");
        }

        public void Remove()
        {
            StaticTextLabel.DisconnectInfoList.Remove(this);
            TextLabel?.Remove();
            TextLabel = null;
            SocialClubId = 0;
            Id = 0;
        }
    }
}
