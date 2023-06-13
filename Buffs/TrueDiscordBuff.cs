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
	public class TrueDiscordBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Discord");
			Description.SetDefault("You may teleport to cursor position by using hotkey"
			+"\nBehaves exactly like Rod of Discord");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Истинный Раздор");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы можете телепортироваться к курсору, используя горячую клавишу\nПри применении ведёт себя аналогично Жезлу Раздора");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "真·混乱传送");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你可以使用快捷键传送至鼠标位置" +
                "\n相当于混乱法杖");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.buffImmune[ModContent.BuffType<Buffs.DiscordBuff>()] = true;
		}
	}
}
