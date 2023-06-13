using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Justitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia (O-02-62)");
			Tooltip.SetDefault("''It remembers the balance of the Long Bird that never forgot others' sins."
			+"\nThis weapon may be able to not only cut flesh but trace of sins as well.''"
			+ "\n[c/FF0000:EGO weapon]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юстиция (O-02-62)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Он помнит баланс Высокой Птицы, никогда не забывавшей грехи других.\nЭто оружие может уничтожать не только плоть, но и следы грехов.\n[c/FF0000:Оружие Э.П.О.С.]");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "正义裁决者 (O-02-62)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'这把武器象征着审判鸟的公平制裁, 这也意味着它需要去权衡全部的罪恶.'\n[c/FF0000:EGO 武器]");
        }

		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 30;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 1000000;
			Item.rare = 12;
			Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.damage = 166;
            Item.knockBack = 4;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("JP").Type;
			Item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int p = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, Mod.Find<ModProjectile>("JP").Type, damage, Item.knockBack, player.whoAmI);
			Main.projectile[p].scale = 1.5f;
            return false;
        }
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 225;
			}
			else
			{
				Item.damage = 120;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			//recipe.AddTile(null, "WingOfTheWorld");
			recipe.Register();
		}
	}
}
