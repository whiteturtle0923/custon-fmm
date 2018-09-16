using Microsoft.Xna.Framework;
using System.Collections.Generic;
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

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Stats"));
            items.Add(item);
        }

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

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            //crate chance
            if (Main.rand.Next(100) < (10 + (player.cratePotion ? 10 : 0)))
            {
                if(liquidType == 0 && player.ZoneSnow)
                {
                    caughtType = mod.ItemType("IceCrate");
                }
                else if (liquidType == 1 && ItemID.Sets.CanFishInLava[fishingRod.type] && player.ZoneUnderworldHeight)
                {
                    caughtType = mod.ItemType("ShadowCrate");
                }
            }
        }
    }
}