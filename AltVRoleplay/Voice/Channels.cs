using AltV.Net;
using AltV.Net.Elements.Entities;

namespace AltVRoleplay.Voice
{
    public class Channels
    {
        private static IVoiceChannel Channel = Alt.CreateVoiceChannel(true, 20f);
        public static void AddPlayerGlobalVoice(MyPlayer.Player player)
        {
            Channel.AddPlayer(player);
        }
        public static void RemovePlayerGlobalVoice(MyPlayer.Player player)
        {
            Channel.RemovePlayer(player);
        }
    }
}
