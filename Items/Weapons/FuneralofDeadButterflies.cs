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
	public class FuneralofDeadButterflies : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solemn Vow (T-01-68)");
			Tooltip.SetDefault("''The atmosphere is grave."
			+ "\nOne represents the sadness of the dead, the other represents fear of the quick.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts Shadowflame and Frostburn"
			+ "\n35% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Торжественная клятва (T-01-68)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Печальная атмосфера. Один отражает грусть мёртвых, а другой отражает страх живущих.''\n[c/FF0000:Оружие Э.П.О.С.]\nНакладывает Теневое Пламя и Морозный Ожог\n35% шанс не потратить патроны");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "圣宣 (T-01-68)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''这两把枪令人感到严肃."
			+"\n死者之哀, 死亡之惧, 烙印其上.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n造成暗影烈焰和霜火"
			+"\n35%概率不消耗弹药");
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useAnimation = 10;
			Item.useTime = 10;
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
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-5, Item.shootSpeed, Item.shootSpeed, type, (damage/3)*2, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, Mod.Find<ModProjectile>("FDB").Type, (damage/3)*2, Item.knockBack, player.whoAmI);
			return false;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .35;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 0);
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 125;
			}
			else
			{
				Item.damage = 26;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("AlchemistNPCReborn:Tier3Bar", 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			//recipe.AddTile(null, "WingOfTheWorld");
			recipe.Register();
		}
	}
}