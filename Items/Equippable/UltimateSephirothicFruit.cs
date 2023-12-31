﻿using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class UltimateSephirothicFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate Sephirotic Fruit");
			Tooltip.SetDefault("The last of Echidna's seeds... Holds incredible powers inside."
			+"\nIncreases minion damage by 15%"
			+"\nIncreases max amount of minions by 3"
			+"\nMinions can critically hit with 10% chance"
			+"\nMinions nearly ignore enemy invincibility frames");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Расцвёвший Плод Сефирот");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Последнее из семян Ехидны... Хранит невероятные силы внутри\nПовышает урон прислужников на 15%\nУвеличивает максимальное количество прислужников на 3\nПрислужники могут нанести критический удар с вероятностью в 10%\nПрислужники почти полностью игнорируют период неуязвимости у противника");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "终极瑟芙罗克之果");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "埃凯德娜最后的种子... 拥有不可思议的力量.\n增加15%召唤伤害\n增加3个最大召唤物数量\n召唤物有10%概率暴击\n召唤物无视敌人无敌帧");
        }
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().SF = true;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().SFU = true;
            player.GetDamage(DamageClass.Summon) += 0.15f;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "SephirothicFruit");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
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