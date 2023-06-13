using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.QuestFishes
{
	public class SolarFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Солнечная Рыба");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "日耀鱼");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Desc4");
            text.SetDefault("There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Есть такая неземного вида рыба... вероятно, она выглядит так потому, что родом из небесных водоемов. Наверное, вкус тоже божественный, так что принеси её мне!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有一条看起来很神秘的鱼。.. 可能看起来是这样的，因为它来自天体的水。 也许味道也很好，所以去帮我拿吧！");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "Catch4");
            text.SetDefault("Caught nearby Solar Pillar.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловится рядом с башней Солнца.");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;		//The rarity of -11 gives the Item orange color
		}

		public override void UpdateInventory(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().SolarFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			if (Main.hardMode && NPC.downedAncientCultist)
			{
				return true;
			}
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			string desc = Language.GetTextValue("Mods.AlchemistNPCReborn.Desc4");
            string catc = Language.GetTextValue("Mods.AlchemistNPCReborn.Catch4");

			description = desc;
			
			catchLocation = catc;
		}
	}
}
