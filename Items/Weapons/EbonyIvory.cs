﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class EbonyIvory : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebony & Ivory");
			Tooltip.SetDefault("''Twin handguns of a Demon Hunter''"
			+ "\nCan very rarely crit for 66666 damage"
			+ "\nShoot custom demonic bullets, which are exploding on hit"
			+ "\n66% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чёрный и Белый");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Парные пистолеты Демона-Охотника''\nМогут нанести очень редкий критический удар, наносящий 66666 урона\n66% шанс не потратить патроны"); 
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑檀木&白象牙");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''一位恶魔猎人的双枪''"
			+"\n极小概率暴击造成66666点伤害"
			+"\n发射定制的恶魔子弹, 撞击时爆炸"
			+"\n66%概率不消耗弹药");
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useAnimation = 6;
			Item.useTime = 6;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 1000000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
			Item.scale = 0.5f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("DemonicBullet").Type;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-5, velocity.X, velocity.Y, type, damage/2, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage/2, Item.knockBack, player.whoAmI);
			return false;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .66;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(ItemID.DemonScythe);
			recipe.AddIngredient(ItemID.UnholyTrident);
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddIngredient(ItemID.VenusMagnum, 2);
			recipe.AddIngredient(null, "AlchemicalBundle");
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}