using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class BakeSale : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bake Sale");
			Tooltip.SetDefault("Summons any lost Town NPCs");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			//item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			if(FargoWorld.guide && !NPC.AnyNPCs(NPCID.Guide))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Guide);
			}
			if(FargoWorld.merch && !NPC.AnyNPCs(NPCID.Merchant))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Merchant);
			}
			if(FargoWorld.nurse && !NPC.AnyNPCs(NPCID.Nurse))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Nurse);
			}
			if(FargoWorld.demo && !NPC.AnyNPCs(NPCID.Demolitionist))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Demolitionist);
			}
			if(FargoWorld.dye && !NPC.AnyNPCs(NPCID.DyeTrader))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.DyeTrader);
			}
			if(FargoWorld.dryad && !NPC.AnyNPCs(NPCID.Dryad))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Dryad);
			}
			if(FargoWorld.keep && !NPC.AnyNPCs(NPCID.DD2Bartender))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.DD2Bartender);
			}
			if(FargoWorld.dealer && !NPC.AnyNPCs(NPCID.ArmsDealer))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.ArmsDealer);
			}
			if(FargoWorld.style && !NPC.AnyNPCs(NPCID.Stylist))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Stylist);
			}
			if(FargoWorld.paint && !NPC.AnyNPCs(NPCID.Painter))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Painter);
			}
			if(FargoWorld.angler && !NPC.AnyNPCs(NPCID.Angler))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Angler);
			}
			if(FargoWorld.goblin && !NPC.AnyNPCs(NPCID.GoblinTinkerer))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.GoblinTinkerer);
			}
			if(FargoWorld.doc && !NPC.AnyNPCs(NPCID.WitchDoctor))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.WitchDoctor);
			}
			if(FargoWorld.cloth && !NPC.AnyNPCs(NPCID.Clothier))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Clothier);
			}
			if(FargoWorld.mech && !NPC.AnyNPCs(NPCID.Mechanic))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Mechanic);
			}
			if(FargoWorld.party && !NPC.AnyNPCs(NPCID.PartyGirl))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.PartyGirl);
			}
			if(FargoWorld.wiz && !NPC.AnyNPCs(NPCID.Wizard))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Wizard);
			}
			if(FargoWorld.tax && !NPC.AnyNPCs(NPCID.TaxCollector))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.TaxCollector);
			}
			if(FargoWorld.truf && !NPC.AnyNPCs(NPCID.Truffle))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Truffle);
			}
			if(FargoWorld.pirate && !NPC.AnyNPCs(NPCID.Pirate))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Pirate);
			}
			if(FargoWorld.steam && !NPC.AnyNPCs(NPCID.Steampunker))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Steampunker);
			}
			if(FargoWorld.borg && !NPC.AnyNPCs(NPCID.Cyborg))
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Cyborg);
			}	
			
			return true;
		}
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.KingStatue);
			recipe.AddIngredient(ItemID.QueenStatue);
			recipe.AddIngredient(ItemID.CookedMarshmallow, 10);
			recipe.AddIngredient(ItemID.PumpkinPie, 8);
			recipe.AddIngredient(ItemID.GingerbreadCookie, 6);
			recipe.AddIngredient(ItemID.CookedShrimp, 4);
			recipe.AddIngredient(ItemID.PadThai, 3);
			recipe.AddIngredient(ItemID.Bacon, 2);
			recipe.AddIngredient(ItemID.GrubSoup);

			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}