using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Projectiles.Minions
{
	public class LittleWitchMonster : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(391);
			Projectile.minionSlots = 1;
            Main.projFrames[Projectile.type] = 11;
			Projectile.aiStyle = 26;
            AIType = 391;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LittleWitchMonster");
		}

		//public override void CheckActive()
		//{
		//	Player player = Main.player[Projectile.owner];
		//	AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
		//	if (player.dead || !modPlayer.LaetitiaGift)
		//	{
		//		modPlayer.lwm = false;
		//		Projectile.Kill();
		//	}
		//	if (!player.HasBuff(mod.BuffType("LittleWitchMonster")))
		//	{
		//		modPlayer.lwm = false;
		//		Projectile.Kill();
		//	}
		//	if (!modPlayer.LaetitiaSet && !modPlayer.ParadiseLost)
		//	{
		//		modPlayer.lwm = false;
		//		Projectile.Kill();
		//	}
		//}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().ParadiseLost == true)
			{
			damage *= 4;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 600);
			target.AddBuff(BuffID.Ichor, 600);
			target.immune[Projectile.owner] = 5;
			Player player = Main.player[Projectile.owner];
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().ParadiseLost == true)
			{
			damage *= 4;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate == 0)
            {
                Projectile.Kill();
            }
            return false;
        }
		
	}
}
