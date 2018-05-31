using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class WitchDoctor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Witch Doctor");
			Tooltip.SetDefault("'Which doctor am I? The Witch Doctor am I.'");
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
			item.makeNPC = NPCID.WitchDoctor;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
		}

        public override string Texture => "Terraria/NPC_228";
    }
}