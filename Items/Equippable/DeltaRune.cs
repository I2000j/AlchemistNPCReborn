﻿using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class DeltaRune : ModItem
	{
		public static int count = 0;
		public static int A = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Delta Rune");
			Tooltip.SetDefault("Adds 10% melee and magic damage and critical strike chances"
				+ "\nIncreases defense by 10"
				+ "\nIncreases damage reduction by 10%"
				+ "\nYour melee attacks have a chance to release red damaging wave"
				+ "\nYour magic attacks have a chance to release swarm of homing magic missiles"
				+ "\nRegenerates life rapidly while standing still");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Руна Дельта");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает магический/ближний урон и шанс критического удара на 10%\nУвеличивает защиту на 10\nУвеличивает стойкость на 10%\nДаёт шанс выпустить красную волну, наносящую урон при взмахе оружием ближнего боя\nДаёт шанс выпустить рой магических снарядов при магической атаке\nБыстро восстанавливает здоровье, пока стоишь на месте");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三角符文");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加10%近战/魔法伤害和暴击率\n增加10%伤害减免\n近战攻击概率释放红色破坏波\n魔法攻击概率释放追踪魔法飞弹\n站立不动时快速恢复生命");
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 64;
			Item.height = 60;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
			Item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DeltaRune = true;
			A = 50 * (player.GetModPlayer<AlchemistNPCRebornPlayer>()).LifeElixir;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Magic) += 0.1f;
			player.GetCritChance(DamageClass.Generic) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
			player.endurance += 0.1f;
			if (player.statLife < (player.statLifeMax2 + A) && player.velocity.X == 0f && player.velocity.Y == 0f)
			{
				if (count >= 12)
				{
					count = 0;
					player.statLife += 5;
					player.HealEffect(5, true);
				}
				count++;
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(Mod.Find<ModItem>("SoulEssence").Type, 3);
			recipe.AddIngredient(Mod.Find<ModItem>("ChromaticCrystal").Type, 5);
			recipe.AddIngredient(Mod.Find<ModItem>("SunkroveraCrystal").Type, 5);
			recipe.AddIngredient(Mod.Find<ModItem>("NyctosythiaCrystal").Type, 5);
			recipe.AddIngredient(Mod.Find<ModItem>("EmagledFragmentation").Type, 150);
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if (Calamity == null)
			{
				recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutator").Type);
			}
			if (Calamity != null)
			{
				recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutatorMK2").Type);
			}
			recipe.Register();
		}
	}
	
}
