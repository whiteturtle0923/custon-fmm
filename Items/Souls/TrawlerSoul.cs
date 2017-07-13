using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
	public class TrawlerSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trawler Soul");
			Tooltip.SetDefault("'The fish catch themselves' \n" +
								"Increases fishing skill substantially \n" +
								"All fishing rods will have 9 extra lures \n" +
								"Fishing line will never break \n" +
								"Decreases chance of bait consumption \n" +
								"Permanent Sonar and Crate Buffs \n" +
								"Effects of the Frog Legs and Spore Sac \n");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 750000;
			item.rare = -12;
			item.expert = true;
		}
		
			public override bool CanEquipAccessory(Player player, int slot)
        {
            if (((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).dimensionSoul == true)
            {
                return false;
            }
            return true;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
          ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).utilitySoul = true;
		  ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).fishSoul2 = true;
		   
		  player.sonarPotion = true;
		  player.fishingSkill += 50;
		  player.cratePotion = true;
		  player.accFishingLine = true;
		  player.accTackleBox = true;
		  player.accFishFinder = true;
		  
		  //fishing in lava??
		  
		  //froglegs
		  player.autoJump = true;
	      player.jumpSpeedBoost += 2.4f;
		  		
		if(soulcheck.spore == true)
		{
		  //spore sac
		 player.SporeSac();
		 player.sporeSac = true;  
		}
		
        }
		
		public override void AddRecipes()
        {
            ModRecipe fishing = new ModRecipe(mod);
			
			fishing.AddIngredient(ItemID.OldShoe, 5);
			fishing.AddIngredient(ItemID.AnglerHat);
			fishing.AddIngredient(ItemID.AnglerVest);
			fishing.AddIngredient(ItemID.AnglerPants);
			fishing.AddIngredient(ItemID.AnglerTackleBag);
			fishing.AddIngredient(null, "SuperRod");
			
			if(Fargowiltas.instance.thoriumLoaded)
			{
			fishing.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AquaticSonarDevice"));
			fishing.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumFisher"));
			}
			
			else
			{
			fishing.AddIngredient(ItemID.GoldenFishingRod);	
			fishing.AddIngredient(ItemID.FinWings);
			}

			fishing.AddIngredient(ItemID.FrogLeg);
			fishing.AddIngredient(ItemID.BalloonHorseshoeSharkron);
            fishing.AddIngredient(ItemID.ObsidianSwordfish);
			fishing.AddRecipeGroup("Fargowiltas:AnyEvilFished");
			fishing.AddIngredient(ItemID.CrystalSerpent);
			fishing.AddIngredient(ItemID.SporeSac);
           
			fishing.AddTile(null, "CrucibleCosmosSheet");
            fishing.SetResult(this);
            fishing.AddRecipe();
		}
		
	}
}


