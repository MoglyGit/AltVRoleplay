using AltVRoleplay.Ped;

namespace AltVRoleplay
{
    public static class ServerMoney
    {
        public static int[] JobMoneyMax = new int[Enum.GetNames(typeof(ServerEnums.MiniJobs)).Length];
        public static int FreeMoney = 1500;
        public static int WoodCourse = 0;
        public static int WoodCourseUpdate = 1000;
        public static void Load()
        {
            JobMoneyMax[(int)ServerEnums.MiniJobs.Mower] = 150;
            JobMoneyMax[(int)ServerEnums.MiniJobs.Lieferant] = 150;
            JobMoneyMax[(int)ServerEnums.MiniJobs.Gravel] = 500;
            JobMoneyMax[(int)ServerEnums.MiniJobs.LumberJack] = 1500;
        }

        public static void UpdateWoodStorage(int x)
        {
            WoodCourseUpdate -= x;
            if(WoodCourseUpdate <= 0)
            {
                WoodCourseUpdate = 1000;
                if (WoodCourse > 1) WoodCourse -= 1;
            }
        }
    }
}
