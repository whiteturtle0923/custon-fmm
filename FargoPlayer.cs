using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using Fargowiltas;

namespace Fargowiltas
{
	public class FargoPlayer : ModPlayer
	{
		public bool wood = false;
		public bool eater = false;
		public bool mWorm = false;
		public bool queenStinger = false;
		public bool infinity = false;
		public bool npcBoost = false;
		
		//shoot speed
		public float firingSpeed = 0f;
		public float castingSpeed = 0f;
		public float throwingSpeed = 0f;
		public float radiantSpeed = 0f;
		public float symphonicSpeed = 0f;
		public float healingSpeed = 0f;
		public float axeSpeed = 0f;
		public float hammerSpeed = 0f;
		public float pickSpeed = 0f;
		
		//minions
		public bool brainMinion = false;
		public bool eaterMinion = false;
		
		//enchantments
		public bool shadowEnchant = false;
		public bool crimsonEnchant = false;
		public bool spectreEnchant = false;
		public bool specHeal = false;
		public int healTown = 0;
		public bool beeEnchant = false;
		public bool spiderEnchant = false;
		public bool stardustEnchant = false;
		public bool mythrilEnchant = false;
		public bool fossilEnchant = false;
		public bool jungleEnchant = false;
		public bool elementEnchant = false;
		public bool shroomEnchant = false;
		public bool cobaltEnchant = false;
		public bool spookyEnchant = false;
		public bool hallowEnchant = false;
		public bool chloroEnchant = false;
		public bool vortexEnchant = false;
		public static int vortexCrit = 4;
		public bool adamantiteEnchant = false;
		public bool frostEnchant = false;
		public bool palladEnchant = false;
		public bool oriEnchant = false;
		public bool meteorEnchant = false;
		
		//pets
		public bool flickerPet = false;
		public bool moonEye = false;
		public bool dinoPet = false;
		public bool seedPet = false;
		public bool dogPet = false;
		public bool catPet = false;
		public bool pumpkinPet = false;
		public bool skullPet = false;
		public bool saplingPet = false;
		public bool turtPet = false;
		public bool lizPet = false;
		public bool eyePet = false;
		public bool minotaurPet = false;
		public bool dragPet = false;
		public bool shadowPet = false;
		public bool crimsonPet = false;
		public bool spectrePet = false;
		
		//soul effects
		public bool meleeEffect = false;
		public bool throwingEffect = false;
		public bool rangedEffect = false;
		public bool miniRangedEffect = false;
		public bool builderEffect = false;
		public bool universeEffect = false;
		public bool speedEffect = false;
		public bool damageSoul = false;
		public bool utilitySoul = false;
		public bool fishSoul1 = false;
		public bool fishSoul2 = false;
		public bool dimensionSoul = false;
		public bool terrariaSoul = false;
		
	
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (Fargowiltas.CheckListKey.JustPressed)
			{
				if(soulcheck.visible == false)
				{
					soulcheck.visible = true;
				}
				else
				{
					soulcheck.visible = false;
				}
			}
		}
		public override void ResetEffects()
		{
			wood = false;
			eater = false;
			mWorm = false;
			
			queenStinger = false;
			infinity = false;
			//npcBoost = false;
			
			firingSpeed = 0f;
			castingSpeed = 0f;
			throwingSpeed = 0f;
			radiantSpeed = 0f;
			symphonicSpeed = 0f;
			healingSpeed = 0f;
			axeSpeed = 0f;
			hammerSpeed = 0f;
			pickSpeed = 0f;
			
			
			brainMinion = false;
			eaterMinion = false;
			
			//enchantments
			shadowEnchant = false;
			crimsonEnchant = false;
			spectreEnchant = false;
			beeEnchant = false;
			spiderEnchant = false;
			stardustEnchant = false;
			mythrilEnchant = false;
			fossilEnchant = false;
			jungleEnchant = false;
			elementEnchant = false;
			shroomEnchant = false;
			cobaltEnchant = false;
			spookyEnchant = false;
			hallowEnchant = false;
			chloroEnchant = false;
			vortexEnchant = false;
			adamantiteEnchant = false;
			frostEnchant = false;
			palladEnchant = false;
			oriEnchant = false;
			meteorEnchant = false;
			
			//pets
			flickerPet = false;
			moonEye = false;
			dinoPet = false;
			seedPet = false;
			dogPet = false;
			catPet = false;
			pumpkinPet = false;
			skullPet = false;
			saplingPet = false;
			turtPet = false;
			lizPet = false;
			eyePet = false;
			minotaurPet = false;
			dragPet = false;
			shadowPet = false;
			crimsonPet = false;
			spectrePet = false;
			
			meleeEffect = false;
			throwingEffect = false;
			rangedEffect = false;
			miniRangedEffect = false;
			builderEffect = false;
			universeEffect = false;
			speedEffect = false;
			damageSoul = false;
		    utilitySoul = false;
			fishSoul1 = false;
			fishSoul2 = false;
			dimensionSoul = false;
			terrariaSoul = false;
			
			
		}
		
		public override void Kill (double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{
			Fargowiltas.instance.multiSlime = false;
			Fargowiltas.slime100 = 0;
			Fargowiltas.instance.multiEye = false;
			Fargowiltas.eye100 = 0;
			Fargowiltas.instance.multiWorm = false;
			Fargowiltas.worm100 = 0;
			Fargowiltas.instance.multiBrain = false;
			Fargowiltas.brain100 = 0;
			Fargowiltas.instance.multiSkele = false;
			Fargowiltas.skele100 = 0;
			Fargowiltas.instance.multiBee = false;
			Fargowiltas.bee100 = 0;
			Fargowiltas.instance.multiFish = false;
			Fargowiltas.fish100 = 0;
		}

		public override void SetupStartInventory(IList<Item> items)
		{
			
		}
		
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			
		}
		
		public override void PostUpdateRunSpeeds()
		{
			if(speedEffect)
			{
				player.maxRunSpeed = 1000;
				player.accRunSpeed = 2;
				player.runAcceleration = 5;
			}
		}
		
		public override void UpdateBadLifeRegen()
		{
			
		}
		
		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			
			if (queenStinger)
            {
				  target.AddBuff(BuffID.Poisoned, 240, true);  
			}   
			
			if (meleeEffect)
            {
               if(proj.melee)
			   {
				  target.AddBuff(BuffID.CursedInferno, 240, true);
			   }  
			}   
			
			if (throwingEffect)
            {
               
                 if(proj.thrown)
			   {
				  target.AddBuff(BuffID.Confused, 120, true);
				  target.AddBuff(BuffID.Venom, 240, true);
				  target.AddBuff(BuffID.Frostburn, 240, true);
			   }
                
            }
			
			if (rangedEffect)
            {
              if(proj.ranged)
			   {
				  target.AddBuff(BuffID.ShadowFlame, 240, true);
			   }
			}   
			
            if (universeEffect)
            {
               
                  target.AddBuff(BuffID.Ichor, 240, true);
				  target.AddBuff(BuffID.CursedInferno, 240, true);
				  target.AddBuff(BuffID.Confused, 240, true);
				  target.AddBuff(BuffID.Venom, 240, true);
				  target.AddBuff(BuffID.ShadowFlame, 240, true);
				  target.AddBuff(BuffID.OnFire, 240, true);
				  target.AddBuff(BuffID.Frostburn, 240, true);
				  target.AddBuff(BuffID.Daybreak, 240, true);	
                
            }
			
			if (shadowEnchant && Main.rand.Next(4) == 0)
            {
				  target.AddBuff(BuffID.ShadowFlame, 120, true);
            }
			
			if(chloroEnchant)
			{
				target.AddBuff(BuffID.Poisoned, 240, true);
				target.AddBuff(BuffID.Venom, 240, true);
			}
			
			if(cobaltEnchant)
			{
				target.AddBuff(BuffID.Confused, 120, true);
			}
        }
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(spectreEnchant && proj.magic)
			{
				if(crit)
				{
					specHeal = true;
					healTown++;
				}
				else
				{
					if(healTown != 0 && healTown <= 6)
					{
						healTown++;
					}
					else
					{
						specHeal = false;
						healTown = 0;
					}
				}
			}
			
			if(vortexEnchant && proj.ranged)
			{
				if(crit && (vortexCrit < 100))
				{
					vortexCrit+= 4;
				}
			}
			
			if(terrariaSoul)
			{
				if(crit && (vortexCrit < 100))
				{
					vortexCrit+= 4;
				
				}
				else if(vortexCrit >= 100 && proj.type != ProjectileID.CrystalLeafShot && proj.type != mod.ProjectileType("HallowSword"))
				{
					player.statLife += (damage / 20);
					player.HealEffect(damage / 20);
				}
			}
			
			if(palladEnchant && Main.rand.Next(25) == 0)
			{
				player.statLife += (damage / 3);
				player.HealEffect(damage / 3);
			}			
			
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if(terrariaSoul && Main.rand.Next(10) == 0)
			{
				player.statLife += (damage);
				player.HealEffect(damage);
			}
		}
		
		public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
		{
			
		}
		
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			
			if (queenStinger)
            {
				  target.AddBuff(BuffID.Poisoned, 240, true);  
			}   
			
			if (meleeEffect)
            {
               if(item.melee)
			   {
				  target.AddBuff(BuffID.CursedInferno, 240, true);
				  
			   }  
			}   
			
			if (rangedEffect)
            {
              if(item.ranged)
			   {
				  target.AddBuff(BuffID.ShadowFlame, 240, true);
			   } 
			    
			}   
			
			if (throwingEffect)
            {
               
                 if(item.thrown)
			   {
				  target.AddBuff(BuffID.Confused, 120, true);
				  target.AddBuff(BuffID.Venom, 240, true);
				  target.AddBuff(BuffID.Frostburn, 240, true);
			   }
                
            }
			
			 if (universeEffect)
            {
                  target.AddBuff(BuffID.Ichor, 240, true);
				  target.AddBuff(BuffID.CursedInferno, 240, true);
				  target.AddBuff(BuffID.Confused, 120, true);
				  target.AddBuff(BuffID.Venom, 240, true);
				  target.AddBuff(BuffID.ShadowFlame, 240, true);
				  target.AddBuff(BuffID.OnFire, 240, true);
				  target.AddBuff(BuffID.Frostburn, 240, true);
				  target.AddBuff(BuffID.Daybreak, 240, true);	
                
            }
			
			if (shadowEnchant && Main.rand.Next(4) == 0)
            {
				  target.AddBuff(BuffID.ShadowFlame, 120, true);
            }
			
			if(chloroEnchant)
			{
				target.AddBuff(BuffID.Poisoned, 240, true);
				target.AddBuff(BuffID.Venom, 240, true);
			}
			
			if(cobaltEnchant && Main.rand.Next(3) == 0)
			{
				target.AddBuff(BuffID.Confused, 120, true);
			}
		}
		
		public override void MeleeEffects(Item item, Rectangle hitbox)
		{
			 
		}

		public override bool CanBeHitByProjectile(Projectile proj)
		{
			if(queenStinger)
			{
				if(proj.type == ProjectileID.Stinger)
				{
					return false;
				}
			}
			return true;
		}
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			
			return true;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (jungleEnchant)
			{
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 62);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
			
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
			}
			
			if(terrariaSoul && jungleEnchant)
			{
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 62);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
			
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
			}
			
			if (spookyEnchant && player.FindBuffIndex(mod.BuffType("SpookyCD")) == -1)
			{
				Main.PlaySound(2/**/, (int)player.position.X, (int)player.position.Y, 62);
			
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
				
				player.AddBuff(mod.BuffType("SpookyCD"), 240);
				
			}
			
			if((vortexEnchant || terrariaSoul) && vortexCrit > 4)
			{
				vortexCrit /= 2;
			}
			
		}
			
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
				
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if(fossilEnchant && player.FindBuffIndex(mod.BuffType("Revived")) == -1)
			{
				player.statLife = 20;
				player.HealEffect(20);
				player.immune = true;
				player.immuneTime = player.longInvince ? 180 : 120;
				Main.NewText("You've been revived!", 175, 75, 255);
				player.AddBuff(mod.BuffType("Revived"), 18000);
				return false;
			}
			if(terrariaSoul && player.FindBuffIndex(mod.BuffType("Revived")) == -1)
			{
				player.statLife = 200;
				player.HealEffect(200);
				player.immune = true;
				player.immuneTime = player.longInvince ? 180 : 120;
				Main.NewText("You've been revived!", 175, 75, 255);
				player.AddBuff(mod.BuffType("Revived"), 14400);
				return false;
			}
			return true;
		}
		
		public override bool ConsumeAmmo(Item weapon, Item ammo)
        {	
			if (infinity)
            {
					return false;
			}	
			
			if (universeEffect)
            {
					if( Main.rand.Next(100) < 50)
					{
						return false;
					}
			}	
			
			if (rangedEffect)
            {
					if( Main.rand.Next(100) < 32)
					{
						return false;
					}
			}	
			
			if (miniRangedEffect)
            {
					if( Main.rand.Next(100) < 4)
					{
						return false;
					}
			}	
			
			if (throwingEffect)
			{
				if(Main.rand.Next(100) < 32)
				{
					return false;
				}
				
			}
			return true;
			
			
        }
		
		public override bool Shoot (Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(meteorEnchant)
			{
				if(item.type == ItemID.SpaceGun || item.type == ItemID.LaserRifle || item.type == ItemID.HeatRay || item.type == ItemID.LaserMachinegun)
				{
					player.statMana += item.mana;
				}
			}
			
			if(item.type == 1553)
			{
				Main.NewText("The swarm has been defeated!", 175, 75, 255);
			}
			
			if(fishSoul2 && item.fishingPole > 0)
			{
					float spread = 2f * 0.1250f;
					float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
					double baseAngle = Math.Atan2(speedX, speedY);
					double randomAngle = baseAngle + 1f * spread;
					double randomAngle2 = baseAngle + 0f * spread;
					double randomAngle3 = baseAngle - 1f * spread;
					double randomAngle4 = baseAngle + .5f * spread;
					double randomAngle5 = baseAngle - .5f * spread;
					double randomAngle6 = baseAngle + 1.5f * spread;
					double randomAngle7 = baseAngle - 1.5f * spread;
					double randomAngle8 = baseAngle + 2f * spread;
					double randomAngle9 = baseAngle - 2f * spread;
					//double randomAngle10 = baseAngle + 0f * spread;
					
					float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.95f;
					speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
					speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
					
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle4), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle5), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle6), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle7), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle8), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle9), type, damage, knockBack, player.whoAmI, 0f, 0f);
            
					return true;
			}
			
			if(fishSoul1 && item.fishingPole > 0)
			{
					float spread = 2f * 0.1250f;
					float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
					double baseAngle = Math.Atan2(speedX, speedY);
					double randomAngle = baseAngle + .5f * spread;
					double randomAngle2 = baseAngle + 1f * spread;
					double randomAngle3 = baseAngle - .5f * spread;
					double randomAngle4 = baseAngle - 1f * spread;

					//double randomAngle10 = baseAngle + 0f * spread;
					
					float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.95f;
					speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
					speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
					
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle4), type, damage, knockBack, player.whoAmI, 0f, 0f);

            
					return true;
			}
			
			if(terrariaSoul && Main.rand.Next(2) == 0 && soulcheck.splitter)
			{
					float spread = 2f * 0.1250f;
					float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
					double baseAngle = Math.Atan2(speedX, speedY);
					double randomAngle = baseAngle + 1f * spread;
					double randomAngle2 = baseAngle + 0f * spread;
					double randomAngle3 = baseAngle - 1f * spread;
					float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.95f;
					speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
					speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
					
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), type, damage, knockBack, player.whoAmI, 0f, 0f);
					
					/*Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), item.shoot, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), item.shoot, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), item.shoot, damage, knockBack, player.whoAmI, 0f, 0f);*/
            
					return true;
			}
			
			if(adamantiteEnchant && item.magic)
			{
				
				if(Main.rand.Next(5) == 0)
				{
					float spread = 2f * 0.1250f;
					float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
					double baseAngle = Math.Atan2(speedX, speedY);
					double randomAngle = baseAngle + 1f * spread;
					double randomAngle2 = baseAngle + 0f * spread;
					double randomAngle3 = baseAngle - 1f * spread;
					float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.95f;
					speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
					speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
					
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle3), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle3), type, damage, knockBack, player.whoAmI, 0f, 0f);
					Projectile.NewProjectile(position.X, position.Y, baseSpeed * randomSpeed * (float)Math.Sin(randomAngle2), baseSpeed * randomSpeed * (float)Math.Cos(randomAngle2), type, damage, knockBack, player.whoAmI, 0f, 0f);
					return true;
				}
				
				else if(Main.rand.Next(20) == 0)
				{
					float spread = 45f * 0.0174f;
					double startAngle = Math.Atan2(speedX, speedY)- spread/2;
					double deltaAngle = spread/8f;
					double offsetAngle;
					int i;
					int j = Main.rand.Next(3);
					
					int r = 0;
			
					do
					{
						r = Main.rand.Next(714);
					}while(r != 15 && r != 20 && r != 27 && r != 45 && r != 88 && r != 95 && r != 114 && r != 253 && r != 261 && r != 280 && r != 316 && r != 409 && r != 438 && r != 459 && r != 504 && r != 510 && r != 521 && r != 634 && r != 635 && r != 660 && r != 711 && r != 704 && !((r >= 76) && (r <= 78)) && !((r >= 121) && (r <= 126)) && !((r >= 294) && (r <= 295)));
					
					for (i = 0; i < 1; i++ )
					{
						offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
						Projectile.NewProjectile(position.X, position.Y, speedX, speedY, r, damage, knockBack, player.whoAmI, 0f, 0f);
					}
					
					return false;
				}
			}
			
			return true;
		}
		
	}
}
