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
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Buffs
{
	public class BastScroll : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Description.SetDefault("Attacks obliterate enemy's armor");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток Баст");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Атаки полностью разрушают броню противника.");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巴斯特卷轴");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "攻击完全摧毁敌人护甲");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCReborn.BastScroll = true;
		}
	}
}
