using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class Guide : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Guide");
			Tooltip.SetDefault("'They say there is a person who will tell you how to survive in this land.'");
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
			item.makeNPC = NPCID.Guide;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
		}

        public override string Texture => "Terraria/NPC_22";

        public override void PostUpdate()
        {
            if (item.lavaWet && !NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                NPC.SpawnWOF(item.position);
                item.active = false;
                item.type = 0;
                item.stack = 0;
            }
        }
    }
}