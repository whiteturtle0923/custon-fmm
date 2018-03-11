using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Fargowiltas.Tiles
{
	public class FargoGlobalTile : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if(type == TileID.CrystalBall)
			{
				int[] adjTiles = new int[]{ TileID.DemonAltar, TileID.CrystalBall}; 
				
				return adjTiles;
			}
			
			if(type == mod.TileType("CrucibleCosmosSheet"))
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
			}
			 
            return base.AdjTiles(type);
		}
	}
}