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
	class GSummonerBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Summoner booster");
			Tooltip.SetDefault("Makes your attacks inflict Shadowflame and makes you immune to it");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Гоблина-Призывателя");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваши атаки усилены Теневым Пламенем, вы также иммунны к нему");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哥布林召唤师增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "让你的攻击能造成暗影炎，你免疫暗影炎");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().GSummonerBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().GSummonerBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().GSummonerBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().GSummonerBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
