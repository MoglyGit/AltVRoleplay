using System.Timers;

namespace AltVRoleplay.Objects.Static
{
    public class ServerGravel
    {
        private static List<Gravel> Gravels = new List<Gravel>();
        private static System.Timers.Timer? Respawn = null;

        public static void RespawnGravel(System.Object? source, ElapsedEventArgs? e)
        {
            foreach (Gravel gravel in Gravels)
            {
                if (gravel.Object.Exists) continue;
                gravel.Respawn();
            }
        }
        public static void LoadServerGravel()
        {
            Respawn = new System.Timers.Timer(1000 * 60 * 10);
            Respawn.Elapsed += RespawnGravel;
            Respawn.AutoReset = true;
            Respawn.Enabled = true;
            Gravels.Add(new Gravel(2945.4197f, 2770.8792f, 39.1875f));//, new Rotation(0f,0f,0.1978956f) || g
            Gravels.Add(new Gravel(2943.323f, 2775.3625f, 39.204346f));//, new Rotation(0f,0f,0.49473903f) || g
            Gravels.Add(new Gravel(2939.1824f, 2780.598f, 39.440308f));//, new Rotation(0f,0f,0.69263464f) || g
            Gravels.Add(new Gravel(2936.6638f, 2784.9626f, 39.62561f));//, new Rotation(0f,0f,0.54421294f) || g
            Gravels.Add(new Gravel(2933.565f, 2790.6067f, 40.164795f));//, new Rotation(0f,0f,0.49473903f) || g
            Gravels.Add(new Gravel(2932.576f, 2795.3142f, 40.687134f));//, new Rotation(0f,0f,0.24736951f) || g
            Gravels.Add(new Gravel(2933.1033f, 2801.1428f, 41.22632f));//, new Rotation(0f,0f,-0.1978956f) || g
            Gravels.Add(new Gravel(2937.6f, 2805.2834f, 41.66443f));//, new Rotation(0f,0f,-0.8905303f) || gw
            Gravels.Add(new Gravel(2943.0461f, 2806.8132f, 41.49597f));//, new Rotation(0f,0f,-1.2863215f) || gw
            Gravels.Add(new Gravel(2946.356f, 2803.6748f, 41.31067f));//, new Rotation(0f,0f,-2.572643f) || gw
            Gravels.Add(new Gravel(2952.778f, 2800.1406f, 41.37805f));//, new Rotation(0f,0f,-2.0779037f) || gw
            Gravels.Add(new Gravel(2958.5671f, 2802.1846f, 41.66443f));//, new Rotation(0f,0f,-1.0884259f) || gw
            Gravels.Add(new Gravel(2963.3933f, 2798.9011f, 41.158936f));//, new Rotation(0f,0f,-2.3747473f) || gw
            Gravels.Add(new Gravel(2964.0923f, 2792.6506f, 40.43445f));//, new Rotation(0f,0f,2.8200123f) || gw
            Gravels.Add(new Gravel(2962.932f, 2785.49f, 39.844727f));//, new Rotation(0f,0f,2.91896f) || gw
            Gravels.Add(new Gravel(2958.6594f, 2779.9648f, 40.400757f));//, new Rotation(0f,0f,2.5231688f) || gw
            Gravels.Add(new Gravel(2954.7297f, 2783.1692f, 40.973633f));//, new Rotation(0f,0f,0.69263464f) || gw
            Gravels.Add(new Gravel(2949.9165f, 2785.622f, 40.73767f));//, new Rotation(0f,0f,1.1873736f) || gw
            Gravels.Add(new Gravel(2948.1099f, 2793.3098f, 40.670288f));//, new Rotation(0f,0f,-0.1978956f) || gw
            Gravels.Add(new Gravel(2966.413f, 2809.0022f, 42.843994f));//, new Rotation(0f,0f,-2.02843f) || gw
            Gravels.Add(new Gravel(2979.2175f, 2820.554f, 44.49524f));//, new Rotation(0f,0f,-0.94000417f) || gw
            Gravels.Add(new Gravel(2974.6155f, 2827.912f, 44.545776f));//, new Rotation(0f,0f,0.3957912f) || gw
            Gravels.Add(new Gravel(2967.323f, 2838.699f, 45.068115f));//, new Rotation(0f,0f,0.44526514f) || gw
            Gravels.Add(new Gravel(2959.1868f, 2832.079f, 45.135498f));//, new Rotation(0f,0f,2.3252733f) || gw

            Gravels.Add(new Gravel(2956.2988f, 2792.532f, 40.70398f));// new Rotation(0f,0f,-0.94000417f) || grav
            Gravels.Add(new Gravel(2970.079f, 2793.7583f, 40.518677f));// new Rotation(0f,0f,-1.7315865f) || grav
            Gravels.Add(new Gravel(2974.8528f, 2783.499f, 39.136963f));// new Rotation(0f,0f,-3.1168559f) || grav
            Gravels.Add(new Gravel(2967.745f, 2780.6375f, 38.91797f));// new Rotation(0f,0f,2.1273777f) || grav
            Gravels.Add(new Gravel(2952.8572f, 2773.8857f, 39.1875f));// new Rotation(0f,0f,2.02843f) || grav
            Gravels.Add(new Gravel(2943.9033f, 2782.655f, 39.62561f));// new Rotation(0f,0f,0.7421085f) || grav
            Gravels.Add(new Gravel(2930.5056f, 2804.756f, 41.934082f));// new Rotation(0f,0f,-0.0494739f) || grav
            Gravels.Add(new Gravel(2932.8264f, 2812.4175f, 43.5011f));// new Rotation(0f,0f,-0.69263464f) || grav
            Gravels.Add(new Gravel(2943.2175f, 2814.0923f, 42.42273f));// new Rotation(0f,0f,-1.7315865f) || grav
            Gravels.Add(new Gravel(2949.6924f, 2818.2593f, 42.45642f));// new Rotation(0f,0f,-0.7915824f) || grav
            Gravels.Add(new Gravel(2920.4307f, 2824.932f, 53.408813f));
            Gravels.Add(new Gravel(2910.91f, 2826.6858f, 53.880615f));
            Gravels.Add(new Gravel(2899.6353f, 2820.8967f, 54.116455f));
            Gravels.Add(new Gravel(2893.9648f, 2797.2131f, 54.82422f));
            Gravels.Add(new Gravel(2897.9604f, 2784.3164f, 54.554565f));
            Gravels.Add(new Gravel(2903.6836f, 2766.1978f, 53.762695f));
            Gravels.Add(new Gravel(2917.9517f, 2758.2197f, 53.526733f));
            Gravels.Add(new Gravel(2928.8835f, 2740.378f, 53.560425f));
            Gravels.Add(new Gravel(2938.945f, 2723.9077f, 54.082764f));
            Gravels.Add(new Gravel(2959.0286f, 2712.1187f, 54.790527f));
            Gravels.Add(new Gravel(2980.8f, 2714.2812f, 55.38025f));
            Gravels.Add(new Gravel(2991.9297f, 2721.0461f, 56.829346f));
            Gravels.Add(new Gravel(3006.6726f, 2728.378f, 57.435913f));
            Gravels.Add(new Gravel(3024.3032f, 2732.5847f, 61.732544f));
            Gravels.Add(new Gravel(3035.0242f, 2739.3757f, 64.1084f));
            Gravels.Add(new Gravel(3045.3098f, 2739.6265f, 64.46228f));
            Gravels.Add(new Gravel(3051.3625f, 2753.6836f, 65.65857f));
            Gravels.Add(new Gravel(3049.2263f, 2770.4307f, 68.28723f));
            Gravels.Add(new Gravel(3037.4373f, 2787.8374f, 68.43884f));
            Gravels.Add(new Gravel(3027.5342f, 2800.1538f, 67.52893f));
            Gravels.Add(new Gravel(3015.5474f, 2819.8682f, 64.125244f));
            Gravels.Add(new Gravel(3004.8264f, 2839.6353f, 62.962646f));
            Gravels.Add(new Gravel(2992.655f, 2858.3867f, 61.412476f));
            Gravels.Add(new Gravel(2994.3823f, 2885.776f, 61.210205f));
            Gravels.Add(new Gravel(2985.402f, 2894.677f, 59.71057f));
            Gravels.Add(new Gravel(2964.1714f, 2888.677f, 59.255615f));
            Gravels.Add(new Gravel(2958.0527f, 2874.224f, 58.699585f));
            Gravels.Add(new Gravel(2967.033f, 2859.389f, 57.2843f));
            Gravels.Add(new Gravel(2980.8528f, 2842.932f, 55.885742f));
            Gravels.Add(new Gravel(2988.6462f, 2826.1187f, 55.41394f));
            Gravels.Add(new Gravel(3004.0352f, 2809.4373f, 55.397095f));
            Gravels.Add(new Gravel(3008.743f, 2791.978f, 53.89746f));
            Gravels.Add(new Gravel(3022.0088f, 2771.0374f, 54.318726f));
            Gravels.Add(new Gravel(3015.178f, 2756.7034f, 53.947998f));
            Gravels.Add(new Gravel(3003.1648f, 2740.4702f, 54.352417f));

        }
    }
}
