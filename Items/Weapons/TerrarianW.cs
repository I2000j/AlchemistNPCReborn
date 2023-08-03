using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class TerrarianW : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terrarian-W (V-05-516)");
			Tooltip.SetDefault("''Angela's actions have rewritten the very understandment of souls''\n[c/FF0000:EGO weapon]\nLeft click to shoot burst of lasers\nRight click to shoot burst of bullets\n33% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Terrarian-W (V-05-516)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Действия Анджелы переписали само понимание душ''\n[c/FF0000:Оружие Э.П.О.С.]\nЛевая кнопка мыши выстреливает очередью из лазеров\nПравая кнопка мыши выстреливает очередью из пуль\n33% шанс не потратить патроны");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Terrarian-W (V-05-516)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''Angela的行为改写了对灵魂本身的理解''\n[c/FF0000:EGO 武器]\n左键发射爆裂激光\n右键发射爆裂弹\n33%概率不消耗弹药");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LaserRifle);
			Item.damage = 25;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.UseSound = SoundID.Item31;
				Item.mana = 0;
				Item.useAnimation = 12;
				Item.useTime = 4;
				Item.reuseDelay = 14;
				Item.shoot = 10;
				Item.useAmmo = AmmoID.Bullet;
				Item.DamageType = DamageClass.Ranged;
				Item.damage = 18;
				if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
				{
					Item.damage = 36;
				}
			}
			else
			{
				Item.UseSound = SoundID.Item12;
				Item.mana = 5;
				Item.useAnimation = 18;
				Item.useTime = 6;
				Item.reuseDelay = 20;
				Item.shoot = 88;
				Item.useAmmo = 0;
				
				Item.DamageType = DamageClass.Magic;
				Item.damage = 25;
				if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
				{
					Item.damage = 100;
				}
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				if (player.altFunctionUse == 2)
				{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				}
				else
				{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-6, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+6, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				}
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == false)
			{
				if (player.altFunctionUse == 2)
				{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
				}
				else
				{
				}
			}
			return true;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}