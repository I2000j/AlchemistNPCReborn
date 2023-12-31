﻿using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class RampageComponents : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rampage Components");
			Tooltip.SetDefault("Turns Musket Balls into deadly Chloroshard Bullets"
			+ "\nThey work like crazy combination of Chlorophyte and Crystal Dust Bullets"
			+ "\nGives effect of Sniper Scope (10% bonus ranged damage and crit, ability to zoom)"
			+ "\nAmmo Reservation Effect"
			+ "\nHide visual to disable Sniper Scope effect"
			+ "\nSpeeds up all arrows"
			+ "\nEmpowers any Electrospheres greatly"
			+ "\n''And the lord poked his head out from the patron clouds,"
			+ "\nto look down on his followers in chaos and anarchy as the world is already aflame,"
			+ "\nout he tossed an canister of gasoline and out from his mouth, his words were: Screw it.''");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Компоненты Буйства");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Превращает мушкетные пули в смертоносные Хлорофитово-осколочные пули\nОни работают как безумная комбинация Хлорифитовых и Пыле-кристальных пуль\nДаёт эффект Снайперского прицела \n10% бонусного урона и шанса критического удара для дальнего боя\nЭффект Экономии Патронов\nОтключение видимости выключает эффект Снайперского Прицела\nУскоряет все стрелы\nУсиливает любое оружие, стреляющее Электросферами\n''..И высунулся Бог с небес,\nжелая увидеть своих последователей в хаосе и анархии пылающего мира;\nвыбросил он канистру бензина и таковы были его слова: Ну и чёрт с ним.''");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "狂暴组件");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "把子弹转变成致命的橓裂弹\n他们看起来就像是叶绿弹和水晶尘子弹的疯狂组合\n给予狙击镜的效果 (10% 的额外远程伤害和暴击率, 允许缩放)\n拥有弹药箱效果\n隐藏可见性关闭狙击镜的效果\n极大增加电疗效果\n'上帝从云中探出头来, 俯视着处在混乱与动荡中的追随者, 世界已陷入火海.\n他丢出一个汽油罐, 并从嘴中吐出一句话：管他呢.'");
        }
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 30;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Rampage = true;
			if (!hideVisual)
			{
				player.scope = true;
			}
			player.magicQuiver = true;
			player.ammoPotion = true;
			player.GetDamage(DamageClass.Ranged) += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().XtraT = true;
		}

		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "CrystalDustBullet", 3996);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
