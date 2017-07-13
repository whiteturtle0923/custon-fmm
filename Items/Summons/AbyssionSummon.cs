using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class AbyssionSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forgotten Claw");
			Tooltip.SetDefault("Summons Abyssion");
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
			
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
				NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Abyssion"));
            }
			
			//NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
			//Main.NewText("Abyssion has awoken!", 175, 75, 255);

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true; 
        }

		
	}
}