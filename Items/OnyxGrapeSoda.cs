using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPCReborn.Items
{
    public class OnyxGrapeSoda : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Grape Soda");
			Tooltip.SetDefault("Returns you home and gives you 75% endurance for 5 seconds."
			+ "\nHas a 30 seconds cooldown, applies Chaos State debuff");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сода Ониксового Винограда");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Возвращает вас домой и даёт бафф на 75% поглощения урона на 5 секунд.\nИмеет 30-ти секундный откат, накладывает дебафф Хаос");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "玛瑙葡萄苏打水");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "传送回家并给予5秒钟的75%耐力.\n30秒冷却, 使用混乱状态Debuff");
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
			Item.value = 0;
            Item.consumable = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.Teleport(player.GetModPlayer<AlchemistNPCRebornPlayer>().spawnPosition, 1);
			player.AddBuff(BuffID.ChaosState, 1800);
			player.AddBuff(ModContent.BuffType<Buffs.OnyxSoda>(),300);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(ModContent.BuffType<Buffs.OnyxSoda>()) == false && player.HasBuff(BuffID.ChaosState) == false);
		}
    }
}
