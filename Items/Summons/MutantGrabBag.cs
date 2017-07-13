using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class MutantGrabBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Mutant's Grab Bag");
			Tooltip.SetDefault("Right click to open");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			
			item.rare = 0;
		}

		public override bool CanRightClick()
		{
			return true;
		}

	
		
		public override void RightClick(Player player)
		{
			
			int j = Main.rand.Next(10);
			
			if(j == 0)
			{
			player.QuickSpawnItem(mod.ItemType("mutantmask"));	
			player.QuickSpawnItem(ItemID.GoldCoin, 5);
			}
			
		    if (j % 2 == 1)
            {
			player.QuickSpawnItem(ItemID.SlimeCrown);
			player.QuickSpawnItem(ItemID.SuspiciousLookingEye);
			player.QuickSpawnItem(ItemID.WormFood);
			player.QuickSpawnItem(ItemID.BloodySpine);
			player.QuickSpawnItem(mod.ItemType("skull"));
			player.QuickSpawnItem(ItemID.Abeemination);
			player.QuickSpawnItem(mod.ItemType("fleshydoll"));
            }
			
			if(j == 2)
			{
			 player.QuickSpawnItem(mod.ItemType("deathbringerfairy"), 5);
			}
			
			if(j == 4)
			{
			player.QuickSpawnItem(mod.ItemType("mutantbody"));	
			player.QuickSpawnItem(ItemID.GoldCoin, 5);
			}
			
			if(j == 6)
			{
			player.QuickSpawnItem(mod.ItemType("mutantpants"));	
			player.QuickSpawnItem(ItemID.GoldCoin, 5);
			}
			
			if(j == 8)
			{
			player.QuickSpawnItem(mod.ItemType("grabbag"), 2);	
			}
			
			
		}
		
	}
}