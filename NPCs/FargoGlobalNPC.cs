using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace Fargowiltas.NPCs
{
	public class FargoGlobalNPC : GlobalNPC
	{
		
		//public bool wood = false;
		
		public override void ResetEffects(NPC npc)
		{
            //wood = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			
		}
		
		public override void EditSpawnRate (Player player, ref int spawnRate, ref int maxSpawns)
		{
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if(modPlayer.npcBoost)
			{
				spawnRate = (int)((double)spawnRate * 0.1);
				maxSpawns = (int)((float)maxSpawns * 10f);
			}
			
		}
		
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			int y = spawnInfo.spawnTileY;
			bool Cavern = (y >= (Main.maxTilesY * 0.4f) && y <= (Main.maxTilesY * 0.8f)); 
			//season enemies
			if(Main.hardMode)
			{
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.HoppinJack] = .04f;
				}
			
				if(Fargowiltas.NormalSpawn(spawnInfo) && Cavern && Fargowiltas.NoBiome(spawnInfo))
				{
					pool[NPCID.Ghost] = .04f;
				}
				
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.Raven] = .018f;
				}
			}
			
			else
			{
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.Raven] = .05f;
				}
			}
			
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonWhite] = .015f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonYellow] = .015f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonGreen] = .015f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonRed] = .015f;
			}
			
			
		
		}

		public override void NPCLoot(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			
			//crimson enchant
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(modPlayer.crimsonEnchant && Main.rand.Next(8) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 1);
			}
			
			//elemental
			if(modPlayer.terrariaSoul && Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 1);
			}
			
			//lumber jaxe
			if(npc.FindBuffIndex(mod.BuffType("WoodDrop")) != -1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, Main.rand.Next(10, 30));
			}		
			
			//halloween and xmas
			if((npc.type == NPCID.Ghost) || (npc.type == NPCID.HoppinJack) || (npc.type == NPCID.Raven))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1);
			}
			
			if((npc.type == NPCID.SlimeRibbonGreen) || (npc.type == NPCID.SlimeRibbonRed) || (npc.type == NPCID.SlimeRibbonWhite) || (npc.type == NPCID.SlimeRibbonYellow))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1);
			}
			
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodyMachete, 1);
			}
			
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BladedGlove, 1);
			}

			//slime multi
			if(npc.type == NPCID.KingSlime)
            {
				if(Fargowiltas.slime100 == 99)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
					Main.NewText("The swarm has been defeated!", 175, 75, 255);
					Fargowiltas.slime100 = 0;
					Fargowiltas.instance.multiSlime = false;
				}
				if(Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1);
				}
				
			}
			
			//eye multi
			if((npc.type == NPCID.EyeofCthulhu) && (Fargowiltas.eye100 == 99))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.eye100 = 0;
				Fargowiltas.instance.multiEye = false;
			}
			
			//worm multi
			if((npc.type == NPCID.EaterofWorldsHead) && (Fargowiltas.worm100 == 99))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.worm100 = 0;
				Fargowiltas.instance.multiWorm = false;
			}
			
			//brain multi
			if((npc.type == NPCID.BrainofCthulhu) && (Fargowiltas.brain100 == 99))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.brain100 = 0;
				Fargowiltas.instance.multiBrain = false;
			}
			
			//skele multi
			if((npc.type == NPCID.SkeletronHead) && (Fargowiltas.skele100 == 79))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.skele100 = 0;
				Fargowiltas.instance.multiSkele = false;
			}
			
			//bee multi
			if((npc.type == NPCID.QueenBee) && (Fargowiltas.bee100 == 79))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.bee100 = 0;
				Fargowiltas.instance.multiBee = false;
			}
			
			//destroyer multi
			if((npc.type == NPCID.TheDestroyer) && (Fargowiltas.destroy100 == 99))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.destroy100 = 0;
				Fargowiltas.instance.multiDestroy = false;
			}
			
			//twins multi
			if(((npc.type == NPCID.Retinazer) || (npc.type == NPCID.Spazmatism)) && (Fargowiltas.twins100 == 199))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.twins100 = 0;
				Fargowiltas.instance.multiTwins = false;
			}
			
			//prime multi
			if((npc.type == NPCID.SkeletronPrime) && (Fargowiltas.prime100 == 99))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.prime100 = 0;
				Fargowiltas.instance.multiPrime = false;
			}
			
			//fishron multi
			if((npc.type == NPCID.DukeFishron) && (Fargowiltas.fish100 == 39))
            {
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
				Fargowiltas.fish100 = 0;
				Fargowiltas.instance.multiFish = false;
			}
			
			//TOWN NPCS
			if(npc.type == NPCID.Guide)
            {
				FargoWorld.guide = true;
			}
			if(npc.type == NPCID.Merchant)
            {
				FargoWorld.merch = true;
			}
			if(npc.type == NPCID.Nurse)
            {
				FargoWorld.nurse = true;
			}
			if(npc.type == NPCID.Demolitionist)
            {
				FargoWorld.demo = true;
			}
			if(npc.type == NPCID.DyeTrader)
            {
				FargoWorld.dye = true;
			}
			if(npc.type == NPCID.Dryad)
            {
				FargoWorld.dryad = true;
			}
			if(npc.type == NPCID.DD2Bartender)
            {
				FargoWorld.keep = true;
			}
			if(npc.type == NPCID.ArmsDealer)
            {
				FargoWorld.dealer = true;
			}
			if(npc.type == NPCID.Stylist)
            {
				FargoWorld.style = true;
			}
			if(npc.type == NPCID.Painter)
            {
				FargoWorld.paint = true;
			}
			if(npc.type == NPCID.Angler)
            {
				FargoWorld.angler = true;
			}
			if(npc.type == NPCID.GoblinTinkerer)
            {
				FargoWorld.goblin = true;
			}
			if(npc.type == NPCID.WitchDoctor)
            {
				FargoWorld.doc = true;
			}
			if(npc.type == NPCID.Clothier)
            {
				FargoWorld.cloth = true;
			}
			if(npc.type == NPCID.Mechanic)
            {
				FargoWorld.mech = true;
			}
			if(npc.type == NPCID.PartyGirl)
            {
				FargoWorld.party = true;
			}
			if(npc.type == NPCID.Wizard)
            {
				FargoWorld.wiz = true;
			}
			if(npc.type == NPCID.TaxCollector)
            {
				FargoWorld.tax = true;
			}
			if(npc.type == NPCID.Truffle)
            {
				FargoWorld.truf = true;
			}
			if(npc.type == NPCID.Pirate)
            {
				FargoWorld.pirate = true;
			}
			if(npc.type == NPCID.Steampunker)
            {
				FargoWorld.steam = true;
			}
			if(npc.type == NPCID.Cyborg)
            {
				FargoWorld.borg = true;
			}
			
		}
		
		public override bool CheckDead(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if (modPlayer.cobaltEnchant && !npc.friendly && (npc.damage > 0 || npc.lifeMax > 5))
			{
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 27);
			                                        
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 5f, 90, 50/*dmg*/, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5f, 0f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, -5f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5f, 0f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4f, 4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4f, -4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4f, -4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4f, 4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
			}
			
            if(npc.type == NPCID.DD2Betsy)
            {
                 Main.NewText("Betsy has been defeated!", 175, 75, 255);
				 FargoWorld.downedBetsy = true;
            }
			
			//slime multi
			if((npc.type == NPCID.KingSlime) && (Fargowiltas.instance.multiSlime))
            {
				Fargowiltas.slime100++;
				
				if(Fargowiltas.slime100 < 90)
				{
					NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.KingSlime);
					//Main.NewText("King Slime has awoken!", 175, 75, 255);
				}
			}
			
			//eye multi
			if((npc.type == NPCID.EyeofCthulhu) && (Fargowiltas.instance.multiEye))
            {
				Fargowiltas.eye100++;
				
				if(Fargowiltas.eye100 < 90)
				{
					NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.EyeofCthulhu);
					Main.NewText("Eye of Cthulhu has awoken!", 175, 75, 255);
				}
			}
			
			//worm multi
			if((npc.type == NPCID.EaterofWorldsHead) && (Fargowiltas.instance.multiWorm))
            {
				Fargowiltas.worm100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.worm100 < 96)
				{
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
				}
			}
			
			//brain multi
			if((npc.type == NPCID.BrainofCthulhu) && (Fargowiltas.instance.multiBrain))
            {
				Fargowiltas.brain100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.brain100 < 95)
				{
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);
				}
			}
			
			//skele multi
			if((npc.type == NPCID.SkeletronHead) && (Fargowiltas.instance.multiSkele))
            {
				Fargowiltas.skele100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.skele100 < 72)
				{
					NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.SkeletronHead);
					Main.NewText("Skeletron has awoken!", 175, 75, 255);
				}
			}
			
			//bee multi
			if((npc.type == NPCID.QueenBee) && (Fargowiltas.instance.multiBee))
            {
				Fargowiltas.bee100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.bee100 < 70)
				{
					NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.QueenBee);
					Main.NewText("Queen Bee has awoken!", 175, 75, 255);
				}
			}
			
			//destroyer multi
			if((npc.type == NPCID.TheDestroyer) && (Fargowiltas.instance.multiDestroy))
            {
				Fargowiltas.destroy100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.destroy100 < 98)
				{
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
				}
			}
			
			//twins multi
			if(((npc.type == NPCID.Retinazer) || (npc.type == NPCID.Spazmatism)) && (Fargowiltas.instance.multiTwins))
            {
				Fargowiltas.twins100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if((Fargowiltas.twins100 < 192) && (Fargowiltas.twins100 % 2 == 0))
				{
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
				}
			}
			
			//prime multi
			if((npc.type == NPCID.SkeletronPrime) && (Fargowiltas.instance.multiPrime))
            {
				Fargowiltas.prime100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.prime100 < 95)
				{
					NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
				}
			}
			
			//prime multi
			if((npc.type == NPCID.DukeFishron) && (Fargowiltas.instance.multiFish))
            {
				Fargowiltas.fish100++;
				
				//Main.NewText(Fargowiltas.slime100.ToString(), 175, 75, 255);
				
				if(Fargowiltas.fish100 < 30)
				{
					NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.DukeFishron);
					Main.NewText("Duke Fishron has awoken!", 175, 75, 255);
				}
			}
			
            return true;
		}
		
		public override void ModifyHitNPC (NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(modPlayer.universeEffect)
			{
				damage += 25;
				if(crit && (Main.rand.Next(5) == 0))
				{
					damage *= 4;
				}
				
			}
			
			
		}
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			
		}

	}
}