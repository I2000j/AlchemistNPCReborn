using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Projectiles
{
	public class BB : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bleeding Bullet");     //The English name of the Projectile
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;           //Act exactly like default Bullet
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.AddBuff(BuffID.OnFire, 720);
		}
	}
}
