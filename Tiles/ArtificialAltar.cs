﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace AlchemistNPCReborn.Tiles
{
	public class ArtificialAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Artificial Altar");
			name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Искусственный Алтарь");
            name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "人造祭坛");
            AddMapEntry(new Color(200, 200, 200), name);
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles = new int[]{ TileID.DemonAltar };
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX < 66)
			{
				r = 0.9f;
				g = 0.3f;
				b = 0.3f;
			}
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, Mod.Find<ModItem>("ArtificialAltar").Type);
		}
	}
}