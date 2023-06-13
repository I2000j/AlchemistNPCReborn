using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.QuestFishes
{
	public class MiniShark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Shark");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мини Акула");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "迷你鲨");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Desc1");
            text.SetDefault("As I heard, sometimes sharks can't grow big enough to be counted as actual sharks. Then they should be called 'Mini Sharks'. And now you are gonna get me one of these!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как я слышал, иногда акулы не могут вырасти достаточно большими, чтобы считаться настоящими акулами. Тогда их следовало бы назвать 'Мини-акулами'. А теперь ты достанешь мне одну из них!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我听说，有时鲨鱼不能长到足以算作真正的鲨鱼。 那么他们应该被称为'迷你鲨鱼'。 现在你要给我一个！");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "Catch1");
            text.SetDefault("Caught in the Ocean.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловится в океане.");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;
		}

		public override void UpdateInventory(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().MiniShark = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return true;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			string desc = Language.GetTextValue("Mods.AlchemistNPCReborn.Desc1");
            string catc = Language.GetTextValue("Mods.AlchemistNPCReborn.Catch1");

			description = desc;
			
			catchLocation = catc;
		}
	}
}
