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
	class WoFBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh booster");
			Tooltip.SetDefault("Increases max amount of minions/sentries by 1, defense and DR by 10/10%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Стены Плоти");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает максимальной количество прислужников/турелей на 1, защиту и сопротивление урону на 10/10%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉之墙增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加1召唤物和哨兵炮台上限，10防御力和10%伤害减免");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().WoFBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().WoFBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().WoFBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().WoFBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
