using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class OverloadFish : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Truffle Worm Clump");
			Tooltip.SetDefault("Summons several Duke Fishrons");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.instance.multiFish = true;
			Fargowiltas.fish100 = 0;
			
			for(int i = 0; i < 10; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.DukeFishron);
				Main.NewText("Duke Fishron has awoken!", 175, 75, 255);
			}
			
			Main.NewText("The ocean swells with ferocious pigs!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			if(NPC.downedMoonlord)
			{
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(null, "TruffleWorm2");
				recipe.AddIngredient(null, "Overloader");
			
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
			
		}
	}
}