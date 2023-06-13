﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCReborn;
using Terraria.WorldBuilding;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Laoskadyn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laoskadyn");
			Tooltip.SetDefault("Rains exploding homing needles from the sky on swing"
			+"\nNeedles release damaging flames");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лаоскадин");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сбрасывает взрывающиеся самонаводящиеся иглы с небес\nИглы испускают наносящие урон огни");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "劳斯卡丁");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "挥舞时从天上降下自动追踪敌人的针\n针会释放出有伤害的火焰");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 88;
			Item.width = 78;
			Item.height = 106;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = 1000000;
			Item.rare = 11;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("SharpNeedle").Type;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), Item.shootSpeed, Item.shootSpeed, type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), Item.shootSpeed, Item.shootSpeed, type, damage, Item.knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
