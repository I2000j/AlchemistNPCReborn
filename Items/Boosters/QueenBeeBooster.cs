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
	class QueenBeeBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee booster");
			Tooltip.SetDefault("Hostile bees do less damage and your regeneration is increased by 6, immunity to poisons");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Королевы Пчёл");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Враждебные пчёлы наносят меньше урона и ваша регенерация увеличена на 6, иммунитет к ядам");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜂后增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "敌方蜜蜂的伤害降低并且你的生命再生速度增加6，免疫中毒");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().QueenBeeBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().QueenBeeBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().QueenBeeBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().QueenBeeBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
