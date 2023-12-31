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
	public class LaetitiaRibbon : ModItem
	{
		public int ad = 3;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Ribbon (O-01-67)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ленточка Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 5%"
			+ "\nDefense grows stronger when certain bosses are killed"
			+ "\nArmor's base defense is 3");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не могло покинуть своих друзей.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает урон прислужников на 5%\nЗащита увеличивается после убийства определенных боссов\nБазовая защита равна 3");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅缎带 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'外套上精美的丝带和蝴蝶结寄托着少女对幸福的向往, 一个孩子不能离开朋友.'\n[c/FF0000:EGO 盔甲]\n增加5%召唤物伤害\n击败特定Boss之后增加防御力\n基础防御为3");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "LaetitiaSetBonus");
		    text.SetDefault("Allows to summon Little Witch Monster from the Gift"
		    + "\nMinion damage grows stronger by additional 25% in Hardmode"
		    + "\nDoubles speed of Laetitia Rifle");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Позволяет призвать Монстра Маленькой Ведьмы из Дара.\nУрон прислужников дополнительно увеличивается на 25% в Хардмоде.\nУдваивает скорость атаки Винтовки Летиции");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "允许召唤来自礼物的小巫怪\n肉后增加25%召唤伤害\n蕾蒂希娅来复枪射速加倍");
            LocalizationLoader.AddTranslation(text);

			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 7;
			Item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("LaetitiaCoat").Type && legs.type == Mod.Find<ModItem>("LaetitiaLeggings").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
			string LaetitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPCReborn.LaetitiaSetBonus");
			player.setBonus = LaetitiaSetBonus;
			if (Main.hardMode)
			{
			player.GetDamage(DamageClass.Summon) += 0.25f;
			}
			if (NPC.downedPlantBoss)
			{
			//player.SporeSac();
            player.sporeSac = true;
			}
            player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet = true;
        }
		
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.05f;
			Item.defense = ad;
			ad = 3;
			if (NPC.downedQueenBee)
			{
				ad = 4;
			}
			if (NPC.downedBoss3)
			{
				ad = 5;
			}
			if (Main.hardMode)
			{
				ad = 8;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 10;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 12;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 14;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 16;
			}
			if (NPC.downedFishron)
			{
				ad = 18;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 19;
			}
			if (NPC.downedMoonlord)
			{
				ad = 22;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			Item.defense = ad;
			ad = 3;
			if (NPC.downedQueenBee)
			{
				ad = 4;
			}
			if (NPC.downedBoss3)
			{
				ad = 5;
			}
			if (Main.hardMode)
			{
				ad = 8;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 10;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 12;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 14;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 16;
			}
			if (NPC.downedFishron)
			{
				ad = 18;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 19;
			}
			if (NPC.downedMoonlord)
			{
				ad = 22;
			}
			string text1 = ad + " defense";
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			line.OverrideColor = Color.White;
			tooltips.RemoveAt(2);
			tooltips.Insert(2,line);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.Cobweb, 30);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 10);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilMush", 5);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}