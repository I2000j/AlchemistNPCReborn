using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TheSecretVR : ModItem
	{ // Not Done Yet
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret VR Glasses");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Секретные VR Очки");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "秘密VR眼镜");

			Tooltip.SetDefault("It's better for you not to know why you have it!");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лучше тебе не знать, почему это у тебя!");

			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "TheSecretVRBonus");
		    text.SetDefault("Gives you unlimited power,"
		    + "\nbut remember [c/4d180d:forbidden fruit is sweetest]");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт вам безграничную силу, \nно помните [c/4d180d:запретный плод сладок]");
			LocalizationLoader.AddTranslation(text);
        }
	
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1650000;
			Item.rare = -12;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return true;
		}

		public override void UpdateArmorSet(Player player)
		{
            string TheSecretVRBonus = Language.GetTextValue("Mods.AlchemistNPCReborn.TheSecretVRBonus");
			player.setBonus = TheSecretVRBonus;
            player.statDefense = 0;
			player.statLifeMax2 = 1;
            player.GetDamage(DamageClass.Generic) += 10f;
			player.GetCritChance(DamageClass.Generic) = 100;
			player.moveSpeed += 0.33f;
			player.dash = 0;
			player.blackBelt = false;
            player.spikedBoots = 0;
			player.AddBuff(ModContent.BuffType<Buffs.UniversalComb>(), 2);
		}
	}
}