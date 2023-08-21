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
	public class CurseOfLight : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Curse of Light");
			Description.SetDefault("Weakens enemies");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Проклятие Света");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ослабляет противника");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "诅咒之光");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "虚弱敌人");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			npc.GetGlobalNPC<ModGlobalNPC>().light = true;
			if (Calamity != null)
			{
				if (npc.type != 222 && npc.type != (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlaguebringerGoliath").Type) && npc.type != (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlaguebringerMiniboss").Type) && npc.type != (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlagueChargerLarge").Type))
				{	
					npc.velocity *= 0.99f;
				}
			}
			else
			{
				if (npc.type != 222)
				{	
					npc.velocity *= 0.99f;
				}
			}
        }
	}
}
