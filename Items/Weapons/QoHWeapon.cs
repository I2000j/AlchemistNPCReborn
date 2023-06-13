using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class QoHWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''In the name of Love and Hate'' (O-01-04)");
			Tooltip.SetDefault("''A magical rod radiating with magical girl's lovely energy."
			+"\nBad people will be purified by its holy light and be born again."
			+"\nThey will burn. They won't want to wake up.''"
			+ "\n[c/FF0000:EGO weapon]"
			+"\nShots 4 different types of projectile"
			+"\nThey may restore HP, Mana, inflict debuff or deal double damage.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Во Имя Любви и Ненависти'' (O-01-04)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Волшебный жезл, излучающий любовную энергию Магической Девочки.\nПлохие люди будут очищены её святым сиянием и будут рождены вновь.\nОни сгорят. Они не захотят пробудиться.''n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает 4 типа снарядов\nОни могут восстановить ХП, Ману, наложить дебафф или нанести двойной урон");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''以爱与恨之名'' (O-01-04)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''这根闪闪发光的魔法棒散发着魔法少女的爱之能量."
			+"\n坏蛋将会被神圣的光辉净化, 然后重生."
			+"\n他们将会被烈焰灼烧, 失去醒来的意志.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n发射4种不同种类的抛射物"
			+"\n会根据伤害类型恢复生命值, 法力值, 造成Debuff或者双倍伤害.");
        }

		public override void SetDefaults()
		{
			Item.damage = 99;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 6;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.useAnimation = 6;   
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 125;
				Item.useTime = 5;
				Item.useAnimation = 5;
			}
			else
			{
				Item.damage = 99;
				Item.useTime = 6;
				Item.useAnimation = 6;
			}
			switch (Main.rand.Next(4))
			{
				case 0:
				Item.shoot = Mod.Find<ModProjectile>("QoH1").Type;
				break;

				case 1:
				Item.shoot = Mod.Find<ModProjectile>("QoH2").Type;
				break;
				
				case 2:
				Item.shoot = Mod.Find<ModProjectile>("QoH3").Type;
				break;
				
				case 3:
				Item.shoot = Mod.Find<ModProjectile>("QoH4").Type;
				break;
			}
		return true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(5));
			float speedX = perturbedSpeed.X;
			float speedY = perturbedSpeed.Y;
			return true;
		}
		
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.RainbowRod);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
