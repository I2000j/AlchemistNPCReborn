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
using Terraria.GameContent.Events;

namespace AlchemistNPCReborn.Items.Misc
{
	public class WorldControlUnit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Simalation Control Unit");
			Tooltip.SetDefault("Exclusive product, designed by Angela"
			+"\nLeft click to change between day and night time"
			+"\nRight click to enable or disable rain (sandstorm in desert)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Устройства контроля симуляции");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эксклюзивное творение Анджелы\nЛевый клик для смены времени суток\nПравый клик для включения или выключения дождя (песчаной бури в пустыне)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模拟控制单元");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "独家产品，安吉拉设计\n左键昼夜交换\n右键控制下雨（沙漠中控制沙尘暴）");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool? UseItem(Player player)
        {
			if (player.altFunctionUse == 2)
			{
				if (player.ZoneDesert)
				{
					if (Sandstorm.Happening)
					{
						Sandstorm.Happening = false;
						Sandstorm.TimeLeft = 0;
					}
					else
					{
						Sandstorm.Happening = true;
						Sandstorm.TimeLeft = 36000;
					}
				} else {
					if (Main.raining)
					{
						Main.rainTime = 0;
						Main.maxRaining = 0f;
						Main.raining = false;
					}
					else
					{
						Main.rainTime = 24000;
						Main.maxRaining = 1f;
						Main.raining = true;
					}
				}
				
			} 
			else 
			{
				if (Main.dayTime)
				{
					Main.dayTime = false;
					Main.time = 0.0;
					return true;
				}
				if (!Main.dayTime)
				{
					Main.dayTime = true;
					Main.time = 0.0;
					return true;
				}
			}
			return base.UseItem(player);
		}
	}
}
