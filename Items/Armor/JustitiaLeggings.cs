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
	[AutoloadEquip(EquipType.Legs)]
	public class JustitiaLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Leggings (O-02-62)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Поножи Юстиции (O-02-62)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "审判鸟袜统 (O-02-62)");
            Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
				+ "\n[c/FF0000:EGO armor piece]"
				+ "\n25% increased movement speed");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире возможна лишь в сказках.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 25%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'就像其他生物一样, 它最初也满怀着希望. 但如今, 对和平的渴望只能潜藏在幼稚的童话里.'\n[c/FF0000:EGO 盔甲]\n增加25%移动速度");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}