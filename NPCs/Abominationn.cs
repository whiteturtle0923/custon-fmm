using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Abominationn : ModNPC
	{	
	
		public override bool Autoload(ref string name)
		{
			name = "Abominationn";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abominationn");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 2;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 40;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public bool GRealmInvasion
		{
			get { return GRealm.MWorld.downedZombieInvasion; }
		}
        public bool BtfaInvasion
        {
            get { return ForgottenMemories.TGEMWorld.downedForestInvasion; }
        }
        public bool SpiritInvasion
        {
            get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
        public bool TremorInvasion
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.ParadoxTitan]; }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            return NPC.downedGoblins;
		}
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Wilta";
				case 1:
					return "Jack";
				case 2:
					return "Harley";
				case 3:
					return "Reaper";
				default:
					return "Betson";
			}
		}

		public override string GetChat()
		{
			int mutant = NPC.FindFirstNPC(mod.NPCType("Mutant"));

			if (mutant >= 0 && Main.rand.Next(7) == 0)
			{
				return "That one guy, " + Main.npc[mutant].GivenName + ", he is my brother... I've fought more bosses than him.";
			}

			switch (Main.rand.Next(6))
			{
				case 0:
					return "I have defeated everything in this land... nothing can beat me.";
				case 1:
					return "Have you ever had a weapon stuck to your hand? It's not very handy.";
				case 2:
					return "What happened to Yoramur? No idea who you're talking about.";
				case 3:
					return "I sure wish I was a boss.";
				case 4:
					return "You wish you could dress like me? Ha! Maybe in 2019.";
				default:
					return "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

        void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (check)
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
                shop.item[nextSlot].value = price;
                nextSlot++;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
		{
			//EVENTS
			if (Fargowiltas.instance.thoriumLoaded)
            {
                AddItem(NPC.downedBoss1, "ThoriumMod", "BloodMoonMedallion", 20000, ref shop, ref nextSlot);
		    }
			 
			if (Fargowiltas.instance.sacredToolsLoaded)
             {
                AddItem(NPC.downedBoss1, "SacredTools", "SandstormMedallion", 20000, ref shop, ref nextSlot);
			 }
			 
			if (Fargowiltas.instance.grealmLoaded)
			{
                AddItem(GRealmInvasion, "GRealm", "HordeStaff", 30000, ref shop, ref nextSlot);
			}
	
			    shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
			    shop.item[nextSlot].value=50000;
	     	    nextSlot++;
			
			if (Fargowiltas.instance.tremorLoaded)
			{
                AddItem(NPC.downedBoss2, "Tremor", "ScrollofUndead", 50000, ref shop, ref nextSlot);
			}

            if (Fargowiltas.instance.spiritLoaded)
			{
                AddItem(SpiritInvasion, "SpiritMod", "BlackPearl", 60000, ref shop, ref nextSlot);
			}

            if (Fargowiltas.instance.btfaLoaded)
            {
                AddItem(BtfaInvasion, "ForgottenMemories", "AncientLog", 50000, ref shop, ref nextSlot);
            }

            if (Main.hardMode)
			{
			    shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
			    shop.item[nextSlot].value=80000;
			    nextSlot++;
			}
			
			if (NPC.downedPirates)
			{	
			    shop.item[nextSlot].SetDefaults(ItemID.PirateMap);
			    shop.item[nextSlot].value=100000;
			    nextSlot++;
			}
			
			if (NPC.downedGolemBoss)
			{	
			    shop.item[nextSlot].SetDefaults(ItemID.SolarTablet);
			    shop.item[nextSlot].value=100000;
			    nextSlot++;
			}

                AddItem(NPC.downedMartians, "Fargowiltas", "RunawayProbe", 100000, ref shop, ref nextSlot);
			
			if (NPC.downedHalloweenKing)
			{	
			    shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
			    shop.item[nextSlot].value=150000;
			    nextSlot++;
			}
			
			if (NPC.downedChristmasIceQueen)
			{	
			    shop.item[nextSlot].SetDefaults(ItemID.NaughtyPresent);
			    shop.item[nextSlot].value=150000;
			    nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
                AddItem(TremorInvasion, "Tremor", "AncientWatch", 200000, ref shop, ref nextSlot);
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.DeathSickle;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore3"), 1f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore2"), 1f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore1"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}