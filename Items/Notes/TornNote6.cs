using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Notes
{
	public class TornNote6 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #6");
			Tooltip.SetDefault("''Defeating the Moon Lord allows the creation of Ultimate Accessories."
			+"\nOne of them are the Rampage Components." 
			+"\nThey increase your ranged damage & crit by 10% and provide the effect of the Sniper Scope."
			+"\nThey also turn your Musket Balls into deadly Chloroshard Bullets..."
			+"\nChloroshard bullets are basically homing Crystal Bullets with increased damage."
			+"\nAny weapons, which shoot Electrospheres would get buffed too."
			+"\nAlso, it speed ups all arrows.''"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Изорванная записка #6");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Компоненты Буйства.\nОни повышают урон и крит дальнего боя на 10%, а также даёт эффект Снайперского Прицела.\nТакжи они превращают мушкетные патроны в смертоносные Хлорофитово-осколочные пули...\nЭти пули по сути своей являются самонаводящимися Кристальными с повышенным уроном.\nЛюбое оружие стреляющее Электросферами тоже будет усилено.\nА, ну и все стрелы летят быстрее.'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破损的笔记 #6");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'在击败月亮领主之后, 你可以制造一些终极饰品." +
                "\n其中之一是狂暴组件." +
                "\n它增加10%远程伤害和暴击, 还提供了狙击镜的效果." +
                "\n同样, 它将子弹转化为了致命的橓裂弹..." +
                "\n橓裂弹就像水晶尘子弹的伤害强化版.'" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}
	}
}
