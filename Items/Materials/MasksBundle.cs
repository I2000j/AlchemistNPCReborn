﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Materials
{
	public class MasksBundle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Masks Bundle");
			Tooltip.SetDefault("Contains masks of all vanilla bosses"
				+ "\nRequired for making ultimate accessory");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Набор Масок");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Содержит в себе маски всех базовых боссов\nНеобходим для создания ультимативного аксессуара");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "面具捆绑包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "打包了所有原版boss的面具\n是制作终极饰品的材料\n并不是Steam的游戏捆绑包哦!");
        }    
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 5000000;
			Item.rare = 9;
			Item.knockBack = 6;
			Item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.KingSlimeMask, 1);
			recipe.AddIngredient(ItemID.EyeMask, 1);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilMask");
			recipe.AddIngredient(ItemID.BeeMask, 1);
			recipe.AddIngredient(ItemID.SkeletronMask, 1);
			recipe.AddIngredient(ItemID.FleshMask, 1);
			recipe.AddIngredient(ItemID.TwinMask, 1);
			recipe.AddIngredient(ItemID.DestroyerMask, 1);
			recipe.AddIngredient(ItemID.SkeletronPrimeMask, 1);
			recipe.AddIngredient(ItemID.PlanteraMask, 1);
			recipe.AddIngredient(ItemID.GolemMask, 1);
			recipe.AddIngredient(ItemID.DukeFishronMask, 1);
			recipe.AddRecipeGroup("AlchemistNPCReborn:CultistMask");
			recipe.AddIngredient(ItemID.BossMaskMoonlord, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
