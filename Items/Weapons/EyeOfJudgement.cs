using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn.Projectiles;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class EyeOfJudgement : ModItem
	{
		public static int counter = 15;
		public override void SetStaticDefaults()
		
		{
			DisplayName.SetDefault("Eye of Judgement");
			Tooltip.SetDefault("'If you keep going the way you are now..."
			+"\nYou're gonna have a bad time.'"
			+"\nEndlessly generates sharp bones, which will home onto enemies while you hold this"
			+"\nCreates 8 homing bones on cursor position on use "
			+"\nDoesn't take minion slots. Can be combined with other minions"
			+"\n33% chance to reduce damage taken by player to 2 hitpoints"
			+"\nReduces player's endurance by 33%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Глаз Правосудия");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ты дальше будешь себя так вести...\nТо у тебя БУДУТ неприятности.\nБесконечно создаёт острые кости, которые наводятся на врагов\nСоздаёт 8 самонаводящихся костей у позиции курсора при применении\n33% шанс снизить полученный урон до 2 ХП при получении удара\nПонижает ваше сопротивление урону на 33%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "审判之眼");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'如果你继续现在的道路...\n你的日子不会好过'\n当你手持此物时会不断产生骨刺自动追踪敌人\n使用时在鼠标位置产生8根会追踪敌人的骨刺\n不占用召唤栏位, 可以结合其他召唤物使用\n33%的几率减少2点所受伤害\n降低33%耐力");
        }    
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Summon;
			Item.damage = 100;
			Item.width = 34;
			Item.mana = 25;
			Item.height = 36;
			Item.noUseGraphic = true;
			Item.useStyle = 1;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.maxStack = 1;
			Item.value = 1000000;
			Item.holdStyle = 1;
			Item.rare = -12;
			Item.scale = 1f;
			Item.knockBack = 4;
			Item.shoot = ModContent.ProjectileType<SharpBone>();
			Item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X+150, position.Y+150, vel1.X, vel1.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X-150, position.Y-150, vel2.X, vel2.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X-150, position.Y+150, vel3.X, vel3.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X+150, position.Y-150, vel4.X, vel4.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y+150, vel5.X, vel5.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y-150, vel6.X, vel6.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X-150, position.Y, vel7.X, vel7.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X+150, position.Y, vel8.X, vel8.Y, ModContent.ProjectileType<SharpBone>(), Item.damage, 0, Main.myPlayer);
			return false;
		}
		
		public override void HoldItem(Player player)
		{
		player.AddBuff(ModContent.BuffType<Buffs.Judgement>(), 60);
		player.endurance -= 0.33f;
		if (counter == 30)
			{
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), player.Center.X+20+Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, ModContent.ProjectileType<SharpBone>(), Item.damage*2, 0, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), player.Center.X+20+Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, ModContent.ProjectileType<SharpBone>(), Item.damage*2, 0, player.whoAmI);
					counter = 0;
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),  player.Center.X-20-Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, ModContent.ProjectileType<SharpBone>(), Item.damage*2, 0, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),  player.Center.X-20-Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, ModContent.ProjectileType<SharpBone>(), Item.damage*2, 0, player.whoAmI);
					counter = 0;
					}
				}
			}
		counter++;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
	}
}
