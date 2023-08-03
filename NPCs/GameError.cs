﻿using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
//using Terraria.World.Generation;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCReborn;
using AlchemistNPCReborn.NPCs;
 
namespace AlchemistNPCReborn.NPCs
{
	[AutoloadBossHead]
	class GameError : ModNPC
	{
		public override void SetDefaults()
		{
			NPC.boss = true;
			//NPC.width = 96;
			//NPC.height = 76;
			NPC.damage = 999999999;
			NPC.defense = 0;
			NPC.lifeMax = 999999999;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 333f;
			NPC.knockBackResist = -1f;
			Music = MusicID.Boss2;
			NPC.noTileCollide = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Game Error");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ошибка Игры");
		}
		
		public override void BossHeadRotation(ref float rotation)
        {
            rotation = NPC.rotation;
        }
		
		public override void AI()
		{
			if (!ModGlobalNPC.geru)
			{
				Main.NewText("Use ??? to summon boss properly", 150, 100, 30);
				NPC.CloneDefaults(-66);
			}
			if (Main.player[NPC.target].dead)
			{
				NPC.TargetClosest(false);
				if (Main.player[NPC.target].dead)
				{
					NPC.timeLeft = 0;
				}
			}
			if (!Main.player[NPC.target].dead)
			{
				NPC.rotation += (float)NPC.direction * 0.3f;
				Vector2 vector21 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
				float num177 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector21.X;
				float num178 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector21.Y;
				float num179 = (float)Math.Sqrt((double)(num177 * num177 + num178 * num178));
				num179 = 12f / num179;
				NPC.velocity.X = num177 * num179;
				NPC.velocity.Y = num178 * num179;
			}
			
			int damage1 = 200;
			int damage2 = 300;
			int damage3 = 350;
			NPC.buffImmune[ModContent.BuffType<Buffs.ArmorDestruction>()] = true;
			NPC.buffImmune[ModContent.BuffType<Buffs.Twilight>()] = true;
			NPC.buffImmune[ModContent.BuffType<Buffs.Electrocute>()] = true;
			NPC.buffImmune[ModContent.BuffType<Buffs.Patience>()] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[69] = true;
			NPC.buffImmune[203] = true;

			if (!Main.expertMode && ModGlobalNPC.gu)
			{
				if (NPC.life > 166666)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
					}
				}
				else
				{
					if (Main.rand.Next(25) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 449, damage2, 0, Main.myPlayer);
					}
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 448, damage2, 0, Main.myPlayer);
					}
				}
			}
			if (Main.expertMode && ModGlobalNPC.gu)
			{
				if (NPC.life > 333333)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 8f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, ModContent.ProjectileType<Projectiles.DeadlyLaser>(), damage1, 0, Main.myPlayer);
					}
				}
				if (NPC.life > 166666 && NPC.life < 333333)
				{
					if (Main.rand.Next(25) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 9f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 449, damage2, 0, Main.myPlayer);
					}
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 448, damage2, 0, Main.myPlayer);
					}
				}
				if (NPC.life < 166666)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 449, damage3, 0, Main.myPlayer);
					}
				if (Main.rand.Next(50) == 0)
				{
					Vector2 vel = new Vector2(-1, -1);
					vel *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel.X, vel.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel2 = new Vector2(1, 1);
					vel2 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel2.X, vel2.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel3 = new Vector2(1, -1);
					vel3 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel3.X, vel3.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel4 = new Vector2(-1, 1);
					vel4 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel4.X, vel4.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel5 = new Vector2(0, -1);
					vel5 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel5.X, vel5.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel6 = new Vector2(0, 1);
					vel6 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel6.X, vel6.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel7 = new Vector2(1, 0);
					vel7 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel7.X, vel7.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel8 = new Vector2(-1, 0);
					vel8 *= 14f;
					Projectile.NewProjectile(((Entity) this.NPC).GetSource_FromThis((string) null),NPC.Center.X, NPC.Center.Y, vel8.X, vel8.Y, 448, damage3, 0, Main.myPlayer);
					}
				}
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int	hitDirection)	
		{
			if (projectile.type == 358)
			{
				NPC.life = 999999999;
			}
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			Player player = Main.player[Main.myPlayer];
			var source = NPC.GetSource_FromAI();
			potionType = ItemID.HealingPotion;

			Item.NewItem(source,(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, 2337, 20);
			Item.NewItem(source,(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, 2338, 20);
			Item.NewItem(source,(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, 2339, 20);

			player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " forgot that the Reborn version has all the features from lite."), 9999.0, 0, false);
		}
	}
}