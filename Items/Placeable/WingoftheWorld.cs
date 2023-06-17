using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Placeable
{
	public class WingoftheWorld : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wing of the World");
			Tooltip.SetDefault("Needed to craft EGO equipment"
			+"\nCounts as table, chair and light source");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крыло Мира");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необходимо для создания Э.П.О.С экипировки\nСчитается за стол, стул и источник света");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界之翼");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用来制作EGO装备\n可视为桌子, 椅子和光源");
        }

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 60;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 100000;
			Item.createTile = Mod.Find<ModTile>("WingoftheWorld").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddRecipeGroup("AlchemistNPCReborn:EvilComponent", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}