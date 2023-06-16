using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
using Terraria.WorldBuilding;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameContent.ItemDropRules;
using AlchemistNPCReborn;

namespace AlchemistNPCReborn.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
		public bool banned = false;
		public bool light = false;
		public bool chaos = false;
		public bool electrocute = false;
        public bool corrosion = false;
		public bool justitiapale = false;
		public static int kc = 0;
		public static bool ks = false;
		public static bool ksu = false;
		public bool start = false;
        public bool rainbowdust = false;
		public bool cheat = false;
		public static bool bsu = false;
		public bool i1 = false;
		public bool i2 = false;
		public bool i3 = false;
		public int bc = 0;
		public int bc2 = 0;
		public bool intermission1 = false;
		public bool stop1 = false;
		public bool intermission2 = false;
		public bool stop2 = false;
		public bool phase2 = false;
		public bool phase3 = false;
		public bool twilight = false;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void ResetEffects(NPC npc)
		{
			banned = false;
			light = false;
			corrosion = false;
			chaos = false;
			rainbowdust = false;
			electrocute = false;
			twilight = false;
			justitiapale = false;
			//N1 = false;
			//N2 = false;
			//N3 = false;
			//N4 = false;
			//N5 = false;
			//N6 = false;
			//N7 = false;
			//N8 = false;
			//N9 = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			/*if (chaos)
			{
				npc.lifeRegen -= 10000 + S*1500;
				if (damage < 999 + S*150)
				{
					damage = 1000 + S*150;
				}
			}
			if (light)
			{
				if (!Main.hardMode)
				{
					npc.lifeRegen -= 5 + C;
					if (damage < 1 + C)
					{
						damage = 1 + C;
					}
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					npc.lifeRegen -= 50 + C*2;
					if (damage < 5 + C)
					{
						damage = 5 + C;
					}
				}
				if (Main.hardMode && NPC.downedMoonlord)
				{
					npc.lifeRegen -= 500 + C*4;
					if (damage < 50 + C*2)
					{
						damage = 50 + C*2;
					}
				}
			}
			if (banned)
			{
				npc.lifeRegen -= 999999;
				if (damage < 9999)
				{
					damage = 9999;
				}
			}
			if (corrosion)
			{
				npc.lifeRegen -= 500;
				if (damage < 49)
				{
					damage = 50;
				}
			}
			if (justitiapale)
			{
				npc.lifeRegen -= 2000;
				if (damage < 199)
				{
					damage = 200;
				}
			}
			if (electrocute)
			{
				npc.lifeRegen -= 1000;
				if (damage < 99)
				{
					damage = 100;
				}
			}*/
			if (twilight)
			{
				npc.lifeRegen -= 5000;
				if (damage < 499)
				{
					damage = 500;
				}
			}
		}

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active && player == Main.player[Main.myPlayer])
                {
                    if (type == ModContent.NPCType<Tinkerer>())
                    {
                        for (nextSlot = 0; nextSlot < 40; ++nextSlot)
                        {
                            shop.item[nextSlot].shopCustomPrice *= 2;
                        }
                    }
                    if (type == ModContent.NPCType<Brewer>() || type == ModContent.NPCType<Alchemist>() || type == ModContent.NPCType<YoungBrewer>())
                    {
                        for (nextSlot = 0; nextSlot < 40; ++nextSlot)
                        {
                            shop.item[nextSlot].shopCustomPrice *= AlchemistNPCReborn.modConfiguration.PotsPriceMulti;
							if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                            {
                                if (AlchemistNPCReborn.modConfiguration.RevPrices && CalamityModRevengeance)
                                {
                                    shop.item[nextSlot].shopCustomPrice += shop.item[nextSlot].shopCustomPrice;
                                }
                            }
                            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier4)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 2;
                            }
                            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier3)
                            {
                                shop.item[nextSlot].shopCustomPrice -= ((shop.item[nextSlot].shopCustomPrice / 20) * 7);
                            }
                            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 4;
                            }
                            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier1)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 10;
                            }
                        }
                    }
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("Tremor") != null)
            {
                if (type == ModLoader.GetMod("Tremor").NPCType("Lady Moon"))
                {
                    addModItemToShop(Tremor, "DarkMass", 7500, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "CarbonSteel", 10000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Doomstone", 25000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "NightmareBar", 25000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "VoidBar", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "AngryShard", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Phantaplasm", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ClusterShard", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "DragonCapsule", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "HuskofDusk", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "NightCore", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "GoldenClaw", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "StoneDice", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ConcentratedEther", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Squorb", 250000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ToothofAbraxas", 250000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "CosmicFuel", 1000000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "EyeofOblivion", 3000000, ref shop, ref nextSlot);
                }
            }
			*/
        }

        public override void SetDefaults(NPC npc)
        {

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "UgandanKnucklesChat1");
            text.SetDefault("I have a question to ask from you...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "У меня есть к тебе вопрос...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我有个问题要问你..");
            LocalizationLoader.AddTranslation(text);

			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat4");
            text.SetDefault("WHAT? You again? I was already defeated with your help! What else do you want from me?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "ЧТО? Снова ты? Я уже потерпел поражение с твоей помощью! Что еще ты хочешь от меня?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat5");
            text.SetDefault("You dared summon me? This is going to be fun!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты посмел призвать меня? Будет весело!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat8");
            text.SetDefault("Hey you! Yes, you! I am asking the one who is controlling this 'puppet'!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эй ты! Да ты! Я спрашиваю того, кто управляет этой 'марионеткой'!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat7");
            text.SetDefault("Do you really think that you would be able to defeat me? That's hilarious!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты действительно думаешь, что сможешь победить меня? Это смешно!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat9");
            text.SetDefault("Enough playing around, now you are gonna die!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хватит баловаться, теперь ты умрешь!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat10");
            text.SetDefault("Madness is unleashed!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Безумие вырвалось на свободу!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat6");
            text.SetDefault("Hey catch this!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эй, лови это!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat11");
            text.SetDefault("You are starting to annoy me, worm!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты начинаешь меня раздражать, червяк!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat12");
            text.SetDefault("Don't start thinking you're safe behind that screen...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Не начинай думать, что ты в безопасности за этим экраном...");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat13");
            text.SetDefault("I will come to your dreams and will turn them into the horrible nightmare!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я приду к твоим снам и превращу их в жуткий кошмар!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat14");
            text.SetDefault("I will not get defeated again!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я больше не потерплю поражения!");
            LocalizationLoader.AddTranslation(text);
			text = LocalizationLoader.CreateTranslation(Mod, "BillCipherChat15");
            text.SetDefault("Prepare to suffer!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Готовься страдать!");
            LocalizationLoader.AddTranslation(text);

            if (npc.type == NPCID.DungeonGuardian)
            {
                NPCID.Sets.MPAllowedEnemies[NPCID.DungeonGuardian] = true;
            }
            if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
            {
                if (NPC.downedMoonlord)
                {
                    npc.lifeMax = 500;
                }
            }
            if (npc.type == ModContent.NPCType<Alchemist>() || npc.type == ModContent.NPCType<Brewer>() || npc.type == ModContent.NPCType<YoungBrewer>() || npc.type == ModContent.NPCType<Jeweler>() || npc.type == ModContent.NPCType<Architect>() || npc.type == ModContent.NPCType<Musician>() || npc.type == ModContent.NPCType<Tinkerer>()|| npc.type == ModContent.NPCType<Explorer>())
            {
                if (NPC.downedMoonlord)
                {
                    npc.lifeMax = 500;
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("MaterialTraderNpc") != null)
			{
				if (npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Jungle Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cavern Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cool Guy")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Desert Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Dungeon Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Evil Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Hell Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Holy Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Ocean Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Sky Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Winter Trader")))
				{
					if (NPC.downedMoonlord)
					{
						npc.lifeMax = 500;
					}
				}
			}
			*/
            if (npc.type == NPCID.Unicorn)
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)ModContent.ItemType<Items.Summoning.CaughtUnicorn>();
			}
            if (npc.type == ModContent.NPCType<Alchemist>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Brewer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Architect>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Jeweler>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
            }
			if (npc.type == ModContent.NPCType<Explorer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.RealityPiercer>();
            }
            if (npc.type == ModContent.NPCType<Operator>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
            }
            if (npc.type == ModContent.NPCType<Musician>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
            }
			if (npc.type == ModContent.NPCType<OtherworldlyPortal>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.NotesBook>();
            }
            if (npc.type == ModContent.NPCType<Tinkerer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
            }
        }
		
		public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (npc.type == ModContent.NPCType<Knuckles>())
			{
				Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
				if (player.HeldItem.type == ItemID.SlapHand)
				{
					defense = 0;
					npc.life = 1;
				}
				if (!player.GetModPlayer<AlchemistNPCRebornPlayer>().MemersRiposte)
				{
					damage = 1;
					if (crit)
					{
						damage = 2;
					}
				}
				if (player.GetModPlayer<AlchemistNPCRebornPlayer>().MemersRiposte)
				{
					damage = 2;
					if (crit)
					{
						damage = 4;
					}
				}
				return false;
			}
			return base.StrikeNPC(npc, ref damage, defense, ref knockback, hitDirection, ref crit);
		}
		
		public override void AI(NPC npc)
		{
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (npc.type == ModContent.NPCType<Knuckles>())
			{
				if (!start)
				{
					npc.position.Y = player.position.Y - 350;
					npc.position.X = player.position.X;
					start = true;
				}
				if (ks == false)
				{
					kc++;
				}
				if (kc == 2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.UgandanKnucklesChat1"), 255, 255, 255);
				}
				if (kc < 180)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					npc.dontTakeDamage = true;
				}
				if (kc == 180)
				{
					Main.NewText("DEW U NO DE WEI?", 255, 0, 0);
					ks = true;
					npc.dontTakeDamage = false;
					kc++;
				}
			}
			
			if (npc.type == ModContent.NPCType<NPCs.BillCipher>())
			{
				if (npc.life == npc.lifeMax && !start && player.name != "Bill")
				{
					npc.position.Y = player.position.Y - 300;
					npc.position.X = player.position.X;
					if (player.name == "Dipper" || player.name == "Mabel" || player.name == "Stanford" || player.name == "Stanlee" || player.name == "Stan")
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat4"), 10, 255, 10);	
					}
					else
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat5"), 10, 255, 10);
					}
					start = true;
				}
				if (npc.life <= npc.lifeMax*0.6f && !i1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat6"), 10, 255, 10);
					//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VoodooDoll"));
					i1 = true;
				}
				if (npc.life <= npc.lifeMax*0.4f && !i2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat6"), 10, 255, 10);
					//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ScreamingHead"));
					i2 = true;
				}
				if (npc.life <= npc.lifeMax*0.2f && !i3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat6"), 10, 255, 10);
					//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedMirror"));
					i3 = true;
				}
				if (npc.life <= (npc.lifeMax - npc.lifeMax/4) && !intermission1 && !stop1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat7"), 30, 255, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat8"), 30, 255, 30);
					npc.dontTakeDamage = true;
					intermission1 = true;
				}
				if (intermission1 && !stop1)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc++;
					if (bc >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop1 = true;
						intermission1 = false;
					}
				}
				if (npc.life <= npc.lifeMax/2 && !phase2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat9"), 150, 100, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat10"), 150, 100, 30);
					phase2 = true;
					for (int index1 = 0; index1 < 30; ++index1)
					{
					float X = npc.Center.X + Main.rand.Next(-2500, 2500);
					float Y = npc.Center.Y + Main.rand.Next(-2500, 2500);
					//Projectile.NewProjectile(X, Y, 0f, 0f, mod.ProjectileType("Madness"), 200, 0, Main.myPlayer);
					}
				}
				if (npc.life <= npc.lifeMax/4 && !intermission2 && !stop2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat11"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat12"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat13"), 210, 50, 10);
					npc.dontTakeDamage = true;
					intermission2 = true;
				}
				if (intermission2 && !stop2)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc2++;
					if (bc2 >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop2 = true;
						intermission2 = false;
					}
				}
				if (npc.life <= npc.lifeMax*0.15f && !phase3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat14"), 255, 0, 0);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCReborn.BillCipherChat15"), 255, 0, 0);
					phase3 = true;
				}
			}
			
		}

        public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
        {
            if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
            {
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    damage += 20;
                }
                if (NPC.downedMoonlord)
                {
                    damage = 100;
                }
            }
        }

        public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
        {
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 4;
                    randExtraCooldown = 4;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                    randExtraCooldown = 3;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                }
            }
        }

        public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
        {
            if (npc.type == NPCID.ArmsDealer)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 4;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Cyborg)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.RocketSnowmanI;
                }
            }
            if (npc.type == NPCID.Wizard)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.CursedFlameFriendly;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.MoonlordArrow;
                }
            }
        }

        public override void DrawTownAttackGun(NPC npc, ref float scale, ref int item, ref int closeness)
        {
            if (npc.type == NPCID.ArmsDealer)
            {
                if (NPC.downedMoonlord)
                {
                    item = ItemID.Megashark;
                }
            }
            if (npc.type == ModContent.NPCType<NPCs.Explorer>())
            {
                item = ModContent.ItemType<Items.Weapons.Nyx>();
                scale = 1f;
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    scale = 1f;
                    closeness = 4;
                    item = ItemID.SDMG;
                }
            }
        }

        public override void BuffTownNPC(ref float damageMult, ref int defense)
        {
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                defense += 30;
            }
            if (NPC.downedMoonlord)
            {
                defense += 80;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active && player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
                {
                    if (npc.type == 112)
                    {
                        npc.color = new Color(255, 255, 0, 100);
                        Lighting.AddLight(npc.position, 1f, 1f, 0f);
                    }
                }

				if (twilight)
				{
					if (Main.rand.Next(4) < 2)
					{
						int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Dusts.JustitiaPale>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
						Main.dust[dust].noGravity = true;
						Main.dust[dust].velocity *= 1.8f;
						Main.dust[dust].velocity.Y -= 0.5f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[dust].noGravity = false;
							Main.dust[dust].scale *= 0.5f;
						}
					}
				}
            }
        }
        public override void OnKill(NPC npc)
        {
			var source = npc.GetSource_FromAI();
			if (AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (npc.type == NPCID.KingSlime)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.KingSlimeBooster>(), 1);
				}
				if (npc.type == NPCID.EyeofCthulhu)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EyeOfCthulhuBooster>(), 1);
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrokenBooster1>(), 1);
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EaterOfWorldsBooster>(), 1);
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EaterOfWorldsBooster>(), 1);
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrainOfCthulhuBooster>(), 1);
				}
				if (npc.type == NPCID.QueenBee)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.QueenBeeBooster>(), 1);
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.SkeletronBooster>(), 1);
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrokenBooster2>(), 1);
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.WoFBooster>(), 1);
				}
				if (npc.type == NPCID.SkeletronPrime)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PrimeBooster>(), 1);
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.TwinsBooster>(), 1);
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.TwinsBooster>(), 1);
				}
				if (npc.type == NPCID.TheDestroyer)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.DestroyerBooster>(), 1);
				}
				if (npc.type == NPCID.Plantera)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PlanteraBooster>(), 1);
				}
				if (npc.type == NPCID.Golem)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.GolemBooster>(), 1);
				}
				if (npc.type == NPCID.DukeFishron)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.FishronBooster>(), 1);
				}
				if (npc.type == NPCID.CultistBoss)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.CultistBooster>(), 1);
				}
				if (npc.type == NPCID.MoonLordCore)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.MoonLordBooster>(), 1);
				}
				if (npc.type == NPCID.DD2DarkMageT1 || npc.type == NPCID.DD2DarkMageT3)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.DarkMageBooster>(), 1);
				}
				if (npc.type == NPCID.DD2OgreT2 || npc.type == NPCID.DD2OgreT3)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.OgreBooster>(), 1);
				}
				if (npc.type == NPCID.DD2Betsy)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BetsyBooster>(), 1);
				}
				if (npc.type == 471)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.GSummonerBooster>(), 1);
				}
				if (npc.type == 243)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.IceGolemBooster>(), 1);
				}
				if (npc.type == 170 || npc.type == 171 || npc.type == 180)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PigronBooster>(), 1);
				}
				if (npc.type == 395)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.MartianSaucerBooster>(), 1);
				}
				for (int k = 0; k < 255; k++)
				{
					Player player = Main.player[k];
					if (player.active)
					{
						AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
						if (modPlayer.CultistBooster == 1)
						{
							if ((npc.type == 402 || npc.type == 405 || npc.type == 407 || npc.type == 409 || npc.type == 411) && Main.rand.NextBool(5))
							{
								source = npc.GetSource_FromAI();
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentStardust, 1, 1);
							}
							if ((npc.type == 412 || npc.type == 415 || npc.type == 416 || npc.type == 417 || npc.type == 418 || npc.type == 419) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentSolar, 1, 1);
							}
							if ((npc.type == 420 || npc.type == 421 || npc.type == 423 || npc.type == 424) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentNebula, 1, 1);
							}
							if ((npc.type == 425 || npc.type == 426 || npc.type == 427 || npc.type == 429) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentVortex, 1, 1);
							}
						}
					}
				}
			}

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 327)
                {
                    if (!AlchemistNPCRebornWorld.downedDOGPumpking)
                    {
                        AlchemistNPCRebornWorld.downedDOGPumpking = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }

                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 345)
                {
                    if (!AlchemistNPCRebornWorld.downedDOGIceQueen)
                    {
                        AlchemistNPCRebornWorld.downedDOGIceQueen = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }
            }

            if (npc.type == NPCID.SandElemental)
            {
                if (!AlchemistNPCRebornWorld.downedSandElemental)
                {
                    AlchemistNPCRebornWorld.downedSandElemental = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npc, npcLoot);

        	if (npc.type == NPCID.EyeofCthulhu)
        	{
        		if (!NPC.downedBoss1)
        		{
				    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.AlchemistCharmTier1>(), 1));
        		}
        	}
			
			if (npc.type == NPCID.EyeofCthulhu && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote1>(), 1));
			}
			if (npc.type == NPCID.Creeper && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote2Piece>(), 1));
			}
			if (npc.type == NPCID.EaterofWorldsBody && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote2Piece>(), 1));
			}
			if (npc.type == NPCID.SkeletronHead && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote3>(), 1));
			}
			if (npc.type == NPCID.SkeletronPrime && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote4>(), 1));
			}
			if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer) && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote5>(), 1));
			}
			if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote5>(), 1));
			}
			if (npc.type == NPCID.TheDestroyer && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote6>(), 1));
			}
			if (npc.type == NPCID.Plantera && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote7>(), 1));
			}
			if (npc.type == NPCID.Golem && AlchemistNPCReborn.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote8>(), 1));
			}


			if (npc.type == NPCID.KingSlime)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,3)));
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));
			}
			if (npc.type == NPCID.Deerclops)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(5,8)));
			}
			if (npc.type == NPCID.QueenBee)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));
			}
			if (npc.type == NPCID.SkeletronHead)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(12,15)));
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(4,6)));
			}
			if (npc.type == NPCID.QueenSlimeBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(6,8)));
			}
			if (npc.type == NPCID.SkeletronPrime)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.TheDestroyer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.Spazmatism)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(1,2)));
			}
			if (npc.type == NPCID.Retinazer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(1,2)));
			}		
			if (npc.type == NPCID.Plantera)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(5,6)));
			}
			if (npc.type == NPCID.Golem)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.HallowBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(5,10)));
			}
			if (npc.type == NPCID.DukeFishron)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));
			}
			if (npc.type == NPCID.CultistBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));
			}

			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

			if (Calamity != null)
			{
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("DesertScourgeHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Crabulon").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("HiveMind").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PerforatorHive").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SlimeGodCore").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Cryogen").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("BrimstoneElemental").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AquaticScourgeHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SoulSeeker").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Leviathan").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AstrumAureus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlaguebringerGoliath").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("RavagerBody").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AstrumDeusHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianCommander").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianDefender").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianHealer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Providence").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("CeaselessVoid").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("StormWeaverHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Signus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Polterghast").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(4,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("OldDuke").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("DevourerofGodsHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Bumblefuck").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Yharon").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SupremeCalamitas").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 66));}
			}

			ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);

			if (ThoriumMod != null)
			{
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheGrandThunderBirdv2").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,2)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("QueenJelly").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("Viscount").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("GraniteEnergyStorm").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheBuriedWarrior").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("ThePrimeScouter").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("BoreanStriderPopped").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("FallenDeathBeholder2").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("LichHeadless").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("AbyssionReleased").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("RealityBreaker").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 33));}
			}

			ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod);

			if (SpiritMod != null)
			{
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Scarabeus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("ReachBoss").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("AncientFlyer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SteamRaiderHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Dusking").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SpiritCore").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("IlluminantMaster").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Atlas").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Overseer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 33));}
			}

            if (npc.type == NPCID.MoonLordCore)
			{
				if (AlchemistNPCReborn.modConfiguration.TornNotesDrop)
				{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote9>(), 1));
				}
				if (NPC.downedMoonlord)
				{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Armor.TheSecretVR>(), 1));
				}
				//if (AlchemistNPC.modConfiguration.TinkererSpawn)
				//{
				//	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				//}
			}
			
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.LuckCharm>(), 1));
                if (NPC.downedDeerclops)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<References.CodexUmbra>(), 1));
                }
            }
        
            //if (npc.type == ModContent.NPCType<Operator>())
            //{
            //    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
            //}
			
			

        }

		public bool CalamityModRevengeance
		{            
            get {
				ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if(Calamity != null) {
                    return (bool)Calamity.Call("GetDifficultyActive", "revengeance");
                }
                return false;
            }
        }
		
		// private readonly ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
	}
}
