using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Minions
{
	public class EaterHead : ModProjectile
	{
		public int dust = 3;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater");
		}
		public override void SetDefaults()
		{
			projectile.width = 500;
			projectile.height = 42;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.netImportant = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.timeLeft *= 5;
			projectile.minion = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 4;
		}

		public override void AI()
		{
			
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.15f, 0.01f, 0.15f);
			Player player9 = Main.player[projectile.owner];
			FargoPlayer modPlayer = player9.GetModPlayer<FargoPlayer>(mod);
			player9.AddBuff(mod.BuffType("EaterMinion"), 3600);
			if ((int)Main.time % 120 == 0)
			{
				projectile.netUpdate = true;
			}
			if (!player9.active)
			{
				projectile.active = false;
				return;
			}
			int num1051 = 30;
			if (player9.dead)
			{
				modPlayer.eaterMinion = false;
			}
			if (modPlayer.eaterMinion)
			{
				projectile.timeLeft = 2;
			}
			Vector2 center14 = player9.Center;
			float num1053 = 700f;
			float num1054 = 1000f;
			int num1055 = -1;
			if (projectile.Distance(center14) > 2000f)
			{
				projectile.Center = center14;
				projectile.netUpdate = true;
			}
			bool flag65 = true;
			if (flag65)
			{
				for (int num1056 = 0; num1056 < 200; num1056++)
				{
					NPC nPC13 = Main.npc[num1056];
					if (nPC13.CanBeChasedBy(projectile, false) && player9.Distance(nPC13.Center) < num1054)
					{
						float num1057 = projectile.Distance(nPC13.Center);
						if (num1057 < num1053)
						{
							num1055 = num1056;
							bool arg_2D8E1_0 = nPC13.boss;
						}
					}
				}
			}
			if (num1055 != -1)
			{
				NPC nPC14 = Main.npc[num1055];
				Vector2 vector132 = nPC14.Center - projectile.Center;
				(vector132.X > 0f).ToDirectionInt();
				(vector132.Y > 0f).ToDirectionInt();
				float scaleFactor16 = 0.4f;
				if (vector132.Length() < 600f)
				{
					scaleFactor16 = 0.6f;
				}
				if (vector132.Length() < 300f)
				{
					scaleFactor16 = 0.8f;
				}
				if (vector132.Length() > nPC14.Size.Length() * 0.75f)
				{
					projectile.velocity += Vector2.Normalize(vector132) * scaleFactor16 * 1.5f;
					if (Vector2.Dot(projectile.velocity, vector132) < 0.25f)
					{
						projectile.velocity *= 0.8f;
					}
				}
				float num1058 = 30f;
				if (projectile.velocity.Length() > num1058)
				{
					projectile.velocity = Vector2.Normalize(projectile.velocity) * num1058;
				}
			}
			else
			{
				float num1059 = 0.2f;
				Vector2 vector133 = center14 - projectile.Center;
				if (vector133.Length() < 200f)
				{
					num1059 = 0.12f;
				}
				if (vector133.Length() < 140f)
				{
					num1059 = 0.06f;
				}
				if (vector133.Length() > 100f)
				{
					if (Math.Abs(center14.X - projectile.Center.X) > 20f)
					{
						projectile.velocity.X = projectile.velocity.X + num1059 * (float)Math.Sign(center14.X - projectile.Center.X);
					}
					if (Math.Abs(center14.Y - projectile.Center.Y) > 10f)
					{
						projectile.velocity.Y = projectile.velocity.Y + num1059 * (float)Math.Sign(center14.Y - projectile.Center.Y);
					}
				}
				else if (projectile.velocity.Length() > 2f)
				{
					projectile.velocity *= 0.96f;
				}
				if (Math.Abs(projectile.velocity.Y) < 1f)
				{
					projectile.velocity.Y = projectile.velocity.Y - 0.1f;
				}
				float num1060 = 15f;
				if (projectile.velocity.Length() > num1060)
				{
					projectile.velocity = Vector2.Normalize(projectile.velocity) * num1060;
				}
			}
			projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
			int direction = projectile.direction;
			projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
			if (direction != projectile.direction)
			{
				projectile.netUpdate = true;
			}
			float num1061 = MathHelper.Clamp(projectile.localAI[0], 0f, 50f);
			projectile.position = projectile.Center;
			projectile.scale = 1f + num1061 * 0.01f;
			projectile.width = (projectile.height = (int)((float)num1051 * projectile.scale));
			projectile.Center = projectile.position;
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 42;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
					return;
				}
			}
		}
	}
}
