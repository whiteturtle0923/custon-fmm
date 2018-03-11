using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class Wizard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Wizard");
			Tooltip.SetDefault("'Want me to pull a coin from behind your ear? No? Ok.'");
		}
		public override void SetDefaults()
		{			
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 1;
			
			item.useStyle = 1; 
			item.useAnimation = 15;
			item.useTime = 10;
			
			item.consumable = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			
			item.UseSound = SoundID.Item44; 
			
			item.makeNPC = NPCID.Wizard;
			
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
		}
		
		public override string Texture
		{
			get
			{
				return "Terraria/NPC_108";
			}
		}
	}
}