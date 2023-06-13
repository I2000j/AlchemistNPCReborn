using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.QuestFishes
{
	public class VortexFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вихревая Рыба");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星旋鱼");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Desc7");
            text.SetDefault("There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Есть такая неземного вида рыба... вероятно, она выглядит так потому, что родом из небесных водоемов. Наверное, вкус тоже божественный, так что принеси её мне!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有一条看起来很神秘的鱼。.. 可能看起来是这样的，因为它来自天体的水。 也许味道也很好，所以去帮我拿吧！");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "Catch7");
            text.SetDefault("Caught nearby Vortex Pillar.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловится рядом с башней Вихря.");
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
		player.GetModPlayer<AlchemistNPCRebornPlayer>().VortexFish = true;
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
			string desc = Language.GetTextValue("Mods.AlchemistNPCReborn.Desc7");
            string catc = Language.GetTextValue("Mods.AlchemistNPCReborn.Catch7");

			description = desc;
			
			catchLocation = catc;
		}
	}
}
