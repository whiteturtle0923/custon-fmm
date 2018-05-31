using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
	public class GoblinTinkerer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Goblin Tinkerer");
			Tooltip.SetDefault("'Looking for a gadgets expert? I'm your goblin!'");
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
			item.makeNPC = NPCID.GoblinTinkerer;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
		}
		
		public override string Texture
		{
			get
			{
				return "Terraria/NPC_107";
			}
		}
	}
}