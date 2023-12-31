using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCReborn.Items.Weapons;

namespace AlchemistNPCReborn.Projectiles
{
	public class DBJ : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBJ");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			Projectile.scale = 0.75f;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.RocketIII;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}