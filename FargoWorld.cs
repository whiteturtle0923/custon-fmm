using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Fargowiltas.Items.Tiles;

namespace Fargowiltas
{
	public class FargoWorld : ModWorld
	{
		public static bool movedLumberjack;
		public static bool downedBetsy;
		public static bool downedBoss;

        public static bool halloween;
        public static bool xmas;
        public static bool eternity;

        public static bool battleCry;

        private static bool[] currentSpawnRateTile;

        public override void Initialize()
		{
			movedLumberjack = false;
			downedBetsy = false;
			downedBoss = false;

            halloween = false;
            xmas = false;
            eternity = false;

            battleCry = false;

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
            if (eternity) downed.Add("eternity");

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
            eternity = downed.Contains("eternity");
        }

		public override void NetReceive(BinaryReader reader)
		{
            BitsByte flags = reader.ReadByte();
			downedBetsy = flags[0];		
			downedBoss = flags[1];
            halloween = flags[2];
            xmas = flags[3];
            eternity = flags[4];
        }
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte
			{
				[0] = downedBetsy,
				[1] = downedBoss,
				[2] = halloween,
                [3] = xmas,
                [4] = eternity
            };

			writer.Write(flags);
        }

        public override void PostUpdate ()
		{
            //seasonals
            Main.halloween = halloween;
            Main.xMas = xmas;

            //no CD on fishing quests
            bool changeQuest = true;

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
            }

            //swarm reset in case something goes wrong
            if (NoBosses())
            {
                Fargowiltas.swarmActive = false;
            }
		}

        public override void TileCountsAvailable(int[] tileCounts)
        {
            //if (Main.netMode == 0) return;

            ref bool current = ref currentSpawnRateTile[0];
            bool oldSpawnRateTile = current;
            current = tileCounts[mod.TileType<RegalStatueSheet>()] > 0;

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