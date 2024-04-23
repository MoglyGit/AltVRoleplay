using AltV.Net.Elements.Entities;
using AltV.Net;
using AltV.Net.Enums;
using System.Timers;
using AltVRoleplay.SQL.Inventory;

namespace AltVRoleplay.MyVehicle
{
    public class MyVehicle : Vehicle, IInventory
    {
        private string syncedFill = "Fill";
        public string? VehName { get; set; }
        public int Dbid { get; set; }

        public ulong RentOwner { get; set; }

        public int Range { get; set; }

        public int Price { get; set; }
        private System.Timers.Timer? FTimer;
        private System.Timers.Timer? NosTimer;
        public string? OwnerName { get; set; }
        public ulong OwnerSocialclubId { get; set; }
        public int FillMax { get; set; }
        public ServerEnums.FillType FillType { get; set; }
        public int FactionId { get; set; }
        public int[] Inv { get; set; }
        public int[] FrontInv { get; set; }
        public float MaxWeightFront = 10;
        public float MaxWeight { get; set; }
        public MyPlayer.Player? TrunkUsedBy { get; set; }
        public MyPlayer.Player? HandschuhfachUsedBy { get; set; }
        public bool MotorDamage { get; set; }
        public bool Death { get; set; }
        private bool CanUseNose;
        public int NosCharges { get; set; }
        public DateTime Tuev { get; set; }

        public MyVehicle(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
            Tuev = new DateTime(1995,3,10,10,12,30);
            MotorDamage = false;
            Death = false;
            Inv = new int[1];
            FrontInv = new int[4];
            MaxWeight = 10;
            TrunkUsedBy = null;
            HandschuhfachUsedBy = null;

            NosCharges = 0;
            CanUseNose = true;
            NosTimer = null;

            FTimer = new System.Timers.Timer(15000);
            FTimer.Elapsed += LoseFill;
            FTimer.AutoReset = true;
            FTimer.Enabled = true;

            NumberplateText = "New";
            OwnerName = "Niemand";
            OwnerSocialclubId = 0;

            Dbid = -1;
            ManualEngineControl = true;
            RentOwner = 0;
            LockState = VehicleLockState.Locked;
            Range = 0;
            Price = 0;
            FactionId=0;
            ModKit = 1;
        }
        public void Sync()
        {
            SetSyncedMetaData("blinker", 0);
            SetSyncedMetaData("Range", 0);
            int[] stats = VehList.GetInfosFromModel(Model);
            SetSyncedMetaData("FillType", stats[0]);
            SetSyncedMetaData(syncedFill, (float)stats[1]);
            Server.Log("syncedMeta: "+ HasSyncedMetaData(syncedFill));
            FillMax = stats[1];
            FillType = (ServerEnums.FillType)stats[0];
            Inv = new int[stats[2]];
            MaxWeight = stats[3];
        }
        public void LoseFill(System.Object? source, ElapsedEventArgs? e)
        {
            if (!CanUseNose)
            {
                CanUseNose = true;
                Random rnd = new Random();
                if(rnd.Next(100) <= 4)
                {
                    MotorDamage = true;
                    EngineOn = false;
                    EngineHealth -= 300;
                    if(Driver != null)
                    {
                        MyPlayer.Player player = (MyPlayer.Player)Driver;
                        player.Notification(ServerEnums.Notify.Danger, "Motor überhitzt");
                    }
                }
            }
            if (!Exists && FTimer != null)
            {
                FTimer.Stop();
                FTimer.Dispose();
                FTimer.Enabled = false;
                FTimer = null;
                Exists = false;
                return;
            }
            if (!EngineOn) return;
            Random randomFill = new Random();
            float f = randomFill.Next(1,5) * 0.1f;
            AddFill(-f);
        }

        public void SetChipSpeed(int x)
        {
            if (x <= 0)
            {
                if(HasSyncedMetaData("SpeedBoost")) DeleteSyncedMetaData("SpeedBoost");
            }
            else SetSyncedMetaData("SpeedBoost", x);
        }

        public void SetNosCharges(int x)
        {
            NosCharges = x;
            SetSyncedMetaData("NosCharges",x);
        }

        public bool UseNos()
        {
            if (HasSyncedMetaData("NosBoost") || !CanUseNose || NosCharges == 0) return false;
            int charges = NosCharges - 1;
            SetNosCharges(charges);
            if (NosCharges < 0) NosCharges = 0;
            CanUseNose = false;
            SetSyncedMetaData("NosBoost", 100);
            NosTimer = new System.Timers.Timer(3500);
            NosTimer.Elapsed += StopUseNos;
            NosTimer.AutoReset = true;
            NosTimer.Enabled = true;
            return true;
        }
        public void StopUseNos(System.Object? source, ElapsedEventArgs? e)
        {
            if (NosTimer == null) return;
            DeleteSyncedMetaData("NosBoost");
            NosTimer.Stop();
            NosTimer.Dispose();
            NosTimer.Enabled = false;
            NosTimer = null;
        }

        public void Lock(VehicleLockState l)
        {
            if (!Exists) return;
            LockState = l;
        }

        public void SetRange(int r)
        {
            if (!Exists) return;
            Range = r;
            SetSyncedMetaData("Range", r);
        }
        public float GetFill()
        {
            if (!Exists) return 0;
            if (!HasSyncedMetaData(syncedFill)) return 0;
            if(GetSyncedMetaData(syncedFill, out float fill))
            {
                return fill;
            }
            return 0;
        }
        public void SetFill(float f)
        {
            if (!Exists) return;
            if (f >= FillMax)
            {
                SetSyncedMetaData(syncedFill, (float)FillMax);
                return;
            }
            if (f <= 0)
            {
                SetSyncedMetaData(syncedFill, (float)0f);
                return;
            }
            SetSyncedMetaData(syncedFill, f);
        }

        public void AddFill(float f)
        {
            if (!Exists) return;
            if (f == 0) return;
            if (!EngineOn) return;
            float fill = GetFill();
            if ((fill + f) <= 2)
            {
                fill = 0;
                EngineOn = false;
                SetSyncedMetaData(syncedFill, (float)fill);
                return;
            }
            if((fill + f) >= FillMax)
            {
                fill = FillMax;
                SetSyncedMetaData(syncedFill, (float)fill);
                return;
            }
            fill += f;
            SetSyncedMetaData(syncedFill, (float)fill);
        }
        public void Save()
        {
            Database.SaveVehicle(this);
        }
        public void RemoveFromGame()
        {
            Database.DeleteVehicle(this);
            DeleteSyncedMetaData(syncedFill);
            Destroy();
            Exists = false;
            if(FTimer != null)
            {
                FTimer.Stop();
                FTimer.Dispose();
                FTimer = null;
            }
        }
    }
}
