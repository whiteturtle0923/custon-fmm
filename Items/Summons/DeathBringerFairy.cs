<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class DeathBringerFairy : ModItem
	{
		public int occur = -1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Bringer Fairy");
			Tooltip.SetDefault("Summons all pre-hardmode bosses \nCertain bosses will only spawn if you're in their specific biome");
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
			if (player.ZoneCorrupt)
				{
					occur = 1;
					return !Main.dayTime; 
				}
				else if (player.ZoneCrimson)
				{
					occur = 2;
					return !Main.dayTime;
				}
				else
				{
					return !Main.dayTime;
				}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
			
			if(occur == 1)
			{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
			}
			
			if(occur == 2)
			{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);	
			}
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
			Main.NewText("Skeletron has awoken!", 175, 75, 255);
			
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnWOF(player.Center);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		
	}
=======
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class DeathBringerFairy : ModItem
	{
		public int occur = -1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Bringer Fairy");
			Tooltip.SetDefault("Summons all pre-hardmode bosses \nCertain bosses will only spawn if you're in their specific biome");
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
			if (player.ZoneCorrupt)
				{
					occur = 1;
					return !Main.dayTime; 
				}
				else if (player.ZoneCrimson)
				{
					occur = 2;
					return !Main.dayTime;
				}
				else
				{
					return !Main.dayTime;
				}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
			
			if(occur == 1)
			{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
			}
			
			if(occur == 2)
			{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);	
			}
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
			Main.NewText("Skeletron has awoken!", 175, 75, 255);
			
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnWOF(player.Center);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}