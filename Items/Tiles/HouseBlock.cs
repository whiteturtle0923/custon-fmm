using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Tiles
{
	public class HouseBlock : ModTile
	{
	    int[] houseshape = new int[] { 
	    1,1,1,1,1,1,1,1,1,1,-1,
	    1,0,0,0,0,2,0,0,0,1,-1,
	    0,0,0,0,0,0,0,0,0,1,-1,
	    0,0,0,0,0,0,0,0,0,1,-1,
	    4,0,0,0,0,3,0,5,0,1,-1,
	    1,1,1,1,1,1,1,1,1,1,-2};

	    int[] housewall = new int[] { 
	    0,0,0,0,0,0,0,0,0,0,-1,
	    0,1,1,1,1,1,1,1,1,0,-1,
	    0,1,1,1,1,1,1,1,1,0,-1,
	    0,1,1,1,1,1,1,1,1,0,-1,
	    0,1,1,1,1,1,1,1,1,0,-1,
	    0,0,0,0,0,0,0,0,0,0,-2}; 

		int n = 0;
		int t = 0;
		int d = 0;
		int[] blocks = new int[] {0, 30, 4};

		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(200, 200, 200));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

		public override void RightClick(int i, int j)
		{
			int xval = i;
			int yval = j - 5;

			for(int v = 0; v <= 65; v++)
			{
				n = houseshape[v];
				t = housewall[v];
				if(n >= 0)
				{
				    WorldGen.KillWall(xval, yval);
				    WorldGen.KillTile(xval, yval, false, false, false);
				}
				if(housewall[v] == 1)
				{
				    WorldGen.PlaceWall(xval, yval, 4);
				}
				if(n == 1 || n == 2)
				{
				    WorldGen.PlaceTile(xval, yval, blocks[n]);
				}
				if(n == -1)
				{
					yval = yval + 1;
					xval = i;
				}
				else
				{
					xval = xval + 1;
				}
			}

			xval = i;
			yval = j - 5;

			for(int s = 0; s <= 65; s++)
			{
				n = houseshape[s];
				if(n == 4)
				{
					WorldGen.PlaceObject(xval, yval, 10, false, 0, 0, -1, 1);
				}
				if(n == 5)
				{
					WorldGen.PlaceObject(xval, yval, 14, false, 0, 0, -1, 1);
				}
				if(n == 3)
				{
					WorldGen.PlaceObject(xval, yval, 15, false, 0, 0, -1, 1);
				}
				if(n == -1)
				{
					yval = yval + 1;
					xval = i;
				}
				else
				{
					xval = xval + 1;
				}
			}
		}
	}
}