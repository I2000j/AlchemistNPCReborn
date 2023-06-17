using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class Pandora : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nBase form 422: Launches sharp shuriken, which sticks to enemies."
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nБазовая форма 422: Запускает бритвенно-острый сюрикен, цепляющийся за противников\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n基础形态 422: 发射锋利的手里剑, 能粘在敌人身上"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PiranhaGun);
			
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 125;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.rare = -12;
			Item.knockBack = 8;
			Item.shoot = Mod.Find<ModProjectile>("PF422").Type;
		}

		public override void HoldItem(Player player)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge += 33;
			if (player.altFunctionUse != 2)
			{
				type = Mod.Find<ModProjectile>("PF422").Type;
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2 && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge >= 500)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge = 0;		
				Item.SetDefaults(Mod.Find<ModItem>("PandoraPF013").Type);
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "PandoraPF422");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}