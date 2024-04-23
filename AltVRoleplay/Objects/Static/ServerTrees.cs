using System.Timers;

namespace AltVRoleplay.Objects.Static
{
    public class ServerTrees
    {
        private static List<Tree> Trees = new List<Tree>();
        private static System.Timers.Timer? Respawn = null;

        public static void RespawnTree(System.Object? source, ElapsedEventArgs? e)
        {
            foreach(Tree tree in Trees)
            {
                if (tree.Object.Exists) continue;
                if (tree.Log == null) continue;
                if (tree.Log.Object.Exists) continue;
                tree.Respawn();
            }
        }
        public static void LoadServerTrees()
        {
            Respawn = new System.Timers.Timer(1000*60*40);
            Respawn.Elapsed += RespawnTree;
            Respawn.AutoReset = true;
            Respawn.Enabled = true;
            Trees.Add(new Tree(-620.04395f, 5250.3823f, 72.75244f - 2f));
            Trees.Add(new Tree(-616.444f, 5246.558f, 72.48279f - 2f));
            Trees.Add(new Tree(-619.9253f, 5244.4746f, 73.055664f - 2f));
            Trees.Add(new Tree(-625.767f, 5243.9736f, 73.71277f - 2f));
            Trees.Add(new Tree(-629.84174f, 5239.8726f, 74.201416f - 2f));
            Trees.Add(new Tree(-619.23956f, 5234.611f, 73.88135f - 2f));
            Trees.Add(new Tree(-612.38245f, 5237.4595f, 72.80298f - 2f));
            Trees.Add(new Tree(-609.0198f, 5243.354f, 71.77515f - 2f));
            Trees.Add(new Tree(-645.6f, 5259.02f, 75.19556f - 2f));
            Trees.Add(new Tree(-652.39124f, 5263.5166f, 75.566284f - 2f));
            Trees.Add(new Tree(-657.9165f, 5261.9077f, 76.17285f - 2f));
            Trees.Add(new Tree(-666.4352f, 5264.822f, 76.324585f - 2f));
            Trees.Add(new Tree(-677.1429f, 5269.6353f, 75.93701f - 2f));
            Trees.Add(new Tree(-654.83075f, 5200.945f, 93.5282f - 2f));
            Trees.Add(new Tree(-649.2264f, 5177.5386f, 103.33484f - 2f));
            Trees.Add(new Tree(-638.54504f, 5165.7363f, 106.51941f - 2f));
            Trees.Add(new Tree(-608.61096f, 5162.5845f, 103.92456f - 2f));
            Trees.Add(new Tree(-592.7868f, 5148.079f, 110.49597f - 2f));
            Trees.Add(new Tree(-641.578f, 5150.7954f, 113.64685f - 2f));
            Trees.Add(new Tree(-675.32306f, 5180.321f, 106.62048f - 2f));
            Trees.Add(new Tree(-689.7099f, 5188.6284f, 104.85132f - 2f));
            Trees.Add(new Tree(-691.1473f, 5212.8f, 97.892334f - 2f));
            Trees.Add(new Tree(-569.6967f, 5429.3276f, 60.772217f - 2f));
            Trees.Add(new Tree(-575.0769f, 5434.813f, 60.23291f - 2f));
            Trees.Add(new Tree(-582.81757f, 5433.4683f, 58.733276f - 2f));
            Trees.Add(new Tree(-589.767f, 5438.993f, 58.32898f - 2f));
            Trees.Add(new Tree(-596.9407f, 5438.756f, 56.89673f - 2f));
            Trees.Add(new Tree(-603.75824f, 5444.6636f, 56.559692f - 2f));
            Trees.Add(new Tree(-612.55383f, 5443.121f, 55.00952f - 2f));
            Trees.Add(new Tree(-620.25494f, 5445.508f, 54.50403f - 2f));
            Trees.Add(new Tree(-617.82855f, 5465.2485f, 55.73401f - 2f));
            Trees.Add(new Tree(-611.82855f, 5478.2505f, 53.34143f - 2f));
            Trees.Add(new Tree(-601.12085f, 5484.501f, 53.964844f - 2f));
            Trees.Add(new Tree(-581.2879f, 5484.804f, 57.233643f - 2f));
            Trees.Add(new Tree(-562.83954f, 5488.655f, 60.098145f - 2f));
            Trees.Add(new Tree(-546.38245f, 5477.7627f, 64.49597f - 2f));
            Trees.Add(new Tree(-530.87476f, 5466.936f, 70.25867f - 2f));
            Trees.Add(new Tree(-513.45496f, 5464.9053f, 75.90332f - 2f));
            Trees.Add(new Tree(-541.10767f, 5535.1914f, 61.47986f - 2f));
            Trees.Add(new Tree(-526.6418f, 5546.334f, 66.433716f - 2f));
            Trees.Add(new Tree(-552.65936f, 5563.042f, 57.098877f - 2f));
            Trees.Add(new Tree(-574.25934f, 5572.312f, 49.36487f - 2f));
            Trees.Add(new Tree(-591.2703f, 5557.055f, 48f - 2f));
            Trees.Add(new Tree(-614.53186f, 5574.4614f, 39.086426f - 2f));
            Trees.Add(new Tree(-668.10986f, 5525.209f, 40.93994f - 2f));
            Trees.Add(new Tree(-677.16925f, 5512.7207f, 43.24829f - 2f));
            Trees.Add(new Tree(-675.0857f, 5490.567f, 48.623413f - 2f));
            Trees.Add(new Tree(-806.17584f, 5590.3384f, 29.212402f - 2f));
            Trees.Add(new Tree(-807.9956f, 5610.989f, 27.07251f - 2f));
            Trees.Add(new Tree(-804.4879f, 5627.1167f, 25.825684f - 2f));
            Trees.Add(new Tree(-810.3956f, 5631.824f, 24.056396f - 2f));
            Trees.Add(new Tree(-814.3648f, 5639.367f, 23.213867f - 2f));
            Trees.Add(new Tree(-811.6352f, 5648.993f, 23.48352f - 2f));
            Trees.Add(new Tree(-810.46155f, 5663.2354f, 22.843262f - 2f));
            Trees.Add(new Tree(-820.022f, 5665.0815f, 21.512085f - 2f));
            Trees.Add(new Tree(-830.9802f, 5661.4946f, 20.383179f - 2f));
            Trees.Add(new Tree(-842.46594f, 5655.389f, 19.355347f - 2f));
            Trees.Add(new Tree(-834.32965f, 5683.4375f, 19.237305f - 2f));
            Trees.Add(new Tree(-717.0593f, 5429.1035f, 44.41101f - 2f));
            Trees.Add(new Tree(-712.0088f, 5418.8438f, 47.56189f - 2f));
            Trees.Add(new Tree(-685.3055f, 5431.0815f, 46.88794f - 2f));
            Trees.Add(new Tree(-658.16705f, 5435.934f, 49.98828f - 2f));
            Trees.Add(new Tree(-660.2769f, 5455.978f, 50.898193f - 2f));
            Trees.Add(new Tree(-734.46594f, 5280.936f, 79.98096f - 2f));
            Trees.Add(new Tree(-730.39124f, 5287.1475f, 77.285034f - 2f));
            Trees.Add(new Tree(-724.68134f, 5299.9385f, 73.13989f - 2f));
            Trees.Add(new Tree(-720.0659f, 5306.5317f, 72.56702f - 2f));
            Trees.Add(new Tree(-699.37585f, 5322.7515f, 70.41028f - 2f));
            Trees.Add(new Tree(-689.26154f, 5333.657f, 69.01172f - 2f));
            Trees.Add(new Tree(-683.7231f, 5345.776f, 67.57947f - 2f));
            Trees.Add(new Tree(-686.1495f, 5359.6353f, 65.557495f - 2f));
            Trees.Add(new Tree(-678.422f, 5364.949f, 62.608765f - 2f));
            Trees.Add(new Tree(-669.53406f, 5360.2944f, 61.39563f - 2f));
            Trees.Add(new Tree(-683.76263f, 5365.991f, 63.232178f - 2f));
            Trees.Add(new Tree(-703.2659f, 5367.323f, 62.760498f - 2f));
            Trees.Add(new Tree(-711.5868f, 5360.044f, 64.22632f - 2f));
            Trees.Add(new Tree(-721.2f, 5348.611f, 65.03516f - 2f));
            Trees.Add(new Tree(-744.65936f, 5329.899f, 72.07837f - 2f));
            Trees.Add(new Tree(-774.4352f, 5313.969f, 76.96484f - 2f));
            Trees.Add(new Tree(-804.03955f, 5300.492f, 82.81177f - 2f));
            Trees.Add(new Tree(-819.83734f, 5287.701f, 85.2887f - 2f));
            Trees.Add(new Tree(-855.38904f, 5267.4595f, 85.62561f - 2f));
            Trees.Add(new Tree(-865.3978f, 5272.101f, 85.0022f - 2f));
            Trees.Add(new Tree(-876.8571f, 5276.914f, 85.10327f - 2f));
            Trees.Add(new Tree(-893.82855f, 5278.246f, 85.23804f - 2f));
            Trees.Add(new Tree(-896.5978f, 5273.644f, 85.62561f - 2f));
            Trees.Add(new Tree(-896.6901f, 5266.47f, 85.70984f - 2f));
            Trees.Add(new Tree(-896.3077f, 5281.398f, 84.59778f - 2f));
            Trees.Add(new Tree(-890.8088f, 5291.433f, 82.35681f - 2f));
            Trees.Add(new Tree(-908.3077f, 5288.466f, 82.019775f - 2f));
            Trees.Add(new Tree(-891.7055f, 5295.2046f, 80.89087f - 2f));

        }
    }
}
