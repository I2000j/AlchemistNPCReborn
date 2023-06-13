using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.QuestFishes
{
	public class MosesFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moses Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Рыба-Моисей");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "摩西鱼");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Desc3");
            text.SetDefault("You heard about Moses, don't you? Then hear what I found in one old fairy tale book. There said that Moses still returning to our world even after his life. And he is prefering Desert pools. Long story short, I want you to get me this fish! It could be a really hard catch, but the reward can be great too!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы слышали о Моисее, не так ли? Тогда послушайте, что я нашел в одной старой книге сказок. Там говорилось, что Моисей все еще возвращается в наш мир даже после своей смерти. И он предпочитает пустынные водоемы. Короче говоря, я хочу, чтобы ты достал мне эту рыбу! Это может быть действительно трудный улов, но и награда может быть отличной!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你听说过摩西，是吗？ 然后听听我在一本古老的童话书中发现的东西。 有人说，摩西即使在他的生命之后，仍然回到我们的世界。 他更喜欢沙漠池。 长话短说，我要你给我这条鱼！ 这可能是一个非常困难的收获，但回报也是巨大的！");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "Catch3");
            text.SetDefault("Caught in Desert.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловится в пустыне.");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 42;
			Item.height = 42;
			Item.uniqueStack = true;
			Item.rare = -11;		//The rarity of -11 gives the Item orange color
		}

		public override void UpdateInventory(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().Manna = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			Player player = Main.player[Main.myPlayer];
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				return true;
			}
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			string desc = Language.GetTextValue("Mods.AlchemistNPCReborn.Desc3");
            string catc = Language.GetTextValue("Mods.AlchemistNPCReborn.Catch3");

			description = desc;
			
			catchLocation = catc;
		}
	}
}
