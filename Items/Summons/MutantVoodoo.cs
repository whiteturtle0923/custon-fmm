using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MutantVoodoo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Voodoo Doll");
			Tooltip.SetDefault("Summons ALL the bosses");
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

		public override bool UseItem(Player player)
        {
			
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
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.MoonLordCore);
			Main.NewText("The Moon Lord has awoken!", 175, 75, 255);
			
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;

        }

		
	}
}