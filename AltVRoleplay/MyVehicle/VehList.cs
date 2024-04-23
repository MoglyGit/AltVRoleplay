using static AltVRoleplay.ServerEnums;

namespace AltVRoleplay.MyVehicle
{
    public class VehList
    {
        public static List<MyVehicle> VehicleServerList = new List<MyVehicle>();
        public static void AddDbVehicle(MyVehicle veh)
        {
            VehicleServerList.Add(veh);
        }
        public static void RemoveVehicle(MyVehicle veh)
        {
            VehicleServerList.Remove(veh);
        }

        public static MyVehicle? Find(int id)
        {
            return VehicleServerList.Find(x => x.Id == id);
        }
        public static MyVehicle? Findbydbid(int id)
        {
            return VehicleServerList.Find(x => x.Dbid == id);
        }

        public static string GetFuelTypeName(ServerEnums.FillType type)
        {
            switch (type)
            {
                case ServerEnums.FillType.Benzin:
                    return "Benzin";
                case ServerEnums.FillType.Diesel:
                    return "Disel";
                case ServerEnums.FillType.Kerosin:
                    return "Kerosin";
                case ServerEnums.FillType.Electro:
                    return "Elektro";
            }
            return "Benzin";
        }
        public static int[] GetInfosFromModel(uint model)
        {
            // 0 = type, 1 = maxfill, 2 = inv Slots, 3= maxWeight
            return model switch
            {
                //adder
                3078201489 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //airbus
                1283517198 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //airtug
                1560980623 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //akula
                1181327175 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //akuma
                1672195559 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //alkonost
                3929093893 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //alpha
                767087018 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //alphaz1
                2771347558 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ambulance
                1171614426 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //annihilator
                837858166 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //annihilator2
                295054921 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //apc
                562680400 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ardent
                159274291 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //armytanker
                3087536137 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //armytrailer
                2818520053 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //armytrailer2
                2657817814 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //asbo
                1118611807 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //asea
                2485144969 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //asea2
                2487343317 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //asterope
                2391954683 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //astron
                629969764 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //autarch
                3981782132 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //avarus
                2179174271 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //avenger
                2176659152 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //avenger2
                408970549 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //avisa
                2588363614 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bagger
                2154536131 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baletrailer
                3895125590 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller
                3486135912 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller2
                142944341 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller3
                1878062887 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller4
                634118882 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller5
                470404958 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller6
                666166960 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //baller7
                359875117 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //banshee
                3253274834 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //banshee2
                633712403 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //barracks
                3471458123 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //barracks2
                1074326203 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //barracks3
                630371791 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //barrage
                4081974053 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bati
                4180675781 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bati2
                3403504941 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //benson
                2053223216 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //besra
                1824333165 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bestiagts
                1274868363 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bf400
                86520421 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bfinjection
                1126868326 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //biff
                850991848 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bifta
                3945366167 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bison
                4278019151 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bison2
                2072156101 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bison3
                1739845664 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bjxl
                850565707 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blade
                3089165662 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blazer
                2166734073 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blazer2
                4246935337 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blazer3
                3025077634 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blazer4
                3854198872 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blazer5
                2704629607 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blimp
                4143991942 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blimp2
                3681241380 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blimp3
                3987008919 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blista
                3950024287 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blista2
                1039032026 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //blista3
                3703315515 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bmx
                1131912276 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boattrailer
                524108981 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bobcatxl
                1069929536 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bodhi2
                2859047862 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bombushka
                4262088844 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boor
                996383885 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boxville
                2307837162 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boxville2
                4061868990 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boxville3
                121658888 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boxville4
                444171386 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //boxville5
                682434785 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brawler
                2815302597 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //broadway
                2361724968 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brickade
                3989239879 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brickade2
                2718380883 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brioso
                1549126457 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brioso2
                1429622905 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brioso3
                15214558 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bruiser
                668439077 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bruiser2
                2600885406 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bruiser3
                2252616474 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brutus
                2139203625 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brutus2
                2403970600 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //brutus3
                2038858402 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //btype
                117401876 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //btype2
                3463132580 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //btype3
                3692679425 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buccaneer
                3612755468 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buccaneer2
                3281516360 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buffalo
                3990165190 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buffalo2
                736902334 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buffalo3
                237764926 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buffalo4
                3675036420 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bulldozer
                1886712733 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bullet
                2598821281 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //burrito
                2948279460 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //burrito2
                3387490166 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //burrito3
                2551651283 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //burrito4
                893081117 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //burrito5
                1132262048 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //bus
                3581397346 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buzzard
                788747387 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //buzzard2
                745926877 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cablecar
                3334677549 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //caddy
                1147287684 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //caddy2
                3757070668 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //caddy3
                3525819835 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //calico
                3101054893 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //camper
                1876516712 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //caracara
                1254014755 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //caracara2
                2945871676 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //carbonizzare
                2072687711 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //carbonrs
                11251904 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargobob
                4244420235 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargobob2
                1621617168 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargobob3
                1394036463 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargobob4
                2025593404 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargoplane
                368211810 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cargoplane2
                2336777441 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //casco
                941800958 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cavalcade
                2006918058 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cavalcade2
                3505073125 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cerberus
                3493417227 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cerberus2
                679453769 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cerberus3
                1909700336 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //champion
                3379732821 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cheburek
                3306466016 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cheetah
                2983812512 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cheetah2
                223240013 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //chernobog
                3602674979 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //chimera
                6774487 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //chino
                349605904 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //chino2
                2933279331 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cinquemila
                2767531027 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cliffhanger
                390201602 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //clique
                2728360112 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //club
                2196012677 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //coach
                2222034228 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cog55
                906642318 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cog552
                704435172 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cogcabrio
                330661258 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cognoscenti
                2264796000 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cognoscenti2
                3690124666 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet2
                3249425686 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet3
                2272483501 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet4
                1561920505 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet5
                661493923 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet6
                2568944644 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //comet7
                1141395928 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //conada
                3817135397 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //contender
                683047626 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //coquette
                108773431 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //coquette2
                1011753235 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //coquette3
                784565758 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //coquette4
                2566281822 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //corsita
                3540279623 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cruiser
                448402357 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //crusader
                321739290 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cuban800
                3650256867 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cutter
                3288047904 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cyclone
                1392481335 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //cypher
                1755697647 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //daemon
                2006142190 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //daemon2
                2890830793 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deathbike
                4267640610 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deathbike2
                2482017624 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deathbike3
                2920466844 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //defiler
                822018448 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deity
                1532171089 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deluxo
                1483171323 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deveste
                1591739866 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //deviant
                1279262537 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //diablous
                4055125828 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //diablous2
                1790834270 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dilettante
                3164157193 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dilettante2
                1682114128 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dinghy
                1033245328 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dinghy2
                276773164 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dinghy3
                509498602 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dinghy4
                867467158 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dinghy5
                3314393930 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dloader
                1770332643 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //docktrailer
                2154757102 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //docktug
                3410276810 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dodo
                3393804037 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator
                80636076 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator2
                3379262425 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator3
                3308022675 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator4
                3606777648 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator5
                2919906639 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator6
                3001042683 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator7
                426742808 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dominator8
                736672010 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //double
                2623969160 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //drafter
                686471183 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //draugur
                3526730918 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dubsta
                1177543287 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dubsta2
                3900892662 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dubsta3
                3057713523 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dukes
                723973206 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dukes2
                3968823444 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dukes3
                2134119907 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dump
                2164484578 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dune
                2633113103 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dune2
                534258863 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dune3
                1897744184 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dune4
                3467805257 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dune5
                3982671785 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //duster
                970356638 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //dynasty
                310284501 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //elegy
                196747873 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //elegy2
                3728579874 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ellie
                3027423925 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //emerus
                1323778901 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //emperor
                3609690755 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //emperor2
                2411965148 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //emperor3
                3053254478 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //enduro
                1753414259 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //entity2
                2174267100 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //entity3
                1748565021 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //entityxf
                3003014393 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //esskey
                2035069708 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //eudora
                3045179290 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //euros
                2038480341 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //everon
                2538945576 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //everon2
                4163619118 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //exemplar
                4289813342 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //f620
                3703357000 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faction
                2175389151 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faction2
                2504420315 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faction3
                2255212070 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fagaloa
                1617472902 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faggio
                2452219115 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faggio2
                55628203 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //faggio3
                3005788552 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fbi
                1127131465 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fbi2
                2647026068 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fcr
                627535535 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fcr2
                3537231886 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //felon
                3903372712 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //felon2
                4205676014 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //feltzer2
                2299640309 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //feltzer3
                2728226064 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //firetruk
                1938952078 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fixter
                3458454463 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //flashgt
                3035832600 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //flatbed
                1353720154 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fmj
                1426219628 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //forklift
                1491375716 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //formula
                340154634 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //formula2
                2334210311 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fq2
                3157435195 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freecrawler
                4240635011 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freight
                1030400667 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freightcar
                184361638 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freightcar2
                3186376089 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freightcont1
                920453016 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freightcont2
                240201337 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freightgrain
                642617954 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //freighttrailer
                3517691494 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //frogger
                744705981 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //frogger2
                1949211328 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fugitive
                1909141499 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //furia
                960812448 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //furoregt
                3205927392 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //fusilade
                499169875 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //futo
                2016857647 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //futo2
                2787736776 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gargoyle
                741090084 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gauntlet
                2494797253 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gauntlet2
                349315417 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gauntlet3
                722226637 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gauntlet4
                1934384720 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gauntlet5
                2172320429 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gb200
                1909189272 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gburrito
                2549763894 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gburrito2
                296357396 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //glendale
                75131841 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //glendale2
                3381377750 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gp1
                1234311532 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //graintrailer
                1019737494 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //granger
                2519238556 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //granger2
                4033620423 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //greenwood
                40817712 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gresley
                2751205197 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //growler
                1304459735 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //gt500
                2215179066 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //guardian
                2186977100 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //habanero
                884422927 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hakuchou
                1265391242 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hakuchou2
                4039289119 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //halftrack
                4262731174 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //handler
                444583674 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hauler
                1518533038 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hauler2
                387748548 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //havok
                2310691317 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hellion
                3932816511 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hermes
                15219735 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hexer
                301427732 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hotknife
                37348240 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hotring
                1115909093 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //howard
                3287439187 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hunter
                4252008158 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //huntley
                486987393 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hustler
                600450546 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //hydra
                970385471 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ignus
                2850852987 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //imorgon
                3162245632 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //impaler
                //3001042683 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //impaler2
                1009171724 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //impaler3
                2370166601 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //impaler4
                2550461639 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //imperator
                444994115 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //imperator2
                1637620610 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //imperator3
                3539435063 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //infernus
                418536135 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //infernus2
                2889029532 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ingot
                3005245074 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //innovation
                4135840458 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //insurgent
                2434067162 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //insurgent2
                2071877360 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //insurgent3
                2370534026 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //intruder
                886934177 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi2
                3117103977 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi3
                931280609 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi4
                628003514 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi5
                1537277726 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi6
                1239571361 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi7
                1854776567 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //issi8
                1550581940 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //italigtb
                2246633323 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //italigtb2
                3812247419 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //italigto
                3963499524 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //italirsx
                3145241962 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //iwagen
                662793086 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jackal
                3670438162 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jb700
                1051415893 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jb7002
                394110044 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jester
                2997294755 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jester2
                3188613414 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jester3
                4080061290 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jester4
                2712905841 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jet
                1058115860 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jetmax
                861409633 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //journey
                4174679674 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //journey2
                2667889793 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jubilee
                461465043 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //jugular
                4086055493 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kalahari
                92612664 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kamacho
                4173521127 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kanjo
                409049982 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kanjosj
                4230891418 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //khamelion
                544021352 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //khanjali
                2859440138 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //komoda
                3460613305 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kosatka
                1336872304 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //krieger
                3630826055 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kuruma
                2922118804 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //kuruma2
                410882957 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //landstalker
                1269098716 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //landstalker2
                3456868130 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lazer
                3013282534 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //le7b
                3062131285 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lectro
                640818791 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lguard
                469291905 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //limo2
                4180339789 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lm87
                4284049613 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //locust
                3353694737 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //longfin
                1861786828 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lurcher
                2068293287 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //luxor
                621481054 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //luxor2
                3080673438 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //lynx
                482197771 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mamba
                2634021974 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mammatus
                2548391185 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //manana
                2170765704 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //manana2
                1717532765 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //manchez
                2771538552 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //manchez2
                1086534307 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //manchez3
                1384502824 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //marquis
                3251507587 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //marshall
                1233534620 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //massacro
                4152024626 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //massacro2
                3663206819 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //maverick
                2634305738 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //menacer
                2044532910 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mesa
                914654722 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mesa2
                3546958660 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mesa3
                2230595153 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //metrotrain
                868868440 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //michelli
                1046206681 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //microlight
                2531412055 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //miljet
                165154707 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //minitank
                3040635986 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //minivan
                3984502180 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //minivan2
                3168702960 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mixer
                3510150843 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mixer2
                475220373 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mogul
                3545667823 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //molotok
                1565978651 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //monroe
                3861591579 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //monster
                3449006043 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //monster3
                1721676810 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //monster4
                840387324 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //monster5
                3579220348 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //moonbeam
                525509695 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //moonbeam2
                1896491931 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mower
                1783355638 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mule
                904750859 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mule2
                3244501995 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mule3
                2242229361 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mule4
                1945374990 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //mule5
                1343932732 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nebula
                3412338231 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nemesis
                3660088182 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //neo
                2674840994 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //neon
                2445973230 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nero
                1034187331 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nero2
                1093792632 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nightblade
                2688780135 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nightshade
                2351681756 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nightshark
                433954513 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nimbus
                2999939664 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ninef
                1032823388 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ninef2
                2833484545 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //nokota
                1036591958 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //novak
                2465530446 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //omnis
                3517794615 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //omnisegt
                3789743831 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //openwheel1
                1492612435 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //openwheel2
                1181339704 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //oppressor
                884483972 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //oppressor2
                2069146067 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //oracle
                1348744438 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //oracle2
                3783366066 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //osiris
                1987142870 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //outlaw
                408825843 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //packer
                569305213 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //panthere
                2100457220 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //panto
                3863274624 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //paradise
                1488164764 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //paragon
                3847255899 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //paragon2
                1416466158 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pariah
                867799010 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //patriot
                3486509883 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //patriot2
                3874056184 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //patriot3
                3624880708 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //patrolboat
                4018222598 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pbus
                2287941233 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pbus2
                345756458 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pcj
                3385765638 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //penetrator
                2536829930 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //penumbra
                3917501776 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //penumbra2
                3663644634 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //peyote
                1830407356 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //peyote2
                2490551588 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //peyote3
                1107404867 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pfister811
                2465164804 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //phantom
                2157618379 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //phantom2
                2645431192 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //phantom3
                177270108 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //phoenix
                2199527893 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //picador
                1507916787 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pigalle
                1078682497 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //police
                2046537925 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //police2
                2667966721 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //police3
                1912215274 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //police4
                2321795001 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //policeb
                4260343491 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //policeold1
                2758042359 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //policeold2
                2515846680 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //policet
                456714581 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //polmav
                353883353 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pony
                4175309224 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pony2
                943752001 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //powersurge
                2908631255 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //postlude
                4000288633 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pounder
                2112052861 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pounder2
                1653666139 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //prairie
                2844316578 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pranger
                741586030 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //predator
                3806844075 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //premier
                2411098011 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //previon
                1416471345 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //primo
                3144368207 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //primo2
                2254540506 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //proptrailer
                356391690 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //prototipo
                2123327359 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //pyro
                2908775872 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //r300
                1076201208 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //radi
                2643899483 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //raiden
                2765724541 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //raketrailer
                390902130 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rallytruck
                2191146052 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rancherxl
                1645267888 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rancherxl2
                1933662059 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rapidgt
                2360515092 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rapidgt2
                1737773231 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rapidgt3
                2049897956 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //raptor
                3620039993 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ratbike
                1873600305 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ratloader
                3627815886 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ratloader2
                3705788919 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rcbandito
                4008920556 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //reaper
                234062309 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rebel
                3087195462 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rebel2
                2249373259 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rebla
                83136452 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //reever
                1993851908 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //regina
                4280472072 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //remus
                1377217886 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rentalbus
                3196165219 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //retinue
                1841130506 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //retinue2
                2031587082 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //revolter
                3884762073 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rhapsody
                841808271 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rhinehart
                2439462158 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rhino
                782665360 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //riata
                2762269779 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //riot
                3089277354 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //riot2
                2601952180 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ripley
                3448987385 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rocoto
                2136773105 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rogue
                3319621991 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //romero
                627094268 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rrocket
                916547552 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rt3000
                3842363289 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rubble
                2589662668 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruffian
                3401388520 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruiner
                4067225593 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruiner2
                941494461 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruiner3
                777714999 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruiner4
                1706945532 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rumpo
                1162065741 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rumpo2
                2518351607 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //rumpo3
                1475773103 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ruston
                719660200 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //s80
                3970348707 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sabregt
                2609945748 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sabregt2
                223258115 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sadler
                3695398481 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sadler2
                734217681 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sanchez
                788045382 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sanchez2
                2841686334 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sanctus
                1491277511 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sandking
                3105951696 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sandking2
                989381445 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //savage
                4212341271 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //savestra
                903794909 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sc1
                1352136073 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scarab
                3147997943 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scarab2
                1542143200 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scarab3
                3715219435 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schafter2
                3039514899 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schafter3
                2809443750 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schafter4
                1489967196 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schafter5
                3406724313 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schafter6
                1922255844 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schlagen
                3787471536 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //schwarzer
                3548084598 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scorcher
                4108429845 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scramjet
                3656405053 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //scrap
                2594165727 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seabreeze
                3902291871 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seashark
                3264692260 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seashark2
                3678636260 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seashark3
                3983945033 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seasparrow
                3568198617 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seasparrow2
                1229411063 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seasparrow3
                1593933419 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seminole
                1221512915 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seminole2
                2484160806 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sentinel
                1349725314 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sentinel2
                873639469 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sentinel3
                1104234922 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sentinel4
                2938086457 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //serrano
                1337041428 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //seven70
                2537130571 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //shamal
                3080461301 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sheava
                819197656 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sheriff
                2611638396 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sheriff2
                1922257928 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //shinobi
                1353120668 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //shotaro
                3889340782 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //skylift
                1044954915 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamtruck
                3249056020 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan
                729783779 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan2
                833469436 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan3
                1119641113 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan4
                2233918197 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan5
                373261600 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //slamvan6
                1742022738 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sm722
                775514032 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sovereign
                743478836 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //specter
                1886268224 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //specter2
                1074745671 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //speeder
                231083307 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //speeder2
                437538602 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //speedo
                3484649228 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //speedo2
                728614474 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //speedo4
                219613597 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //squaddie
                4192631813 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //squalo
                400514754 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stafford
                321186144 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stalion
                1923400478 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stalion2
                3893323758 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stanier
                2817386317 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //starling
                2594093022 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stinger
                1545842587 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stingergt
                2196019706 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stockade
                1747439474 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stockade3
                4080511798 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stratum
                1723137093 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //streiter
                1741861769 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stretch
                2333339779 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //strikeforce
                1692272545 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stromberg
                886810209 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stryder
                301304410 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //stunt
                2172210288 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //submersible
                771711535 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //submersible2
                3228633070 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sugoi
                987469656 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sultan
                970598228 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sultan2
                872704284 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sultan3
                4003946083 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //sultanrs
                3999278268 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //suntrap
                4012021193 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //superd
                1123216662 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //supervolito
                710198397 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //supervolito2
                2623428164 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //surano
                384071873 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //surfer
                699456151 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //surfer2
                2983726598 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //surfer3
                3259477733 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //surge
                2400073108 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //swift
                3955379698 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //swift2
                1075432268 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //swinger
                500482303 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //t20
                1663218586 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //taco
                1951180813 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tahoma
                3833117047 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tailgater
                3286105550 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tailgater2
                3050505892 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //taipan
                3160260734 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tampa
                972671128 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tampa2
                3223586949 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tampa3
                3084515313 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tanker
                3564062519 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tanker2
                1956216962 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tankercar
                586013744 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //taxi
                3338918751 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //technical
                2198148358 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //technical2
                1180875963 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //technical3
                1356124575 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tempesta
                272929391 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tenf
                3400983137 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tenf2
                274946574 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //terbyte
                2306538597 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tezeract
                1031562256 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //thrax
                1044193113 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //thrust
                1836027715 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //thruster
                1489874736 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tigon
                2936769864 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tiptruck
                48339065 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tiptruck2
                3347205726 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //titan
                1981688531 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //toreador
                1455990255 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //torero
                1504306544 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //torero2
                4129572538 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado
                464687292 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado2
                1531094468 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado3
                1762279763 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado4
                2261744861 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado5
                2497353967 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tornado6
                2736567667 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //toro
                1070967343 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //toro2
                908897389 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //toros
                3126015148 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tourbus
                1941029835 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //towtruck
                2971866336 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //towtruck2
                3852654278 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tr2
                2078290630 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tr3
                1784254509 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tr4
                2091594960 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tractor
                1641462412 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tractor2
                2218488798 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tractor3
                1445631933 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailerlarge
                1502869817 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailerlogs
                2016027501 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailers
                3417488910 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailers2
                2715434129 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailers3
                2236089197 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailers4
                3194418602 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailersmall
                712162987 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trailersmall2
                2413121211 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trash
                1917016601 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trash2
                3039269212 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trflat
                2942498482 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tribike
                1127861609 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tribike2
                3061159916 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tribike3
                3894672200 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trophytruck
                101905590 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //trophytruck2
                3631668194 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tropic
                290013743 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tropic2
                1448677353 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tropos
                1887331236 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tug
                2194326579 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tula
                1043222410 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tulip
                1456744817 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tulip2
                268758436 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //turismo2
                3312836369 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //turismor
                408192225 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tvtrailer
                2524324030 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tyrant
                3918533058 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //tyrus
                2067820283 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //utillitruck
                516990260 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //utillitruck2
                887537515 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //utillitruck3
                2132890591 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vacca
                338562499 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vader
                4154065143 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vagner
                1939284556 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vagrant
                740289177 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //valkyrie
                2694714877 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //valkyrie2
                1543134283 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vamos
                4245851645 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vectre
                2754593701 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //velum
                2621610858 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //velum2
                1077420264 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //verlierer2
                1102544804 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //verus
                298565713 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vestra
                1341619767 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vetir
                2014313426 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //veto
                3437611258 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //veto2
                2802050217 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vigero
                3469130167 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vigero2
                2536587772 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vigilante
                3052358707 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vindicator
                2941886209 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //virgo
                3796912450 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //virgo2
                3395457658 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //virgo3
                16646064 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //viseris
                3903371924 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //visione
                3296789504 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //virtue
                669204833 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //volatol
                447548909 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //volatus
                2449479409 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //voltic
                2672523198 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //voltic2
                989294410 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //voodoo
                2006667053 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //voodoo2
                523724515 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vortex
                3685342204 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //vstr
                1456336509 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //warrener
                579912970 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //washington
                1777363799 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //wastelander
                2382949506 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //weevil
                1644055914 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //weevil2
                3300595976 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //windsor
                1581459400 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //windsor2
                2364918497 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //winky
                4084658662 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //wolfsbane
                3676349299 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //xa21
                917809321 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //xls
                1203490606 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //xls2
                3862958888 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //yosemite
                1871995513 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //yosemite2
                1693751655 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //yosemite3
                67753863 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //youga
                65402552 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //youga2
                1026149675 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //youga3
                1802742206 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //youga4
                1486521356 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //z190
                838982985 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zeno
                655665811 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zentorno
                2891838741 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zhaba
                1284356689 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zion
                3172678083 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zion2
                3101863448 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zion3
                1862507111 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zombiea
                3285698347 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zombieb
                3724934023 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zorrusso
                3612858749 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zr350
                2436313176 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zr380
                540101442 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zr3802
                3188846534 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //zr3803
                2816263004 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //ztype
                758895617 => new int[] { (int)FillType.Benzin, 60, 14, 20 },
                //Default
                _ => new int[] { (int)FillType.Benzin, 60, 7, 10 }
            };
        }
    }
}
