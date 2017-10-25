using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Linq;
using Terraria.ModLoader.IO;
using Fargowiltas;
using System;

namespace Fargowiltas
{
	public class FargoWorld : ModWorld
	{
		public static bool movedLumberjack = false;
		public static bool downedBetsy = false;
		public static bool downedBoss = false;
	
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
		
		//thorium npcs
		
		
		public override void Initialize()
		{
			movedLumberjack = false;
			downedBetsy = false;
			downedBoss = false;
			
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
			
			//if (soulcheck.bee) downed.Add("bee");

			return new TagCompound {
                {"downed", downed},
            };
		}
		
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			movedLumberjack = downed.Contains("lumberjack");
			downedBetsy = downed.Contains("betsy");
			downedBoss = downed.Contains("boss");
			
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
			
			//soulcheck.bee = downed.Contains("bee");
			//if(!soulcheck.bee)
			//{
			//	UICheckbox movie = ;
			//	UICheckbox.Selected = !UICheckbox.Selected;
			//}
		}
		
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			
			BitsByte flags = reader.ReadByte();
			FargoWorld.downedBetsy = flags[0];
			FargoWorld.downedBoss = flags[1];						
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			FargoWorld.downedBetsy = flags[0];		
			FargoWorld.downedBoss = flags[1];		
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedBetsy;
			flags[1] = downedBoss;
			writer.Write(flags);			
		}
	}
}
		