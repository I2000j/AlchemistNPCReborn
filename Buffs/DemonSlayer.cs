using System;
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
	public class DemonSlayer : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Slayer");
			Description.SetDefault("You became stronger after beating him"
			+"\nImmune to Mana Sickness debuff"
			+"\nMelee speed is increased by 10%"
			+"\nArmor penetration is increased by 20"
			+"\nAdds 25% chance not to consume ammo"
			+"\nIncreases max amount of minions and sentries by 1"
			+"\nYou have a chance to release additional throwing Projectiles"
			+"\nYou are immune to some specific debuffs");
			Main.debuff[Type] = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Убийца Демонов");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы стали сильнее после победы над НИМ\nИммунитет к Магической Слабости\nСкорость ближнего боя увеличена на 10%\nПробивание брони увеличено на 20\n25% шанс не потратить патроны\nМаксимальное число турелей и прислужников увеличено на 1\nВы имеете шанс бросить дополнительное метательное оружие\nВы иммунны к некоторым дебаффам");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恶魔杀手");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "击败他之后,你变得更强了\n免疫法力病\n增加10%近战速度\n增加20点护甲穿透\n增加20%概率不消耗子弹\n+1最大召唤栏\n概率释放额外的投掷抛射物\n免疫某些特定Debuff");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
			player.maxMinions += 1;
			player.maxTurrets += 1;
			player.GetArmorPenetration(DamageClass.Generic) += 20;
			player.buffImmune[20] = true;
			player.buffImmune[22] = true;
			player.buffImmune[23] = true;
			player.buffImmune[24] = true;
			player.buffImmune[30] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.buffImmune[33] = true;
			player.buffImmune[35] = true;
			player.buffImmune[36] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[70] = true;
			player.buffImmune[94] = true;
			player.buffImmune[BuffID.Electrified] = true;
			player.buffImmune[BuffID.OgreSpit] = true;
		}
	}
}
