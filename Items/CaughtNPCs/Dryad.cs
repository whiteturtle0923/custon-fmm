using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class Dryad : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Dryad");
			Tooltip.SetDefault("'Be safe; Terraria needs you!'");
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
			item.makeNPC = NPCID.Dryad;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 21));
		}
		
		public override string Texture
		{
			get
			{
				return "Terraria/NPC_20";
			}
		}
	}
}