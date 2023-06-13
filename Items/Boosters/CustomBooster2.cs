using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Boosters
{
	class CustomBooster2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Custom Booster 2");
			Tooltip.SetDefault("Provides immunity to fire blocks, gives Obsidian Skin, Gills and Flipper effects");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выборочный усилитель 2");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт иммунитет к огненным блокам, даёт эффекты Жабр и Обсидиановой Кожи");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "普通增益容器2号");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "给予免疫火块，黑曜石皮肤，鱼鳃，脚蹼药剂效果");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster2 == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster2 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster2 == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster2 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(ModContent.ItemType<BrokenBooster2>(), 1);
			recipe.AddIngredient(ItemID.ObsidianSkinPotion, 30);
			recipe.AddIngredient(ItemID.GillsPotion, 30);
			recipe.AddIngredient(ItemID.FlipperPotion, 30);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilBar", 8);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
