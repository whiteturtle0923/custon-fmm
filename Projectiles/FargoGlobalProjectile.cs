using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Fargowiltas.Projectiles
{
	public class FargoGlobalProjectile : GlobalProjectile
	{
		public override void SetDefaults (Projectile projectile)
		{
			
					/*if(projectile.type == 1)
					{
						projectile.penetrate = -1;
					}*/

		}
		
		public override void AI (Projectile projectile)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if(projectile.type == 373)
			{
				if ((!modPlayer.beeEnchant) && (player.FindBuffIndex(125) == -1))
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == 391 || projectile.type == 392 || projectile.type == 390)
			{
				if (!modPlayer.spiderEnchant && (player.FindBuffIndex(133) == -1))
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == 623)
			{
				if (!modPlayer.stardustEnchant && (player.FindBuffIndex(187) == -1))
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == mod.ProjectileType("HallowProj"))
			{
				if (!modPlayer.hallowEnchant)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == mod.ProjectileType("Chlorofuck"))
			{
				if (!modPlayer.chloroEnchant)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.DD2PetDragon && (player.FindBuffIndex(202) == -1))
			{
				if (!modPlayer.dragPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			/*if(projectile.type == ProjectileID.DD2PetGato && (player.FindBuffIndex(200) == -1))
			{
				if (!modPlayer.mythrilPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.Parrot && (player.FindBuffIndex(54) == -1))
			{
				if (!modPlayer.oriPet)
				{
					projectile.Kill();
					return;
				}
			}*/
			
			if(projectile.type == ProjectileID.Puppy && (player.FindBuffIndex(91) == -1))
			{
				if (!modPlayer.dogPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.BabyFaceMonster && (player.FindBuffIndex(154) == -1))
			{
				if (!modPlayer.crimsonPet)
				{
					projectile.Kill();
					return;
				}
			}
			/*
			if(projectile.type == ProjectileID.BabyHornet && (player.FindBuffIndex(51) == -1))
			{
				if (!modPlayer.beePet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.TikiSpirit && (player.FindBuffIndex(52) == -1))
			{
				if (!modPlayer.turtPet)
				{
					projectile.Kill();
					return;
				}
			}*/
			
			if(projectile.type == ProjectileID.PetLizard && (player.FindBuffIndex(53) == -1))
			{
				if (!modPlayer.lizPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.BlackCat && (player.FindBuffIndex(84) == -1))
			{
				if (!modPlayer.catPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.MiniMinotaur && (player.FindBuffIndex(136) == -1))
			{
				if (!modPlayer.minotaurPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.CursedSapling && (player.FindBuffIndex(85) == -1))
			{
				if (!modPlayer.saplingPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.Squashling && (player.FindBuffIndex(82) == -1))
			{
				if (!modPlayer.pumpkinPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.BabyEater && (player.FindBuffIndex(45) == -1))
			{
				if (!modPlayer.shadowPet)
				{
					projectile.Kill();
					return;
				}
			}
			
			if(projectile.type == ProjectileID.Wisp && (player.FindBuffIndex(57) == -1))
			{
				if (!modPlayer.spectrePet)
				{
					projectile.Kill();
					return;
				}
			}
			
		}
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			//spawn proj on hit
			if (modPlayer.shroomEnchant && (projectile.magic || projectile.thrown || projectile.melee || projectile.minion || projectile.ranged) && Main.rand.Next(5) == 0)
			{
				int shrooms = Projectile.NewProjectile(projectile.Center.X + Main.rand.Next(-40, 40), projectile.Center.Y + Main.rand.Next(-40, 40), 0f, 0f, 590, 32/*dmg*/, 0f, projectile.owner, 0f, 0f);
				Main.projectile[shrooms].melee = false;
			}
			
			if(modPlayer.oriEnchant && projectile.magic && Main.rand.Next(6) == 0)
			{
				int[] ball = {15, 95, 253};
				int fireball = Projectile.NewProjectile(projectile.Center.X + Main.rand.Next(-40, 40), projectile.Center.Y + Main.rand.Next(-40, 40), 0f + Main.rand.Next(-5, 5), -5f, ball[Main.rand.Next(3)], 32/*dmg*/, 0f, projectile.owner, 0f, 0f);
				Main.projectile[fireball].melee = false;
			}
			
			if (projectile.minion)
			{
				if (modPlayer.universeEffect)
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
			}
		}
		
		public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
		{
			/*Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			//reflect proj
			if (modPlayer.hallowEnchant && projectile.active && !projectile.friendly && projectile.hostile && damage > 0/* && Main.rand.Next(8) == 0)
			{
				projectile.hostile = false;
				target.statLife += damage;
				
    			//target.HealEffect(damage);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, 156, damage, 2f, Main.myPlayer, 0f, 0f);
				
				
			}*/
		}
		
		/*public override bool Colliding (Rectangle projHitbox, Rectangle targetHitbox)
		{
			if(projectile.projHitbox == mod.ProjectileType("DualSaberProj").projHitbox)
			{
				stuff
			}
		}*/
		
		public override void ModifyHitPlayer (Projectile projectile, Player target, ref int damage, ref bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			int chance = 0;
			if (modPlayer.hallowEnchant)
			{
				chance = 8;
			}
			else if(modPlayer.terrariaSoul)
			{
				chance = 2;
			}
			
			//reflect proj
			if (chance != 0 && projectile.active && !projectile.friendly && projectile.hostile && damage > 0 && Main.rand.Next(chance) == 0)
			{
				target.statLife += damage;
				
				//Projectile.NewProjectile(player.Center.X, player.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, mod.ProjectileType("HallowSword"), damage, 2f, Main.myPlayer, 0f, 0f);
				
				// Set ownership
				projectile.hostile = false;
				projectile.friendly = true;
				projectile.owner = player.whoAmI;
	
				// Turn around
				projectile.velocity *= -1f;
				projectile.penetrate = 1;
	
				// Flip sprite
				if (projectile.Center.X > player.Center.X * 0.5f)
				{
					projectile.direction = 1;
					projectile.spriteDirection = 1;
				}
				else
				{
					projectile.direction = -1;
					projectile.spriteDirection = -1;
				}
	
				// Don't know if this will help but here it is
				projectile.netUpdate = true;
				
			}
		}
	}
}