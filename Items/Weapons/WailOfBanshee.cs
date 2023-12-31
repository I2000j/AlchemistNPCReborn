﻿using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class WailOfBanshee : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Wail Of Banshee''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Wail of Banshee''"
			+"\nWhen used causes all normal enemies on the screen to instantly die"
			+"\nExhausts player for 1 minute, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток ''Вопль Баньши''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Одноразовый предмет\nЭтот свиток содержит заклинание ''Вопль Баньши''\nПрименение мгновенно убивает всех обычных врагов на экране\nИстощает игрока на 1 минуту, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "卷轴 ''女妖之嚎''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一次性物品"
			+"\n包含着 ''女妖之嚎''法术"
			+"\n使用时, 即死屏幕中所有普通敌人"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }

		public override void SetDefaults()
		{
			Item.consumable = true;
			Item.maxStack = 99;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 2;
			Item.noMelee = true;
			Item.rare = 11;
			Item.mana = 200;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("WailOfBanshee").Type;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.UseSound = SoundID.NPCDeath59;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X, player.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("WailOfBanshee").Type, 1, 0, Main.myPlayer);
			player.AddBuff(Mod.Find<ModBuff>("Exhausted").Type, 3600); 
			return false;
		}
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(Mod.Find<ModBuff>("Exhausted").Type) && !player.HasBuff(Mod.Find<ModBuff>("ExecutionersEyes").Type) && !player.HasBuff(Mod.Find<ModBuff>("CloakOfFear").Type))
			{
				return true;
			}
			return false;
		}
	}
}
