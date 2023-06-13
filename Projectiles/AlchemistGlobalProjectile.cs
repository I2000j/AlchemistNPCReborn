using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCReborn.Projectiles;
using System.IO;
using AlchemistNPCReborn.NPCs;
using Terraria.ModLoader.IO;

namespace AlchemistNPCReborn.Projectiles
{
	public class AlchemistGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity
		{
			get { return true; }
		}
		
		public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
					{
						if (projectile.hostile && !projectile.friendly)
						{
							Lighting.AddLight(projectile.Center, 1f, 1f, 0f);
							return Color.Yellow;
						}
					}
				}
			}
			return base.GetAlpha(projectile, lightColor);
        }

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if ((projectile.type == 98) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 184) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 185) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 3;
			}
			if ((projectile.type == 186) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 20;
				}
				else
				{
					projectile.damage += 10;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 187) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 188) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 654) && ((AlchemistNPCRebornPlayer)player.GetModPlayer<AlchemistNPCRebornPlayer>()).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
		}
	}
}