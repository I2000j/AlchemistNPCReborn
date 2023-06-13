using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Laetitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia (O-01-67)");
			Tooltip.SetDefault("''It takes a lot of time, but its power cannot be ignored''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nShoots heavy damaging bullets 2 times in 1 second"
			+ "\nCan be powered up by equipping full set of 'Laetitia'");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Летиция (O-01-67)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пусть она и требует много времени, но ее мощь нельзя игнорировать.\n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает мощные пули 2 раза в секунду\nМожет быть усилена экипировкой полного сета 'Летиция'");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'粗糙的结构设计令它的外表有些老旧, 可它仍有不可忽视的威力.'\n[c/FF0000:EGO 武器]\n一秒发射两发威力巨大的子弹\n身着全套'蕾蒂希娅'可提升伤害");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Musket);
			Item.damage = 35;
			Item.autoReuse = true;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet == true)
			{
			Item.damage = 35;
			Item.useTime = 15;
			Item.useAnimation = 15;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet == false)
			{
			Item.damage = 35;
			Item.useTime = 30;
			Item.useAnimation = 30;
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
			Item.damage = 500;
			Item.useTime = 15;
			Item.useAnimation = 15;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, type, damage/2, Item.knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilMush", 10);
			//recipe.AddTile(null, "WingOfTheWorld");
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TheUndertaker);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilMush", 10);
			//recipe.AddTile(null, "WingOfTheWorld");
			recipe.Register();
		}
	}
}