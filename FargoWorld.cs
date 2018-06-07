using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
	public class FargoWorld : ModWorld
	{
		public static bool movedLumberjack = false;
		public static bool downedBetsy = false;
		public static bool downedBoss = false;

        public static bool halloween = true;
        public static bool xmas = true;

        //town npcs
        public static bool guide = false;
		public static bool merch = false;
		public static bool nurse = false;
		public static bool demo = false;
		public static bool dye = false;
		public static bool dryad = false;
		public static bool keep = false;
		public static bool dealer = false;
		public static bool style = false;
		public static bool paint = false;
		public static bool angler = false;	
		public static bool goblin = false;
		public static bool doc = false;
		public static bool cloth = false;
		public static bool mech = false;
		public static bool party = false;
		public static bool wiz = false;
		public static bool tax = false;
		public static bool truf = false;
		public static bool pirate = false;
		public static bool steam = false;
		public static bool borg = false;		
		
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
            var downed = new List<string>();
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
            var downed = tag.GetList<string>("downed");
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
            BitsByte flags = new BitsByte();
			flags[0] = downedBetsy;
			flags[1] = downedBoss;
            flags[2] = guide;
            flags[3] = merch;
            flags[4] = nurse;
            flags[5] = demo;
            flags[6] = dye;
            flags[7] = dryad;

            BitsByte flags2 = new BitsByte();  
            flags2[0] = keep;
            flags2[1] = dealer;
            flags2[2] = style;
            flags2[3] = paint;
            flags2[4] = angler;
            flags2[5] = goblin;
            flags2[6] = doc;
            flags2[7] = cloth;

            BitsByte flags3 = new BitsByte();
            flags3[0] = mech;
            flags3[1] = party;
            flags3[2] = wiz;
            flags3[3] = tax;
            flags3[4] = truf;
            flags3[5] = pirate;
            flags3[6] = steam;
            flags3[7] = borg;

            BitsByte flags4 = new BitsByte();
            flags4[0] = halloween;
            flags4[1] = xmas;

            writer.Write(flags);
            writer.Write(flags2);
            writer.Write(flags3);
            writer.Write(flags4);
        }

        public override void PostUpdate ()
		{
            //seasonals
            if (halloween)
            {
                Main.halloween = true;
            }
            else
            {
                Main.halloween = false;
            }

            if (xmas)
            {
                Main.xMas = true;
            }
            else
            {
                Main.xMas = false;
            }

            //swarm reset in case something goes wrong
            if (NoBosses())
            {
                Fargowiltas.swarmActive = false;
            }
		}

        bool NoBosses()
        {
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return false;
                }
            }

            return true;
        }
	}
}
		