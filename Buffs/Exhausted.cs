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
using AlchemistNPCReborn.NPCs;
using Terraria.Localization;

namespace AlchemistNPCReborn.Buffs
{
	public class Exhausted : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exhausted");
			Description.SetDefault("You cannot use magic now, lowered horizontal flight speed, decreased melee speed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Истощение");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы не можете использовать магию сейчас, снижена скорость горизонтального полёта, понижена скорость ближнего боя");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "精疲力尽");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无法使用魔法,降低水平飞行速度,减少近战攻击速度");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.silence = true;
			player.GetAttackSpeed(DamageClass.Melee) -= 0.15f;
            player.statMana = 0;
			player.moveSpeed -= 0.5f;
        }
	}
}
