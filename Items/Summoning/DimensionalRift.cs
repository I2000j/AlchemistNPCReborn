﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Summoning
{
	public class DimensionalRift : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 64;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.height = 64;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<Projectiles.DimensionalRift>();
			Item.shootSpeed = 10f;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Rift");
			Tooltip.SetDefault(@"Glass globe containing the rift between dimensions
Don't break it!!!");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разрыв между измерениями");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), @"Стеклянный шар, хранящий разрыв между измерениями внутри
Не разбей его!!!");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "次元裂隙");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), @"含有次元之间裂缝的玻璃球
别打破了!!!");
        }

		public override bool CanUseItem(Player player){
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BillCipher>());
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("StrangeTopHat").Type);
			recipe.AddIngredient(170, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
