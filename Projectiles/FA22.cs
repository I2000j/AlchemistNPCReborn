using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPCReborn.Projectiles
{
	public class FA22 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Cloud 2");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(512);
			
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 92;
			AIType = 512;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.OnFire, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.CursedInferno, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.Daybreak, 180);
			}
		}
	}
}
