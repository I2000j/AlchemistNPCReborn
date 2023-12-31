﻿using System;
using AlchemistNPCReborn.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCReborn.Tiles;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Spore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore (O-04-66)");
			Tooltip.SetDefault("''The spear, covered with spores and attention."
			+ "\nIt expands mind, shines like a star and gradually becomes closer to weilder.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nIts attack hits enemy several times"
			+ "\nAfter certain amount of hits releases damaging spores into enemy");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Спора (O-04-66)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Копьё, покрытое спорами и вниманием.\nОно раскрывает разум, сияет словно звезда и постепенно сближается с носителем.\n[c/FF0000:Оружие Э.П.О.С.]\nЕго атаки наносят урон противнику несколько раз\nПри нанесении определённого количество ударов выпускает атакующие споры во врага");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "荧光菌孢 (O-04-66)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'这是一支生长着孢子, 并且寄宿着情感的长矛.'\n'它能够揭示思维, 在他们脑海中如同繁星一般闪烁, 并且使他们逐渐变得驯服安分.'\n[c/FF0000:EGO 武器]\n攻击能多次伤害敌人\n在命中一定次数之后释放伤害性孢子进入敌人体内");
        }

		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.useStyle = 5;
			Item.useAnimation = 20;
			Item.useTime = 25;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = 6;
			Item.value = Item.sellPrice(gold: 50);

			Item.DamageType = DamageClass.Magic;
			Item.mana = 4;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("Spore").Type;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 250;
					}
					else
					{
					Item.damage = 55;
					}
			return player.ownedProjectileCounts[Item.shoot] < 1; 
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 25);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
