﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Items.Misc
{
	public class MenacingToken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Menacing Token");
			Tooltip.SetDefault("While this is in your inventory, your next accessory reforge would be ''Menacing''"
			+"\nReforging priorities: Menacing->Lucky->Violent->Warding"
			+"\nConsumes in process");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Значок Угрозы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, ваше следующая перековка аксессуара будет ''Грозный''\nБудет потрачен в процессе");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "险恶重铸币");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 饰品下一次重铸时词缀变为'险恶'\n重铸优先级: 险恶->幸运->暴力->护佑\n在过程中将会被消耗");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 250000;
			Item.rare = 7;
		}
	}
}
