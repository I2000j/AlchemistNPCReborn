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
	class BetsyBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Betsy Booster");
			Tooltip.SetDefault("Your attacks inflict Daybroken, flight abilities are increased");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Бетси");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваши атаки накладывают Солнечное Пламя, улучшает способности к полёту");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "贝特西增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你的攻击造成破晓，飞行能力提升");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().BetsyBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().BetsyBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().BetsyBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().BetsyBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}

		
	}
}
