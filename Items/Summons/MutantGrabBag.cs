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
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if(modPlayer.voidSoul)
			{
				for (int j = 0; j < 50; j++)
				{
					if(player.inventory[j] != null && player.inventory[j].maxStack > 10 && player.inventory[j].type != mod.ItemType("MutantGrabBag"))
					{
						player.QuickSpawnItem(player.inventory[j].type, 5);
					}
				}
			}
			else
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
				player.QuickSpawnItem(mod.ItemType("SuspiciousSkull"));
				player.QuickSpawnItem(ItemID.Abeemination);
				player.QuickSpawnItem(mod.ItemType("FleshyDoll"));
				}
				
				if(j == 2)
				{
				player.QuickSpawnItem(mod.ItemType("DeathBringerFairy"), 5);
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
				player.QuickSpawnItem(mod.ItemType("MutantGrabBag"), 2);	
				}	
			}
			
			
			
		}
		
	}
}