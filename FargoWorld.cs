using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
	public class FargoWorld : ModWorld
	{
		public static bool movedLumberjack;
		public static bool downedBetsy;
		public static bool downedBoss;

        public static bool halloween;
        public static bool xmas;
        public static bool battleCry;
		
		public override void Initialize()
		{
			movedLumberjack = false;
			downedBetsy = false;
			downedBoss = false;

            halloween = true;
            xmas = true;
            battleCry = false;
		}

		public override TagCompound Save()
		{
            List<string> downed = new List<string>();
			if (movedLumberjack) downed.Add("lumberjack");
			if (downedBetsy) downed.Add("betsy");
			if (downedBoss) downed.Add("boss");

            if (halloween) downed.Add("halloween");
            if (xmas) downed.Add("xmas");

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
		}

		public override void NetReceive(BinaryReader reader)
		{
            BitsByte flags = reader.ReadByte();
			downedBetsy = flags[0];		
			downedBoss = flags[1];
            halloween = flags[2];
            xmas = flags[3];
        }
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte
			{
				[0] = downedBetsy,
				[1] = downedBoss,
				[2] = halloween,
                [3] = xmas
			};

			writer.Write(flags);
        }

        public override void PostUpdate ()
		{
            //seasonals
            Main.halloween = halloween;
            Main.xMas = xmas;

            //swarm reset in case something goes wrong
            if (NoBosses())
            {
                Fargowiltas.swarmActive = false;
            }
		}

		private bool NoBosses() => Main.npc.All(i => !i.active || !i.boss);
	}
}