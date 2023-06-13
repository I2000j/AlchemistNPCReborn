using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Notes
{
	public class TornNote2Piece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Note Piece");
			Tooltip.SetDefault("Looks forgotten...");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фрагмент Записки");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выглядит забытой...");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "注意事项");
            base.Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "看起来被遗忘了。..");
        }

		public override void SetDefaults()
		{
			Item.width = 15;
			Item.height = 11;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}
	}
}
