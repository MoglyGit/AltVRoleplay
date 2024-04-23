
using AltVRoleplay.Appartments;

namespace AltVRoleplay.Items
{
    public class Items
    {
        public int Id { get; set; }
        public int Businesskey { get; set; }
        public int Vehkey { get; set; }
        public string Weapons { get; set; }
        public int Housekey { get; set; }
        public int Backpack { get; set; }
        public int Clothes { get; set; }
        public int Prop { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int Munitype { get; set; }
        public int Objhash { get; set; }

        public int Drivinglicense { get; set; }
        public int Perso { get; set; }
        public ServerEnums.Items Serveritem { get; set; }
        public float Mass { get; set; }
        public int MaxAmount { get; set; }
        public Items()
        {
            Serveritem = (int)ServerEnums.Items.None;
            Id = 0;
            Businesskey = 0;
            Vehkey = 0;
            Weapons = "-1";
            Housekey = 0;
            Backpack = 0;
            Clothes = 0;
            Amount = 1;
            Prop = 0;
            Munitype = -1;
            Description = "Ein normales Item";
            Objhash=0;
            Perso = 0;
            Drivinglicense = 0;
            Mass = 0.1f;
            MaxAmount = 1;
        }
        public Items(Items item, int amount)
        {
            Serveritem = item.Serveritem;
            Businesskey = item.Businesskey;
            Vehkey = item.Vehkey;
            Weapons = item.Weapons;
            Housekey = item.Housekey;
            Backpack = item.Backpack;
            Clothes = item.Clothes;
            Amount = amount;
            Prop = item.Prop;
            Munitype = item.Munitype;
            Description = item.Description;
            Objhash = item.Objhash;
            Perso = item.Perso;
            Drivinglicense = item.Drivinglicense;
            Mass = item.Mass;
            MaxAmount = item.MaxAmount;
            Id = Database.CreateItem(this);
            ItemList.AddItem(this);
        }

        public void CreateItem(ServerEnums.Items item, int amount=1)
        {
            Amount = 1;
            MaxAmount = 1;
            switch (item)
            {
                //Pickaxe, Lockpick, FirstAid, Toolbox, PatrolTank, Apple, NewHouseKey, Houselock, Cafe, Energy, Beer,Hotdog, Pizza, Cigarrets
                case ServerEnums.Items.Cigarrets:
                    Serveritem = ServerEnums.Items.Cigarrets;
                    Description = "Zigarretten";
                    Objhash = 1120955680;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.Pizza:
                    Serveritem = ServerEnums.Items.Pizza;
                    Description = "Pizza";
                    Objhash = 1120955680;
                    MaxAmount = 10;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Hotdog:
                    Serveritem = ServerEnums.Items.Hotdog;
                    Description = "Hotdog";
                    Objhash = -1729226035;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.Beer:
                    Serveritem = ServerEnums.Items.Beer;
                    Description = "Bier";
                    Objhash = 1451528099;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.25f;
                    break;
                case ServerEnums.Items.Energy:
                    Serveritem = ServerEnums.Items.Energy;
                    Description = "Energy";
                    Objhash = 1489222168;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.25f;
                    break;
                case ServerEnums.Items.Cafe:
                    Serveritem = ServerEnums.Items.Cafe;
                    Description = "Kaffe";
                    Objhash = 692778550;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.25f;
                    break;
                case ServerEnums.Items.Houselock:
                    Serveritem = ServerEnums.Items.Houselock;
                    Description = "Neues Türschloss";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.NewHouseKey:
                    Serveritem = ServerEnums.Items.NewHouseKey;
                    Description = "Neuer Schlüssel";
                    Objhash = 494219267;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Apple:
                    Serveritem = ServerEnums.Items.Apple;
                    Description = "Apfel";
                    Objhash = -2071489092;
                    MaxAmount = 20;
                    Amount = amount;
                    Mass = 0.08f;
                    break;
                case ServerEnums.Items.PatrolTank:
                    Serveritem = ServerEnums.Items.PatrolTank;
                    Description = "Benzinkanister Leer";
                    Objhash = -963445391;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Toolbox:
                    Serveritem = ServerEnums.Items.Toolbox;
                    Description = "Werkzeugkasten";
                    Objhash = 1871266393;
                    MaxAmount = 3;
                    Amount = amount;
                    Mass = 0.8f;
                    break;
                case ServerEnums.Items.FirstAid:
                    Serveritem = ServerEnums.Items.FirstAid;
                    Description = "Erstehilfekasten";
                    Objhash = -2140074399;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.5f;
                    break;
                case ServerEnums.Items.Lockpick:
                    Serveritem = ServerEnums.Items.Lockpick;
                    Description = "Lockpick";
                    Objhash = -1134789989;
                    MaxAmount = 15;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Pickaxe:
                    Serveritem = ServerEnums.Items.Pickaxe;
                    Description = "Spitzhacke";
                    Objhash = 260873931;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 1.5f;
                    break;
                case ServerEnums.Items.Shark:
                    Serveritem = ServerEnums.Items.Shark;
                    Description = "Baby Hai";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Dolphin:
                    Serveritem = ServerEnums.Items.Dolphin;
                    Description = "Baby Delfin";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Kraken:
                    Serveritem = ServerEnums.Items.Kraken;
                    Description = "Kraken";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.TropicalFish:
                    Serveritem = ServerEnums.Items.TropicalFish;
                    Description = "Tropischen Fisch";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.KugelFish:
                    Serveritem = ServerEnums.Items.KugelFish;
                    Description = "Kugel Fisch";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Fish:
                    Serveritem = ServerEnums.Items.Fish;
                    Description = "Fisch";
                    Objhash = -1134789989;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Wurm:
                    Serveritem = ServerEnums.Items.Wurm;
                    Description = "Wurm";
                    Objhash = -1134789989;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.01f;
                    break;
                case ServerEnums.Items.Made:
                    Serveritem = ServerEnums.Items.Made;
                    Description = "Made";
                    Objhash = -1134789989;
                    MaxAmount = 5;
                    Amount = amount;
                    Mass = 0.01f;
                    break;
                case ServerEnums.Items.Fishingrod:
                    Serveritem = ServerEnums.Items.Fishingrod;
                    Description = "Angel";
                    Objhash = -1910604593;
                    MaxAmount = 1;
                    Amount = amount;
                    Mass = 0.3f;
                    break;
                case ServerEnums.Items.Metall:
                    Serveritem = ServerEnums.Items.Metall;
                    Description = "Unbearbeitetes Eisen";
                    Objhash = -1134789989;
                    MaxAmount = 100;
                    Amount = amount;
                    Mass = 0.4f;
                    break;
                case ServerEnums.Items.ProcessedMetall:
                    Serveritem = ServerEnums.Items.ProcessedMetall;
                    Description = "Verarbeitetes Eisen";
                    Objhash = -1134789989;
                    MaxAmount = 100;
                    Amount = amount;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.ProcessedWood:
                    Serveritem = ServerEnums.Items.ProcessedWood;
                    Description = "Verarbeitetes Holz";
                    Objhash = -1996501787;
                    MaxAmount = 100;
                    Amount = amount;
                    Mass = 0.1f;
                    break;
                case ServerEnums.Items.Wood:
                    Serveritem = ServerEnums.Items.Wood;
                    Description = "Unbearbeitetes Holz";
                    Objhash = -1996501787;
                    MaxAmount = 100;
                    Amount = amount;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.GPS:
                    Serveritem = ServerEnums.Items.GPS;
                    Description = "GPS gerät";
                    Objhash = -1585232418;
                    Mass = 0.4f;
                    break;
                case ServerEnums.Items.VehicleKey:
                    Serveritem = ServerEnums.Items.VehicleKey;
                    Objhash = 977923025;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.NewVehicleKey:
                    Serveritem = ServerEnums.Items.NewVehicleKey;
                    Description = "Neuer Schlüssel";
                    Objhash = 977923025;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.DrivingLicense:
                    Serveritem = ServerEnums.Items.DrivingLicense;
                    Objhash = 292851939;
                    Mass = 0.3f;
                    break;
                case ServerEnums.Items.Perso:
                    Serveritem = ServerEnums.Items.Perso;
                    Objhash = 292851939;
                    Mass = 0.3f;
                    break;
                case ServerEnums.Items.Weapon:
                    Serveritem = ServerEnums.Items.Weapon;
                    break;
                case ServerEnums.Items.Muni:
                    Serveritem = ServerEnums.Items.Muni;
                    Amount = WeaponInfo.GetWeaponClip(Munitype);
                    MaxAmount = Amount;
                    Description = "Munition";
                    break;
                case ServerEnums.Items.AppartmentKey:
                    Serveritem = ServerEnums.Items.AppartmentKey;
                    Mass = 0.2f;
                    break;
                case ServerEnums.Items.Backpack:
                    Serveritem = ServerEnums.Items.Backpack;
                    Mass = 0.0f;
                    break;
                case ServerEnums.Items.Cloth:
                    Serveritem = ServerEnums.Items.Cloth;
                    Mass = 0.25f;
                    break;
                case ServerEnums.Items.Prop:
                    Serveritem = ServerEnums.Items.Prop;
                    Mass = 0.15f;
                    break;
            }
            if(amount > MaxAmount)Amount = MaxAmount;
            Id = Database.CreateItem(this);
            ItemList.AddItem(this);
        }
        public void CreateBackpack(int backid, int size)
        {
            Backpack = backid;
            Description = "Rucksack größe " + size;
            Objhash = 1203231469;
            switch (size)
            {
                case 1:
                    Objhash = 1203231469;
                    break;
                case 2:
                    Objhash = 2096599423;
                    break;
            }
            CreateItem(ServerEnums.Items.Backpack);
        }
        public void CreateAppartmentKey(Appartment a)
        {
            Housekey = a.id;
            Description = "Wohnungsschlüssel " + a.name;
            Objhash = 494219267;
            CreateItem(ServerEnums.Items.AppartmentKey);
        }
        public void CreateMuni(ServerEnums.Muni muni)
        {
            switch (muni)
            {
                case ServerEnums.Muni.Pistol:
                    Objhash = -1899196150;
                    Mass = 0.03f;
                    break;
                case ServerEnums.Muni.AssaultRifles:
                    Objhash = 1044133150;
                    Mass = 0.06f;
                    break;
                case ServerEnums.Muni.Shotgun:
                    Objhash = -1793660294;
                    Mass = 0.05f;
                    break;
                case ServerEnums.Muni.MP:
                    Objhash = -177292685;
                    Mass = 0.04f;
                    break;
                default:
                    muni = ServerEnums.Muni.Pistol;
                    Objhash = -1899196150;
                    Mass = 0.03f;
                    break;
            }
            Munitype = (int)muni;
            CreateItem(ServerEnums.Items.Muni);
        }
        public void CreateWepon(ServerEnums.Weapons weapon)
        {
            switch (weapon)
            {
                case ServerEnums.Weapons.Pistol:
                    Weapons = "weapon_pistol";
                    Objhash = 1467525553;
                    Mass = 0.6f;
                    break;
                case ServerEnums.Weapons.M4:
                    Weapons = "weapon_heavyrifle";
                    Objhash = 273925117;
                    Mass = 2.9f;
                    break;
                case ServerEnums.Weapons.Shotgun:
                    Weapons = "weapon_pumpshotgun";
                    Objhash = 689760839;
                    Mass = 1.8f;
                    break;
                case ServerEnums.Weapons.MicroMP:
                    Weapons = "weapon_microsmg";
                    Objhash = -1056713654;
                    Mass = 1.2f;
                    break;
                default:
                    Weapons = "weapon_pistol";
                    Objhash = 1467525553;
                    Mass = 0.6f;
                    break;
            }
            Description = WeaponInfo.GetWeaponDescription(Weapons);
            CreateItem(ServerEnums.Items.Weapon);
        }

        public void CreateVehicleKey(MyVehicle.MyVehicle veh)
        {
            Vehkey = veh.Dbid;
            Description = "Fahrzeugschlüssel ("+Vehkey+")";
            CreateItem(ServerEnums.Items.VehicleKey);
        }

        public void CreateDrivingLicense(MyPlayer.Player player, DrivingLicense p)
        {
            Drivinglicense = p.id;
            Description = "Fuehrerschein " + player.Fname + " " + player.Lname;
            CreateItem(ServerEnums.Items.DrivingLicense);
        }

        public void CreatePerso(MyPlayer.Player player, Perso p)
        {
            Perso = p.id;
            Description = "Ausweis " + p.Fname + " " + p.Lname;
            CreateItem(ServerEnums.Items.Perso);
        }

        public void SaveItem()
        {
            if(Amount == 0)
            {
                Remove();
                return;
            }
            Database.SaveItem(this);
        }

        public void Remove()
        {
            ItemList.RemoveItem(this);
            Database.DeleteItem(this);
        }
    }
}
