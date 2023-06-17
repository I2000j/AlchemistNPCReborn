using Microsoft.Xna.Framework;
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
	public class MagicBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Bullet (F-01-69)");
			Tooltip.SetDefault("''Though, unable to fully extract its original power, the magical power it holds is still potent.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nBullets shot by this weapon will go through tiles"
			+ "\nPierces through multiple enemies");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебная Пуля (F-01-69)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Несмотря на невозможность извлечения полного потенциала, магическая мощь этого оружия всё ещё велика.''\n[c/FF0000:Оружие Э.П.О.С.]\nПули проходят сквозь блоки\nПробивает значительное количество противников одним выстрелом");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔弹射手 (F-01-69)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''尽管无法完全提取该异常核心中那股深奥的力量, 但利用那神奇力量所研制出来的武器仍然无比强大.''\n[c/FF0000:EGO 武器]\n从该武器射出的子弹能穿透方块\n子弹能穿透多个敌人");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 500;
			Item.autoReuse = true;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("MB").Type;
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 600;
					Item.useTime = 10;
					Item.useAnimation = 10;
					}
					else
					{
					Item.damage = 500;
					Item.useTime = 15;
					Item.useAnimation = 15;
					}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.Ectoplasm, 30);
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}