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
	public class JustitiaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Crown (O-02-62)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Корона Юстиции (O-02-62)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "审判鸟王冠 (O-02-62)");
            Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases melee speed by 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире имеет место лишь в сказках.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость атак ближнего боя на 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'就像其他生物一样, 它最初也满怀着希望. 但如今, 对和平的渴望只能潜藏在幼稚的童话里.'\n[c/FF0000:EGO 盔甲]\n增加20%近战速度");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "JustitiaSetBonus");
		    text.SetDefault("Increases current melee damage by 30% and adds 15% to melee critical strike chance");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в ближнем бою на 30% и добаляет 15% к шансу критического удара");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加当前30%的近战伤害和15%近战暴击率");
            LocalizationLoader.AddTranslation(text);

			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.defense = 25;
		}
	
		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("JustitiaSuit").Type && legs.type == Mod.Find<ModItem>("JustitiaLeggings").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
			string JustitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPCReborn.JustitiaSetBonus");
			player.setBonus = JustitiaSetBonus;
			player.GetDamage(DamageClass.Melee) += 0.30f;
			player.GetCritChance(DamageClass.Generic) += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Blindfold);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}