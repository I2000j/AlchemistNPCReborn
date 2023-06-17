﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BlackCatHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cat's bow and ears");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бантик и ушки Чёрной Кошки");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑猫的头箍和耳朵");
			
			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "BlackCatSetBonus");
		    text.SetDefault("Increases current melee damage by 25% and adds 15% to melee critical strike chance"
		    + "\n+48 defense"
		    + "\nIncreases movement speed by 33%"
		    + "\nPlayer is under permanent effect of Battle Combination"
            + "\nGrants the abilities of a Master Ninja");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в ближнем бою на 25% и добавляет 15% к шансу критического удара\n+48 защиты\nИгрок находится под постоянным эффектом комбинации Битвы\nДаёт способности Мастера Ниндзя");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加25%当前近战伤害, 增加15%近战暴击率"
            + "\n增加 48 防御力"
            + "\n增加33%移动速度"
            + "\n给予永久坦战药剂包效果"
            + "\n并获得忍者大师的能力");
			LocalizationLoader.AddTranslation(text);

			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("BlackCatBody").Type && legs.type == Mod.Find<ModItem>("BlackCatLegs").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
            string BlackCatSetBonus = Language.GetTextValue("Mods.AlchemistNPCReborn.BlackCatSetBonus");
			player.setBonus = BlackCatSetBonus;
            player.statDefense += 48;
            player.GetDamage(DamageClass.Melee) += 0.25f;
			player.GetCritChance(DamageClass.Generic) += 15;
			player.moveSpeed += 0.33f;
			player.AddBuff(Mod.Find<ModBuff>("BattleComb").Type, 2);
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
	}
}