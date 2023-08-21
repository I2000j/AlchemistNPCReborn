using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using AlchemistNPCReborn.Items;
using AlchemistNPCReborn.Interface;

namespace AlchemistNPCReborn
{
	public class AlchemistNPCReborn : Mod
	{

		public AlchemistNPCReborn()
        {
            ;
        }

        public static Mod Instance;
        internal static AlchemistNPCReborn instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind LampLight;
        public static ModKeybind DiscordBuff;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static bool BastScroll = false;
        public static bool Stormbreaker = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "VVV101"; } }
        public static string GithubProjectName { get { return "AlchemistNPCReborn"; } }
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;
        private UserInterface alchemistUserInterfaceH;
        internal HealingUI alchemistUIH;
        private UserInterface alchemistUserInterfaceDC;
        internal DimensionalCasketUI alchemistUIDC;

        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;

        public override void Load()
        {
            Instance = this;

            string DiscordBuffTeleportation = Language.GetTextValue("Discord Buff Teleportation");
            string LampLightToggle = Language.GetTextValue("Lamp Light Toggle");
            
            DiscordBuff = KeybindLoader.RegisterKeybind(this, DiscordBuffTeleportation, "Q");
            LampLight = KeybindLoader.RegisterKeybind(this, LampLightToggle, "L");

            instance = this;

            SetTranslation(); 

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
            if (!Main.dedServ)
            {
                EquipLoader.AddEquipTexture(this, "AlchemistNPCReborn/Items/Armor/somebody0214Robe_Legs", EquipType.Legs, name: "somebody0214Robe_Legs");
            }
            ReversivityCoinTier1ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier1Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), 999L));
            ReversivityCoinTier2ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier2Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), 999L));
            ReversivityCoinTier3ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier3Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), 999L));
            ReversivityCoinTier4ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier4Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 999L));
            ReversivityCoinTier5ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier5Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), 999L));
            ReversivityCoinTier6ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier6Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 999L));
        }

		public override void PostSetupContent()
		{
            ModLoader.TryGetMod("Census", out Mod censusMod);
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Alchemist>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Brewer>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Jeweler>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Tinkerer>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Architect>(), "Have any 3 other NPC present");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Operator>(), "Defeat Eater of Worlds/Brain of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Musician>(), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.YoungBrewer>(), "World state is Hardmode and both Alchemist and Operator are alive");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.OtherworldlyPortal>(), "Not exactly a Town NPC, one of the steps for saving the Explorer");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Explorer>(), "Defeat Moon Lord and find the way to use all 9 Torn Notes for saving her");
			}
		}

        public override void Unload()
        {
            Instance = null;
            instance = null;
            LampLight = null;
            DiscordBuff = null;
            modConfiguration = null;
        }

        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPCReborn.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPCReborn.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPCReborn.tier3HardmodeBar");
            string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPCReborn.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPCReborn.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPCReborn.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPCReborn.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPCReborn.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPCReborn.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPCReborn.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPCReborn.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPCReborn.CelestialWings");
            string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPCReborn.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPCReborn.tier3Watch");

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:EvilMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:CultistMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:Tier3Bar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:HardmodeComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:EvilBar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:EvilMush", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:EvilComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:EvilDrop", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyForge", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyCelestialWings", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyLunarHamaxe", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPCReborn:AnyWatch", group);

        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCRebornMessageType msgType = (AlchemistNPCRebornMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCRebornMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("AlchemistNPCReborn: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCRebornMessageType : byte
        {
            TeleportPlayer
        }

        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            Recipe.Create(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearLava)
                .Register();

            Recipe.Create(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearLava)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPCReborn:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPCReborn:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPCReborn:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPCReborn:EvilDrop")
                .AddRecipeGroup("AlchemistNPCReborn:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();
        }

        //SBMW:Transtation method
        public void SetTranslation()
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(this, "DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混乱药剂传送");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Reversivity Coin
            //SBMW:Russian comes from Items.ReversivityCoin
            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier1");
            text.SetDefault("Reversivity Coin Tier 1");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Первого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个1级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier2");
            text.SetDefault("Reversivity Coin Tier 2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Второго Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个2级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier3");
            text.SetDefault("Reversivity Coin Tier 3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Третьего Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个3级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier4");
            text.SetDefault("Reversivity Coin Tier 4");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Четвертого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个4级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier5");
            text.SetDefault("Reversivity Coin Tier 5");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Пятого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个5级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier6");
            text.SetDefault("Reversivity Coin Tier 6");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Шестого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个6级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "pale");
            text.SetDefault("pale");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "бледный");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失色");
            LocalizationLoader.AddTranslation(text);

            //SBMW:RecipeGroups
            text = LocalizationLoader.CreateTranslation(this, "evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐化/血腥Boss面具");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "cultist");
            text.SetDefault("Cultist mask/hood");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪教徒面具/兜帽");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3HardmodeBar");
            text.SetDefault("tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级肉后锭(精金/钛金)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "hardmodeComponent");
            text.SetDefault("Hardmode component");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔金/血腥锭");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilMushroom");
            text.SetDefault("evil mushroom");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶蘑菇");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilComponent");
            text.SetDefault("evil component");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶材料(暗影鳞片/组织样本)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilDrop");
            text.SetDefault("evil drop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶掉落物(腐肉/椎骨)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2anvil");
            text.SetDefault("tier 2 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级砧(秘银/山铜砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2forge");
            text.SetDefault("tier 2 forge");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级熔炉(精金/钛金熔炉)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier1anvil");
            text.SetDefault("tier 1 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一级砧(铁/铅砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "四柱翅膀");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3Watch");
            text.SetDefault("tier 3 Watch");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级表(金表/铂金表)");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Vanilla
            text = LocalizationLoader.CreateTranslation(this, "KingSlime");
            text.SetDefault("King Slime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之脑宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜂后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Deerclops");
            text.SetDefault("Deerclops Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉之墙宝藏袋");
            LocalizationLoader.AddTranslation(text);
            
            text = LocalizationLoader.CreateTranslation(this, "QueenSlime");
            text.SetDefault("Queen Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械蠕虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Twins");
            text.SetDefault("Twins Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "双子魔眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Plantera");
            text.SetDefault("Plantera Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世纪之花宝藏袋");
            LocalizationLoader.AddTranslation(text);
            
            text = LocalizationLoader.CreateTranslation(this, "EmpressOfLight");
            text.SetDefault("Empress of Light Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Golem");
            text.SetDefault("Golem Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "石巨人宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Betsy");
            text.SetDefault("Betsy Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "猪鲨公爵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月亮领主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //SBMW:CalamityMod
            text = LocalizationLoader.CreateTranslation(this, "DesertScourge");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "荒漠灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蘑菇螃蟹宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐巢意志宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Perforator");
            text.SetDefault("The Perforators Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉宿主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "硫磺火元素宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "渊海灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾厄之眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AstrageldonSlime");
            text.SetDefault("Astrum Aureus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Звёздного Заразителя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大彗星史莱姆宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星神吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "利维坦宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瘟疫使者歌莉娅宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ravager");
            text.SetDefault("Ravager Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "毁灭魔像宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Providence");
            text.SetDefault("Providence, the Profaned Goddess Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "亵渎天神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "StormWeaver");
            text.SetDefault("Storm Weaver Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CeaselessVoid");
            text.SetDefault("Ceaseless Void Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Signus");
            text.SetDefault("Signus, Envoy of the Devourer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "噬魂幽花宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "OldDuke");
            text.SetDefault("The Old Duke Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Старого Герцога");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神明吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Bumblebirb");
            text.SetDefault("The Dragonfolly Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "癫痫鸟宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Yharon");
            text.SetDefault("Jungle Dragon, Yharon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "犽戎宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ExoMechs");
            text.SetDefault("Exo Mechs Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SupremeCalamitas");
            text.SetDefault("Supreme Calamitas Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SBMW:ThoriumMod
            text = LocalizationLoader.CreateTranslation(this, "DarkMage");
            text.SetDefault("Dark Mage Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ogre");
            text.SetDefault("Ogre Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "惊雷王鹰宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水母皇后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CountEcho");
            text.SetDefault("Count Echo Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水母皇后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "花岗岩流能风暴宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "英灵遗骸宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheStarScouter");
            text.SetDefault("The Star Scouter Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星际监察者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BoreanStrider");
            text.SetDefault("Borean Strider Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地遁蛛宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CoznixTheFallenBeholder");
            text.SetDefault("Coznix, The Fallen Beholder Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落注视者·克兹尼格斯宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheLich");
            text.SetDefault("The Lich Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巫妖宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被遗忘者-深渊之主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾难之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //Redemption
            text = LocalizationLoader.CreateTranslation(this, "KingChicken");
            text.SetDefault("The Mighty King Chicken Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornBane");
            text.SetDefault("Thorn, Bane of the Forest Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheKeeper");
            text.SetDefault("The Keeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "XenoCrystal");
            text.SetDefault("Xenomite Crystal Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IEye");
            text.SetDefault("Infected Eye Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "KingSlayer");
            text.SetDefault("King Slayer III Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V1");
            text.SetDefault("Vlitch Cleaver Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V2");
            text.SetDefault("Vlitch Gigipede Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V3");
            text.SetDefault("Omega Obliterator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PZ");
            text.SetDefault("Patient Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornRematch");
            text.SetDefault("Thorn, Bane of the Forest Rematch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nebuleus");
            text.SetDefault("Nebuleus, Angel of the Cosmos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //ElementsAwoken
            text = LocalizationLoader.CreateTranslation(this, "Wasteland");
            text.SetDefault("Wasteland Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernace");
            text.SetDefault("Infernace Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ScourgeFighter");
            text.SetDefault("Scourge Fighter Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Regaroth");
            text.SetDefault("Regaroth Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheCelestials");
            text.SetDefault("The Celestials Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Permafrost");
            text.SetDefault("Permafrost Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Obsidious");
            text.SetDefault("Obsidious Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Aqueous");
            text.SetDefault("Aqueous Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TempleKeepers");
            text.SetDefault("The Temple Keepers Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Guardian");
            text.SetDefault("The Guardian Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Volcanox");
            text.SetDefault("Volcanox Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "VoidLevi");
            text.SetDefault("Void Leviathan Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Azana");
            text.SetDefault("Azana Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ancients");
            text.SetDefault("The Ancients Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SacredTools
            text = LocalizationLoader.CreateTranslation(this, "Decree");
            text.SetDefault("The Decree Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Декри");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "焚炎南瓜宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Горящей Тыквы");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Jensen");
            text.SetDefault("Jensen, the Grand Harpy Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дженсен, Великой Гарпии");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巨型鸟妖詹森宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araneas");
            text.SetDefault("Araneas Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Аранеи");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рейнейр, Королевы Гарпий");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "鸟妖女王雷纳宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Primordia");
            text.SetDefault("Primordia Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Примордии");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Абаддона, Эмиссара Кошмаров");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "梦魇使者亚巴顿宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Арагура, Огненного Змия");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "熔火巨蟒宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лунарианов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月军宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Spookboi");
            text.SetDefault("Nihilus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Нигилюса");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Portal");
            text.SetDefault("An Otherworldly Portal was opened.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Междумировой портал был открыт.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "连接另一个世界的传送门已开启");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PortalName");
            text.SetDefault("Otherworldly Portal");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Портал Иного Мира");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "异界传送门");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(this, "portalOpen");
            text.SetDefault("I am alive...? I cannot believe this! Thank you!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я жива...? Не верю своим глазам! Спасибо!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我...我还活着?! 我简直无法相信! 谢谢你!");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(this, "barrierStabilized");
            text.SetDefault("The Barrier between world is stabilized.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Барьер между мирами стабилизировался.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界间的屏障重新归于稳定");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation(this, "Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernon");
            text.SetDefault("Infernon Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Dusking");
            text.SetDefault("Dusking Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Atlas");
            text.SetDefault("Atlas Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Overseer");
            text.SetDefault("Overseer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation(this, "Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //Pinky
            text = LocalizationLoader.CreateTranslation(this, "SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //AAMod
            text = LocalizationLoader.CreateTranslation(this, "Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hydra");
            text.SetDefault("Hydra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Retriever");
            text.SetDefault("Retriever Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Yamata");
            text.SetDefault("Yamata Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Akuma");
            text.SetDefault("Akuma Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Zero");
            text.SetDefault("Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            LocalizationLoader.AddTranslation(text);

        }

	}
}