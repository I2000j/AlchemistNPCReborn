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
	public class EvilPresence : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Presence");
			Description.SetDefault("A mechanical boss is coming for you..");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Присутствие Зла");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сейчас появится механический босс");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶降临");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械Boss即将到来!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (!NPC.AnyNPCs(125) && !NPC.AnyNPCs(126) && !NPC.AnyNPCs(127) && !NPC.AnyNPCs(134))
			{
				switch (Main.rand.Next(3))
				{
				case 0:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
				break;
				case 1:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
				break;
				case 2:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
				break;
				default:
				break;
				}
			}
		}
	}
}
