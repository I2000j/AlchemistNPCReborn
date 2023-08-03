using System.Collections.Generic;
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
	public class MoneyVacuum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Greed");
			Tooltip.SetDefault("While in your inventory, all money dropped goes in your inventory");

			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "贪欲之心");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "在你的背包中时，所有掉落的钱币都会吸进你的背包");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			for (int number = 0; number < 400; ++number)
			{
				if (Main.item[number].active && Main.item[number].type == 71)
				{
					player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null),Main.item[number]);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 72)
				{
					player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null),Main.item[number]);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 73)
				{
					player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null),Main.item[number]);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 74)
				{
					player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null), Main.item[number]);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}
		
		public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimsonHeart);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(Mod.Find<ModItem>("BrokenDimensionalCasket").Type);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(Mod.Find<ModItem>("DivineLava").Type, 15);
			recipe.Register();
			
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShadowOrb);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(Mod.Find<ModItem>("BrokenDimensionalCasket").Type);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(Mod.Find<ModItem>("DivineLava").Type, 15);
			recipe.Register();
        }
	}
}
