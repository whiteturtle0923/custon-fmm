using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
	public class WorldShaperSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("World Shaper Soul");
			Tooltip.SetDefault("'Limitless possibilities' \nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 25% \nMining speed doubled \nAuto paint and actuator effect \nProvides light \nSeveral common enemies are harmless \nWarning: Do not use smart cursor with walls while this is equipped" );
			if(Fargowiltas.instance.thoriumLoaded)
			{
				Tooltip.SetDefault("'Limitless possibilities' \nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 25% \nMining speed doubled \nAuto paint and actuator effect \nProvides light \nSeveral common enemies are harmless \nAllows you to detect enemies and hazards around you \nWarning: Do not use smart cursor with walls while this is equipped");
			}
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 750000;
			item.expert = true;
			item.rare = -12;
		}
		
		public override bool CanEquipAccessory(Player player, int slot)
        {
            if (((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).dimensionSoul == true)
            {
                return false;
            }
            return true;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
		((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).utilitySoul = true;
		
		player.tileSpeed += 0.25f;
		player.wallSpeed += 0.25f;
		
		
		//toolbox
		Player.tileRangeX+= 50;
		Player.tileRangeY+= 50;
		
		//gizmo pack
		player.autoPaint = true;
	
		//pick axe stuff
		player.pickSpeed -= 0.50f; 
		
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
		if(soulcheck.light == false)
		{
		Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
		}
		//presserator
		player.autoActuator = true;
		
		((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).builderEffect = true;
		 
		if(Fargowiltas.instance.thoriumLoaded)
		{
			player.dangerSense = true;
			player.detectCreature = true;
		}
		
        }
		
		public override void AddRecipes()
			{
            ModRecipe build = new ModRecipe(mod);

			if(Fargowiltas.instance.thoriumLoaded)
			{
				if(Fargowiltas.instance.calamityLoaded)
				{
						//thorium and calamity
						build.AddIngredient(ItemID.Toolbelt);
						build.AddIngredient(ItemID.Toolbox); 
						build.AddIngredient(ItemID.ArchitectGizmoPack);
						build.AddIngredient(ItemID.ActuationAccessory);
						build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AncientFossil"));
						build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrystalineCharm"));
						build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DreadEye"));
						build.AddRecipeGroup("Fargowiltas:AnyDrax");
						build.AddIngredient(ItemID.ShroomiteDiggingClaw);
						build.AddIngredient(ItemID.Picksaw);
						build.AddIngredient(ItemID.LaserDrill);
						build.AddIngredient(ItemID.DrillContainmentUnit);
						build.AddIngredient(ItemID.RoyalGel);
						build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("OceanCrest"));
				}
				
				if(!Fargowiltas.instance.calamityLoaded)
				{
						//just thorium
						build.AddIngredient(ItemID.Toolbelt);
						build.AddIngredient(ItemID.Toolbox); 
						build.AddIngredient(ItemID.ArchitectGizmoPack);
						build.AddIngredient(ItemID.ActuationAccessory);
						build.AddIngredient(ItemID.MiningHelmet);
						build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrystalineCharm"));
						build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DreadEye"));
						build.AddRecipeGroup("Fargowiltas:AnyDrax");
						build.AddIngredient(ItemID.ShroomiteDiggingClaw);
						build.AddIngredient(ItemID.Picksaw);
						build.AddIngredient(ItemID.LaserDrill);
						build.AddIngredient(ItemID.DrillContainmentUnit);
						build.AddIngredient(ItemID.PeaceCandle, 10);
						build.AddIngredient(ItemID.RoyalGel);
				}
			}
				
			if(!Fargowiltas.instance.thoriumLoaded)
			{
				if(Fargowiltas.instance.calamityLoaded)
				{
						//just calamity
						build.AddIngredient(ItemID.Toolbelt);
						build.AddIngredient(ItemID.Toolbox); 
						build.AddIngredient(ItemID.ArchitectGizmoPack);
						build.AddIngredient(ItemID.ActuationAccessory);
						build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AncientFossil"));
						build.AddRecipeGroup("Fargowiltas:AnyDrax");
						build.AddIngredient(ItemID.ShroomiteDiggingClaw);
						build.AddIngredient(ItemID.MoltenPickaxe);
						build.AddIngredient(ItemID.Picksaw);
						build.AddIngredient(ItemID.LaserDrill);
						build.AddIngredient(ItemID.DrillContainmentUnit);
						build.AddIngredient(ItemID.PeaceCandle, 10);
						build.AddIngredient(ItemID.RoyalGel);
						build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("OceanCrest"));
				}
			
				if(!Fargowiltas.instance.calamityLoaded)
				{
						//no others
						build.AddIngredient(ItemID.Toolbelt);
						build.AddIngredient(ItemID.Toolbox); 
						build.AddIngredient(ItemID.ArchitectGizmoPack);
						build.AddIngredient(ItemID.ActuationAccessory);
						build.AddRecipeGroup("Fargowiltas:AnyDrax");
						build.AddIngredient(ItemID.ShroomiteDiggingClaw);
						build.AddIngredient(ItemID.MoltenPickaxe);
						build.AddIngredient(ItemID.Picksaw);
						build.AddIngredient(ItemID.LaserDrill);
						build.AddIngredient(ItemID.DrillContainmentUnit);
						build.AddIngredient(ItemID.Sunflower, 50);
						build.AddIngredient(ItemID.PeaceCandle, 10);
						build.AddIngredient(ItemID.RoyalGel);
				}
			}
			
			build.AddTile(null, "CrucibleCosmosSheet");
            build.SetResult(this);
            build.AddRecipe();
			}
		}
}