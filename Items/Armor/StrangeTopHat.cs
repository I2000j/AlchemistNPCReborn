﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn.NPCs;

namespace AlchemistNPCReborn.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StrangeTopHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strange Top Hat");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Странный Циллиндр"); 
			Tooltip.SetDefault("''We'll meet again, don't know where, don't know when!"
			+"\nOh, I know we'll meet again some sunny day!''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Не знаю где, не знаю когда, но мы встретимся вновь!\nО, я знаю, что мы встретимся вновь в какой-нибудь солнечный день!''");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "奇怪的高顶礼帽");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''我们会再见的, 不知何地, 不知何时!\n哦, 那将是个大晴天!");

			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.vanity = true;
		}
	
	}
}
