
namespace AltVRoleplay
{
    public class ServerEnums
    {
        public enum PlayerAttachedSlots { Right_Hand, Left_Hand }
        public enum Fraktions { None, Garbage, Pd, Medic, Fire}
        public enum CheckpointEvent { None, MinijobPizza, GravelDump}
        public enum ProgressEvent { None, CutLog, ProcessingWood, SellingWood, LoadGravel, UnLoadGravel, UnLoadGarbage, SellingIron, ChangeIron, Anchor, EnterMarquis, BoatTrailer, Toolbox,
        SellFishes, SellIllegal, LoadFlatbed, UnLoadFlatbed, RepairVehicleMechanic, TuevVehicleMechanic, ChangeLockMechanic}
        public enum SkillType { Kraft}
        public enum FillType { Electro, Benzin, Diesel, Kerosin }
        public enum Items { None, GPS, VehicleKey, DrivingLicense, Perso, Weapon, Muni, AppartmentKey, Backpack, Cloth, Prop, Wood, ProcessedWood, Metall, ProcessedMetall, Fishingrod, Wurm, Made, Fish, KugelFish, Kraken,TropicalFish, Shark, Dolphin, Pickaxe, Lockpick, FirstAid, Toolbox, PatrolTank, Apple, NewHouseKey, Houselock, Cafe, Energy, Beer,Hotdog, Pizza, Cigarrets, NewVehicleKey }
        public enum Weapons { Pistol, Shotgun, M4, MicroMP}
        public enum Muni { Pistol, Shotgun, AssaultRifles, MP }
        public enum Entitys { ItemObject, Text, Ped, Object  }
        public enum Notify { Check, Info, Warning, Danger}
        public enum MiniJobs { None, Mower, Lieferant, Gravel, LumberJack}
        public enum CarHouse { Sandy, BlaineCounty, Bike, Boat }
        public enum TextLabelEvent { None, ShowApartmentHud, OpenFleecaBank, DrivingSchool, GetDrivingLicense, GetPerso, RatBike, BikeRent, EBikeRent, MiniJobGolf, MiniJobLieferant, CarHouse_CarBuy, CarSell, CarRegister, OpenWeaponShop, TreeCut, WoodJob, WoodProcessing, WoodSell, GravelSpawnDozer, GravelDump, GravelSpawnDump, SchoolBergbau, GarbageStart, GarbageUnload, IronMine, IronSell, IronChange, Wardrobe, ShopOwner, Show247Shop,
            CreateFirma, SellFishes, SellIllegal, FirmaMenu, CarDealerGetList, AdminDisconnectInfo, LTDGas }
        public enum OtherInventoryTypes { None, Wardrobe, Vehicle, Backpack, TargetPlayer, VehicleFront}
        public enum Firmen { None, Tuner, Mechanic, Taxi, Drivingschool, Logistik, CarDealer}
        public enum FirmenRanks { Praktikant, Worker, Manager, Owner}
        public enum AdminRanks { None, Supporter, Admin, Manage, Owner}
        public enum Crime { None, Anmerkung, Verbrechen, Verwarnung}

    }
}
