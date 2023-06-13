using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class DeterminationBlade : ModItem
	{
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Determination Blade");
			Tooltip.SetDefault("Contains Determination of 7 souls"
			+"\nAttacks build Hate" 
			+"\nAfter a certain amount of hits, right-clicking will release the Hate");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Клинок Решимости");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хранит в себе Решимость семи душ\nАтаки заряжают Ненависть\nПосле определённого количества ударов вы можете её выпустить, нажав правую кнопку мыши");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "决绝之剑");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "七魂之决绝蕴于此剑\n攻击增加仇恨\n攻击达到一定次数后, 右键释放仇恨.");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 99;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = 1000000;
			Item.rare = 10;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("DBD").Type;
			Item.shootSpeed = 9f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			if (AlchemistNPCReborn.DTH >= 10)
			{
			player.AddBuff(Mod.Find<ModBuff>("Hate").Type, 2);
			}
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && (AlchemistNPCReborn.DTH < 10))
			{
				return false;
			}
			if (player.altFunctionUse == 2 && (AlchemistNPCReborn.DTH >= 10))
			{
				Item.shoot = Mod.Find<ModProjectile>("DTH").Type;
				AlchemistNPCReborn.DTH = 0;
			}
			if (player.altFunctionUse == 0){
			switch (count)
			{
				case 0:
				Item.shoot = Mod.Find<ModProjectile>("DBD").Type;
				count++;
				break;

				case 1:
				Item.shoot = Mod.Find<ModProjectile>("DBPV").Type;
				count++;
				break;
				
				case 2:
				Item.shoot = Mod.Find<ModProjectile>("DBJ").Type;
				count++;
				break;
				
				case 3:
				Item.shoot = Mod.Find<ModProjectile>("DBB").Type;
				count++;
				break;
				
				case 4:
				Item.shoot = Mod.Find<ModProjectile>("DBP").Type;
				count++;
				break;
				
				case 5:
				Item.shoot = Mod.Find<ModProjectile>("DBI").Type;
				count++;
				break;
				
				case 6:
				Item.shoot = Mod.Find<ModProjectile>("DBK").Type;
				count = 0;
				break;
			}
			
		}
		return true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (count == 3)
			{
				Item.shoot = Mod.Find<ModProjectile>("DBJ").Type;
				int numberProjectiles = 3 + Main.rand.Next(3);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("DBJ").Type, damage*2, Item.knockBack, player.whoAmI);
				}
			}
			if (count == 4)
			{
				Item.shoot = Mod.Find<ModProjectile>("DBB").Type;
				int numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("DBB").Type, damage*2, Item.knockBack, player.whoAmI);
				}
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "SoulEssence", 7);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
