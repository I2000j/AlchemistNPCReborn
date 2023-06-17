using Terraria.ID;
using Terraria;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Equippable
{
	public class LilithCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lilith Charm");
			Tooltip.SetDefault("Gives 15% magic bonus damage and 10% to critical strike chance"
			+ "\nDecreases mana usage by 25%"
			+ "\nIncreases max mana by 100"
			+ "\nIncreases mana regeneration rate greatly"
			+ "\nIncreases mana stars pickup range"
			+ "\nAutomatically uses mana potions"
			+ "\nYou shoot cluster of deadly bees while using magic weapons"
			+ "\nBees has low chance to heal you after hitting the enemy"
			+ "\nHide visual to disable bees"
			+ "\nDoesn't work with some very specific weapons");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Оберег Лилит");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает магический урон на 15% и шанс критического удара\nУменьшает затраты маны на 25%\nУвеличивает максимальную ману на 100\nЗначительно ускоряет восстановление маны\nУвеличивает радиус сбора звёзд\nАвтоматически использует зелья маны\nВы выстреливает кучку смертоносных пчёл при использовании любого магического оружия\nПчёлы имеют шанс полечить вас после удара по противнику\nСмена видимости аксессуара выключает пчёл\nПоследнее не работает с некоторым специфическим оружием");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "莉莉丝魔咒");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加15%魔法伤害和10%暴击率\n减少25%法力消耗\n增加100法力最大值\n极大增加法力回复\n增加法力星拾取范围\n自动使用魔力药水\n使用魔法武器时, 发射一群致命蜜蜂\n蜜蜂攻击敌人后小概率治愈玩家\n关闭饰品可见度来关闭蜜蜂\n不适用于某些武器");
        }
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (!hideVisual)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).LilithEmblem = true;
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).BeeHeal = true;
			}
			if (hideVisual)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).LilithEmblem = false;
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).BeeHeal = false;
			}
			player.manaMagnet = true;
			player.GetDamage(DamageClass.Magic) += 0.15f;
			player.GetCritChance(DamageClass.Magic) += 15;
			player.statManaMax2 += 100;
			player.manaFlower = true;
            player.manaCost -= 0.25f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 50;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "LilithEmblem");
			recipe.AddIngredient(null, "ChromaticCrystal", 4);
			recipe.AddIngredient(null, "SunkroveraCrystal", 4);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 4);
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if (Calamity == null)
			{
				recipe.AddTile(null, "MateriaTransmutator");
			}
			if (Calamity != null)
			{
				recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.Register();
		}
	}
}