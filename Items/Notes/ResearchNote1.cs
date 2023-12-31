using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Notes
{
	public class ResearchNote1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #1");
			Tooltip.SetDefault("'I know that Sasscade Yo-Yo exists. But how do you make it?"
			+"\nI am pretty sure that the [c/00FF00:Terrarian Yo-Yo] is the first component."
			+"\nAn [c/00FF00:Alchemical Bundle] should be the second component..."
			+"\nBut what could be the third one? I think that it is something, related to the Sass..." 
			+"\nMaybe inner part of the [c/00FF00:Rod of Discord] can be it?"
			+"\nAnd the final component... Is the [c/00FF00:Yo-yo Bag]. I am 100% sure about this.'");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Запись исследования №1");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Я знаю, что йо-йо Сасскад существует. Но как именно его сделать?\nЯ уверена, что первый компонент - [c/00FF00:Йо-Йо Террариан].\n[c/00FF00:Алхимический Набор] может быть вторым компонентом...\nНо что насчёт третьего? Я думаю, это что-то относящееся к ссорам...\nМожет внутренняя часть [c/00FF00:Жезла Раздора] подойдёт?\nИ последний компонент... Это [c/00FF00:Сумка для Йо-Йо]. Я на 100% в этом уверена.'");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "研究笔记 #1");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'我知道那个名为萨斯卡德的悠悠球是真实存在的. 但是究竟要如何来制造它呢?" +
                "\n我很确定那个 [c/00FF00:泰拉悠悠球] 是第一个材料." +
                "\n[c/00FF00:炼金捆绑包] 也许是第二个..." +
                "\n但什么是第三个呢? 我认为那是某种, 和 Sass 相关的东西..." +
                "\n也许 [c/00FF00:裂位法杖] 的核心就是?" +
                "\n最后的材料... 是 [c/00FF00:悠悠球袋]. 我100%确定.'");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = 10000000;
			Item.rare = 10;
		}	
	}
}