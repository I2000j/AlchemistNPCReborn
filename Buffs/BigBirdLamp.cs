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
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Buffs
{
	public class BigBirdLamp : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Bird's Lamp");
			Description.SetDefault("Character is emitting light, all damage & crit chance are increased by 5%, attacks remove some of the enemy defense");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лампа Большой Птицы");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Персонаж светится, весь урон и шанс крита повышаются на 5%, атаки повреждают часть брони противника");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大鸟灯");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你会发光~~~ \n增加5%全伤害和暴击率, 攻击摧毁敌人护甲");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).trigger == true)
			{
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
			}
			else
			{
			}
		}
	}
}
