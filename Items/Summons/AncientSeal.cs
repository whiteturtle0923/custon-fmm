using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class AncientSeal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Seal");
			Tooltip.SetDefault("Summons ALL the bosses modded included \n'Use at your own risk'");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}
		
		public bool SacredToolsDownedLunarians
		{
			get { return SacredTools.ModdedWorld.downedLunarians; }
		}

		public override bool UseItem(Player player)
        {
			// NPC npc = new NPC();
			// for (int i = NPCID.Count; i < Main.npcTexture.Length; i++)
			// {
				// npc.SetDefaults(i);
				// if (npc.boss && !NPC.AnyNPCs(npc.type))
				// {
					// NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000 ,1000), (int)player.position.Y + Main.rand.Next(-1000 ,1000), npc.type);
					// Main.NewText(npc.modNPC.Name + " has awoken!", 175, 75, 255);
				// }
			// }
			
			 if (ModLoader.GetLoadedMods().Contains("SacredTools"))
             {
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("HarpyBoss")); 
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("ArmoredHarpy")); 
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("ShadowWrath")); 
				 
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("StardustLunarian"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("VortexLunarian"));
                 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("SolarLunarian"));
				 
                 if(SacredToolsDownedLunarians)
                 {
                     NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("NebulaLunarian"));
                 }
                 else
                 {
                     NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType("ShadowLunarian"));
                 }
			 }

			
			 if (ModLoader.GetLoadedMods().Contains("EpicnessModRemastered"))
             {
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("RedGoblinKing"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("PixieLord"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MeteoriteGuardian"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MegaTitanHead"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MegaTitanHand1"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MegaTitanHand2"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MegaTitanHand3"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("MegaTitanHand4"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("Derpatron"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("DarkNebulaPhase1"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("EpicnessModRemastered").NPCType("ArgothTheDemonLord"));
			}
			
			if (ModLoader.GetLoadedMods().Contains("Pumpking"))
             {
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Pumpking").NPCType("PumpkingHorseman")); 
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Pumpking").NPCType("TerraLord"));
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Pumpking").NPCType("TerraGuard"));
			 }
			
			if (ModLoader.GetLoadedMods().Contains("CrystiliumMod"))
             {
				 NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CrystiliumMod").NPCType("CrystalKing")); 
			 }
			
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
             {
                NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("TheGrandThunderBird")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("QueenJellyDiverless")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("GraniteEnergyStorm"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("TheBuriedWarrior"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("ThePrimeScouter"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("BoreanStrider"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("FallenDeathBeholder")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Lich")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Abyssion"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Aquaius")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Omnicide"));
				player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("TouchOfOmnicide"), 14400);
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("SlagFury"));
            }
			
			if (ModLoader.GetLoadedMods().Contains("Ersion"))
             {
				  NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Ersion").NPCType("GiantSlime")); 
				  NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Ersion").NPCType("GoldenSlime")); 
				  NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Ersion").NPCType("BionicBrain")); 
			 }
			
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
             {
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("HiveMind")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("PerforatorHive"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("SlimeGod"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("SlimeGodRun"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("SlimeGodCore"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Cryogen"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("BrimstoneElemental"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Calamitas")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Siren")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Leviathan")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss2")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss3")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Providence")); 
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("CeaselessVoid"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("CosmicWraith"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Bumblefuck"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("Yharon"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas"));
			 }

			if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
			{
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Scarabeus"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("AncientFlyer"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Infernon"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Dusking"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("IlluminantMaster"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Scarabeus"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Atlas"));
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType("Overseer"));
			}
			
			
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
			Main.NewText("Skeletron has awoken!", 175, 75, 255);
			
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnWOF(player.Center);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			
            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 300, NPCID.Golem);
			Main.NewText("Golem has awoken!", 175, 75, 255);
			
            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 400, NPCID.DukeFishron);
			Main.NewText("Duke Fishron has awoken!", 175, 75, 255);
			
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.MoonLordCore);
			Main.NewText("The Moon Lord has awoken!", 175, 75, 255);
			
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

	}
}