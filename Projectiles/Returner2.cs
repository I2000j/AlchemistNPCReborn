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
	public class Returner2 : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Returner 2");
		}
	}
}
