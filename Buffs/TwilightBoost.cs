using System;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Linq;
using Microsoft.Xna.Framework;
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
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCReborn;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCReborn.Buffs
{
    public class TwilightBoost : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twilight Boost");
            Description.SetDefault("You are immune to damage and deal 3x damage");
            Main.debuff[Type] = false;
            
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумеречное Усиление");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы неуязвимы и наносите трёхкратный урон");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅增强");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "免疫伤害, 造成3倍伤害");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //if (player.HeldItem.type != mod.ItemType("Twilight"))
            //{
            //    player.DelBuff(buffIndex);
            //    buffIndex--;
            //}
            player.immune = true;
            
            player.GetDamage(DamageClass.Melee) += 3f;
            player.GetDamage(DamageClass.Ranged) += 3f;
            player.GetDamage(DamageClass.Magic) += 3f;
            player.GetDamage(DamageClass.Summon) += 3f;
            //if (ModLoader.GetMod("ThoriumMod") != null)
            //{
            //    ThoriumBoosts(player);
            //}
            //if (ModLoader.GetMod("Redemption") != null)
            //{
            //    RedemptionBoost(player);
            //}
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                Calamity.Call("AddRogueDamage", player, 300);
            }
        }

        //private void RedemptionBoost(Player player)
        //{
        //    Redemption.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.DruidDamagePlayer>();
        //    RedemptionPlayer.druidDamage += 3f;
        //}
//
        //private void ThoriumBoosts(Player player)
        //{
        //    ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
        //    ThoriumPlayer.symphonicDamage += 3f;
        //    ThoriumPlayer.radiantBoost += 3f;
        //}
    }
}
