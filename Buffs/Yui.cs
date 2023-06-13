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
using Terraria.Localization;

namespace AlchemistNPCReborn.Buffs
{
	public class Yui : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yui");
			Description.SetDefault("Welcome back to the A-- Wait, that is not Alfheim! Where are we?"
			+"\nHighlights treasure, creatures and traps");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юи");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Добро пожаловать обратно в А... Погоди-ка, это не Альфхейм! Где мы?\nПодсвечивает сокровища, существ и ловушки");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小悠");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'欢迎回到亚... 等等, 这儿不是亚尔夫海姆! 我们在哪儿?'\n照亮宝物, 生物和陷阱");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Yui = true;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().YuiS = false;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Yui>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Yui>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			//if ((player.controlDown && player.releaseDown))
			//{
			//	if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)
			//	{
			//		for (int j = 0; j < 1000; j++)
			//		{
			//			if (Main.Projectile[j].active && Main.Projectile[j].type == ModContent.ProjectileType<Projectiles.Pets.Yui>() && Main.Projectile[j].owner == player.whoAmI)
			//			{
			//				Projectile lightpet = Main.Projectile[j];
			//				Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
			//				lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
			//			}
			//		}
			//	}
			//}
		}
	}
}
