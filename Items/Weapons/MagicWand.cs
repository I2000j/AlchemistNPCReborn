using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class MagicWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Royal Magic Wand"
			//+"\nShoots a laser beam that can eliminate everything on its way.");
			+"\nEmits magical particles that illuminate the area"
			+"\nWhen used next to an enemy, it can cause huge damage to enemy!");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебная Палочка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Королевская Волшебная Палочка\nИспускает магические частицы, которые освещают местность\nПри использовании рядом с врагом он может нанести колоссальный урон врагу!");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔杖");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "皇家魔杖\n发出神奇的粒子，照亮该地区，恢复你的健康。");
        }

		public override void SetDefaults()
		{
			Item.damage = 3500;
			Item.DamageType = DamageClass.Magic;
			Item.channel = true;                            //Channel so that you can held the weapon [Important]
			Item.mana = 55;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 1;			
			Item.shoot = ModContent.ProjectileType<Projectiles.MagicWand>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
	}
}
