using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using AlchemistNPCReborn.Interface;
using Terraria.GameContent;
using System;
using Terraria.ModLoader.Config;

namespace AlchemistNPCReborn
{
    public class AlchemistNPCRebornWorld : ModSystem
    {
        private const int saveVersion = 0;
        public static bool foundAglet;
		public static bool foundClimbingClaws;
		public static bool foundAnklet;
		public static bool foundShoeSpikes;
		public static bool foundBalloon;
		public static bool foundHermesBoots;
		public static bool foundFlippers;
		public static bool foundFrogLeg;
		public static bool foundCloud;
		public static bool foundBlizzard;
		public static bool foundSandstorm;
		public static bool foundPuffer;
		public static bool foundTsunami;
		public static bool foundWWB;
		public static bool foundIceSkates;
		public static bool foundLavaCharm;
		public static bool foundHorseshoe;
		public static bool foundCMagnet;
		public static bool foundPStone;
		public static bool foundHTFL;
		public static bool foundAnglerEarring;
		public static bool foundTackleBox;
		public static bool foundJFNeck;
		public static bool foundFlowerBoots;
		public static bool foundTabi;
		public static bool foundGoldRing;
		public static bool foundLuckyCoin;
		public static bool foundDiscountCard;
		public static bool foundNeptuneShell;
		public static bool foundString;
		public static bool foundGreenCW;
		public static bool foundYoyoGlove;
		public static bool foundBlindfold;
		public static bool foundArmorPolish;
		public static bool foundVitamins;
		public static bool foundBezoar;
		public static bool foundAdhesiveBandage;
		public static bool foundFastClock;
		public static bool foundTrifoldMap;
		public static bool foundMegaphone;
		public static bool foundNazar;
		public static bool foundSorcE;
		public static bool foundWE;
		public static bool foundRE;
		public static bool foundSumE;
		public static bool foundFeralClaw;
		public static bool foundTitanGlove;
		public static bool foundMagmaStone;
		public static bool foundSharkTooth;
		public static bool foundBlackBelt;
		public static bool foundMoonCharm;
		public static bool foundMoonStone;
		public static bool foundRifleScope;
		public static bool foundPaladinShield;
		public static bool foundFrozenTurtleShell;
		public static bool foundPutridScent;
		public static bool foundFleshKnuckles;
		public static bool foundMagicQuiver;
		public static bool foundCobaltShield;
		public static bool foundPanicNecklace;
		public static bool foundCrossNecklace;
		public static bool foundStarCloak;
		public static bool foundNecromanticScroll;
		public static bool foundObsidianRose;
		public static bool foundShackle;
		public static bool foundSunStone;
		public static bool foundHerculesBeetle;
		public static bool foundPygmyNecklace;
		public static bool foundMP7;
		public static bool foundT1;
		public static bool foundT2;
		public static bool foundT3;
		public static bool foundPHD;
        public static bool downedDOGPumpking;
        public static bool downedDOGIceQueen;
        public static bool downedSandElemental;
        public static bool foundAntiBuffMode;
        public static bool foundFlyingCarpet;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;

    

        public override void OnWorldLoad()
        {
            foundAglet = false;
			foundClimbingClaws = false;
			foundAnklet = false;
			foundShoeSpikes = false;
			foundBalloon = false;
			foundHermesBoots = false;
			foundFlippers = false;
			foundFrogLeg = false;
			foundCloud = false;
			foundBlizzard = false;
			foundSandstorm = false;
			foundPuffer = false;
			foundTsunami = false;
			foundWWB = false;
			foundIceSkates = false;
			foundLavaCharm = false;
			foundHorseshoe = false;
			foundCMagnet = false;
			foundPStone = false;
			foundHTFL = false;
			foundAnglerEarring = false;
			foundTackleBox = false;
			foundJFNeck = false;
			foundFlowerBoots = false;
			foundTabi = false;
			foundGoldRing = false;
			foundLuckyCoin = false;
			foundDiscountCard = false;
			foundNeptuneShell = false;
			foundString = false;
			foundGreenCW = false;
			foundYoyoGlove = false;
			foundBlindfold = false;
			foundArmorPolish = false;
			foundVitamins = false;
			foundBezoar = false;
			foundAdhesiveBandage = false;
			foundFastClock = false;
			foundTrifoldMap = false;
			foundMegaphone = false;
			foundNazar = false;
			foundSorcE = false;
			foundWE = false;
			foundRE = false;
			foundSumE = false;
			foundFeralClaw = false;
			foundTitanGlove = false;
			foundMagmaStone = false;
			foundSharkTooth = false;
			foundBlackBelt = false;
			foundMoonCharm = false;
			foundMoonStone = false;
			foundRifleScope = false;
			foundPaladinShield = false;
			foundFrozenTurtleShell = false;
			foundPutridScent = false;
			foundFleshKnuckles = false;
			foundMagicQuiver = false;
			foundCobaltShield = false;
			foundPanicNecklace = false;
			foundCrossNecklace = false;
			foundStarCloak = false;
			foundNecromanticScroll = false;
			foundObsidianRose = false;
			foundShackle = false;
			foundSunStone = false;
			foundHerculesBeetle = false;
			foundPygmyNecklace = false;
			foundMP7 = false;
			foundT1 = false;
			foundT2 = false;
			foundT3 = false;
			foundPHD = false;
			foundAntiBuffMode = false;
			foundFlyingCarpet = false;
            downedDOGIceQueen = false;
            downedDOGPumpking = false;
            downedSandElemental = false;
            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDOGPumpking = downed.Contains("DOGPumpking");
            downedDOGIceQueen = downed.Contains("DOGIceQueen");
            downedSandElemental = downed.Contains("SandElemental");
            var found = tag.GetList<string>("found");
            foundAntiBuffMode = found.Contains("AntiBuffMode");
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedDOGPumpking) downed.Add("DOGPumpking");
            if (downedDOGIceQueen) downed.Add("DOGIceQueen");
            if (downedSandElemental) downed.Add("SandElemental");

            var found = new List<string>();

            if (foundAntiBuffMode) found.Add("AntiBuffMode");

            tag["downed"] = downed;
            tag["found"] = found;
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedDOGPumpking;
            flags[1] = downedDOGIceQueen;
            flags[2] = downedSandElemental;
            writer.Write(flags);

            BitsByte flags10 = new BitsByte();
			//flags10[0] = foundPHD;
			flags10[1] = foundAntiBuffMode;
			//flags10[2] = foundFlyingCarpet;
			writer.Write(flags10);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedDOGPumpking = flags[0];
            downedDOGIceQueen = flags[1];
            downedSandElemental = flags[2];

            BitsByte flags10 = reader.ReadByte();
			//foundPHD = flags10[0];
			foundAntiBuffMode = flags10[1];
			//foundFlyingCarpet = flags10[2];
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPC: Shop Selector",
                    delegate
                    {
                        if (ShopChangeUI.visible)
                        {
                            alchemistUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexA != -1)
            {
                layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
                    "AlchemistNPC: Shop Selector A",
                    delegate
                    {
                        if (ShopChangeUIA.visible)
                        {
                            alchemistUIA.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexO != -1)
            {
                layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
                    "AlchemistNPC: Shop Selector O",
                    delegate
                    {
                        if (ShopChangeUIO.visible)
                        {
                            alchemistUIO.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexM != -1)
            {
                layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
                    "AlchemistNPC: Shop Selector M",
                    delegate
                    {
                        if (ShopChangeUIM.visible)
                        {
                            alchemistUIM.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            int LocatorArrowIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (LocatorArrowIndex != -1)
            {
               layers.Insert(LocatorArrowIndex, new LegacyGameInterfaceLayer(
                   "AlchemistNPC: Locator Arrow",
                   delegate
                   {
                       Player player = Main.LocalPlayer;
                       if (player.accCritterGuide && AlchemistNPCReborn.modConfiguration.LifeformAnalyzer)
                       {
                           for (int v = 0; v < 200; ++v)
                           {
                               NPC npc = Main.npc[v];
                               if (npc.active && npc.rarity >= 1 && !AlchemistNPCReborn.modConfiguration.DisabledLocatorNpcs.Contains(new NPCDefinition(npc.type)))
                               {
                                   // Adapted from Census mod
                                   Vector2 playerCenter = Main.LocalPlayer.Center + new Vector2(0, Main.LocalPlayer.gfxOffY);
                                   var vector = npc.Center - playerCenter;
                                   var distance = vector.Length();
                                   if (distance > 40 && distance <= AlchemistNPCReborn.modConfiguration.LocatorRange)
                                   {
                                       var offset = Vector2.Normalize(vector) * Math.Min(70, distance - 20);
                                       float rotation = vector.ToRotation() + (float)(Math.PI / 2);
                                       var drawPosition = playerCenter - Main.screenPosition + offset;
                                       float fade = Math.Min(1f, (distance - 20) / 70);
                                       Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCReborn/Projectiles/LocatorProjectile").Value, drawPosition,
                                                               null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                   }
                               }
                           }
                       }
                       return true;
                   }, InterfaceScaleType.Game)// Maybe this is problem solver |Game -> UI|
               );
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (alchemistUserInterface != null && ShopChangeUI.visible)
            {
                alchemistUserInterface.Update(gameTime);
            }

            if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
            {
                alchemistUserInterfaceA.Update(gameTime);
            }

            if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
            {
                alchemistUserInterfaceO.Update(gameTime);
            }

            if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
            {
                alchemistUserInterfaceM.Update(gameTime);
            }
        }
    }
}
