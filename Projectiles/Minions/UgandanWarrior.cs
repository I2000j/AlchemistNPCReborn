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

namespace AlchemistNPCReborn.Projectiles.Minions
{
	public class UgandanWarrior : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Warrior");
			Main.projFrames[Projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(533);
			Projectile.width = 96;
			Projectile.height = 76;
			Projectile.aiStyle = 66;
			Projectile.minionSlots = 1;
			AIType = 533;
			Projectile.tileCollide = false;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			damage -= (damage/10) * player.maxMinions;
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
			{
				damage /= 100;
			}
		}
		
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner]; 
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.UgandanWarrior>()))
			{
				Projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}
