﻿using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCReborn.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class ParadiseLostWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost Wings (T-03-46)");
			Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
			+ "\nHave thou not yet realized that pain is nothing?"
			+ "\nThou want me to prove the miracle."
			+ "\nThou shall believe in me and granted with life. I shall show you the power.''"
			+ "\n[c/FF0000:EGO Gift]"
			+ "\nCounts as wings"
			+ "\nAlso allows to run"
			+ "\nHas very huge wing time and excellent horizontal speed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крылья Потерянного Рая (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Э.П.О.С. Дар]\nСчитается крыльями\nИмеют большое время полёта и великолепную горизонтальную скорость");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失乐园之翼 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'你不必担心, 我已经听到了你那略带惊恐的祈祷."
            + "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?"
            + "\n你要我证明奇迹."
            + "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'"
            + "\n[c/FF0000:EGO 礼物]"
            + "\n等同于翅膀"
            + "\n允许奔跑"
            + "\n拥有非常长的飞行时间和优秀的水平飞行速度");
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
			if (player.velocity.Y == 0f)
			{
				player.accRunSpeed = 10f;
				player.moveSpeed += 0.25f;
			}
			player.wingTimeMax = 280;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}
		
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 18f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "TwilightWings");
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}