using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace Fargowiltas.Items
{
	public class FargoGlobalItem : GlobalItem
	{
	
	public class UseSpeed : GlobalItem
	{
		
		
		public override float UseTimeMultiplier(Item item, Player player)
		{
			FargoPlayer p = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			if (item.ranged && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.firingSpeed;
			}
			if (item.magic && item.width != 25 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.castingSpeed;
			}
			if ((item.thrown && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1) || (item.ranged && item.width == 29 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1))
			{
				return 1f + p.throwingSpeed;
			}
			if (item.width == 27 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.radiantSpeed;
			}
			if (item.width == 25 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.symphonicSpeed;
			}
			if (item.magic && item.damage < 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.healingSpeed;
			}
			if (item.axe >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.axeSpeed;
			}
			if (item.hammer >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.hammerSpeed;
			}
			if (item.pick >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.pickSpeed;
			}
			return 1f;
		}
		
		public override float MeleeSpeedMultiplier(Item item, Player player)
		{
			FargoPlayer p = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			//IInfo i = (IInfo)item.GetModInfo(mod, "IInfo");
			if (item.ranged && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.firingSpeed;
			}
			if (item.magic && item.width != 25 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.castingSpeed;
			}
			if ((item.thrown && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1) || (item.ranged && item.width == 29 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1))
			{
				return 1f + p.throwingSpeed;
			}
			if (item.width == 27 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.radiantSpeed;
			}
			if (item.width == 25 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.symphonicSpeed;
			}
			if (item.magic && item.damage < 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.healingSpeed;
			}
			if (item.axe >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.axeSpeed;
			}
			if (item.hammer >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.hammerSpeed;
			}
			if (item.pick >= 1 && item.useTime > 1 && item.useAnimation > 1)
			{
				return 1f + p.pickSpeed;
			}
			return 1f;
		}
		
		
	}
		
		public override void SetDefaults (Item item)
		{
				/*if (item.type == ItemID.BeeGun)
				{
					item.useAnimation = 2;		
				}   item.useTime = 2;
				
				if(item.type == ItemID.DogWhistle)
				{
					item.toolTip = "Summons a Puppy\nShoutout to Browny and Paca";
				}*/
				if(item.maxStack == 999 ||item.maxStack == 99)
				{
					item.maxStack = item.maxStack * 10 + 9;
				}
				else if(item.maxStack > 10 && item.maxStack != 100 && item.type != 71 && item.type != 72 && item.type != 73 && item.type != 74)
				{
					item.maxStack = 99;
				}
		}
		
		//pouch divers
		/*public override void PickAmmo (Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			
					type = mod.ProjectileType("Hungry");
		}*/
		
		public override bool ConsumeItem (Item item, Player player)
		{
			FargoPlayer p = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			
			if(p.infinity && item.createTile == -1)
			{
				return false;
			}
			
			if(p.builderEffect && item.createTile != -1)
			{
				return false;
			}
			return true;
		}
		
		public override void OpenVanillaBag (string context, Player player, int arg)
		{
			if(arg == ItemID.KingSlimeBossBag)
			{
				if(Main.rand.Next(50) == 0)
				{
					player.QuickSpawnItem(ItemID.SlimeStaff);
				}
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("SlimeKingsSlasher"));
				}
			}
			if(arg == ItemID.EyeOfCthulhuBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("EyeFlail"));
				}
			}
			if(arg == ItemID.EaterOfWorldsBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("EaterStaff"));
				}
			}
			if(arg == ItemID.BrainOfCthulhuBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("BrainStaff"));
				}
			}
			if(arg == ItemID.SkeletronBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("BoneZone"));
				}
			}
			if(arg == ItemID.QueenBeeBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("QueenStinger"));
				}
			}
			if(arg == ItemID.DestroyerBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("Probe"));
				}
			}
			if(arg == ItemID.TwinsBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("TwinBoomerangs"));
				}
			}
			if(arg == ItemID.SkeletronPrimeBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("PrimeStaff"));
				}
			}
			if(arg == ItemID.PlanteraBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("Dicer"));
				}
			}
			if(arg == ItemID.GolemBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("GolemStaff"));
				}
			}
			if(arg == ItemID.FishronBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("FishStick"));
				}
			}
			if(arg == ItemID.MoonLordBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("HentaiSpear"));
				}
			}

		}
		
	}
}