using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCReborn;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace AlchemistNPCReborn.Items.Weapons
{
	public class Akumu : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("'Akumu'");
			Tooltip.SetDefault("It means '[c/FF00FF:nightmare]' in Japanese"
			+"\nIts slice pierces through any amount of enemies on its way"
			+"\nLeft click launches a short travelling projectile"
			+"\nRight click slices the air in place"
			+"\nWhile at 25% of life or lower, Akumu generates projectile reflecting shield"
			+"\nThis would lower weapon's power until life regens back to 25%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Акуму'");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это означает [c/FF00FF:'кошмар'] на Японском\nЕё удар пронзает любое количество врагов\nЗапускает снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nЕсли здоровье ниже 25% Акуму создает щит, отражающий снаряды\nНаличие щита снижает урон Акуму");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'Akumu'");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "在日语里, [c/FF00FF:'Akumu']的意思是'噩梦'\n它的斩击能穿透经过的所有敌人\n左键发射剑气\n右键近距离攻击\n生命值低于25%时, Akumu会生成反射抛射物的护盾\n这将会降低武器的威力, 直至生命回复到25%");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 150;
			Item.width = 58;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 12;
			Item.knockBack = 8;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<Projectiles.Akumu>();
			Item.shootSpeed = 8f;
		}
		
		public override void HoldItem(Player player)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().Akumu = true;
				player.AddBuff(ModContent.BuffType<Buffs.Akumu>(), 2);
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 40;
				Item.useAnimation = 40;
			}
			else
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
			damage /= 2;
			}
			if (player.altFunctionUse != 2)
			{
			Item.noMelee = false;
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			//Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuThrow>(), damage, knockBack , player.whoAmI);
			}
			if (player.altFunctionUse == 2)
			{
				Item.noMelee = true;
				if (player.direction == 1)
				{
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.Akumu>(), damage, knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuMirror>(), damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
	}
}
