using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using AltVRoleplay.Appartments;
using AltVRoleplay.Bank;
using AltVRoleplay.Events.Player;
using AltVRoleplay.Items;
using AltVRoleplay.Jobs;
using AltVRoleplay.JS_Objects;
using AltVRoleplay.MyVehicle;
using AltVRoleplay.Ped;
using AltVRoleplay.SQL.Firma.Class;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.SQL.Friends;
using AltVRoleplay.SQL.Inventory;
using System.Timers;
using Org.BouncyCastle.Asn1.Crmf;
using AltVRoleplay.SQL.LTD_Gas.Class;

namespace AltVRoleplay.MyPlayer
{
    public partial class Player : AltV.Net.Elements.Entities.Player
    {
        public DateTime timeToPayGas;
        private byte minuteTimer;
        public enum AdminRanks { Spieler, Supporter, Moderator, Administrator}
        public bool LoggedIn { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Age { get; set; }
        public int Height { get; set; }
        public long Money { get; set; }
        public byte AdminLevel{ get; set; }
        public byte Sex { get; set; }

        //inv
        public int[] Inv { get;set; }
        public int Mask { get; set; }
        public int Top { get; set; }
        public int Under { get; set; }
        public int Legs { get; set; }
        public int Shoes { get; set; }
        public int Acces { get; set; }

        public int Hat { get; set; }
        public int Ears { get; set; }
        public int Bracelet { get; set; }
        public int Watches { get; set; }
        public int Glasses { get; set; }
        public System.Timers.Timer? RentTimer { get; set; }

        public MyVehicle.MyVehicle? RentedVehicle { get; set; }

        public System.Timers.Timer? pTimer = null;

        public int LastInterriorSwap { get; set; }

        public int PersoWait { get; set; }

        public IVehicle? schoolcar = null;

        public int DrivingTheory { get; set; }
        public int DrivingTheoryWait { get; set; }
        public int DrivingLicense { get; set; }
        public int DrivingPickup { get; set; }

        public List<MdcPlayer>? mdcPlayer { get; set; }
        public int Bank { get; set; }
        public int BankType { get; set; }

        public int Kredit { get; set; }
        public int KreditPayBack { get; set; }
        public int PayDay { get; set; }
        public int PayDayMoney { get; set; }
        public MyVehicle.MyVehicle? MiniJobCar { get; set; }
        public int MiniJob { get; set; }
        public int MiniJobMoneyTimer { get; set; }
        private int DriveBack = 10;
        public PedEntity? MiniJobPed = null;
        public int KraftLevel { get; set; }
        public int KraftSkill { get; set; }
        public int BergBau { get; set; }
        public int BergBauCd { get; set; }

        public bool canDoProg = true;
        public int Firma { get; set; }
        public ServerEnums.FirmenRanks Firma_Rank { get; set; }
        public int FirmaGehalt { get; set; }
        public int Faction { get; set; }
        public int Faction_Rank { get; set; }
        public int Duty { get; set; }
        public int[] JobMoney = new int[Enum.GetNames(typeof (ServerEnums.MiniJobs)).Length];
        public int Thirst { get; set; }
        public int Happy { get; set; }
        public int Hunger { get; set; }
        public int Harn {  get; set; }
        public Player(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
            timeToPayGas = DateTime.Now;
            minuteTimer = 60;
            Happy = 100;
            Hunger = 100;
            Harn = 0;
            Thirst = 100;
            FirmaGehalt = 0;
            Duty = 0;
            Faction = 0;
            Faction_Rank = 0;
            Firma_Rank = 0;
            Firma = 0;
            BergBauCd = 0;
            BergBau = 0;
            Acces = -1;
            KraftSkill = 0;
            KraftLevel = 0;
            MiniJobPed = null;
            MiniJobMoneyTimer = -1;
            MiniJob = 0;
            MiniJobCar = null;
            PayDayMoney = 0;
            PayDay = 0;
            KreditPayBack = 0;
            Kredit = 0;
            BankType = 0;
            Bank = 0;
            mdcPlayer = null;
            LoggedIn = false;
            AdminLevel = 0;
            Money = 0;
            Fname = "";
            Sex = 3;
            Lname = "";
            Age = "01.01.2000";
            Height = 0;
            Inv = new int[24];
            Mask = 0;
            Top = 0;    
            Under = 0;
            Legs = 0;
            Shoes = 0;
            Hat = 0;
            Ears = 0;
            Bracelet = 0;
            Watches = 0;
            Glasses = 0;
            RentedVehicle = null;
            RentTimer = null;
            pTimer = new System.Timers.Timer(1000);
            pTimer.Elapsed += Second;
            pTimer.AutoReset = true;
            pTimer.Enabled = true;
            LastInterriorSwap = 0;
            PersoWait = 0;
            schoolcar = null;
            DrivingTheory = 0;
            DrivingTheoryWait = 0;
            DrivingLicense = 0;
            DrivingPickup = 0;
            canDoProg = true;
            MiniJob = (int)ServerEnums.MiniJobs.None;
        }
        public void AddThirst(int perc)
        {
            if (Thirst - perc < 0) Thirst = 0;
            else Thirst -= perc;
            this.SetSyncedMetaData("Thirst", Thirst);
        }
        public void AddHunger(int perc)
        {
            if (Hunger - perc < 0) Hunger = 0;
            else Hunger -= perc;
            this.SetSyncedMetaData("Hunger", Hunger);
        }
        public void AddHarn(int perc)
        {
            if (Harn + perc > 190) Harn = 100;
            else Harn += perc;
            this.SetSyncedMetaData("Harn", Harn);
        }
        public void AddHappy(int perc)
        {
            if (Happy - perc < 0) Happy = 0;
            else Happy -= perc;
            this.SetSyncedMetaData("Happy", Happy);
        }
        public void ResetRouteAndCheckpoint()
        {
            this.Emit("ResetRoute");
        }
        public void SetRoute(int color,float x, float y, float z, ServerEnums.CheckpointEvent cevent, float yaw=0, float yawRange=0)
        {
            SetData("Checkpoint", (int)cevent);
            this.Emit("SetRoute",color,x,y,z);
            this.Emit("SetCheckpoint", x, y, z, yaw, yawRange);
        }
        public void BlockInventory(bool state)
        {
            this.Emit("blockPlayerInventory", state);
        }
        public void BlockAnimationMenu(bool state)
        {
            if (state) this.SetData("CantUseAnimationMenu", 1);
            else this.DeleteData("CantUseAnimationMenu");
        }
        public bool IsAnimationMenuBlocked()
        {
            return this.HasData("CantUseAnimationMenu");
        }
        public void Notification(ServerEnums.Notify n, string text)
        {
            this.Emit("Notify", (int)n, text);
        }
        public void AddFriend(ulong targetSocialClubId)
        {
            FriendSql.AddFriend(this, targetSocialClubId);
            this.Emit("AddFriend", targetSocialClubId);
        }
        public void RemoveFriend(ulong targetSocialClubId)
        {
            FriendSql.RemoveFriend(this, targetSocialClubId);
            this.Emit("RemoveFriend", targetSocialClubId);
        }
        public bool HasattachedObject(ServerEnums.PlayerAttachedSlots slot)
        {
            return this.HasData("attachedObj" + (int)slot);
        }

        public void CreateCrime(int type, int cost, string reason, int gesucht, int time, string from)
        {
            Crime c = new Crime(SocialClubId, type, cost, reason, gesucht, time, from);
            c.id = Database.CreateCrime(c);
            c.CreateCrime();
        }
        public void DetachObjectFromPlayer(ServerEnums.PlayerAttachedSlots slot)
        {
            if (!HasattachedObject(slot)) return;
            this.GetData("attachedObj" + (int)slot, out IObject ob);
            ob.ResetNetworkOwner();
            ob.Destroy();
            this.DeleteData("attachedObj" + (int)slot);
        }
        public void AttachObjectToPlayer(ServerEnums.PlayerAttachedSlots slot, string objectname, ushort player_bone, ushort obj_bone, Position pos, Rotation rot, bool colision, bool noFiexRotation)
        {
            if (HasattachedObject(slot)) return;
            IObject ob = Alt.CreateObject(objectname, this.Position, new Rotation(0, 0, 0));
            ob.SetNetworkOwner(this);
            ob.AttachToEntity(this, player_bone, obj_bone, pos, rot, colision, noFiexRotation);
            this.SetData("attachedObj"+(int)slot, ob);
        }

        public void SetAllSyncedDataOnSpawn()
        {
            SetSyncedMetaData("PayDay", (int)(PayDay / 60));
            SetStreamSyncedMetaData("FullName", "" + Fname + " " + Lname);
            SetStreamSyncedMetaData("PlayerId", Id);
            SetStreamSyncedMetaData("SocialClubId", SocialClubId);
            SetSyncedMetaData("Thirst",Thirst);
            SetSyncedMetaData("Hunger", Hunger);
            SetSyncedMetaData("Harn", Harn);
            SetSyncedMetaData("Happy", Happy);
        }
        public void BankTransfer(int money, string fromwho, string reason, ulong target = 0)
        {
            if (money == 0) return;
            Bank += money;
            BankTransfers bt = new BankTransfers(SocialClubId,money,fromwho,reason);
            bt.Create();
            Save();
        }
        public bool SetProgress(int seconds, int eventType, string text = "Verarbeite...")
        {
            if (!canDoProg)
            {
                Notification(ServerEnums.Notify.Warning,"Du bist noch beschäftigt");
                return false;
            }
            canDoProg = false;
            Emit("setProgressBar", seconds, eventType, text+" (Nutze X zum abbrechen)");
            return true;
        }
        public bool IsAduty()
        {
            return HasSyncedMetaData("Aduty");
        }
        public string GetFullName()
        {
            return Fname + " " + Lname;
        }

        public bool IsSplielerAdmin(int alvl)
        {
            return AdminLevel >= alvl;
        }

        public async void Save()
        {
            if (!LoggedIn) return;
            await Database.SaveAccount(this);
        }

        public int GetSkill(ServerEnums.SkillType type)
        {
            return type switch
            {
                ServerEnums.SkillType.Kraft => KraftSkill,
                _ => 100,
            };
        }
        public int GetSkillNeeded(ServerEnums.SkillType type)
        {
            return type switch
            {
                ServerEnums.SkillType.Kraft => 100 + 100 * KraftLevel,
                _ => 100,
            };
        }

        public void AddSkill(ServerEnums.SkillType type, int points)
        {
            switch(type)
            {
                case ServerEnums.SkillType.Kraft:
                    KraftSkill += points;
                    if(KraftSkill >= GetSkillNeeded(ServerEnums.SkillType.Kraft))
                    {
                        if (KraftLevel >= 10) return;
                        KraftLevel += 1;
                        KraftSkill = 0;
                        Notification(ServerEnums.Notify.Info, "Kraft verbesser");
                    }
                    break;
            }
        }
        public float GetMaxInvWieght()
        {
            return 5 + 0.5f * KraftLevel;
        }

        public Firma? GetFirma()
        {
            Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == this.Firma);
            if (firma == null || this.Position.Distance(firma.GetPosition()) > 60) return null;
            return firma;
        }

        public void GiveDBWeapon(ServerEnums.Weapons weapon)
        {
            int[] place = GetFreeInvPlace();
            if (place[0] != -1 || place[1] != -1)
            {
                Items.Items item = new Items.Items();
                item.CreateWepon(weapon);
                if (place[0] != -1) Inv[place[0]] = item.Id;
                else if (place[0] != -1)
                {
                    Backpack? back = GetPlayerBackPack();
                    if(back != null)
                    {
                        back.AddItem(place[1], item.Id);
                    }
                }
                GiveInvWeapons();
                return;
            }
            this.SendChatMessage("Du hast kein Platz im Inventar");
        }

        public void MinuteTimer()
        {
            Random rnd = new Random();
            AddThirst(rnd.Next(1, 5));
            AddHappy(rnd.Next(1, 5));
            AddHarn(rnd.Next(1, 5));
            AddHunger(rnd.Next(1, 5));
        }

        public void Second(System.Object? source, ElapsedEventArgs? e)
        {
            if (!LoggedIn) return;
            if(HasData("LTD:PAYMENT") && HasData("LTD:ID"))
            {
                if (DateTime.Now > timeToPayGas)
                {
                    GetData("LTD:PAYMENT", out int pay);
                    if (pay > 0)
                    {
                        GetData("LTD:ID", out int id);
                        LTDGasStation? ltdStolen = SQL.LTD_Gas.LTDList.LTDServerList.Find(x => x.Id == id);
                        if (ltdStolen != null)
                        {
                            CreateCrime(2, pay, "Tankstellen Rechnung nicht bezahlt", 1, 3 * 60, "Tankstelle: " + ltdStolen.Name);
                            Notification(ServerEnums.Notify.Info, "Tankstellen Rechnung nicht gezahlt");
                        }
                    }
                    DeleteData("LTD:PAYMENT");
                    DeleteData("LTD:ID");
                }
            }
            minuteTimer--;
            if(minuteTimer <= 0)
            {
                minuteTimer = 60;
                MinuteTimer();
            }
            if (BergBauCd > 0) BergBauCd--;
            if (Money > 10000)
            {
                Random rnd = new Random();
                GiveMoney(-rnd.Next(10,20));
            }
            PayDay++;
            if(PayDay >= 60*60)
            {
                PayDay = 0;
                GivePayDay();
            }
            if (PayDay % 60 == 0 && LoggedIn) this.SetSyncedMetaData("PayDay", PayDay / 60);
            if (LastInterriorSwap > 0) LastInterriorSwap--;
            if (PersoWait > 2) PersoWait--;
            if (DrivingTheoryWait > 0) DrivingTheoryWait--;
            if (PersoWait == 2)
            {
                this.SendChatMessage("Dein Ausweis ist abholbereit, denk an das Geld");
                PersoWait = 1;
            }
            CheckMiniJob();
            GravelWorker.CheckGravelArea(this);
            LumberJack.CheckLumberJackArea(this);
        }
        public void GivePayDay()
        {
            //Money Reset Jobs
            for(int i = 0; i < JobMoney.Length; i++)
            {
                JobMoney[i] = 0;
            }
            //Kredit
            if (Kredit > 0)
            {
                Kredit--;
                string bank = "Bank";
                if (BankType == 1) bank = "Fleeca Bank";
                BankTransfer(-KreditPayBack,bank, "Kredit rückzahlung");
            }
            foreach(Appartment a in AppartmentList.AppartmentServerList)
            {
                if (a.owned != SocialClubId) continue;
                if (a.MinRentTime > 0)
                {
                    a.MinRentTime -= 1;
                    a.Save();
                }
                BankTransfer(-a.rent, "Hausverwaltung", "Miete: "+a.name);
            }
            foreach(MyVehicle.MyVehicle veh in VehList.VehicleServerList)
            {
                if (veh.OwnerSocialclubId != SocialClubId) continue;
                if (veh.NumberplateText == "New") continue;
                BankTransfer(-(int)Math.Ceiling(veh.Price*0.15f), "Staat", "Kfz-Steuer: " + veh.VehName);
            }
            int getSteuern = 0;
            if(Firma != 0 && FirmaGehalt != 0)
            {
                Firma? firma = FirmaList.FirmaServerList.Find(s => s.Id == Firma);
                if (firma == null) return;
                BankTransfer(FirmaGehalt, "Firma: "+firma.Info, "Gehalt");
                getSteuern += FirmaGehalt;
                BankTransfers_Firmen bax = new BankTransfers_Firmen(firma.Id, -FirmaGehalt, GetFullName(), "Gehalt");
                bax.Create();
                firma.Save();
            }
            if (PayDayMoney > 0)
            {
                getSteuern += PayDayMoney;
                BankTransfer(PayDayMoney, "Arbeitgeber", "Gehalt");
                if (getSteuern > ServerMoney.FreeMoney)//frei betrag
                {
                    float abzug = getSteuern - ServerMoney.FreeMoney;
                    float lohnsteur = (0.1f + 0.05f * abzug / 1000);
                    float x = abzug * lohnsteur;
                    BankTransfer(-(int)Math.Ceiling(x), "Staat", "Lohnsteuer("+(lohnsteur*100).ToString("0.00")+"%)");
                }
            }
            PayDayMoney = 0;
            Save();
        }
        public void StopMinijob()
        {
            if(MiniJob == (int)ServerEnums.MiniJobs.LumberJack)
            {
                RemoveWeapon(Alt.Hash("weapon_hatchet"));
            }
            DriveBack = 10;
            MiniJob = (int)ServerEnums.MiniJobs.None;
            if (MiniJobCar != null) MiniJobCar.Destroy();
            MiniJobCar = null;
            MiniJobMoneyTimer = -1;
            if (MiniJobPed != null) MiniJobPed.Remove();
            this.Emit("ResetRoute");
        }
        public void WarnLeavingArea()
        {
            if (DriveBack % 3 == 0) Notification(ServerEnums.Notify.Warning, "Du entfernst dich zu weit!");
            DriveBack--;
            if (DriveBack == 0)
            {
                Notification(ServerEnums.Notify.Danger, "Du hast dich zu weit entfernt!");
                StopMinijob();
                return;
            }
        }
        private void CheckMiniJob()
        {
            if (MiniJob == (int)ServerEnums.MiniJobs.None) return;
            if (MiniJobMoneyTimer > 0)
            {
                switch (MiniJob)
                {
                    case (int)ServerEnums.MiniJobs.Mower:
                        if (Server.h() > 15 && Server.h() < 8)
                        {
                            Notification(ServerEnums.Notify.Danger, "Die Arbeitszeit ist vorbei");
                            StopMinijob();
                            return;
                        }
                        if (!(Position.X < -884.3604f && Position.X > -1419.8242f && Position.Y > -95.525276f && Position.Y < 198.59341f))
                        {
                            WarnLeavingArea();
                            return;
                        }
                        break;
                    case (int)ServerEnums.MiniJobs.Lieferant:
                        if (Server.h() < 12)
                        {
                            Notification(ServerEnums.Notify.Danger, "Die Arbeitszeit ist vorbei");
                            StopMinijob();
                            return;
                        }
                        if (!(Position.X < 350.95825f && Position.X > -290 && Position.Y > -430 && Position.Y < 100))
                        {
                            WarnLeavingArea();
                            return;
                        }
                        break;
                }
            }
            MiniJobMoneyTimer--;
            if (MiniJobMoneyTimer == 0)
            {
                Random rnd = new Random();
                switch (MiniJob)
                {
                    case (int)ServerEnums.MiniJobs.Mower:
                        MiniJobMoneyTimer = 10;
                        int money = 1 + rnd.Next(3);
                        PayDayMoney += money;
                        JobMoney[(int)ServerEnums.MiniJobs.Mower] += money;
                        if (JobMoney[(int)ServerEnums.MiniJobs.Mower] >= ServerMoney.JobMoneyMax[(int)ServerEnums.MiniJobs.Mower])
                        {
                            Notification(ServerEnums.Notify.Warning, "Du hast genug gearbeitet");
                            StopMinijob();
                            return;
                        }
                        Notification(ServerEnums.Notify.Check, "PayDay: +" + money + "$");
                        Save();
                        break;
                    case (int)ServerEnums.MiniJobs.Lieferant:
                        Notification(ServerEnums.Notify.Danger, "Der Kunde hat die Bestellung zurückgezogen!");
                        StopMinijob();
                        break;
                }
            }
        }
        public bool GetOtherInv(ref int[] other)
        {
            if (HasData("HandschuhfachUse"))
            {
                GetData("HandschuhfachUse", out MyVehicle.MyVehicle veh);
                if (veh == null) return false;
                other = veh.FrontInv;
                return true;
            }
            if (HasData("WardrobeUse"))
            {
                GetData("WardrobeUse", out Wardrobe w);
                if(w == null)return false;
                other = w.Inv;
                return true;
            }
            if (HasData("SearchedPlayerInv"))
            {
                GetData("SearchedPlayerInv", out Player targetPlayer);
                if (targetPlayer == null || !targetPlayer.LoggedIn || targetPlayer.Position.Distance(this.Position) > 3) return false;
                other = targetPlayer.Inv;
                return true;
            }
            if (HasData("TrunkUse"))
            {
                GetData("TrunkUse", out MyVehicle.MyVehicle veh);
                if (veh == null) return false;
                other = veh.Inv;
                return true;
            }
            if (HasData("OpenedOtherBackpack"))
            {
                GetData("OpenedOtherBackpack", out Backpack back);
                if (back == null) return false;
                other = back.Inv;
                return true;
            }
            return false;
        }

        public MyVehicle.MyVehicle? GetClosestBoat()
        {
            IVehicle? closestVehicle = null;
            float distance = 10;
            foreach (IVehicle veh in Alt.GetAllVehicles())
            {
                if (Alt.GetVehicleModelInfo(veh.Model).Type != VehicleModelType.BOAT) continue;
                float dis = Position.Distance(veh.Position);
                if (dis <= distance)
                {
                    distance = dis;
                    closestVehicle = veh;
                }
            }
            return (MyVehicle.MyVehicle?)closestVehicle;
        }
        public MyVehicle.MyVehicle? GetClosestBoat(Position pos)
        {
            IVehicle? closestVehicle = null;
            float distance = 5;
            foreach (IVehicle veh in Alt.GetAllVehicles())
            {
                if (Alt.GetVehicleModelInfo(veh.Model).Type != VehicleModelType.BOAT) continue;
                float dis = pos.Distance(veh.Position);
                if (dis <= distance)
                {
                    distance = dis;
                    closestVehicle = veh;
                }
            }
            return (MyVehicle.MyVehicle?)closestVehicle;
        }
        public MyVehicle.MyVehicle? GetClosestVehicle()
        {
            IVehicle? closestVehicle = null;
            float distance = 15;
            foreach(IVehicle veh in Alt.GetAllVehicles())
            {
                float dis = Position.Distance(veh.Position);
                if (dis <= distance)
                {
                    distance = dis;
                    closestVehicle = veh;
                }
            }
            return (MyVehicle.MyVehicle?)closestVehicle;
        }
        public MyVehicle.MyVehicle? GetClosestVehicle(uint model)
        {
            IVehicle? closestVehicle = null;
            float distance = 15;
            foreach (IVehicle veh in Alt.GetAllVehicles())
            {
                if (veh.Model != model) continue;
                float dis = Position.Distance(veh.Position);
                if (dis <= distance)
                {
                    distance = dis;
                    closestVehicle = veh;
                }
            }
            return (MyVehicle.MyVehicle?)closestVehicle;
        }
        public Appartment? GetClosestAppartment()
        {
            Appartment? a = null;
            float distance = -10;
            if(Dimension != 0)
            {
                a = AppartmentList.AppartmentServerList.Find(x => x.id == Dimension);
                if (a != null) return a;
            }
            foreach (Appartment appartment in AppartmentList.AppartmentServerList)
            {
                float dis = Position.Distance(new Position(appartment.x, appartment.y, appartment.z));
                if (dis > 3) continue;
                if (distance == -10)
                {
                    distance = dis;
                    a = appartment;
                }
                if (dis < distance)
                {
                    distance = dis;
                    a = appartment;
                }
            }
            return a;
        }

        public void UnrentVehilce()
        {
            if (RentedVehicle == null) return;
            RentedVehicle.Destroy();
            VehList.RemoveVehicle(RentedVehicle);
            RentedVehicle = null;
            if(RentTimer != null)RentTimer.Dispose();
        }
        public void SetMoney(long amount)
        {
            Money = amount;
            SetSyncedMetaData("PMoney", Money);
            Save();
        }
        public void GiveMoney(long amount)
        {
            Money += amount;
            SetSyncedMetaData("PMoney",Money);
            Save();
        }
        public void SlowPlayer(float slow, bool sprintallowd)
        {
            Emit("SlowPlayer", slow, sprintallowd);
        }
        public void PlaceItemInInv(int place, Items.Items? addItem)
        {
            if (addItem == null) return;
            Inv[place] = addItem.Id;
            float weight = 0;
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i]);
                if (item != null)
                {
                    weight += item.Mass * item.Amount;
                    continue;
                }
            }
            float max = GetMaxInvWieght();
            if (weight > max)
            {
                Backpack? back = GetPlayerBackPack();
                if (back != null)
                {
                    if(back.GetBackpackMass() + addItem.Mass*addItem.Amount < back.MaxWeight)
                    {
                        back.AddItem(addItem);
                        Inv[place] = 0;
                        return;
                    }
                }
                Notification(ServerEnums.Notify.Warning, "Das Item ist zu Schwer, du hast es fallen gelassen");
                Emit("RemoveHudItem", addItem.Id);
                PedEvents.AddGroundItem(this, addItem.Id, "inv"+place, 0);
                return;
            }
        }
        public Backpack? GetPlayerBackPack()
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                if (Inv[i] == -1 || Inv[i] == 0) continue;
                Items.Items? backitem = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Backpack != 0);
                if (backitem == null) continue;
                return BackpackList.BackpackServerList.Find(x => x.Id == backitem.Backpack);
            }
            return null;
        }
        public int[] GetFreeInvPlace()
        {
            int[] places = new int[2];
            places[0] = -1;
            places[1] = -1;
            float weight = 0;
            for (int i = 0; i < Inv.Length; i++)
            {
                if (places[0] == -1 && (Inv[i] == -1 || Inv[i] == 0))
                {
                    places[0] = i;
                    continue;
                }
                if (Inv[i] == -1 || Inv[i] == 0) continue;
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i]);
                if (item != null)
                {
                    weight += item.Mass * item.Amount;
                    continue;
                }
            }
            float max = GetMaxInvWieght();
            if (weight >= max)places[0] = -1;
            if(places[0] != -1) return places;
            Backpack? back = GetPlayerBackPack();
            if(back != null)
            {
                places[1] = back.GetFreeBackpackPlace();
            }
            return places;
        }
        public void RemoveHouseKey(int houseid)
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Housekey == houseid);
                if (item != null)
                {
                    Inv[i] = 0;
                    item.Remove();
                    continue;
                }
                Items.Items? backitem = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Backpack != 0);
                if (backitem == null) continue;
                Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == backitem.Backpack);
                if (back == null) continue;
                for (int a = 0; a < back.Inv.Length; a++)
                {
                    if (back.Inv[a] == 0) continue;
                    Items.Items? key = Items.ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Housekey == houseid);
                    if (key != null)
                    {
                        Inv[i] = 0;
                        key.Remove();
                        continue;
                    }
                }
            }
        }
        public void GiveBackpack()
        {
            int size = 0;
            for (int i = 0; i < Inv.Length; i++)
            {
                if (Inv[i] == 0 || Inv[i] == -1) continue;
                Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i]);
                if (item != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == item.Backpack);
                    if (back != null)
                    {
                        size= back.Size;

                        for (int a = 0; a < back.Inv.Length; a++)
                        {
                            if (back.Inv[a] == 0) continue;
                            Items.Items? gps = Items.ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Serveritem == ServerEnums.Items.GPS);
                            if (gps != null)
                            {
                                this.Emit("SetRadar", true);
                            }
                        }
                        break;
                    }
                }
            }
            switch (size)
            {
                case 0:
                    if (GetClothes(5).Drawable != 0) SetClothes(5, 0, 0, 0);
                    break;
                //mit gekafuten ändern
                case 1:
                    if (GetClothes(5).Drawable != 52) SetClothes(5, 52, 0, 0);
                    break;
                case 2:
                    if (GetClothes(5).Drawable != 45) SetClothes(5, 45, 0, 0);
                    break;
                case 3:
                    if (GetClothes(5).Drawable != 10) SetClothes(5, 10, 0, 0);
                    break;
            }
        }
        public bool HasOwnPerso()
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Perso > 0);
                if (item != null)
                {
                    Perso? p = PersoList.PersoServerList.Find(x => x.id == item.Perso && x.Socialclubid == SocialClubId && x.Searched == 0);
                    if (p != null) return true;
                }
                Items.Items? backitem = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Backpack != 0);
                if (backitem != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == backitem.Backpack);
                    if (back != null)
                    {
                        for (int a = 0; a < back.Inv.Length; a++)
                        {
                            if (back.Inv[a] == 0) continue;
                            Items.Items? perso = Items.ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Perso > 0);
                            if (perso != null)
                            {
                                Perso? p = PersoList.PersoServerList.Find(x => x.id == perso.Perso && x.Socialclubid == SocialClubId && x.Searched == 0);
                                if (p != null) return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool HasVehicleKey(int id)
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Vehkey == id);
                if (item != null) return true;
                Items.Items? backitem = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Backpack != 0);
                if(backitem != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x=> x.Id == backitem.Backpack);
                    if(back != null)
                    {
                        for (int a=0; a< back.Inv.Length;a++)
                        {
                            if (back.Inv[a] == 0) continue;
                            Items.Items? key = Items.ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Vehkey == id);
                            if (key != null) return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool HasHouseKey(int id)
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Housekey == id);
                if (item != null) return true;
                Items.Items? backitem = Items.ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Backpack != 0);
                if (backitem != null)
                {
                    Backpack? back = BackpackList.BackpackServerList.Find(x => x.Id == backitem.Backpack);
                    if (back != null)
                    {
                        for (int a = 0; a < back.Inv.Length; a++)
                        {
                            if (back.Inv[a] == 0) continue;
                            Items.Items? key = Items.ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Housekey == id);
                            if (key != null) return true;
                        }
                    }
                }
            }
            return false;
        }
        public void RemoveItemFromInv(int itemid)
        {
            for (int i = 0; i < Inv.Length; i++)
            {
                if (Inv[i] != itemid) continue;
                Inv[i] = 0;
                return;
            }
            Backpack? back = GetPlayerBackPack();
            if (back != null)
            {
                for (int a = 0; a < back.Inv.Length; a++)
                {
                    if (back.Inv[a] != itemid) continue;
                    back.Inv[a] = 0;
                    return;
                }
            }
            int[] otherInv = new int[1];
            if (!GetOtherInv(ref otherInv)) return;
            for (int i = 0; i < otherInv.Length; i++)
            {
                if (otherInv[i] != itemid) continue;
                otherInv[i] = 0;
                return;
            }
        }

        public void SaveInvMuni()
        {
            if (HasWeapon(Alt.Hash("weapon_pistol")))
            {
                CalculateInvMuni((int)ServerEnums.Muni.Pistol, GetWeaponAmmo(Alt.Hash("weapon_pistol")));
            }
            if (HasWeapon(Alt.Hash("weapon_heavyrifle")))
            {
                CalculateInvMuni((int)ServerEnums.Muni.AssaultRifles, GetWeaponAmmo(Alt.Hash("weapon_heavyrifle")));
            }
            if (HasWeapon(Alt.Hash("weapon_pumpshotgun")))
            {
                CalculateInvMuni((int)ServerEnums.Muni.Shotgun, GetWeaponAmmo(Alt.Hash("weapon_pumpshotgun")));
            }
            if (HasWeapon(Alt.Hash("weapon_microsmg")))
            {
                CalculateInvMuni((int)ServerEnums.Muni.MP, GetWeaponAmmo(Alt.Hash("weapon_microsmg")));
            }
        }

        public void CalculateInvMuni(int munitype, int muni)
        {
            int diff = 0;
            bool remove=false;
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Munitype == munitype);
                if (item != null)
                {
                    if (remove)
                    {
                        Inv[i] = -1;
                        item.Amount = 0;
                        item.SaveItem();
                        continue;
                    }
                    if (diff + item.Amount > muni)
                    {
                        item.Amount = muni-diff;
                        if(item.Amount<=0) Inv[i] = -1;
                        remove = true;
                        item.SaveItem();
                        continue;
                    }
                    diff += item.Amount;
                }
            }
            Backpack? back = GetPlayerBackPack();
            if (back != null)
            {
                for (int a = 0; a < back.Inv.Length; a++)
                {
                    if (back.Inv[a] == 0) continue;
                    Items.Items? item = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Munitype == munitype);
                    if (item != null)
                    {
                        if (remove)
                        {
                            back.Inv[a] = -1;
                            item.Amount = 0;
                            item.SaveItem();
                            continue;
                        }
                        if (diff + item.Amount > muni)
                        {
                            item.Amount = muni - diff;
                            if (item.Amount <= 0) back.Inv[a] = -1;
                            remove = true;
                            item.SaveItem();
                            continue;
                        }
                        diff += item.Amount;
                    }
                }
            }
        }

        public void GiveInvWeapons()
        {
            RemoveAllWeapons(true);
            int[] muni = new int[5];
            string[] weapons = new string[5];
            for (int i = 0; i < Inv.Length; i++)
            {
                Items.Items? item = ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Munitype != -1);
                if (item != null)
                {
                    muni[item.Munitype] += item.Amount;
                    continue;
                }
                item = ItemList.ItemsList.Find(x => x.Id == Inv[i] && x.Weapons != "-1" && x.Weapons != "0");
                if (item != null)
                {
                    weapons[WeaponInfo.GetWeaponType(item.Weapons)] = item.Weapons;
                    continue;
                }
            }
            Backpack? back = GetPlayerBackPack();
            if (back != null)
            {
                for (int a = 0; a < back.Inv.Length; a++)
                {
                    if (back.Inv[a] == 0 || back.Inv[a] == -1) continue;
                    Items.Items? item = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Munitype != -1);
                    if (item != null)
                    {
                        muni[item.Munitype] += item.Amount;
                        continue;
                    }
                    item = ItemList.ItemsList.Find(x => x.Id == back.Inv[a] && x.Weapons != "-1" && x.Weapons != "0");
                    if (item != null)
                    {
                        weapons[WeaponInfo.GetWeaponType(item.Weapons)] = item.Weapons;
                    }
                }
            }
            foreach (string weap in weapons)
            {
                GiveWeapon(Alt.Hash(weap), muni[WeaponInfo.GetWeaponType(weap)], false);
            }
        }
    }
}