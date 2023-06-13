﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCReborn;
using Terraria.WorldBuilding;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Stormbreaker : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Forged to fight the most powerful beings in the universe. Wield it wisely."
			+"\nRight click in inventory to change damage type");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Громобой");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выкован для противодействия самым мощным существам во вселенной. Используй его мудро.\nПравый клик в инвентаре меняет тип урона");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "风暴战锤");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "为了与宇宙中最强大的存在战斗而打造. 请明智地使用它."
			+"\n在物品栏中右键切换伤害类型");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(3858);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 110;
			Item.crit = 21;
			Item.width = 50;
			Item.height = 40;
			Item.hammer = 600;
			Item.axe = 120;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 10;
			Item.expert = true;
			Item.scale = 1.5f;
			Item.shoot = Mod.Find<ModProjectile>("StormbreakerSwing").Type;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.shoot = Mod.Find<ModProjectile>("StormbreakerSwing").Type;
			}
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.damage = 150;
				Item.shootSpeed = 24f;
				Item.shoot = Mod.Find<ModProjectile>("Stormbreaker").Type;
				Item.noMelee = true;
				Item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			Item.consumable = true;
            Item.NewItem(((Entity) player).GetSource_FromThis((string) null),(int)player.position.X, (int)player.position.Y, player.width, player.height, Mod.Find<ModItem>("StormbreakerThrown").Type, 1, false, 82);
        }
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddRecipeGroup("AlchemistNPCReborn:AnyLunarHamaxe");
			recipe.AddIngredient(ItemID.MoltenHamaxe);
			recipe.AddIngredient(ItemID.MeteorHamaxe);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
