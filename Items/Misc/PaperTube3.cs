﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Items.Misc
{
	public class PaperTube3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube (T3)");
			Tooltip.SetDefault("Contains blueprints of a random post Plantera accessory\nUse to unlock");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тубус (3)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хранит в себе чертёж случайного Пост-Плантерного аксессуара\nИспользуйте для разблокировки");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蓝图纸管 (T-3)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含一项随机世纪之花后饰品的蓝图\n使用以解锁");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "PaperTubeT3Info1");
            text.SetDefault("You need to defeat Golem to unlock leftover post Plantera accessory.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你需要打败石巨人以解锁剩下世纪之花的饰品.");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PaperTubeT3Info2");
            text.SetDefault("There was nothing interesting in those blueprints.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这些蓝图没什么意思.");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PaperTubeT3Info3");
            text.SetDefault("You have found a new accessory blueprint. You can ask Tinkerer about making it now.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你发现了一个新的饰品蓝图. 你可以现在问问工匠这东西能干什么.");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PaperTubeT3Info4");
            text.SetDefault("You have found all post Plantera blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你已经找到了所有世纪之花后的蓝图. 恭喜! 你可以把剩下的蓝图都兜售给工匠.");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PaperTubeT3Info5");
            text.SetDefault("Talk to Tinkerer when you will defeat Moon Lord and unlock all accessories.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "当你打败月球领主之后和工匠交谈即可解锁所有饰品.");
            LocalizationLoader.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 200000;
			Item.rare = 8;
			Item.maxStack = 99;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item37;
			Item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCRebornWorld.foundT3)
			{
				return false;
			}
			return true;
		}
		
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
			var randomAcc = new List<string>();
								
			if (!AlchemistNPCRebornWorld.foundTabi) {
			randomAcc.Add("foundTabi");}
			if (!AlchemistNPCRebornWorld.foundBlackBelt) {
			randomAcc.Add("foundBlackBelt");}
			if (!AlchemistNPCRebornWorld.foundRifleScope) {
			randomAcc.Add("foundRifleScope");}
			if (!AlchemistNPCRebornWorld.foundPaladinShield) {
			randomAcc.Add("foundPaladinShield");}
			if (!AlchemistNPCRebornWorld.foundNecromanticScroll) {
			randomAcc.Add("foundNecromanticScroll");}
			if (NPC.downedGolemBoss)
			{
				if (!AlchemistNPCRebornWorld.foundSunStone) {
				randomAcc.Add("foundSunStone");}
			}
			if (!AlchemistNPCRebornWorld.foundHerculesBeetle) {
			randomAcc.Add("foundHerculesBeetle");}
			if (!AlchemistNPCRebornWorld.foundPygmyNecklace) {
			randomAcc.Add("foundPygmyNecklace");}
			if (randomAcc.Count == 0 && !NPC.downedGolemBoss)
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.PaperTubeT3Info1"), 100,149,237);
				return true;
			}
			if (Main.rand.NextBool(5))
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.PaperTubeT3Info2"), 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.PaperTubeT3Info3"), 255, 255, 255);
			
			if (randomAcc[acc] == "foundTabi") {
			AlchemistNPCRebornWorld.foundTabi = true;}
			if (randomAcc[acc] == "foundBlackBelt") {
			AlchemistNPCRebornWorld.foundBlackBelt = true;}
			if (randomAcc[acc] == "foundRifleScope") {
			AlchemistNPCRebornWorld.foundRifleScope = true;}
			if (randomAcc[acc] == "foundPaladinShield") {
			AlchemistNPCRebornWorld.foundPaladinShield = true;}
			if (randomAcc[acc] == "foundNecromanticScroll") {
			AlchemistNPCRebornWorld.foundNecromanticScroll = true;}
			if (randomAcc[acc] == "foundSunStone") {
			AlchemistNPCRebornWorld.foundSunStone = true;}
			if (randomAcc[acc] == "foundHerculesBeetle") {
			AlchemistNPCRebornWorld.foundHerculesBeetle = true;}
			if (randomAcc[acc] == "foundPygmyNecklace") {
			AlchemistNPCRebornWorld.foundPygmyNecklace = true;}
			if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			
			if (randomAcc.Count == 1 && NPC.downedGolemBoss)
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.PaperTubeT3Info4"), 0, 255, 0);
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.PaperTubeT3Info5"), 0, 255, 0);
				AlchemistNPCRebornWorld.foundT3 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
			return true;
		}
	}
}
