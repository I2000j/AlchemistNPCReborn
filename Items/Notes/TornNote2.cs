using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Notes
{
	public class TornNote2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #2");
			Tooltip.SetDefault("''It is not well known, but the Wing of the World allows you to make EGO equipment, which is unique in its own ways."
			+ "\nIf the Wing of the World is placed in empty housing, it can attract a special NPC, called Operator."
			+ "\nAnd if you are wondering what EGO stands for, then here it is: Extermination of Geometrical Organ.''"
			+ "\nThere is something else, but you couldn't read it. Not without parts #1 & #3. Maybe the Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Изорванная записка #2");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Это малоизвестно, но Крыло Мира позволяет создавать экипировку Э.П.О.С., которая по своему уникальна.\nЕсли Крыло Мира установить в свободном доме, то оно привлечёт особого NPC (Оператора)\nИ если кто-то всё ещё спрашивает, что означает Э.П.О.С., то вот: Экспериментально Полученные Орудия уСмирения.'\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破损的笔记 #2");
            base.Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'它并不是众所周知的, 但是世界之翼可以制作EGO器材, 某种意义上来说是独一无二的." +
                "\n如果世界之翼被放置在了一间空房子里, 就会招来一个特殊的NPC, 叫做操作员" +
                "\n如果你想知道, EGO到底代表了什么, 答案是：Extermination of Geometrical Organ.'" +
                "\n(汉化组无聊科普：全套EGO装备来自于游戏《脑叶公司》, 本模组EGO部分翻译参考中文Wiki)" +
                "\n还有一些内容, 但是你并读不到. 除非你有碎片 #1 和 #3. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TornNote2Piece>(),35);
            recipe.AddIngredient(ItemID.ShadowScale, 15);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

			Recipe recipe_alt = CreateRecipe();
            recipe_alt.AddIngredient(ModContent.ItemType<TornNote2Piece>(),35);
            recipe_alt.AddIngredient(ItemID.TissueSample, 15);
            recipe_alt.AddTile(TileID.Loom);
            recipe_alt.Register();  
        }	
	}
}
