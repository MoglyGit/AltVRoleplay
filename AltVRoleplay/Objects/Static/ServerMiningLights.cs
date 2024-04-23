
using AltV.Net;

namespace AltVRoleplay.Objects.Static
{
    public class ServerMiningLights
    {
        private static List<Object> MiningLights = new List<Object>();
        public static bool Streamed = false;
        public static void LoadLights()
        {
            if (Streamed) return;
            Streamed = true;
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -593.94727f, 2086.1406f, 130.54138f, 0, 0, -30));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -592.39124f, 2080.2593f, 130.38977f, 0, 0, -30));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -590.5055f, 2073.3494f, 130.23804f, 0, 0, -30));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -587.9209f, 2060.7034f, 129.74951f, 0, 0, -30));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -586.74725f, 2050.5627f, 129.12598f, 0, 0, -30));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -583.2132f, 2041.9385f, 128.19922f, 0, 0, -10));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -577.9121f, 2033.4198f, 127.44104f, 0, 0, -10));

            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -510.17142f, 1894.8264f, 120.684204f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -505.2132f, 1892.611f, 120.448364f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -500.47913f, 1894.378f, 120.07764f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -493.05493f, 1892.8484f, 119.369995f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -485.98682f, 1895.5912f, 119.167725f, 0, 0, 90));

            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -521.53845f, 1895.0374f, 121.45935f, 0, 0, -180));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -530.2022f, 1899.0725f, 122.03223f, 0, 0, -180));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -537.38904f, 1903.9517f, 122.116455f, 0, 0, -180));

            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -538.6022f, 1912.4572f, 122.57141f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -536.5582f, 1923.5472f, 123.32971f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -536.62415f, 1933.978f, 124.10474f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -539.578f, 1946.1758f, 125.065186f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -542.2022f, 1958.189f, 125.587524f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -544.04834f, 1973.8813f, 126.00879f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -547.4374f, 1986.3561f, 126.22778f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -552.7121f, 1996.589f, 126.12671f, 0, 0, 90));
            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -559.4901f, 2008.1538f, 126.19409f, 0, 0, 90));

            MiningLights.Add(new Object(Alt.Hash("xm_prop_lab_wall_lampa"), 0, 70, -568.76044f, 2019.5472f, 126.59851f, 0, 0, 150));
        }

        public static void DeleteLights()
        {
            if (!Streamed) return;
            foreach (Object lamp in MiningLights)
            {
                lamp.Destroy();
            }
            Streamed = false;
        }
    }
}
