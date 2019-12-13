using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
    public class FargoWorld : ModWorld
    {
        internal static int AbomClearCD;
        internal static bool MovedLumberjack;

        internal static bool OverloadGoblins;
        internal static bool OverloadPirates;
        internal static bool OverloadPumpkinMoon;
        internal static bool OverloadFrostMoon;
        internal static bool OverloadMartians;

        internal static bool[] CurrentSpawnRateTile;
        internal static Dictionary<string, bool> DownedBools;

        public override void Initialize()
        {
            DownedBools = new Dictionary<string, bool>
            {
                ["lumberjack"] = false,
                ["betsy"] = false,
                ["boss"] = false,
                ["halloween"] = false,
                ["xmas"] = false,
                ["rareEnemy"] = false,
                ["pinky"] = false,
                ["undeadMiner"] = false,
                ["tim"] = false,
                ["doctorBones"] = false,
                ["mimic"] = false,
                ["wyvern"] = false,
                ["runeWizard"] = false,
                ["nymph"] = false,
                ["moth"] = false,
                ["rainbowSlime"] = false,
                ["paladin"] = false,
                ["medusa"] = false,
                ["clown"] = false,
                ["iceGolem"] = false,
                ["sandElemental"] = false,
                ["mothron"] = false,
                ["mimicHallow"] = false,
                ["mimicCorrupt"] = false,
                ["mimicCrimson"] = false,
                ["mimicJungle"] = false,
                ["goblinSummoner"] = false,
                ["flyingDutchman"] = false,
                ["dungeonSlime"] = false,
                ["pirateCaptain"] = false,
                ["skeletonGun"] = false,
                ["skeletonMage"] = false,
                ["boneLee"] = false,
                ["darkMage3"] = false,
                ["ogre"] = false,
            };

            AbomClearCD = 0;

            OverloadGoblins = false;
            OverloadPirates = false;
            OverloadPumpkinMoon = false;
            OverloadFrostMoon = false;
            OverloadMartians = false;

            CurrentSpawnRateTile = new bool[Main.netMode == NetmodeID.Server ? 255 : 1];
        }

        public override TagCompound Save()
        {
            List<string> downed = new List<string>();
            foreach (KeyValuePair<string, bool> downedBool in DownedBools.ToList())
            {
                downed.AddWithCondition(downedBool.Key, downedBool.Value);
            }

            return new TagCompound
            {
                { "downed", downed },
            };
        }

        public override void Load(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            foreach (KeyValuePair<string, bool> downedBool in DownedBools.ToList())
            {
                DownedBools[downedBool.Key] = downed.Contains(downedBool.Key);
            }
        }

        public override void NetReceive(BinaryReader reader)
        {
            foreach (KeyValuePair<string, bool> downedBool in DownedBools.ToList())
            {
                if (downedBool.Key != "lumberjack")
                {
                    DownedBools[downedBool.Key] = reader.ReadBoolean();
                }
            }

            AbomClearCD = reader.ReadInt32();
        }

        public override void NetSend(BinaryWriter writer)
        {
            foreach (KeyValuePair<string, bool> downedBool in DownedBools.ToList())
            {
                if (downedBool.Key != "lumberjack")
                {
                    writer.Write(DownedBools[downedBool.Key]);
                }
            }

            writer.Write(AbomClearCD);
        }

        public override void PostUpdate()
        {
            // seasonals
            Main.halloween = DownedBools["halloween"];
            Main.xMas = DownedBools["xmas"];

            // swarm reset in case something goes wrong
            if (Fargowiltas.SwarmActive && NoBosses() && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
            {
                Fargowiltas.SwarmActive = false;
            }

            if (AbomClearCD > 0)
            {
                AbomClearCD--;
            }

            if (OverloadGoblins && Main.invasionType != InvasionID.GoblinArmy)
            {
                OverloadGoblins = false;
            }

            if (OverloadPirates && Main.invasionType != InvasionID.PirateInvasion)
            {
                OverloadPirates = false;
            }

            if (OverloadPumpkinMoon && !Main.pumpkinMoon)
            {
                OverloadPumpkinMoon = false;
            }

            if (OverloadFrostMoon && !Main.snowMoon)
            {
                OverloadFrostMoon = false;
            }

            if (OverloadMartians && Main.invasionType != InvasionID.MartianMadness)
            {
                OverloadMartians = false;
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            ref bool current = ref CurrentSpawnRateTile[0];
            bool oldSpawnRateTile = current;
            current = tileCounts[mod.TileType("RegalStatueSheet")] > 0;

            if (Main.netMode == NetmodeID.MultiplayerClient && current != oldSpawnRateTile)
            {
                ModPacket packet = ModContent.GetInstance<Fargowiltas>().GetPacket();
                packet.Write((byte)1);
                packet.Write(current);
                packet.Send();
            }
        }

        public override void PreUpdate()
        {
            bool rate = false;
            for (int i = 0; i < CurrentSpawnRateTile.Length; i++)
            {
                if (CurrentSpawnRateTile[i])
                {
                    Player player = Main.player[i];
                    if (player.active)
                    {
                        if (!player.dead)
                        {
                            rate = true;
                        }
                    }
                    else
                    {
                        CurrentSpawnRateTile[i] = false;
                    }
                }
            }

            if (rate)
            {
                Main.checkForSpawns += 81;
            }
        }

        private bool NoBosses() => Main.npc.All(i => !i.active || !i.boss);
    }
}