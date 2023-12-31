using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Materials
{
	public class HateVial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hate Vial");
			Tooltip.SetDefault("Contains concentrated Hate of a defeated foe"
			+"\nCan be consumed"
			+"\nConsuming grants Hate buff and Potion Sickness debuff for 2 minutes"
			+"\nHate buff gives +15% to all damages and crits and +20 to life regeneration"
			+"\nAlso decreases your defense by 30 and endurance by 15%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сосуд с Ненавистью");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хранит концентрированную Ненависть поверженного врага\nМожет быть выпит\nДаёт бафф Ненависть и дебафф Послезельевая болезнь на 2 минуты\nБафф увеличивает все виды урона и криты на 15% и увеличивает регенерацию на 20\nНо также бафф понижает защиту на 30 и стойкость на 15%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "仇恨之瓶");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "充满着来自被击败敌人的仇恨\n可消耗\n使用获得仇恨Buff和药水疾病Debuff2分钟\n仇恨Buff增加15%所有伤害和暴击率, 增加20生命恢复速度\n同时减少30点防御力和15%耐力");
        }    
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.HealingPotion);
            Item.maxStack = 99;
            Item.consumable = true;
			Item.healLife = 150;
			Item.potion = true;
			Item.value = 5000000;
			Item.rare = 10;
		}
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(21, 7200);
			player.AddBuff(ModContent.BuffType<Buffs.Hate>(), 7200);
			return true;
		}
	}
}
