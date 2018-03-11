using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class DyeTrader : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Dye Trader");
			Tooltip.SetDefault("'My dear, what you're wearing is much too drab.'");
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
			
			item.makeNPC = NPCID.DyeTrader;
			
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
		}
		
		public override string Texture
		{
			get
			{
				return "Terraria/NPC_207";
			}
		}
	}
}