using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Projectiles
{
	public class CorrosiveFlaskMagic : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ToxicFlask);
			Projectile.damage = 350;
			Projectile.DamageType = DamageClass.Magic;
			
			AIType = ProjectileID.ToxicFlask;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.ToxicFlask;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
			if (Projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(20, 31);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(20, 402) * 0.01f;
					Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, value17.X, value17.Y, ModContent.ProjectileType<CorrosiveFlaskCloudMagic>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-30, 2));
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 300);
				target.immune[Projectile.owner] = 1;
			}
	}
}