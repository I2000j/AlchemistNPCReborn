﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class ConeOfCold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cone of Cold");
			Tooltip.SetDefault("Magic spell which releases cone of arctic cold"
			+"\nMay slowdown or freeze normal enemies in place");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Конус Холода");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магическое заклинание, испускающие конус арктического холода\nМожет замедлить или заморозить обычных противников");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冰锥术");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放极寒冰锥的魔咒"
			+"\n概率缓慢或冻结普通敌人");
        }

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.rare = 5;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 12;
			Item.UseSound = SoundID.Item20;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.autoReuse = true;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = Mod.Find<ModProjectile>("ConeOfColdProjectile").Type;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed2 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed3 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed4 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed5 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed6 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 perturbedSpeed7 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			float speedX4 = perturbedSpeed4.X;
			float speedY4 = perturbedSpeed4.Y;
			float speedX5 = perturbedSpeed5.X;
			float speedY5 = perturbedSpeed5.Y;
			float speedX6 = perturbedSpeed6.X;
			float speedY6 = perturbedSpeed6.Y;
			float speedX7 = perturbedSpeed7.X;
			float speedY7 = perturbedSpeed7.Y;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y+4, speedX2, speedY2, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y, Item.shootSpeed, Item.shootSpeed, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y-4, speedX3, speedY3, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y-8, speedX4, speedY4, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y+8, speedX5, speedY5, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y-12, speedX6, speedY6, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y+12, speedX7, speedY7, Mod.Find<ModProjectile>("ConeOfColdProjectile").Type, damage, Item.knockBack, player.whoAmI);
			return true;
		}
		
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}
	}
}
