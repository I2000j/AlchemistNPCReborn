using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;
using AlchemistNPCReborn.Items;
using Terraria.Audio;

namespace AlchemistNPCReborn.Items.Misc
{
	public class StatsChecker2 : ModItem
	{
		int place = 0;
		bool TPIP1 = false;
		bool TPIP2 = false;
		bool TPIP4 = false;
		bool TPIP5 = false;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pip-Boy 4K (SpawnPoint)");
			Tooltip.SetDefault("Left click to teleport home, hotkey to open teleportation menu");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Точка появления)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Левый клик телепортирует вас домой, горячая клавиша открывает телепортационное меню");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哔哔小子 4K");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "左键传送回家, 使用快捷键打开传送菜单");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "PIP1");
            text.SetDefault("Pip-Boy 4K (SpawnPoint)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Точка появления)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "PIP2");
            text.SetDefault("Pip-Boy 4K (Beach)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Пляж)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "PIP3");
            text.SetDefault("Pip-Boy 4K (Ocean)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Океан)");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PIP4");
            text.SetDefault("Pip-Boy 4K (Dungeon)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Данж)");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PIP5");
            text.SetDefault("Pip-Boy 4K (Underworld)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Ад)");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PIP6");
            text.SetDefault("Pip-Boy 4K (Jungle)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Джунгли)");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "PIP7");
            text.SetDefault("Pip-Boy 4K (Temple)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Храм Джунглей)");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			//Item.CloneDefaults(ItemID.MagicMirror);
			Item.width = 32;
			Item.height = 32;
			Item.value = 5000000;
			Item.rare = 8;
			Item.useAnimation = 15;
            Item.useTime = 15;
			Item.useStyle = 4;
			Item.consumable = false;
			Item.noUseGraphic = true;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}


		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{	
				if (place > 5){
					place = 0;
				} else {
					place += 1;
				}
			} else {
				SoundEngine.PlaySound(SoundID.Item6);
				if (place == 0){
					player.Teleport(player.GetModPlayer<AlchemistNPCRebornPlayer>().spawnPosition, 1);
				}
				if (place == 1){
					if (TPIP1){
						TeleportClass.HandleTeleport(3);
					} else {
						TeleportClass.HandleTeleport(4);
					}
					TPIP1 = !TPIP1;
				}
				if (place == 2){
					if (TPIP2){
						TeleportClass.HandleTeleport(1);
					} else {
						TeleportClass.HandleTeleport(2);
					}
					TPIP2 = !TPIP2;
				}
				if (place == 3){
					TeleportClass.HandleTeleport(0);
				}
				if (place == 4){
					if (TPIP4){
						TeleportClass.HandleTeleport(5);
					} else {
						TeleportClass.HandleTeleport(6);
					}
					TPIP4 = !TPIP4;
				}
				if (place == 5){
					if (TPIP5){
						TeleportClass.HandleTeleport(10);
					} else {
						TeleportClass.HandleTeleport(9);
					}
					TPIP5 = !TPIP5;
				}
				if (place == 6){
					TeleportClass.HandleTeleport(7);
				}
			}
			if (place == 0){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP1"));
			}
			if (place == 1){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP2"));
			}
			if (place == 2){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP3"));
			}
			if (place == 3){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP4"));
			}
			if (place == 4){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP5"));
			}
			if (place == 5){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP6"));
			}
			if (place == 6){
				Item.SetNameOverride(Language.GetTextValue("Mods.AlchemistNPCReborn.PIP7"));
			}
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			//player.GetModPlayer<AlchemistNPCRebornPlayer>().PB4K = true;
			player.accWatch = 3;
			player.accDepthMeter = 1;
			player.accCompass = 1;
			player.accFishFinder = true;
			player.accWeatherRadio = true;
			player.accCalendar = true;
			player.accThirdEye = true;
			player.accJarOfSouls = true;
			player.accCritterGuide = true;
			player.accStopwatch = true;
			player.accOreFinder = true;
			player.accDreamCatcher = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CellPhone);
			recipe.AddIngredient(ModContent.ItemType<Items.BeachTeleporterPotion>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.OceanTeleporterPotion>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.DungeonTeleportationPotion>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.UnderworldTeleportationPotion>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.JungleTeleporterPotion>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.TempleTeleportationPotion>(), 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}
