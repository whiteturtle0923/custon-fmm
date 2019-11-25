using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Fargowiltas.Items.Tiles;
using Terraria.ID;

namespace Fargowiltas
{
	public class FargoWorld : ModWorld
	{
		public static bool movedLumberjack;
		public static bool downedBetsy;
		public static bool downedBoss;

        public static bool halloween;
        public static bool xmas;

        public static bool downedRareEnemy;
        public static bool downedPinky;
        public static bool downedUndeadMiner;
        public static bool downedTim;
        public static bool downedDoctorBones;
        public static bool downedMimic;
        public static bool downedWyvern;
        public static bool downedRuneWizard;
        public static bool downedNymph;
        public static bool downedMoth;
        public static bool downedRainbowSlime;
        public static bool downedPaladin;
        public static bool downedMedusa;
        public static bool downedClown;
        public static bool downedIceGolem;
        public static bool downedSandElemental;
        public static bool downedMothron;
        public static bool downedMimicHallow;
        public static bool downedMimicCorrupt;
        public static bool downedMimicCrimson;
        public static bool downedMimicJungle;
        public static bool downedGoblinSummoner;
        public static bool downedFlyingDutchman;
        public static bool downedDungeonSlime;
        public static bool downedPirateCaptain;
        public static bool downedSkeletonGunAny;
        public static bool downedSkeletonMageAny;
        public static bool downedBoneLee;

        public static bool downedDarkMage3;
        public static bool downedOgre3;

        public static int AbomClearCD;

        public static bool OverloadGoblins;
        public static bool OverloadPirates;
        public static bool OverloadPumpkinMoon;
        public static bool OverloadFrostMoon;
        public static bool OverloadMartians;

        private static bool[] currentSpawnRateTile;

        public override void Initialize()
        {
            movedLumberjack = false;
            downedBetsy = false;
            downedBoss = false;

            halloween = false;
            xmas = false;

            downedRareEnemy = false;
            downedPinky = false;
            downedUndeadMiner = false;
            downedTim = false;
            downedDoctorBones = false;
            downedMimic = false;
            downedWyvern = false;
            downedRuneWizard = false;
            downedNymph = false;
            downedMoth = false;
            downedRainbowSlime = false;
            downedPaladin = false;
            downedMedusa = false;
            downedClown = false;
            downedIceGolem = false;
            downedSandElemental = false;
            downedMothron = false;
            downedMimicHallow = false;
            downedMimicCorrupt = false;
            downedMimicCrimson = false;
            downedMimicJungle = false;
            downedGoblinSummoner = false;
            downedFlyingDutchman = false;
            downedDungeonSlime = false;
            downedPirateCaptain = false;
            downedSkeletonGunAny = false;
            downedSkeletonMageAny = false;
            downedBoneLee = false;

            downedDarkMage3 = false;
            downedOgre3 = false;

            AbomClearCD = 0;

            OverloadGoblins = false;
            OverloadPirates = false;
            OverloadPumpkinMoon = false;
            OverloadFrostMoon = false;
            OverloadMartians = false;

            currentSpawnRateTile = new bool[Main.netMode == 2 ? 255 : 1];
        }

		public override TagCompound Save()
		{
            List<string> downed = new List<string>();
			if (movedLumberjack) downed.Add("lumberjack");
			if (downedBetsy) downed.Add("betsy");
			if (downedBoss) downed.Add("boss");

            if (halloween) downed.Add("halloween");
            if (xmas) downed.Add("xmas");

            if (downedRareEnemy) downed.Add("rareEnemy");
            if (downedPinky) downed.Add("pinky");
            if (downedUndeadMiner) downed.Add("undeadMiner");
            if (downedTim) downed.Add("tim");
            if (downedDoctorBones) downed.Add("doctorBones");
            if (downedMimic) downed.Add("mimic");
            if (downedWyvern) downed.Add("wyvern");
            if (downedRuneWizard) downed.Add("runeWizard");
            if (downedNymph) downed.Add("nymph");
            if (downedMoth) downed.Add("moth");
            if (downedRainbowSlime) downed.Add("rainbowSlime");
            if (downedPaladin) downed.Add("paladin");
            if (downedMedusa) downed.Add("medusa");
            if (downedClown) downed.Add("clown");
            if (downedIceGolem) downed.Add("iceGolem");
            if (downedSandElemental) downed.Add("sandElemental");
            if (downedMothron) downed.Add("mothron");
            if (downedMimicHallow) downed.Add("mimicHallow");
            if (downedMimicCorrupt) downed.Add("mimicCorrupt");
            if (downedMimicCrimson) downed.Add("mimicCrimson");
            if (downedMimicJungle) downed.Add("mimicJungle");
            if (downedGoblinSummoner) downed.Add("goblinSummoner");
            if (downedFlyingDutchman) downed.Add("flyingDutchman");
            if (downedDungeonSlime) downed.Add("dungeonSlime");
            if (downedPirateCaptain) downed.Add("pirateCaptain");
            if (downedSkeletonGunAny) downed.Add("skeletonGun");
            if (downedSkeletonMageAny) downed.Add("skeletonMage");
            if (downedBoneLee) downed.Add("boneLee");

            if (downedDarkMage3) downed.Add("darkMage3");
            if (downedOgre3) downed.Add("ogre");

            return new TagCompound {
                {"downed", downed}
            };
		}
		
		public override void Load(TagCompound tag)
		{
            IList<string> downed = tag.GetList<string>("downed");
			movedLumberjack = downed.Contains("lumberjack");
			downedBetsy = downed.Contains("betsy");
			downedBoss = downed.Contains("boss");

            halloween = downed.Contains("halloween");
            xmas = downed.Contains("xmas");

            downedRareEnemy = downed.Contains("rareEnemy");
            downedPinky = downed.Contains("pinky");
            downedUndeadMiner = downed.Contains("undeadMiner");
            downedTim = downed.Contains("tim");
            downedDoctorBones = downed.Contains("doctorBones");
            downedMimic = downed.Contains("mimic");
            downedWyvern = downed.Contains("wyvern");
            downedRuneWizard = downed.Contains("runeWizard");
            downedNymph = downed.Contains("nymph");
            downedMoth = downed.Contains("moth");
            downedRainbowSlime = downed.Contains("rainbowSlime");
            downedPaladin = downed.Contains("paladin");
            downedMedusa = downed.Contains("medusa");
            downedClown = downed.Contains("clown");
            downedIceGolem = downed.Contains("iceGolem");
            downedSandElemental = downed.Contains("sandElemental");
            downedMothron = downed.Contains("mothron");
            downedMimicHallow = downed.Contains("mimicHallow");
            downedMimicCorrupt = downed.Contains("mimicCorrupt");
            downedMimicCrimson = downed.Contains("mimicCrimson");
            downedMimicJungle = downed.Contains("mimicJungle");
            downedGoblinSummoner = downed.Contains("goblinSummoner");
            downedFlyingDutchman = downed.Contains("flyingDutchman");
            downedDungeonSlime = downed.Contains("dungeonSlime");
            downedPirateCaptain = downed.Contains("pirateCaptain");
            downedSkeletonGunAny = downed.Contains("skeletonGun");
            downedSkeletonMageAny = downed.Contains("skeletonMage");
            downedBoneLee = downed.Contains("boneLee");

            downedDarkMage3 = downed.Contains("darkMage3");
            downedOgre3 = downed.Contains("ogre");
        }

		public override void NetReceive(BinaryReader reader)
		{
			downedBetsy = reader.ReadBoolean();
			downedBoss = reader.ReadBoolean();
            halloween = reader.ReadBoolean();
            xmas = reader.ReadBoolean();

            downedRareEnemy = reader.ReadBoolean();
            downedPinky = reader.ReadBoolean();
            downedUndeadMiner = reader.ReadBoolean();
            downedTim = reader.ReadBoolean();
            downedDoctorBones = reader.ReadBoolean();
            downedMimic = reader.ReadBoolean();
            downedWyvern = reader.ReadBoolean();
            downedRuneWizard = reader.ReadBoolean();
            downedNymph = reader.ReadBoolean();
            downedMoth = reader.ReadBoolean();
            downedRainbowSlime = reader.ReadBoolean();
            downedPaladin = reader.ReadBoolean();
            downedMedusa = reader.ReadBoolean();
            downedClown = reader.ReadBoolean();
            downedIceGolem = reader.ReadBoolean();
            downedSandElemental = reader.ReadBoolean();
            downedMothron = reader.ReadBoolean();
            downedMimicHallow = reader.ReadBoolean();
            downedMimicCorrupt = reader.ReadBoolean();
            downedMimicCrimson = reader.ReadBoolean();
            downedMimicJungle = reader.ReadBoolean();
            downedGoblinSummoner = reader.ReadBoolean();
            downedFlyingDutchman = reader.ReadBoolean();
            downedDungeonSlime = reader.ReadBoolean();
            downedPirateCaptain = reader.ReadBoolean();
            downedSkeletonGunAny = reader.ReadBoolean();
            downedSkeletonMageAny = reader.ReadBoolean();
            downedBoneLee = reader.ReadBoolean();
            downedDarkMage3 = reader.ReadBoolean();
            downedOgre3 = reader.ReadBoolean();

            AbomClearCD = reader.ReadInt32();
        }
		
		public override void NetSend(BinaryWriter writer)
		{
            writer.Write(downedBetsy);
            writer.Write(downedBoss);
            writer.Write(halloween);
            writer.Write(xmas);

            writer.Write(downedRareEnemy);
            writer.Write(downedPinky);
            writer.Write(downedUndeadMiner);
            writer.Write(downedTim);
            writer.Write(downedDoctorBones);
            writer.Write(downedMimic);
            writer.Write(downedWyvern);
            writer.Write(downedRuneWizard);
            writer.Write(downedNymph);
            writer.Write(downedMoth);
            writer.Write(downedRainbowSlime);
            writer.Write(downedPaladin);
            writer.Write(downedMedusa);
            writer.Write(downedClown);
            writer.Write(downedIceGolem);
            writer.Write(downedSandElemental);
            writer.Write(downedMothron);
            writer.Write(downedMimicHallow);
            writer.Write(downedMimicCorrupt);
            writer.Write(downedMimicCrimson);
            writer.Write(downedMimicJungle);
            writer.Write(downedGoblinSummoner);
            writer.Write(downedFlyingDutchman);
            writer.Write(downedDungeonSlime);
            writer.Write(downedPirateCaptain);
            writer.Write(downedSkeletonGunAny);
            writer.Write(downedSkeletonMageAny);
            writer.Write(downedBoneLee);
            writer.Write(downedDarkMage3);
            writer.Write(downedOgre3);

            writer.Write(AbomClearCD);
        }

        public override void PostUpdate ()
		{
            //seasonals
            Main.halloween = halloween;
            Main.xMas = xmas;

            //swarm reset in case something goes wrong
            if (Fargowiltas.swarmActive && NoBosses() && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
                Fargowiltas.swarmActive = false;

            if (AbomClearCD > 0)
                AbomClearCD--;

            if (OverloadGoblins && Main.invasionType != 1)
                OverloadGoblins = false;

            if (OverloadPirates && Main.invasionType != 3)
                OverloadPirates = false;

            if (OverloadPumpkinMoon && !Main.pumpkinMoon)
                OverloadPumpkinMoon = false;

            if (OverloadFrostMoon && !Main.snowMoon)
                OverloadFrostMoon = false;

            if (OverloadMartians && Main.invasionType != 4)
                OverloadMartians = false;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            //if (Main.netMode == 0) return;

            ref bool current = ref currentSpawnRateTile[0];
            bool oldSpawnRateTile = current;
            current = tileCounts[mod.TileType("RegalStatueSheet")] > 0;

            if (Main.netMode == 1 && current != oldSpawnRateTile)
            {
                ModPacket packet = Fargowiltas.instance.GetPacket();
                packet.Write((byte)1);
                packet.Write(current);
                packet.Send();
            }
        }

        public static void ReceiveCurrentSpawnRateTile(BinaryReader reader, int whoAmI) => currentSpawnRateTile[whoAmI] = reader.ReadBoolean();

        public override void PreUpdate()
        {
            bool rate = false;
            for (int i = 0; i < currentSpawnRateTile.Length; i++)
            {
                if (currentSpawnRateTile[i])
                {
                    Player p = Main.player[i];
                    if (p.active)
                    {
                        if (!p.dead)
                            rate = true;
                    }
                    else
                        currentSpawnRateTile[i] = false;
                }
            }

            if (rate)
                Main.checkForSpawns += 81;
        }

        private bool NoBosses() => Main.npc.All(i => !i.active || !i.boss);
	}
}