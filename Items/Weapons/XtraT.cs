using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class XtraT : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("XtraT");
			Tooltip.SetDefault("Shoots 2 arrows and an energy bolt"
			+ "\nBolt deals triple weapon damage and pierces through enemies and tiles"
			+ "\n50% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "XtraT");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выстреливает 2 стрелы и энергетический снаряд\nЭнергетический снаряд наносит утроенный урон оружия и проходит сквозь противников и блоки\n50% шанс не потратить стрелы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "XtraT");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "发射两支箭和一个能量球\n能量球造成三倍伤害并且能穿透敌人和方块\n50%几率不消耗弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 92;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 32f;
			Item.useAmmo = AmmoID.Arrow;
			Item.scale = 0.75f;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
		return Main.rand.NextFloat() >= .5;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(ItemID.ChlorophyteShotbow);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX = 10f;
			float speedY = 10f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+10, speedX, speedY, type, damage, knockback, player.whoAmI);
			SoundEngine.PlaySound(SoundID.Item12, position);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("ElectricBolt").Type, damage*3, knockback, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-10, speedX, speedY, type, damage, knockback, player.whoAmI);
			return false;
		}
	}
}
