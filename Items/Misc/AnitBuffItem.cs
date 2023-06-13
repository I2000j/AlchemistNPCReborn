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
using Terraria.Audio;

namespace AlchemistNPCReborn.Items.Misc
{
	public class AntiBuffItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Anti Buff");
			Tooltip.SetDefault("Use to toggle Anti Buff mode"
			+"\nDuring Anti Buff mode, you are immune to all buffs (not debuffs)"
			+"\nBuffs without duration display are not disabled"
			+"\nBosses and minibosses may drop permament boosting items"
			+"\nTheir effects would work only if mode is on");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Анти Бафф");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Используйте для переключения Анти Бафф режима\nВы имунны ко всем баффам (не дебаффам)\nБаффы не показывающие длительности разрешены\nИз боссов и минибоссов могут выпадать предметы, дающие эффекты постоянного усиления\nЭти эффекты активны только когда режим включён");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "反buff模式");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使用以切换反buff模式"
			+"\n在反buff模式中，你将免疫所有增益buff(而不是debuff)"
			+"\n没有持续时间的buff不会被禁止"
			+"\nBoss和一些小Boss会掉落永久增益物品"
			+"\n这些物品的效果只会在这个模式启动时生效");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "AntiBuffmodeactive");
            text.SetDefault("AntiBuff mode is on.");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "АнтиБафф режим включен.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "反Buff模式开启。");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(Mod, "AntiBuffmodeisdisabled");
            text.SetDefault("AntiBuff mode is off.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "АнтиБафф режим выключен.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "反Buff模式关闭。");
            LocalizationLoader.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			//Item.UseSound = SoundID.Item4;
		}
		
		public override bool? UseItem(Player player)
        {
			SoundStyle UnHardButSound = new SoundStyle("AlchemistNPCReborn/Sounds/Item/AntiBuffChanged");
			SoundEngine.PlaySound(UnHardButSound);
			if (!AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.AntiBuffmodeactive"), 255, 255, 255);
				}
				AlchemistNPCRebornWorld.foundAntiBuffMode = true;
				return true;
			}
			if (AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.AntiBuffmodeisdisabled"), 255, 255, 255);
				}
				AlchemistNPCRebornWorld.foundAntiBuffMode = false;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
	}
}
