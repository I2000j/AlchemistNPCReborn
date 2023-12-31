﻿using Terraria.ID;
using Terraria;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class SupremeRampageComponents : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supreme Rampage Components");
			Tooltip.SetDefault("Turns Musket Balls into deadly Chloroshard Bullets"
			+ "\nThey work like crazy combination of Chlorophyte and Crystal Dust Bullets"
			+ "\nGives effect of Sniper Scope (15% bonus ranged damage and crit, ability to zoom)"
			+ "\nHide visual to disable Sniper Scope effect"
			+ "\nIncreases armor penetration by 40"
			+ "\nAmmo Reservation Effect"
			+ "\nSpeeds up all arrows"
			+ "\nEmpowers any Electrospheres greatly"
			+ "\n''And the Heavens have opened, and God reached down upon my life, and said upon me:"
			+ "\nRek thigh scrbs, an fk ther sht ahp.''");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Истинные Компоненты Буйства");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Превращает мушкетные пули в смертоносные Хлорофитово-осколочные пули\nОни работают как безумная комбинация Хлорифитовых и Пыле-кристальных пуль\nДаёт эффект Снайперского прицела \n15% бонусного урона и шанса критического удара для дальнего боя\nОтключение видимости выключает эффект Снайперского Прицела\nУвеличивает пробивание брони на 40\nЭффект Экономии Патронов\nУскоряет все стрелы\nУсиливает любое оружие, стреляющее Электросферами\n''И разверзлись Небеса, спустив послание Бога, завещавшее мне:\nДй им всм п щщам, и рздлбй вс чт вдишь.''");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "至尊狂暴组件");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "把子弹转变成致命的橓裂弹\n他们看起来就像是叶绿弹和水晶尘子弹的疯狂组合\n给予狙击镜的效果 (15% 的额外远程伤害和暴击率, 允许缩放)\n隐藏可见性关闭狙击镜的效果\n增加40点护甲穿透\n弹药储备效果\n加速所有箭矢\n极大增加电击效果\n''And the Heavens have opened, and God reached down upon my life, and said upon me:\nRek thigh scrbs, an fk ther sht ahp.''");
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
			player.GetArmorPenetration(DamageClass.Generic) += 40;
			player.magicQuiver = true;
			player.ammoPotion = true;
			player.GetDamage(DamageClass.Ranged) += 0.15f;
			player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().XtraT = true;
		}

		
		public override void AddRecipes()
		{
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "RampageComponents");
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (Calamity == null)
			{
				recipe.AddTile(null, "MateriaTransmutator");
			}
			if (Calamity != null)
			{
				recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.Register();
		}
	}
}