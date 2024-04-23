using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay.Items
{
    public class WeaponInfo
    {
        public static int GetWeaponType(string name)
        {
            if (name == "weapon_pistol") return (int)ServerEnums.Muni.Pistol;//pistols = 1
            if (name == "weapon_heavyrifle") return (int)ServerEnums.Muni.AssaultRifles;//assaults = 2
            if (name == "weapon_pumpshotgun") return (int)ServerEnums.Muni.Shotgun; //shotguns =3
            if (name == "weapon_microsmg") return (int)ServerEnums.Muni.MP; //shotguns =4
            return 0;
        }

        public static int GetWeaponClip(int munitype)
        {
            if (munitype == (int)ServerEnums.Muni.Pistol) return 12;//pistols = 1
            if (munitype == (int)ServerEnums.Muni.AssaultRifles) return 30;//assaults = 2
            if (munitype == (int)ServerEnums.Muni.Shotgun) return 8;//assaults = 2
            if (munitype == (int)ServerEnums.Muni.MP) return 16;//assaults = 2
            return 0;
        }
        public static string GetWeaponDescription(string name)
        {
            if (name == "weapon_pistol") return "Pistole";
            if (name == "weapon_heavyrifle") return "Assault Rifle";
            if (name == "weapon_pumpshotgun") return "Pump Shotgun";
            if (name == "weapon_microsmg") return "Micro MG";
            return "Unbekannte Waffe";
        }
    }
}
