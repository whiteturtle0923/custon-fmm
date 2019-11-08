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

        public static int AbomClearCD;

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

            AbomClearCD = 0;

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
        }

		public override void NetReceive(BinaryReader reader)
		{
            BitsByte flags = reader.ReadByte();
			downedBetsy = flags[0];		
			downedBoss = flags[1];
            halloween = flags[2];
            xmas = flags[3];
            downedRareEnemy = flags[4];
            downedPinky = flags[5];
            downedUndeadMiner = flags[6];
            downedTim = flags[7];
            downedDoctorBones = flags[8];
            downedMimic = flags[9];
            downedWyvern = flags[10];
            downedRuneWizard = flags[11];
            downedNymph = flags[12];
            downedMoth = flags[13];
            downedRainbowSlime = flags[14];
            downedPaladin = flags[15];
            downedMedusa = flags[16];
            downedClown = flags[17];
            downedIceGolem = flags[18];
            downedSandElemental = flags[19];
            downedMothron = flags[20];
            downedMimicHallow = flags[21];
            downedMimicCorrupt = flags[22];
            downedMimicCrimson = flags[23];
            downedMimicJungle = flags[24];
            downedGoblinSummoner = flags[25];
            downedFlyingDutchman = flags[26];
            downedDungeonSlime = flags[27];
            downedPirateCaptain = flags[28];
            downedSkeletonGunAny = flags[29];
            downedSkeletonMageAny = flags[30];
            downedBoneLee = flags[31];

            AbomClearCD = reader.ReadInt32();
        }
		
		public override void NetSend(BinaryWriter writer)
		{
            BitsByte flags = new BitsByte
            {
                [0] = downedBetsy,
                [1] = downedBoss,
                [2] = halloween,
                [3] = xmas,
                [4] = downedRareEnemy,
                [5] = downedPinky,
                [6] = downedUndeadMiner,
                [7] = downedTim,
                [8] = downedDoctorBones,
                [9] = downedMimic,
                [10] = downedWyvern,
                [11] = downedRuneWizard,
                [12] = downedNymph,
                [13] = downedMoth,
                [14] = downedRainbowSlime,
                [15] = downedPaladin,
                [16] = downedMedusa,
                [17] = downedClown,
                [18] = downedIceGolem,
                [19] = downedSandElemental,
                [20] = downedMothron,
                [21] = downedMimicHallow,
                [22] = downedMimicCorrupt,
                [23] = downedMimicCrimson,
                [24] = downedMimicJungle,
                [25] = downedGoblinSummoner,
                [26] = downedFlyingDutchman,
                [27] = downedDungeonSlime,
                [28] = downedPirateCaptain,
                [29] = downedSkeletonGunAny,
                [30] = downedSkeletonMageAny,
                [31] = downedBoneLee
            };

			writer.Write(flags);

            writer.Write(AbomClearCD);
        }

        public override void PostUpdate ()
		{
            //seasonals
            Main.halloween = halloween;
            Main.xMas = xmas;

            //no CD on fishing quests
            /*bool changeQuest = true;
            foreach (Player p in Main.player.Where(x => x.active))
            {
                if (!Main.anglerWhoFinishedToday.Contains(p.name))
                {
                    changeQuest = false;
                    break;
                }
            }
            if (changeQuest)
            {
                Main.AnglerQuestSwap();
            }*/

            //swarm reset in case something goes wrong
            if (Fargowiltas.swarmActive && NoBosses() && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
                Fargowiltas.swarmActive = false;

            if (AbomClearCD > 0)
                AbomClearCD--;
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