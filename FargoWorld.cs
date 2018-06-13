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

        public static bool halloween = true;
        public static bool xmas = true;

        //town npcs
        public static bool guide;
		public static bool merch;
		public static bool nurse;
		public static bool demo;
		public static bool dye;
		public static bool dryad;
		public static bool keep;
		public static bool dealer;
		public static bool style;
		public static bool paint;
		public static bool angler;	
		public static bool goblin;
		public static bool doc;
		public static bool cloth;
		public static bool mech;
		public static bool party;
		public static bool wiz;
		public static bool tax;
		public static bool truf;
		public static bool pirate;
		public static bool steam;
		public static bool borg;		
		
		public override void Initialize()
		{
			movedLumberjack = false;
			downedBetsy = false;
			downedBoss = false;

            halloween = true;
            xmas = true;

            //town npcs
            guide = false;
			merch = false;
			nurse = false;
			demo = false;
			dye = false;
			dryad = false;
			keep = false;
			dealer = false;
			style = false;
			paint = false;
			angler = false;
			goblin = false;
			doc = false;
			cloth = false;
			mech = false;
			party = false;
			wiz = false;
			tax = false;
			truf = false;
			pirate = false;
			steam = false;
			borg = false;
		}

		public override TagCompound Save()
		{
            List<string> downed = new List<string>();
			if (movedLumberjack) downed.Add("lumberjack");
			if (downedBetsy) downed.Add("betsy");
			if (downedBoss) downed.Add("boss");

            if (halloween) downed.Add("halloween");
            if (xmas) downed.Add("xmas");

            //town npcs
            if (guide) downed.Add("guide");
			if (merch) downed.Add("merch");
			if (nurse) downed.Add("nurse");
			if (demo) downed.Add("demo");
			if (dye) downed.Add("dye");
			if (dryad) downed.Add("dryad");
			if (keep) downed.Add("keep");
			if (dealer) downed.Add("dealer");
			if (style) downed.Add("style");
			if (paint) downed.Add("paint");
			if (angler) downed.Add("angler");
			if (goblin) downed.Add("goblin");
			if (doc) downed.Add("doc");
			if (cloth) downed.Add("cloth");
			if (mech) downed.Add("mech");
			if (party) downed.Add("party");
			if (wiz) downed.Add("wiz");
			if (tax) downed.Add("tax");
			if (truf) downed.Add("truf");
			if (pirate) downed.Add("pirate");
			if (steam) downed.Add("steam");
			if (borg) downed.Add("borg");

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
			
			guide = downed.Contains("guide");
			merch = downed.Contains("merch");
			nurse = downed.Contains("nurse");
			demo = downed.Contains("demo");
			dye = downed.Contains("dye");
			dryad = downed.Contains("dryad");
			keep = downed.Contains("keep");
			dealer = downed.Contains("dealer");
			style = downed.Contains("style");
			paint = downed.Contains("paint");
			angler = downed.Contains("angler");
			goblin = downed.Contains("goblin");
			doc = downed.Contains("doc");
			cloth = downed.Contains("cloth");
			mech = downed.Contains("mech");
			party = downed.Contains("party");
			wiz = downed.Contains("wiz");
			tax = downed.Contains("tax");
			truf = downed.Contains("truf");
			pirate = downed.Contains("pirate");
			steam = downed.Contains("steam");
			borg = downed.Contains("borg");
		}

		public override void NetReceive(BinaryReader reader)
		{
            BitsByte flags = reader.ReadByte();
			downedBetsy = flags[0];		
			downedBoss = flags[1];
            guide = flags[2];
            merch = flags[3];
            nurse = flags[4];
            demo = flags[5];
            dye = flags[6];
            dryad = flags[7];

            BitsByte flags2 = reader.ReadByte();
            keep = flags2[0];
            dealer = flags2[1];
            style = flags2[2];
            paint = flags2[3];
            angler = flags2[4];
            goblin = flags2[5];
            doc = flags2[6];
            cloth = flags2[7];

            BitsByte flags3 = reader.ReadByte();
            mech = flags3[0];
            party = flags3[1];
            wiz = flags3[2];
            tax = flags3[3];
            truf = flags3[4];
            pirate = flags3[5];
            steam = flags3[6];
            borg = flags3[7];

            BitsByte flags4 = reader.ReadByte();
            halloween = flags4[0];
            xmas = flags4[1];
        }
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte
			{
				[0] = downedBetsy,
				[1] = downedBoss,
				[2] = guide,
				[3] = merch,
				[4] = nurse,
				[5] = demo,
				[6] = dye,
				[7] = dryad
			};

			BitsByte flags2 = new BitsByte
			{
				[0] = keep,
				[1] = dealer,
				[2] = style,
				[3] = paint,
				[4] = angler,
				[5] = goblin,
				[6] = doc,
				[7] = cloth
			};

			BitsByte flags3 = new BitsByte
			{
				[0] = mech,
				[1] = party,
				[2] = wiz,
				[3] = tax,
				[4] = truf,
				[5] = pirate,
				[6] = steam,
				[7] = borg
			};

			BitsByte flags4 = new BitsByte
			{
				[0] = halloween,
				[1] = xmas
			};

			writer.Write(flags);
            writer.Write(flags2);
            writer.Write(flags3);
            writer.Write(flags4);
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
		