﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCReborn.Projectiles
{
	public class ElementalWasps3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Wasp");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(189);
			Projectile.netImportant = true;
			Projectile.netUpdate = true;
			Projectile.DamageType = DamageClass.Ranged;
			
			Projectile.aiStyle = 36;
			AIType = 189;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
			{
				ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
				if (Calamity != null)
				{
					//if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					//{
					//	Projectile.scale = 1.5f;
					//}	
					if (player.armor[index1].type == 3333)
					{
						Projectile.scale = 1.5f;
					}
					//else if (ModLoader.GetMod("FargowiltasSouls") != null)
					//{
					//	if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
					//	{
					//		Projectile.scale = 1.5f;
					//	}
					//}
				}
				if (Calamity == null)
				{
					if (player.armor[index1].type == 3333)
					{
						Projectile.scale = 1.5f;
					}
					//else if (ModLoader.GetMod("FargowiltasSouls") != null)
					//{
					//	if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
					//	{
					//		Projectile.scale = 1.5f;
					//	}
					//}
				}	
			}
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			Player player = Main.player[Projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
			{
				if (Calamity != null)
				{
					//if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					//{
					//	damage += damage/2;
					//}
					if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					//else if (ModLoader.GetMod("FargowiltasSouls") != null)
					//{
					//	if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
					//	{
					//		damage += damage/2;
					//	}
					//}
				}
				if (Calamity == null)
				{
					if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					//else if (ModLoader.GetMod("FargowiltasSouls") != null)
					//{
					//	if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
					//	{
					//		damage += damage/2;
					//	}
					//}
				}	
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
			target.buffImmune[BuffID.CursedInferno] = false;
			target.AddBuff(BuffID.CursedInferno, 600);
			Projectile.penetrate = 1;
		}
	}
}
