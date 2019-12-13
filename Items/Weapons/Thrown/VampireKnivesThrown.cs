using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class VampireKnivesThrown : BaseThrownItem
    {
        public override int Type => ItemID.VampireKnives;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Rapidly throw life stealing daggers");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = item.shootSpeed;
            int itemDamage = item.damage;
            float itemKB = item.knockBack;
            itemKB = player.GetWeaponKnockback(item, itemKB);
            player.itemTime = item.useTime;

            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
            Vector2 vector2 = Main.MouseWorld - vector;

            float num80 = (float)Math.Sqrt(vector2.X * vector2.X + vector2.Y * vector2.Y);
            if (vector2.HasNaNs() || vector2 == Vector2.Zero)
            {
                vector2 = new Vector2(player.direction, 0f);
                num80 = shootSpeed;
            }
            else
            {
                num80 = shootSpeed / num80;
            }

            vector2 *= num80;

            int amount = 4;
            for (int i = 2; i <= 16; i *= 2)
            {
                if (Main.rand.NextBool(i))
                {
                    amount++;
                }
            }

            for (int i = 0; i < amount; i++)
            {
                float vecX = vector2.X + Main.rand.Next(-35, 36) * (0.05f * i);
                float vecY = vector2.Y + Main.rand.Next(-35, 36) * (0.05f * i);

                num80 = (float)Math.Sqrt(vecX * vecX + vecY * vecY);
                num80 = shootSpeed / num80;

                vecX *= num80;
                vecY *= num80;

                int proj = Projectile.NewProjectile(vector.X, vector.Y, vecX, vecY, ProjectileID.VampireKnife, itemDamage, itemKB, Main.myPlayer);
                Main.projectile[proj].thrown = true;
                Main.projectile[proj].melee = false;
            }

            return false;
        }
    }
}