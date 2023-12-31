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
	public class StatsChecker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pip-Boy 3000");
			Tooltip.SetDefault("Shows most of the player's stats while in your inventory");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 3000");
            		Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, то показывает большинство параметров игрока");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哔哔小子 3000");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 显示玩家的绝大部分属性");
			
			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text1");
            		text.SetDefault("Melee damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text2");
            		text.SetDefault("Ranged damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "远程伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text3");
            		text.SetDefault("Magic damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text4");
            		text.SetDefault("Thrown damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text5");
            		text.SetDefault("Summoner damage boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤伤害增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text6");
            		text.SetDefault("Damage Reduction boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伤害抗性增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text7");
            		text.SetDefault("Movement speed boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "移动速度增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text8");
            		text.SetDefault("Max life boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大生命增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text9");
            		text.SetDefault("Life regeneration is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "生命再生速度");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text10");
            		text.SetDefault("Mana usage reduction is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法消耗减少");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text11");
            		text.SetDefault("Max amounts of minions/sentries are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大召唤物/炮台数量");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy3000text12");
            		text.SetDefault("Melee swing time is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战武器挥动");
            		LocalizationLoader.AddTranslation(text);
        	}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 5000000;
			Item.rare = 8;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			//string text1 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text1") + ((player.GetDamage(DamageClass.Melee)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Generic)-4) + "%";
			//string text2 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text2") + ((player.GetDamage(DamageClass.Ranged)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Ranged)-4) + "%";
			//string text3 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text3") + ((player.GetDamage(DamageClass.Magic)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Magic)-4) + "%";
			//string text4 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text4") + ((player.GetDamage(DamageClass.Throwing)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Throwing)-4) + "%";
			//string text5 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text5") + ((player.GetDamage(DamageClass.Summon)*100)-100) + "%";
			string text1 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text6") + (int)(player.endurance*100) + "%";
			string text2 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text7") + (int)((player.moveSpeed*100)-100) + "%";
			string text3 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text8") + (player.statLifeMax2 - player.statLifeMax);
			string text4 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text9") + (player.lifeRegen);
			string text5 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text10") + (int)((player.manaCost*100)-100) + "%";
			string text6 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text11") + player.maxMinions + " / " + player.maxTurrets;
			string text7 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text12") + (int)(player.GetAttackSpeed(DamageClass.Melee)*100) + "%";
			//TooltipLine line = new TooltipLine(Mod, "text1", text1);
			//TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
			//TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
			//TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
			//TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
			TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
			TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
			TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
			TooltipLine line6 = new TooltipLine(Mod, "text6", text6);
			TooltipLine line7 = new TooltipLine(Mod, "text7", text7);
			//line.OverrideColor = Color.Red;
			//line2.OverrideColor = Color.LimeGreen;
			//line3.OverrideColor = Color.SkyBlue;
			//line4.OverrideColor = Color.Orange;
			//line5.OverrideColor = Color.MediumVioletRed;
			line.OverrideColor = Color.Gray;
			line2.OverrideColor = Color.Green;
			line3.OverrideColor = Color.Yellow;
			line4.OverrideColor = Color.Brown;
			line5.OverrideColor = Color.SkyBlue;
			line6.OverrideColor = Color.Magenta;
			line7.OverrideColor = Color.Red;
			//tooltips.Insert(2,line);
			//tooltips.Insert(3,line2);
			//tooltips.Insert(4,line3);
			//tooltips.Insert(5,line4);
			//tooltips.Insert(6,line5);
			tooltips.Insert(2,line);
			tooltips.Insert(3,line2);
			tooltips.Insert(4,line3);
			tooltips.Insert(5,line4);
			tooltips.Insert(6,line5);
			tooltips.Insert(7,line6);
			tooltips.Insert(8,line7);
		}
	}
}
