using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.SQL
{
    class DataGet
    {
        //Props
        public static string GetPropString(MyPlayer.Player player, byte componente)
        {
            return "" + player.GetProps(componente).Drawable + "|" + player.GetProps(componente).Texture + "|";
        }
    }
}
