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
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCReborn.NPCs;
using Terraria.Localization;

namespace AlchemistNPCReborn.Buffs
{
	public class Infested : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infested");
			Description.SetDefault("Slowed, spiders are ready to burst");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заражён");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Замедлен, пауки готовы к выходу");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蛛群滋生");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减速，蜘蛛种群暴涨");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			if (!npc.boss)
			{
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (npc.type != 222)
					{	
						npc.velocity *= 0.95f;
					}
				}
			}
        }
	}
}
