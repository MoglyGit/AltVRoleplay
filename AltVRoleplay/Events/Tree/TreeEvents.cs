
namespace AltVRoleplay.Events.Tree
{
    public class TreeEvents
    {
        public static void CutTree(MyPlayer.Player player, float posx)
        {
            if (!player.LoggedIn) return;
            if (player.IsInVehicle) return;
            Objects.Tree? tree = Objects.ObjectLists.TreeServerList.Find(x => x.TextLabel != null && x.TextLabel.x == posx);
            if (tree == null) return;
            if (!tree.Object.Exists) return;
            if (!tree.interaction) return;
            if (!player.SetProgress(8-player.KraftLevel/2, (int)ServerEnums.ProgressEvent.CutLog, "Zerkleinere")) return;
            player.SetData("tree", tree);
            tree.interaction = false;
        }
    }
}
