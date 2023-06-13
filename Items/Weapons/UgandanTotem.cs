using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class UgandanTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Totem");
			Tooltip.SetDefault("Summons Ugandan Warrior to protect you"
			+"\nMax minions slots multiply summon's damage");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тотем Уганды");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает Воина Уганды для уничтожения ваших врагов\nМаксимальное количество прислужников увеличивает урон");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乌干达图腾");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤乌干达战士保护你"
			+"\n召唤物伤害与最大召唤栏数量成正比");
        }
		
		public override void SetDefaults()
		{
			Item.damage = 12345;
			Item.mana = 200;
			Item.width = 28;
			Item.height = 22;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(15, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Summon;
			Item.shoot = ModContent.ProjectileType<Projectiles.Minions.UgandanWarrior>();
			Item.shootSpeed = 16f;
			Item.buffType = ModContent.BuffType<Buffs.UgandanWarrior>();
			Item.buffTime = 3600;
			
		}

		//public override void UseStyle(Player player)
		//{
		//	if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		//	{
		//		player.AddBuff(item.buffType, 3600, true);
		//	}
		//}
		
		//public override bool? UseItem(Player player)
		//{
		//	if (player.altFunctionUse == 2)
		//	{
		//		player.MinionNPCTargetAim();
		//	}
		//	return base.UseItem(player);
		//}

		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{
		//	for (int l = 0; l < Main.projectile.Length; l++)
		//	{
		//		Projectile proj = Main.projectile[l];
		//		if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
		//		{
		//			proj.active = false;
		//		}
		//	}
		//	return player.altFunctionUse != 2;
		//}
	}
}
