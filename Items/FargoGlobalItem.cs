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
		
	//public int originalTime;
	//public int originalAnimation;
	//public int originalBoost;
	
	public class UseSpeed : GlobalItem
	{
		
		
		public override float UseTimeMultiplier(Item item, Player player)
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
		}
		
		public override void PickAmmo (Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			
					type = mod.ProjectileType("Hungry");
			
					float spread = 2f * 0.1250f;
					float baseSpeed = (float)Math.Sqrt(speed * speed + speed * speed);
					double baseAngle = Math.Atan2(speed, speed);
					double randomAngle = baseAngle + 1f * spread;
					double randomAngle2 = baseAngle + 0f * spread;
					double randomAngle3 = baseAngle - 1f * spread;
					float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.95f;
					speed = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
					speed = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
					
					Projectile.NewProjectile(player.Center.X, player.Center.X, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), type, damage, knockback, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(player.Center.X, player.Center.X, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), type, damage, knockback, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(player.Center.X, player.Center.X, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		
		public override bool ConsumeItem (Item item, Player player)
		{
			FargoPlayer p = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			
			if(p.infinity && item.createTile == -1)
			{
				return false;
			}
			return true;
		}
		
	}
}