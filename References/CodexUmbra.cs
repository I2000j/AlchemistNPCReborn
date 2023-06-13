using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.References
{
	public class CodexUmbra : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Codex Umbra");
			Tooltip.SetDefault("I'm so sorry, Charlie..."
			+"\n[c/8b0088:*Reference Item*]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кодекс Умбра");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мне так жаль, Чарли...\n[c/8b0088:*Предмет Отсылка*]");
        }

		public override void SetDefaults()
		{
			Item.DefaultToStaff(ModContent.ProjectileType<Projectiles.DarkShot>(), 7, 20, 11);
			Item.width = 23;
			Item.height = 16;
			Item.maxStack = 1;
			Item.rare = 3;
			Item.UseSound = SoundID.Item21;

			Item.SetWeaponValues(35, 6, 32);
		}	
	}
}