﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCReborn.Items.Equippable
{
	class GrapplingHookGunItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grappling Hook Gun");
			Tooltip.SetDefault("Shoots insanely fast hook very far away");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пистолет с крюком-кошкой");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Запускает крайне быстрый крюк очень далеко");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "抓钩枪");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "速度飞快, 射程极远");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmethystHook);
			Item.shootSpeed = 28f;
			Item.rare = 11;
			Item.shoot = Mod.Find<ModProjectile>("GrapplingHookGunProjectile").Type;
		}
	}
	class GrapplingHookGunProjectile : ModProjectile
	{
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grappling Hook Gun Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
			Projectile.height = 22;
		}

		public override float GrappleRange()
		{
			return 900f;
		}

		public override bool? SingleGrappleHook(Player player)
		{
			return true;
		}
		
		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 1;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 56f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 24;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			counter++;
			Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
			Vector2 center = Projectile.Center;
			Vector2 distToProj = playerCenter - Projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			while (distance > 20f && !float.IsNaN(distance))
			{
				distToProj.Normalize();                 //get unit vector
				distToProj *= 10f;                      //speed = 24
				center += distToProj;                   //update draw position
				distToProj = playerCenter - center;    //update distance
				distance = distToProj.Length();
			}
			return true;
		}
	}
}
