using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
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

namespace AlchemistNPCReborn.Items.Weapons
{
	public class TheBeak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Beak (O-02-56)");
			Tooltip.SetDefault("''Size has no meaning while it overflows with power.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nShoots 2 times in one use"
			+ "\nBullets set enemies ablaze"
			+ "\n25% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Клюв (O-02-56)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Размер не имеет значения, пока он переполнен силой.\n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает по 2 пули\nПули поджигают противника\n25% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小喙 (O-02-56)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'虽然这只鸟的身材娇小, 可它有着很恐怖的嘴巴.'\n[c/FF0000:EGO 武器]\n一次射出两发子弹\n子弹会点燃敌人\n25%几率不消耗弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.useAnimation = 20;
			Item.useTime = 10;
			Item.reuseDelay = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage/2, Item.knockBack, player.whoAmI);
			type = Mod.Find<ModProjectile>("BB").Type;
			return true;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .25;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 4);
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 150;
					Item.useAnimation = 12;
					Item.useTime = 6;
					Item.reuseDelay = 6;
					}
					else
					{
					Item.damage = 12;
					Item.useAnimation = 20;
					Item.useTime = 10;
					Item.reuseDelay = 20;
					}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilBar", 12);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 10);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilMush", 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}