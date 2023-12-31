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

namespace AlchemistNPCReborn.Buffs
{
	public class ExplorersBrew : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explorer's Brew");
			Description.SetDefault("Grants all possible vision buffs, vastly increases mining speed and light radius around the player. Your attacks can Electrocute enemies"
			+"\nGrants effects of Gills, Flippers and Water Walking Potions");
			Main.debuff[Type] = false;
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Варево Исследователя");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт все возможные виды зрения, значительно увеличивает скорость копания.\nЗначительно увеличивает радиус света вокруг игрока и ваши атаки могут поразить врага Электрошоком\nТакже даёт эффекты Подводного Дыхания, Ласт и Хождения по воде");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "探险者陈酿");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得所有感知效果, 极大增加召唤速度, 极大增加玩家周围的光照效果, 并且你的攻击会使敌人触电\n同时给予鱼鳃、脚蹼和水上行走药剂效果");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
			player.nightVision = true;
			player.detectCreature = true;
			player.pickSpeed -= 0.50f;
			player.dangerSense = true;
			player.gills = true;
			player.waterWalk = true;
			player.ignoreWater = true;
            player.accFlipper = true;
			player.buffImmune[ModContent.BuffType<ExplorerComb>()] = true;
			player.buffImmune[4] = true;
			player.buffImmune[15] = true;
			player.buffImmune[109] = true;
			player.buffImmune[9] = true;
			player.buffImmune[11] = true;
			player.buffImmune[12] = true;
			player.buffImmune[17] = true;
			player.buffImmune[104] = true;
			player.buffImmune[111] = true;
			BuffLoader.Update(BuffID.Gills, player, ref buffIndex);
			BuffLoader.Update(BuffID.Flipper, player, ref buffIndex);
			BuffLoader.Update(BuffID.Shine, player, ref buffIndex);
		}
	}
}
