using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;

namespace Fargowiltas
{
	public class FargoPlayer : ModPlayer
	{		
		public bool wood = false;
        public bool hasMirror = false;
        public bool npcBoost = false;

        public override void ProcessTriggers(TriggersSet triggersSet)
		{
			//may need cooldown?
			if (hasMirror && Fargowiltas.HomeKey.JustPressed)
			{
				if (Main.rand.Next(2) == 0)
					Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.1f);
	
				for (int index = 0; index < 70; ++index)
					Dust.NewDust(player.position, player.width, player.height, 15, (float) (player.velocity.X * 0.5), (float) (player.velocity.Y * 0.5), 150, Color.White, 1.5f);
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
			}
		}
		public override void ResetEffects()
		{
			wood = false;
            hasMirror = false;
        }
    }
}
