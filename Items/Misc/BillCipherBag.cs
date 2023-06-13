using Terraria;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPCReborn.Items.Misc
{
	public class BillCipherBag : ModItem
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

			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("GoldenKnuckles").Type));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("WrathOfTheCelestial").Type));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("LaserCannon").Type));
			//((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("GrapplingHookGunItem").Type));
			//((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("IlluminatiGift").Type));
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("BillSoul").Type));
			if (Main.rand.Next(5) == 0)
			{
				((ILoot) (object) itemLoot).Add(ItemDropRule.Common(Mod.Find<ModItem>("MysticAmulet").Type));
			}
			((ILoot) (object) itemLoot).Add(ItemDropRule.Common(ItemID.PlatinumCoin, 10));
			}
	
	}
}