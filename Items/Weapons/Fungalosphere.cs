using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Fungalosphere : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 76;
			Item.height = 36;
			Item.useTime = 10;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.UseSound = SoundID.Item34;
			Item.value = 1000000;
			Item.rare = 11;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("FungalosphereProjectile").Type;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Gel;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungalosphere");
			Tooltip.SetDefault("Consumes gel as ammo"
			+"\nInflicts Electrocute and Frostburn debuffs"
			+"\n33% chance not to consume gel");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "凝胶喷射器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "消耗凝胶作为弹药\n造成触电和霜火Debuff\n33%的概率不消耗凝胶");
        }

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
		return Main.rand.NextFloat() >= .33;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
		int numberProjectiles = 4;
		for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(5));
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("FungalosphereProjectile").Type, damage, Item.knockBack, player.whoAmI);
			}
		for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed1 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(5));
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, Mod.Find<ModProjectile>("FungalosphereProjectileDummy").Type, damage, Item.knockBack, player.whoAmI);
			}
			return true;
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
			recipe.AddIngredient(ItemID.Flamethrower);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
