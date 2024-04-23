using AltV.Net.Data;
using AltVRoleplay.Text;
using System.Timers;
using AltV.Net;
using AltV.Net.EntitySync;

namespace AltVRoleplay.Objects
{
    public class Tree
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public TextLabel? TextLabel { get; set; }
        public bool interaction = true;
        public Objects.Object Object { get; set; }
        public int Health { get; set; }
        private System.Timers.Timer? FallTimer = null;
        float FallSpeed = 0.001f;
        public Logs? Log { get; set; }
        public Tree(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            Health = 75;
            TextLabel = new TextLabel("Der Baum sieht fällig aus", new Position(X, Y, Z + 2.5f), 20, 0);
            ObjectLists.AddTree(this);
            interaction = true;
            Object = new Object(1827343468, 0, 100, X, Y, Z, 0, 0, 0);
            Log = null;
        }
        public void Respawn()
        {
            Health = 75;
            TextLabel = new TextLabel("Der Baum sieht fällig aus", new Position(X, Y, Z + 2.5f), 20, 0);
            ObjectLists.AddTree(this);
            interaction = true;
            Object = new Object(1827343468, 0, 100, X, Y, Z, 0, 0, 0);
            Log = null;
        }
        public void Remove()
        {
            if (Object.Exists) Object.Destroy();
            if (TextLabel != null) TextLabel.Remove();
            TextLabel = null;
            /*
             * Falls ringenommen, funktioneirt Respawn nicht mehr wegen = Koordinaten
            X = 0;
            Y = 0;
            Z = 0;*/
            ObjectLists.RemoveTree(this);
            interaction = false;
        }
        public void Fall()
        {
            if (!Object.Exists) return;
            if (FallTimer != null) return;
            FallTimer = new System.Timers.Timer(1);
            FallTimer.Elapsed += FallAnimation;
            FallTimer.AutoReset = true;
            FallTimer.Enabled = true;
            interaction = false;
        }
        public void FallAnimation(System.Object? source, ElapsedEventArgs? e)
        {
            if (!Object.Exists || Object.Pitch >= 87f)
            {
                if (FallTimer == null) return;
                FallTimer.Stop();
                FallTimer.Dispose();
                if (TextLabel == null) return;
                TextLabel.SetText("Nutze E, zum verarbeiten");
                TextLabel.SetEventType((int)ServerEnums.TextLabelEvent.TreeCut, 2f);
                interaction = true;
                return;
            }
            Object.SetRotation(0, Object.Pitch + FallSpeed, 0);
            if(Object.Pitch >= 43) FallSpeed += 0.006f;
            FallSpeed += 0.001f;
        }
    }
}
