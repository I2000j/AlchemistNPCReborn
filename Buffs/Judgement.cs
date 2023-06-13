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
	public class Judgement : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Judgement");
			Description.SetDefault("You conjure sharp bones to impale your foes"
			+"\n33% chance to reduce taken damage to 2 hitpoints"
			+"\nReduces your Damage reduction by 33%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Правосудие");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы призываете острые кости, пронзающие врагов\n33% шанс уменьшить полученный урон до 2 единиц здоровья\nПонижает ваше сопротивление урону на 33%");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "审判");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "产生锋利的骨刺穿透你的敌人\n有33%的概率减少2点所受伤害\n伤害减免降低33%");
        }
		
		public override void Update(Player player, ref int buffIndex)
        {
            player.yoraiz0rEye = 9 - 2;
        }
	}
}
