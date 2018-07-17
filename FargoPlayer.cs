using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        private bool hasMirror;
        private int mirrorCD;
        internal int rodCD;
        public bool npcBoost;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (!hasMirror || mirrorCD != 0 || !Fargowiltas.HomeKey.JustPressed) return;
            if (Main.rand.Next(2) == 0)
                Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.1f);

            for (int index = 0; index < 70; ++index)
                Dust.NewDust(player.position, player.width, player.height, 15, (float)(player.velocity.X * 0.5), (float)(player.velocity.Y * 0.5), 150, Color.White, 1.5f);
            player.grappling[0] = -1;
            player.grapCount = 0;
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
                    Main.projectile[index].Kill();
            }
            player.Spawn();
            for (int index = 0; index < 70; ++index)
                Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.5f);

            mirrorCD = 120;
        }

        public override void ResetEffects()
        {
            hasMirror = false;
        }

        public override void PostUpdateEquips()
        {
            for (int j = 0; j < player.inventory.Length; j++)
            {
                if (player.inventory[j].type == ItemID.IceMirror || player.inventory[j].type == ItemID.MagicMirror || player.inventory[j].type == ItemID.CellPhone)
                {
                    hasMirror = true;
                    break;
                }
            }

            if(mirrorCD > 0)
            {
                mirrorCD--;
            }
        }
    }
}