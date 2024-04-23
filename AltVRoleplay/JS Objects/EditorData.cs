using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.JS_Objects
{
    internal class EditorData
    {
        public string crime { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public int age { get; set; }
        public int height { get; set; }
        public int shapeFirstID { get; set; }
        public int shapeSecondID { get; set; }
        public int shapeThirdID { get; set; }
        public int skinFirstID { get; set; }
        public int skinSecondID { get; set; }
        public int skinThirdID { get; set; }
        public float shapeMix { get; set; }
        public float skinMix { get; set; }
        public int thirdMix { get; set; }
        public int sex { get; set; }
        public bool isParent { get; set; }

        public int haircolor { get; set; }
        public int hairtint { get; set; }
        public int rpszenario { get; set; }

        public int[] clothes { get; set; }
        public int[] clothestext { get; set; }

        public int eyecolor { get; set; }

        public int[] overlaytint { get; set; }
        public float[] micro { get; set; }
        public int[] head { get; set; }
        public float[] opa { get; set; }
    }
}
