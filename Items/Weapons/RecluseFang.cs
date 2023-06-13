using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class RecluseFang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recluse's Fang");
            Tooltip.SetDefault("Throws venomous boomerang");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Клык Реклюзы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бросает ядовитый бумеранг");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑隐士牙旋刃");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷剧毒回旋刃");
        }   
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Bananarang);
			Item.damage = 48;
			
			Item.DamageType = DamageClass.Throwing;
			Item.maxStack = 1;
			Item.rare = 2;
			Item.value = 3333;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.shootSpeed = 16f;
			Item.shoot = Mod.Find<ModProjectile>("RecluseFang").Type;
		}
		
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(Mod.Find<ModItem>("SpiderFangarang").Type, 3);
			recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}