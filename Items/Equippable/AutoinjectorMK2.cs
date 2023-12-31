﻿using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Equippable
{
    public class AutoinjectorMK2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Autoinjector MK2");
            Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions and increases length of invincibility after taking hit"
                + "\nAdds 15% to all damage and 10% to all critical chances"
                + "\nGives all effects of Universal Combination"
                + "\nGives effects of modded Combinations as well"
                + "\nHiding visual disables Thorium and Spirit buffs"
                + "\nLowers critical strike chance reduction of Memer's Riposte");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Автоинъектор MK2");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усиливает регенерацию \nУменьшает откат зелий лечения \nУвеличивает период неуязвимости после получения урона\nДобавляет 15% ко всем видам урона и 10% ко всем шансам критического удара\nДаёт эффект Комбинации Универсала\nТакже даёт эффекты модовых Комбинаций\nМожно отключить эффекты модовых баффов Ториума и Спирита с помощью изменения видимости\nПонижает уменьшение шанса критического удара Ответа Мемеру");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "自动注射器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "提供生命回复, 降低治疗药水的冷却时间, 延长收到伤害后的无敌时间\n增加15%全伤害和10%全伤害的暴击率\n给予万能药剂包buff（包含坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包）\n同样给予所有模组药剂包的效果\n调节饰品可见度来关闭瑟银和魂灵的Buff\n减少'Memer的反击'给予的暴击率降低效果");
        }

        public override void SetDefaults()
        {
            Item.stack = 1;
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = 11;
            Item.accessory = true;
            Item.defense = 4;
            Item.lifeRegen = 2;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AutoinjectorMK2 = true;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
            player.pStone = true;
            player.longInvince = true;
            player.AddBuff(Mod.Find<ModBuff>("UniversalComb").Type, 2);
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                player.AddBuff(Mod.Find<ModBuff>("CalamityComb").Type, 2);
                if (Calamity != null)
                {
                    Calamity.Call("AddRogueCrit", player, 10);
                }
            }
        }

    }
}
