using System.Linq;
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
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCReborn;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCReborn.Buffs
{
	public class LittleWitchMonster : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Little Witch Monster");
			Description.SetDefault("So that's what it contained...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монстр Маленькой Ведьмы");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Так вот что было внутри...");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小巫怪");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗯，这就是它里面的东西...");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.LittleWitchMonster>()] < 1)
			{
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X-15, player.position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.Minions.LittleWitchMonster>(), 24, 3f, player.whoAmI);
				modPlayer.lwm = true;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}