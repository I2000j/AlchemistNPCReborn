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
	public class Counter : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Counter");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
			
			Projectile.width = 200;
			Projectile.height = 200;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 15;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			AIType = ProjectileID.BulletHighVelocity;
		}
		
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
		}
		
		public void DestroyProjectile(Projectile proj)
		{
			proj.Kill();
		}
	}
}