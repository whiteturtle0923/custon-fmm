using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class Stylist : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Stylist");
			Tooltip.SetDefault("'Did you even try to brush your hair today?'");
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
			item.makeNPC = NPCID.Stylist;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
		}

        public override string Texture => "Terraria/NPC_353";
    }
}