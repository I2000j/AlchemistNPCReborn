using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Placeable
{
	public class Beacon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beacon");
			Tooltip.SetDefault("Can be used as target for Beacon Teleporter potion while placed"
			+"\nCannot be placed if another one is already placed in the world");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Маяк");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Может быть использован в качестве цели для Телепортатора к Маяку, когда размещён\nНе может быть установлен, если он уже есть в мире");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "信标");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置后可以用来作为信标传送药剂的目标\n在已经放置了一个信标的情况下无法放置第二个");
        }

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 30;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = Mod.Find<ModTile>("Beacon").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalBall);
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddRecipeGroup("AlchemistNPCReborn:Tier3Bar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalBall);
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddRecipeGroup("AlchemistNPCReborn:Tier3Bar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}