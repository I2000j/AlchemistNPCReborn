﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class SunkroveraArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Even holding these make you feel... uneasy."
			+"\nReleases life stealing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сункроверная стрела");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даже держать эти стрелы в руках... нелегко.\nВыпускает похищающие жизнь снаряды при попадании во врага/стену");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "森克罗维拉之箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "即便是带着它你也能感受到那份...压力\n击中墙壁或敌人后释放可以汲取生命的子弹");
        }

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 10;
			Item.shoot = Mod.Find<ModProjectile>("SunkroveraArrow").Type;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(150);
			recipe.AddIngredient(ItemID.MoonlordArrow, 150);
			recipe.AddIngredient(null, "SunkroveraCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
