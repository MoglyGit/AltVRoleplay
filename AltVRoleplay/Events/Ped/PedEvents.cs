using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System.Text.Json;
using AltVRoleplay.JS_Objects;
using AltV.Net.Enums;
using AltV.Net.Elements.Entities;
using AltV.Net.Data;
using AltVRoleplay.Events.Shop247;
using AltVRoleplay.Voice;
using AltVRoleplay.SQL.Firma;
using AltVRoleplay.Events.LTDGas;

namespace AltVRoleplay.Events.CreatePed
{
    public class PedEvents: IScript
    {
        [ClientEvent("spawnPlayerAfterCreation")]
        public static void OnPlayerFirstTimeSpawn(MyPlayer.Player player, string s)
        {
            EditorData? data = JsonSerializer.Deserialize<EditorData>(s);
            if (data == null) return;
            if(data.sex == 0)
            {
                player.Model = (uint)PedModel.FreemodeMale01;
            }
            else
            {
                player.Model = (uint)PedModel.FreemodeFemale01;
            }

            player.SetHeadBlendData((uint)data.shapeFirstID, (uint)data.shapeSecondID, (uint)data.shapeThirdID, (uint)data.skinFirstID, (uint)data.skinSecondID, (uint)data.skinThirdID, data.shapeMix, data.skinMix, data.thirdMix);

            for (byte i = 0; i <= 19; i++)
            {
                player.SetFaceFeature(i, data.micro[i]);
            }

            for (byte i = 0; i <= 12; i++)
            {
                player.SetHeadOverlay(i, (byte)data.head[i], (byte)data.opa[i]);
            }

            player.SetHeadOverlayColor(1,1,(byte)data.overlaytint[0],0);
            player.SetHeadOverlayColor(2, 1, (byte)data.overlaytint[1], 0);
            player.SetHeadOverlayColor(10, 1, (byte)data.overlaytint[2], 0);
            player.SetHeadOverlayColor(8, 2, (byte)data.overlaytint[3], 0);
            player.SetHeadOverlayColor(5, 2, (byte)data.overlaytint[4], 0);

            player.SetEyeColor((byte)data.eyecolor);

            player.HairColor = (byte)data.haircolor;
            player.HairHighlightColor = (byte)data.hairtint;
            for (byte i = 0; i <= 11; i++)
            {
                player.SetClothes(i, (ushort)data.clothes[i], (byte)data.clothestext[i], 0);
                if ((ushort)data.clothes[i] == 15 && i==8) continue;
                if ((ushort)data.clothes[i] == 15 && i == 11) continue;
                Items.Cloth? cloth = null;
                int itemid = -1;
                switch (i)
                {
                    case 4:
                        cloth = new Items.Cloth(i, (ushort)data.clothes[i], (byte)data.clothestext[i], (byte)data.sex);
                        itemid = cloth.CreateCloth();
                        player.Legs = itemid;
                        break;
                    case 6:
                        cloth = new Items.Cloth(i, (ushort)data.clothes[i], (byte)data.clothestext[i], (byte)data.sex);
                        itemid = cloth.CreateCloth();
                        player.Shoes = itemid;
                        break;
                    case 8:
                        cloth = new Items.Cloth(i, (ushort)data.clothes[i], (byte)data.clothestext[i], (byte)data.sex);
                        itemid = cloth.CreateCloth();
                        player.Under = itemid;
                        break;
                    case 11:
                        cloth = new Items.Cloth(i, (ushort)data.clothes[i], (byte)data.clothestext[i], (byte)data.sex);
                        itemid = cloth.CreateCloth();
                        player.Top = itemid;
                        break;
                }
            }
            player.Sex = (byte)data.sex;
            player.Dimension = 0;
            DateTime now = Server.serverDate;
            player.Age = ""+now.Day+"."+now.Month+"."+(now.Year - data.age);
            player.Height = data.height;
            player.Fname = data.firstname;
            player.Lname = data.name;
            if(data.rpszenario == 0)
            {
                Crime c = new Crime(player.SocialClubId, 3, 0, data.crime, 0, 0, "Staatsgefängnis");
                c.id = Database.CreateCrime(c);
                c.CreateCrime();
            }
            player.LoggedIn = true;
            FirstSpawnSzenario(player, data.rpszenario);
            player.Save();
        }
        public static void FirstSpawnSzenario(MyPlayer.Player player, int szenario)
        {
            player.SetWeather(Server.weatherid);
            player.Emit("LoginComplete");
            player.Emit("setTime", Server.h(), Server.m(), Server.s());
            player.SetAllSyncedDataOnSpawn();
            player.Emit("allowedToSpawn");
            Shop247Handler.LoadShopBlips(player);
            LTDGasstation_Handler.LoadLTDBlips(player);
            FirmenNameHandler.LoadFirmenBlips(player);
            Channels.AddPlayerGlobalVoice(player);
            //player Synchron
            if (szenario == 0)
            {
                float[,] prisonSpawn = { { 1669.1868f, 2564.4526f, 45.556763f , 3.1f},{ 1636.0088f, 2563.9912f, 45.556763f ,3.1f} ,{ 1624.8528f, 2502.8704f, 45.556763f,-1.3f },{ 1637.6571f, 2491.5034f, 45.556763f, 0f }, { 1683.877f, 2477.4724f, 45.556763f,-0.7f } ,{ 1701.0725f, 2478.765f, 45.556763f, 0.6f } };

                Random rand = new Random();
                int i = rand.Next(prisonSpawn.GetLength(0));

                player.Spawn(new Position(prisonSpawn[i,0], prisonSpawn[i,1], prisonSpawn[i,2]), 0); //Prison spawn einreise: 405, -993, -99
                player.Rotation = new Rotation(roll: 0, pitch: 0, yaw: prisonSpawn[i, 3]);
                player.SendChatMessage("Du bist nach langer Zeit wieder auf freiem fuß");
                player.SetData("FirstPrison",1);
                player.GiveMoney(250);

            }
            else if(szenario == 1)
            {
                float[,] neutralSpawn = {
                    { -1285.8066f, -1568.9143f, 4.3084717f, 2.1f},
                    { -1309.3846f, -1548.9758f, 4.3084717f, -0.6f},
                    { -1325.3011f, -1485.3495f, 4.3084717f, -1.0f},
                    { -1291.0549f, -1473.6659f, 4.3084717f, 1.9f}
                };
                Random rand = new Random();
                int i = rand.Next(neutralSpawn.GetLength(0));

                player.Spawn(new Position(neutralSpawn[i, 0], neutralSpawn[i, 1], neutralSpawn[i, 2]), 0); //Prison spawn einreise: 405, -993, -99
                player.Rotation = new Rotation(roll: 0, pitch: 0, yaw: neutralSpawn[i, 3]);
                player.SendChatMessage("Genug entspannt");
                player.GiveMoney(300);
            }
            else
            {
                float[,] neutralSpawn = {
                    { -1033.6879f, -2739.811f, 20.164062f, 0.7f},
                    { -1042.5099f, -2736.079f, 20.164062f, -1.7f},
                    { -1047.3363f, -2735.3274f, 13.845459f, -1.6f},
                    { -1029.811f, -2742.4746f, 13.794922f, 0.4f}
                };
                Random rand = new Random();
                int i = rand.Next(neutralSpawn.GetLength(0));

                player.Spawn(new Position(neutralSpawn[i, 0], neutralSpawn[i, 1], neutralSpawn[i, 2]), 0); //Prison spawn einreise: 405, -993, -99
                player.Rotation = new Rotation(roll: 0, pitch: 0, yaw: neutralSpawn[i, 3]);
                player.SendChatMessage("Flughafen: Flug "+rand.Next(100,1000) +" ist gelandet");
                player.GiveMoney(400);
            }
            player.Emit("SetRadar", false);
        }

        public static void CreateChar(MyPlayer.Player player)
        {
            player.Dimension = (int)player.SocialClubId;
            player.SetPosition(399.98242f, -999.4154f, -99.01465f);
            player.Rotation = new Rotation(roll: 0, pitch: 0, yaw: 2.9f);
            Alt.Emit("charCreate", player, 1, 402.76483f, -996.54065f, -99.01465f, 170);
        }

        [ClientEvent("doTheTeleport")]
        public static void TpToWayPoint(MyPlayer.Player player, float x, float y, float z)
        {
            player.SendChatMessage("z: "+z);
            player.SetPosition(x, y, z);
        }
    }
}
