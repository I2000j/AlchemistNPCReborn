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
	public class WatcherCrystal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher Crystal");
			Description.SetDefault("The powers of Galaxy support you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристалл-наблюдатель");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Силы Галактики поддерживают вас");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "凝视者水晶");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "银河之力在你身边环绕");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.WatcherCrystal>()] > 0)
			{
				modPlayer.watchercrystal = true;
			}
			if (!modPlayer.watchercrystal)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}
