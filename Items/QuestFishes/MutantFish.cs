using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.QuestFishes
{
	public class MutantFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мутировавшая Рыба");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "变种鱼");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Desc2");
            text.SetDefault("As I heard, sometimes sharks can't grow big enough to be counted as actual sharks. Then they should be called ''Mini Sharks''. And now you are gonna get me one of these!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Похоже, наш дорогой алхимик часто терпит неудачу в приготовлении 'качественных' зелий. Он всегда выливает свои плохие результаты в ближайший большой бассейн. И сегодня я увидел последствия этого. Рыба-мутант, которая была похожа на самолет. Я хочу, чтобы ты притащил мне её!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "看来我们亲爱的炼金术士在制备'高品质'药水方面经常失败。 他总是把糟糕的成绩倒在最近的大池子里. 今天我看到了后果。 一条看起来像飞机的变种鱼。 我要你把它带给我！");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "Catch2");
            text.SetDefault("Caught anywhere.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловится везде.");
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
		player.GetModPlayer<AlchemistNPCRebornPlayer>().DriedFish = true;
		}

		public override bool IsQuestFish() => true;

		public override bool IsAnglerQuestAvailable() => Main.hardMode;

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			string desc = Language.GetTextValue("Mods.AlchemistNPCReborn.Desc2");
            string catc = Language.GetTextValue("Mods.AlchemistNPCReborn.Catch2");

			description = desc;
			
			catchLocation = catc;
		}
	}
}
