using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Equippable
{
    [AutoloadEquip(EquipType.Waist)]
    public class BigBirdLamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Bird's Lamp (O-02-40)");
            Tooltip.SetDefault("A month later we concluded, there was no such thing as the beast."
            + "\n[c/FF0000:EGO Gift]"
            + "\nProvides light around the character"
            + "\nIncreases all damages and critical strike chances by 5%"
            + "\nAttacks remove some of the enemy's defense depending on progression");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лампа Большой Птицы (O-02-40)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Месяц спустя мы заключили, что не было никакого Зверя.\nСоздаёт свет вокруг персонажа\nПовышает все виды урона и шанс критической атаки на 5%\nАтаки повреждают защиту противника в зависимости от стадии игры");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大鸟灯 (O-02-40)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'一个月后我们得出了结论：那些所谓的怪物根本就不存在.'\n[c/FF0000:EGO 礼物]\n点亮玩家周围\n增加5%全伤害和暴击\n攻击移除敌人大部分护甲");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = 100000;
            Item.rare = 8;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 5);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(null, "DivineLava", 30);
            recipe.AddIngredient(ItemID.PutridScent);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddIngredient(ItemID.SoulofFright, 25);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}