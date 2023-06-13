using System;
using AlchemistNPCReborn.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class GrinderMK4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grinder MK4 (T-05-41)");
			Tooltip.SetDefault("''The sharp teeth of the grinder makes a clean cut through the enemy.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nIts attack goes through enemy invincibility frames"
			+ "\nAfter certain amount of hits releases broken blades into enemies");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дробильщик MK4 (T-05-41)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Острые зубы этого дробильщика способны сделать чистый разрез сквозь врага.\n[c/FF0000:Оружие Э.П.О.С.]\nАтаки игнорируют период неуязвимости противника\nПри нанесении определённого количество ударов выпускает отработанные лезвия во врагов");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "粉碎机MK4 (T-05-41)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'锋利的刀刃能将它的目标干净利落地锯开.'\n[c/FF0000:EGO 武器]\n攻击无视无敌帧\n在命中一定次数之后将破碎的刀片释放入敌人体内");
        }

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.useStyle = 5;
			Item.useAnimation = 24;
			Item.useTime = 30;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = 6;
			Item.value = Item.sellPrice(gold: 50);

			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("GrinderMK4").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			//recipe.AddTile(null, "WingOfTheWorld");
			recipe.Register();
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 200;
					}
					else
					{
					Item.damage = 35;
					}
			return player.ownedProjectileCounts[Item.shoot] < 1; 
		}
	}
}
