using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPCReborn.Items.Misc
{
	public class KnucklesBag : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мешок с сокровищами");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "宝藏袋");
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.EdgeOfChaos>()));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.LastTantrum>()));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.BreathOfTheVoid>()));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.ChaosBomb>()));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.UgandanTotem>()));
			//((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ModContent.ItemType<AutoinjectorMK2>()));
			
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ItemID.PlatinumCoin, 25));
		}
	}
}