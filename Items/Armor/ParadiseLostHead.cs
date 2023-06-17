using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCReborn.Items.PaleDamageClass;

namespace AlchemistNPCReborn.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ParadiseLostHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paradise Lost Crown of Thorns (T-03-46)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Терновый Венец Потерянного Рая (T-03-46)");
            Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
            + "\nHave thou not yet realized that pain is nothing?"
            + "\nThou want me to prove the miracle."
            + "\nThou shall believe in me and granted with life. I shall show you the power.''"
            + "\n[c/FF0000:EGO armor piece]"
            + "\n+100 max mana"
            + "\nIncreases melee speed by 33%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы хотите, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Часть брони Э.П.О.С.]\n+100 к максимуму маны\nУвеличивает скорость ближнего боя на 35%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失乐园荆棘王冠 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'你不必担心, 我已经听到了你那略带惊恐的祈祷." +
                "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?" +
                "\n你要我证明奇迹." +
                "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'" +
                "\n[c/FF0000:EGO 盔甲]" +
                "\n增加 100 最大法力值" +
                "\n增加 33% 近战速度");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "ParadiseLostSetBonus");
            text.SetDefault("Increases all damage by 35% and adds 25% to critical strike chance"
            + "\nIncreases damage dealt by EGO weapons"
            + "\nChanges would be seen after first usage of weapons"
            + "\nIf hit taken deals less than 100 damage, then it will be nullified.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает любой урон на 35% и добаляет 25% к шансу критического удара\nУвеличивает урон наносимый оружием Э.П.О.С.\nЕсли вы получаете меньше 150 урона, то урон будет аннулирован");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加 35% 所有伤害, 增加 25% 暴击率"
            + "\n使用 EGO 武器造成更多伤害"
            + "\n第一次使用武器后就能看见变化"
            + "\n如果你受到的伤害小于 150 , 伤害将会无效化.");
            LocalizationLoader.AddTranslation(text);

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000000;
            Item.rare = 11;
            Item.defense = 35;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 100;
            player.GetAttackSpeed(DamageClass.Melee) += 0.33f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("ParadiseLostBody").Type && legs.type == Mod.Find<ModItem>("ParadiseLostLegs").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            string ParadiseLostSetBonus = Language.GetTextValue("Mods.AlchemistNPCReborn.ParadiseLostSetBonus");
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost = true;
            player.setBonus = ParadiseLostSetBonus;
            player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
            player.GetDamage(DamageClass.Generic) += 0.35f;
            player.GetCritChance(DamageClass.Generic) += 25;
            player.GetCritChance(DamageClass.Magic) += 25;
            player.GetCritChance(DamageClass.Ranged) += 25;
            player.GetCritChance(DamageClass.Throwing) += 25;
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 25);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "TwilightCrown");
            recipe.AddIngredient(null, "ChromaticCrystal", 5);
            recipe.AddIngredient(null, "SunkroveraCrystal", 5);
            recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
            recipe.AddIngredient(null, "EmagledFragmentation", 100);
            recipe.AddTile(null, "MateriaTransmutator");
            recipe.Register();
        }
    }
}