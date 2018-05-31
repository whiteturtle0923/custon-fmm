using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class TravellingMerchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Travelling Merchant");
			Tooltip.SetDefault("'I sell wares from places that might not even exist!'");
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
			item.makeNPC = NPCID.TravellingMerchant;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
		}
		
		public override string Texture => "Terraria/NPC_368";
	}
}