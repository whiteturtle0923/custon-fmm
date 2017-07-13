using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System;

namespace Fargowiltas.Items.Souls
{
	[AutoloadEquip(EquipType.Wings)]
	public class DimensionSoul : ModItem
	{
		public int dragonTimer = 60;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Dimensions");
			
			
			
			Tooltip.SetDefault("'The dimensions of Terraria are at your fingertips'"
				+ "\nDoes various things");
               /* + "\nActs as wings \nAllows for infinite flight"
                + "\n30% damage reduction \nIncreases life regeneration by 15 \nIncreases HP by 500 \nReflect 100% of damage back to attackers \nEffects of the Star Veil, Paladin's Shield, and Frozen Turtle Shell \nGrants immunity to even more debuffs"
                + "\n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nAllows the player to dash into the enemy"
                + "\nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 50% \nMining speed tripled and Auto paint effect \nSeveral common enemies are harmless"
                + "\nIncreases fishing skill massively \nPermanent Sonar and Crate Buffs \nAll other effects of material souls");*/
           /* if(Fargowiltas.instance.thoriumLoaded)
            {
                Tooltip.SetDefault("'The dimensions of Terraria are at your fingertips'"
                + "\nActs as wings \nAllows for infinite flight"
                + "\n30% damage reduction \nIncreases life regeneration by 15 \nIncreases HP by 500 \nReflect 100% of damage back to attackers \nEffects of the Star Veil and Terrarium Defender \nAllows you to detect enemies and hazards around you \nGrants immunity to even more debuffs"
                + "\n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nAllows the player to dash into the enemy"
                + "\nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 50% \nMining speed tripled and Auto paint effect \nSeveral common enemies are harmless"
                + "*/
				
				Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 18));

		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.accessory = true;
			item.defense = 25;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.value = 1500000;
			item.rare = -12;
			item.expert = true;
		}		
		public override bool CanEquipAccessory(Player player, int slot)
        {
            if (((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).utilitySoul == true)
            {
                return false;
            }
            return true;
        }
		
			
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
		((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).dimensionSoul = true;
			
		//tank
			player.endurance += 0.30f;
			player.lifeRegen += 15;
			player.thorns += 1f; 
			player.aggro += 100;
			player.statLifeMax2 += 500;
		   
		//ankh shield
			player.buffImmune[46] = true; //chilled
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[33] = true; //weak
			player.buffImmune[36] = true; //broken armor
			player.buffImmune[30] = true; //bleeding
			player.buffImmune[20] = true; //Poisoned
			player.buffImmune[32] = true; //slow
			player.buffImmune[31] = true; //Confused
			player.buffImmune[35] = true; //silenced
			player.buffImmune[23] = true; //cursed
			player.buffImmune[22] = true; //darkness
			
			player.buffImmune[44] = true; //Frostburn
			player.buffImmune[47] = true; //Frozen
			player.buffImmune[24] = true; //Fire
			player.buffImmune[69] = true; //Ichor
			player.buffImmune[70] = true; //Venom
			player.buffImmune[80] = true; //Black Out
			player.buffImmune[156] = true; //Stoned
			
			player.buffImmune[88] = true; //chaos state
			player.buffImmune[37] = true; //horrified
			player.buffImmune[39] = true; //cursed inferno
			player.buffImmune[68] = true; //suffocation
			
		// sweet vengeance or star veil
			if(Fargowiltas.instance.thoriumLoaded)
			{
				player.panic = true;
				player.starCloak = true;
				player.longInvince = true;
			}

			if(!Fargowiltas.instance.thoriumLoaded)
			{
				player.starCloak = true;
				player.longInvince = true;
			}
			
		// shiny stone
		    player.shinyStone = true;
			
		//charm of myths
			player.pStone = true;
			
		//paladin
			 if (player.statLife > player.statLifeMax2 * .20)
            {
                player.AddBuff(BuffID.PaladinsShield, 30, true);
            }
		   
		 //frozenshell
		    if (player.statLife < player.statLifeMax2 * .6)
            {
                player.AddBuff(BuffID.IceBarrier, 30, true);
            }
			
			//celestial shell
			player.accMerman = true;
			player.wolfAcc = true;
			if (hideVisual)
			{
				player.hideMerman = true;
				player.hideWolf = true;
			}
			
		//wings
			player.ignoreWater = true;

			player.wingTimeMax = 99999;
			
		//speed
		
		//arctic diving gear
		player.arcticDivingGear = true;
		player.accFlipper = true;
		player.accDivingHelm = true;
		player.iceSkate = true;
		player.ignoreWater = true;
		
	
		//frostspark
		if(soulcheck.sanic == true)
		{
			((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).speedEffect = true;
			player.accRunSpeed = 2.00f;
			player.moveSpeed += 5f;
		}
		else
		{
			player.accRunSpeed = 35.00f;
			player.moveSpeed += 0.25f;
		}
		player.rocketBoots = 3;
		player.iceSkate = true;
		
		//lava waders
		player.waterWalk = true;
		player.fireWalk = true;
		player.lavaImmune = true;

	
		//balloons
		player.noFallDmg = true;
		player.jumpBoost = true;
		
		//honey
		player.bee = true;
	
		//shield of cthulu
		if(!Fargowiltas.instance.calamityLoaded)
		{
			 player.dash = 2;
		}
		
	
		//slime mount
		player.maxFallSpeed += 6f;
		player.autoJump = true;
		
		//builder
		
		player.tileSpeed += 0.5f;
		player.wallSpeed += 0.5f;
		
		
		//toolbox
		Player.tileRangeX+= 50;//WORKS
		Player.tileRangeY+= 50;
		
		//gizmo pack
		player.autoPaint = true;
	
		//pick axe stuff
		player.pickSpeed -= 0.66f; 
		
		//royal gel
		player.npcTypeNoAggro[1] = true;
		player.npcTypeNoAggro[2] = true;
		player.npcTypeNoAggro[3] = true;
		player.npcTypeNoAggro[6] = true;
		player.npcTypeNoAggro[7] = true;
		player.npcTypeNoAggro[8] = true;
		player.npcTypeNoAggro[9] = true;
		player.npcTypeNoAggro[10] = true;
		player.npcTypeNoAggro[11] = true;
		player.npcTypeNoAggro[12] = true;
		player.npcTypeNoAggro[16] = true;
		player.npcTypeNoAggro[21] = true;
		player.npcTypeNoAggro[23] = true;
		player.npcTypeNoAggro[24] = true;
		player.npcTypeNoAggro[25] = true;
		player.npcTypeNoAggro[31] = true;
		player.npcTypeNoAggro[32] = true;
		player.npcTypeNoAggro[33] = true;
		player.npcTypeNoAggro[42] = true;
		player.npcTypeNoAggro[43] = true;
		player.npcTypeNoAggro[47] = true;
		player.npcTypeNoAggro[48] = true;
		player.npcTypeNoAggro[49] = true;
		player.npcTypeNoAggro[51] = true;
		player.npcTypeNoAggro[56] = true;
		player.npcTypeNoAggro[58] = true;
		player.npcTypeNoAggro[59] = true;
		player.npcTypeNoAggro[60] = true;
		player.npcTypeNoAggro[61] = true;
		player.npcTypeNoAggro[63] = true;
		player.npcTypeNoAggro[64] = true;
		player.npcTypeNoAggro[65] = true;
		player.npcTypeNoAggro[67] = true;
		player.npcTypeNoAggro[69] = true;
		player.npcTypeNoAggro[70] = true;
		player.npcTypeNoAggro[71] = true;
		player.npcTypeNoAggro[72] = true;
		player.npcTypeNoAggro[73] = true;
		player.npcTypeNoAggro[81] = true;
		player.npcTypeNoAggro[93] = true;
		player.npcTypeNoAggro[121] = true;
		player.npcTypeNoAggro[122] = true;
		player.npcTypeNoAggro[132] = true;
		player.npcTypeNoAggro[137] = true;
		player.npcTypeNoAggro[138] = true;
		player.npcTypeNoAggro[141] = true;
		player.npcTypeNoAggro[147] = true;
		player.npcTypeNoAggro[150] = true;
		player.npcTypeNoAggro[151] = true;
		player.npcTypeNoAggro[152] = true;
		player.npcTypeNoAggro[161] = true;
		player.npcTypeNoAggro[173] = true;
		player.npcTypeNoAggro[183] = true;
		player.npcTypeNoAggro[184] = true;
		player.npcTypeNoAggro[186] = true;
		player.npcTypeNoAggro[187] = true;
		player.npcTypeNoAggro[188] = true;
		player.npcTypeNoAggro[189] = true;
		player.npcTypeNoAggro[190] = true;
		player.npcTypeNoAggro[191] = true;
		player.npcTypeNoAggro[192] = true;
		player.npcTypeNoAggro[193] = true;
		player.npcTypeNoAggro[194] = true;
		player.npcTypeNoAggro[200] = true;
		player.npcTypeNoAggro[201] = true;
		player.npcTypeNoAggro[202] = true;
		player.npcTypeNoAggro[203] = true;
		player.npcTypeNoAggro[204] = true;
		player.npcTypeNoAggro[220] = true;
		player.npcTypeNoAggro[221] = true;
		player.npcTypeNoAggro[223] = true;
		player.npcTypeNoAggro[224] = true;
		player.npcTypeNoAggro[225] = true;
		player.npcTypeNoAggro[231] = true;
		player.npcTypeNoAggro[232] = true;
		player.npcTypeNoAggro[233] = true;
		player.npcTypeNoAggro[234] = true;
		player.npcTypeNoAggro[235] = true;
		player.npcTypeNoAggro[244] = true;
		player.npcTypeNoAggro[294] = true;
		player.npcTypeNoAggro[295] = true;
		player.npcTypeNoAggro[296] = true;
		player.npcTypeNoAggro[302] = true;
		player.npcTypeNoAggro[304] = true;
		player.npcTypeNoAggro[317] = true;
		player.npcTypeNoAggro[318] = true;
		player.npcTypeNoAggro[319] = true;
		player.npcTypeNoAggro[320] = true;
		player.npcTypeNoAggro[321] = true;
		player.npcTypeNoAggro[322] = true;
		player.npcTypeNoAggro[323] = true;
		player.npcTypeNoAggro[324] = true;
		player.npcTypeNoAggro[331] = true;
		player.npcTypeNoAggro[332] = true;
		player.npcTypeNoAggro[333] = true;
		player.npcTypeNoAggro[334] = true;
		player.npcTypeNoAggro[335] = true;
		player.npcTypeNoAggro[336] = true;
		player.npcTypeNoAggro[430] = true;
		player.npcTypeNoAggro[431] = true;
		player.npcTypeNoAggro[432] = true;
		player.npcTypeNoAggro[433] = true;
		player.npcTypeNoAggro[434] = true;
		player.npcTypeNoAggro[435] = true;
		player.npcTypeNoAggro[436] = true;
		player.npcTypeNoAggro[449] = true;
		player.npcTypeNoAggro[450] = true;
		player.npcTypeNoAggro[451] = true;
		player.npcTypeNoAggro[452] = true;
		player.npcTypeNoAggro[537] = true;
	
		
		//mining helmet
		if(soulcheck.light == true)
		{
		Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
		}
		//fishing
		 player.sonarPotion = true;
		 player.fishingSkill += 50;
		 player.cratePotion = true;
		 player.accFishingLine = true;
		 player.accTackleBox = true;
		 player.accFishFinder = true;
	
		 //froglegs
		 player.autoJump = true;
	     player.jumpSpeedBoost += 2.5f;
		  
		 if(soulcheck.spore == true)
		{
		  //spore sac
		 player.SporeSac();
		 player.sporeSac = true;  
		}
		
		((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).fishSoul2 = true;
		
		//dread eye
		if(Fargowiltas.instance.thoriumLoaded)
		{
			if(soulcheck.danger == true)
			{
			player.dangerSense = true;
			}
			if(soulcheck.hunt == true)
			{
			player.detectCreature = true;
			}
		}
		
		//yharims gift
		if(Fargowiltas.instance.calamityLoaded)
		{
			if (((double)player.velocity.X > 0 || (double)player.velocity.Y > 0 || (double)player.velocity.X < -0.1 || (double)player.velocity.Y < -0.1))
			{
				dragonTimer--;
				if (dragonTimer <= 0)
				{
					Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 20);
					int projectile1 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ModLoader.GetMod("CalamityMod").ProjectileType("DragonDust"), 350, 5f, player.whoAmI, 0f, 0f);
					Main.projectile[projectile1].timeLeft = 60;
					dragonTimer = 60;
				}
			}
			else
			{
				dragonTimer = 60;
			}
			if (player.immune)
			{
				if (Main.rand.Next(8) == 0)
				{
					for (int l = 0; l < 1; l++)
					{
						float x = player.position.X + (float)Main.rand.Next(-400, 400);
						float y = player.position.Y - (float)Main.rand.Next(500, 800);
						Vector2 vector = new Vector2(x, y);
						float num15 = player.position.X + (float)(player.width / 2) - vector.X;
						float num16 = player.position.Y + (float)(player.height / 2) - vector.Y;
						num15 += (float)Main.rand.Next(-100, 101);
						int num17 = 22;
						float num18 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
						num18 = (float)num17 / num18;
						num15 *= num18;
						num16 *= num18;
						int num19 = Projectile.NewProjectile(x, y, num15, num16, ModLoader.GetMod("CalamityMod").ProjectileType("SkyFlareFriendly"), 750, 9f, player.whoAmI, 0f, 0f);
						Main.projectile[num19].ai[1] = player.position.Y;
						Main.projectile[num19].hostile = false;
						Main.projectile[num19].friendly = true;
					}
				}
			}
			
			
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("BrimstoneFlames")] = true;
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("HolyLight")] = true;
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("GlacialState")] = true;
				
				CalamityTank(player);
				
				CalamityBoots(player);
		} 
		
		if(Fargowiltas.instance.blueMagicLoaded)
		{
			BlueTank(player);
		}
	}
	
		public void CalamityTank(Player player)
		{
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianAegis = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).dashMod = 4;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).aSpark = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).gShell = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).fCarapace = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).absorber = true;
		}
		
		public void CalamityBoots(Player player)
		{
			player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).IBoots = true;
			player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianFire = true;
		}
		
		public void BlueTank(Player player)
		{
				player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).lifeMagnet2 = true;
				player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).crystalCloak = true;
		}
			
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.25f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 18f;
			acceleration *= 3.5f;
		}
			
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "ColossusSoul");
			recipe.AddIngredient(null, "SupersonicSoul");
			recipe.AddIngredient(null, "FlightMasterySoul");
			recipe.AddIngredient(null, "WorldShaperSoul");
			recipe.AddIngredient(null, "TrawlerSoul");
			
			if(Fargowiltas.instance.calamityLoaded)
			{
			recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("YharimsGift"));
			}
			
			recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
		
	}
	
}