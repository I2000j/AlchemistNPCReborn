using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class WatcherAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher Amulet");
			Tooltip.SetDefault("No wonder it had an oddly shaped amulet in the middle."
				+ "\nBy obtaining certain essentials you have awakened the true form of this amulet."
				+ "\nWhat unearthly powers does it have? Nobody knows.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(25, 12));
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дозорный Амулет");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Неудивительно, что он имел амулет странной формы в середине.\nДобыв необходимые материалы, вы пробудили его истинную силу.\nКакую невероятную мощь он имеет в себе? Никто не знает.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "凝视者护符");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "怪不得中间有个奇形怪状的护身符.\n通过某种方式, 你唤醒了这个护身符的真实形态.\n它拥有怎样的可怕力量？没人知道.");
        }    
		
		public override void SetDefaults()
		{
			Item.damage = 250;
			Item.mana = 100;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.value = Item.buyPrice(10, 0, 0, 0);
			Item.rare = 9;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("WatcherCrystal").Type;
			Item.DamageType = DamageClass.Summon;
			Item.sentry = true;
			Item.buffType = Mod.Find<ModBuff>("WatcherCrystal").Type;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "OtherworldlyAmulet", 1);
			recipe.AddRecipeGroup("AlchemistNPCReborn:Tier3Bar", 25);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.ShroomiteBar, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.AddIngredient(null, "AlchemicalBundle", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("WatcherCrystal").Type] < player.maxTurrets)
			{
				return true;
			}
			return false;
		}
	}
}
