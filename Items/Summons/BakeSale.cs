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
		}
		public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}

		public override bool UseItem(Player player)
		{
			if(FargoWorld.guide && !NPC.AnyNPCs(NPCID.Guide))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Guide);
				Main.NewText("The Guide has arrived!", 175, 75, 255);
			}
			if(FargoWorld.merch && !NPC.AnyNPCs(NPCID.Merchant))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Merchant);
				Main.NewText("The Merchant has arrived!", 175, 75, 255);
			}
			if(FargoWorld.nurse && !NPC.AnyNPCs(NPCID.Nurse))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Nurse);
				Main.NewText("The Nurse has arrived!", 175, 75, 255);
			}
			if(FargoWorld.demo && !NPC.AnyNPCs(NPCID.Demolitionist))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Demolitionist);
				Main.NewText("The Demolitionist has arrived!", 175, 75, 255);
			}
			if(FargoWorld.dye && !NPC.AnyNPCs(NPCID.DyeTrader))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.DyeTrader);
				Main.NewText("The Dye Trader has arrived!", 175, 75, 255);
			}
			if(FargoWorld.dryad && !NPC.AnyNPCs(NPCID.Dryad))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Dryad);
				Main.NewText("The Dryad has arrived!", 175, 75, 255);
			}
			if(FargoWorld.keep && !NPC.AnyNPCs(NPCID.DD2Bartender))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.DD2Bartender);
				Main.NewText("The Tavernkeep has arrived!", 175, 75, 255);
			}
			if(FargoWorld.dealer && !NPC.AnyNPCs(NPCID.ArmsDealer))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.ArmsDealer);
				Main.NewText("The Arms Dealer has arrived!", 175, 75, 255);
			}
			if(FargoWorld.style && !NPC.AnyNPCs(NPCID.Stylist))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Stylist);
				Main.NewText("The Stylist has arrived!", 175, 75, 255);
			}
			if(FargoWorld.paint && !NPC.AnyNPCs(NPCID.Painter))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Painter);
				Main.NewText("The Painter has arrived!", 175, 75, 255);
			}
			if(FargoWorld.angler && !NPC.AnyNPCs(NPCID.Angler))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Angler);
				Main.NewText("The Angler has regrettably arrived!", 175, 75, 255);
			}
			if(FargoWorld.goblin && !NPC.AnyNPCs(NPCID.GoblinTinkerer))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.GoblinTinkerer);
				Main.NewText("The Goblin Tinkerer has arrived!", 175, 75, 255);
			}
			if(FargoWorld.doc && !NPC.AnyNPCs(NPCID.WitchDoctor))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.WitchDoctor);
				Main.NewText("The Witch Doctor has arrived!", 175, 75, 255);
			}
			if(FargoWorld.cloth && !NPC.AnyNPCs(NPCID.Clothier))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Clothier);
				Main.NewText("The Clothier has arrived!", 175, 75, 255);
			}
			if(FargoWorld.mech && !NPC.AnyNPCs(NPCID.Mechanic))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Mechanic);
				Main.NewText("The Mechanic has arrived!", 175, 75, 255);
			}
			if(FargoWorld.party && !NPC.AnyNPCs(NPCID.PartyGirl))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.PartyGirl);
				Main.NewText("The PartyGirl has arrived!", 175, 75, 255);
			}
			if(FargoWorld.wiz && !NPC.AnyNPCs(NPCID.Wizard))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Wizard);
				Main.NewText("The Wizard has arrived!", 175, 75, 255);
			}
			if(FargoWorld.tax && !NPC.AnyNPCs(NPCID.TaxCollector))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.TaxCollector);
				Main.NewText("The Tax Collector has arrived!", 175, 75, 255);
			}
			if(FargoWorld.truf && !NPC.AnyNPCs(NPCID.Truffle))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Truffle);
				Main.NewText("The Truffle has arrived!", 175, 75, 255);
			}
			if(FargoWorld.pirate && !NPC.AnyNPCs(NPCID.Pirate))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Pirate);
				Main.NewText("The Pirate has arrived!", 175, 75, 255);
			}
			if(FargoWorld.steam && !NPC.AnyNPCs(NPCID.Steampunker))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Steampunker);
				Main.NewText("The Steampunker has arrived!", 175, 75, 255);
			}
			if(FargoWorld.borg && !NPC.AnyNPCs(NPCID.Cyborg))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Cyborg);
				Main.NewText("The Cyborg has arrived!", 175, 75, 255);
			}	
			/*if(FargoWorld.borg && !NPC.AnyNPCs(NPCID.Cyborg))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Cyborg);
				Main.NewText("The Cyborg has arrived!", 175, 75, 255);
			}	
			if(FargoWorld.borg && !NPC.AnyNPCs(NPCID.Cyborg))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Cyborg);
				Main.NewText("The Cyborg has arrived!", 175, 75, 255);
			}	
			if(FargoWorld.borg && !NPC.AnyNPCs(NPCID.Cyborg))
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-200,200), (int)player.position.Y - 50, NPCID.Cyborg);
				Main.NewText("The Cyborg has arrived!", 175, 75, 255);
			}	*/
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
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

			recipe.AddTile(TileID.Tables);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}