using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Objects
{
    public class ObjectLists
    {
        public static List<Tree> TreeServerList = new List<Tree>();
        public static List<Logs> LogServerList = new List<Logs>();
        public static List<Gravel> GravelServerList = new List<Gravel>();
        public static void AddTree(Tree item)
        {
            TreeServerList.Add(item);
        }
        public static void RemoveTree(Tree item)
        {
            TreeServerList.Remove(item);
        }
        public static void AddLog(Logs item)
        {
            LogServerList.Add(item);
        }
        public static void RemoveLog(Logs item)
        {
            LogServerList.Remove(item);
        }
        public static void AddGravel(Gravel item)
        {
            GravelServerList.Add(item);
        }
        public static void RemoveGravel(Gravel item)
        {
            GravelServerList.Remove(item);
        }
    }
}
