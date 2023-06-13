using System;
using Microsoft.Xna.Framework;
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
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Buffs
{
	public class ShieldofSpring : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield of Spring");
			Description.SetDefault("Reduces all incoming damage by 15%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Щит Весны");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Уменьшает весь входящий урон на 15%");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "源泉之盾");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减免15%所受伤害");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.15f;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SpringShield>()] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.SpringShield>(), 0, 0, player.whoAmI);
				}
			}
		}
	}
}
