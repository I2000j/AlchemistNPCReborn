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
			Tooltip.SetDefault("Left click to teleport, right click to change teleportation location");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K (Точка появления)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Левый клик телепортирует вас, правый клик меняет локацию для телепортации");
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

			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext1");
            text.SetDefault("Melee damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战伤害/暴击率增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext2");
            text.SetDefault("Ranged damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "远程伤害/暴击率增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext3");
            text.SetDefault("Magic damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法伤害/暴击率增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext4");
            text.SetDefault("Thrown damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷伤害/暴击率增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext5");
            text.SetDefault("Summoner damage boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤伤害增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext6");
            text.SetDefault("Damage Reduction boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伤害抗性增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext7");
            text.SetDefault("Movement speed boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "移动速度增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext8");
            text.SetDefault("Max life boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大生命增加");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext9");
            text.SetDefault("Life regeneration is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "生命再生速度");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext10");
            text.SetDefault("Mana usage reduction is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法消耗减少");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext11");
            text.SetDefault("Max amounts of minions/sentries are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大召唤物/炮台数量");
            LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation("Pip-Boy4ktext12");
            text.SetDefault("Melee swing time is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战武器挥动");
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

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			//string text1 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text1") + ((player.GetDamage(DamageClass.Melee)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Generic)-4) + "%";
			//string text2 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text2") + ((player.GetDamage(DamageClass.Ranged)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Ranged)-4) + "%";
			//string text3 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text3") + ((player.GetDamage(DamageClass.Magic)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Magic)-4) + "%";
			//string text4 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text4") + ((player.GetDamage(DamageClass.Throwing)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Throwing)-4) + "%";
			//string text5 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text5") + ((player.GetDamage(DamageClass.Summon)*100)-100) + "%";
			string text1 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text6") + (int)(player.endurance*100) + "%";
			string text2 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text7") + (int)((player.moveSpeed*100)-100) + "%";
			string text3 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text8") + (player.statLifeMax2 - player.statLifeMax);
			string text4 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text9") + (player.lifeRegen);
			string text5 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text10") + (int)((player.manaCost*100)-100) + "%";
			string text6 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text11") + player.maxMinions + " / " + player.maxTurrets;
			string text7 = Language.GetTextValue("Mods.AlchemistNPCReborn.Pip-Boy3000text12") + (int)(player.GetAttackSpeed(DamageClass.Melee)*100) + "%";
			//TooltipLine line = new TooltipLine(Mod, "text1", text1);
			//TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
			//TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
			//TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
			//TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
			TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
			TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
			TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
			TooltipLine line6 = new TooltipLine(Mod, "text6", text6);
			TooltipLine line7 = new TooltipLine(Mod, "text7", text7);
			//line.OverrideColor = Color.Red;
			//line2.OverrideColor = Color.LimeGreen;
			//line3.OverrideColor = Color.SkyBlue;
			//line4.OverrideColor = Color.Orange;
			//line5.OverrideColor = Color.MediumVioletRed;
			line.OverrideColor = Color.Gray;
			line2.OverrideColor = Color.Green;
			line3.OverrideColor = Color.Yellow;
			line4.OverrideColor = Color.Brown;
			line5.OverrideColor = Color.SkyBlue;
			line6.OverrideColor = Color.Magenta;
			line7.OverrideColor = Color.Red;
			//tooltips.Insert(2,line);
			//tooltips.Insert(3,line2);
			//tooltips.Insert(4,line3);
			//tooltips.Insert(5,line4);
			//tooltips.Insert(6,line5);
			tooltips.Insert(2,line);
			tooltips.Insert(3,line2);
			tooltips.Insert(4,line3);
			tooltips.Insert(5,line4);
			tooltips.Insert(6,line5);
			tooltips.Insert(7,line6);
			tooltips.Insert(8,line7);
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
					player.GetModPlayer<TeleportSystem>().DoHomeTeleport();
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
