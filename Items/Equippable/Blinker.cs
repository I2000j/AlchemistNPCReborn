using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class Blinker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blinker");
			Tooltip.SetDefault("Gives you dash in the form of instant teleport for short distance\nGives a chance to dodge attacks and allows the ability to climb walls");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Блинкер");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт вам рывок в форме мгновенного телепорта на небольшое расстояние\nДаёт шанс увернуться от атаки и позволяет цепляться за стены");
        
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "闪位大师装备");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "让你的短距离冲刺变成传送\n有机会躲避攻击并能在墙壁攀爬");
		}
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 10;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).Blinker = true;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.RodofDiscord);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}