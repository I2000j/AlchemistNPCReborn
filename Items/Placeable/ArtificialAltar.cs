using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Placeable
{
	public class ArtificialAltar : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Artificial Altar, made by occult powers");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Искусственный Алтарь");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Искусственный алтарь, созданный оккультными силами");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "人造祭坛");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "人造祭坛, 使用神秘力量制作而成");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 10000;
			Item.createTile = Mod.Find<ModTile>("ArtificialAltar").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
			recipe.AddIngredient(ItemID.RottenChunk, 15);
			recipe.AddIngredient(ItemID.BattlePotion, 5);
			recipe.AddIngredient(ItemID.ThornsPotion, 5);
			recipe.AddIngredient(ItemID.Deathweed, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
			recipe.AddIngredient(ItemID.Vertebrae, 15);
			recipe.AddIngredient(ItemID.BattlePotion, 5);
			recipe.AddIngredient(ItemID.ThornsPotion, 5);
			recipe.AddIngredient(ItemID.Deathweed, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}