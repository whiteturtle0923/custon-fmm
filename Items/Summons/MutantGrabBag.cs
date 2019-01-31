using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MutantGrabBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Mutant's Grab Bag");
            Tooltip.SetDefault("Right click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 0;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
				
            int j = Main.rand.Next(10);

            if (j == 0)
            {
                player.QuickSpawnItem(mod.ItemType("MutantMask"));
                player.QuickSpawnItem(ItemID.GoldCoin, 5);
            }

            if (j % 2 == 1)
            {
                player.QuickSpawnItem(ItemID.SlimeCrown);
                player.QuickSpawnItem(ItemID.SuspiciousLookingEye);
                player.QuickSpawnItem(ItemID.WormFood);
                player.QuickSpawnItem(ItemID.BloodySpine);
                player.QuickSpawnItem(mod.ItemType("SuspiciousSkull"));
                player.QuickSpawnItem(ItemID.Abeemination);
                player.QuickSpawnItem(mod.ItemType("FleshyDoll"));
            }

            if (j == 2)
            {
                player.QuickSpawnItem(mod.ItemType("DeathBringerFairy"), 5);
            }

            if (j == 4)
            {
                player.QuickSpawnItem(mod.ItemType("MutantBody"));
                player.QuickSpawnItem(ItemID.GoldCoin, 5);
            }

            if (j == 6)
            {
                player.QuickSpawnItem(mod.ItemType("MutantPants"));
                player.QuickSpawnItem(ItemID.GoldCoin, 5);
            }

            if (j == 8)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (player.inventory[i] != null && player.inventory[i].maxStack > 10 && player.inventory[i].type != mod.ItemType("MutantGrabBag"))
                    {
                        player.QuickSpawnItem(player.inventory[i].type, 5);
                    }
                }
            }

            if (Fargowiltas.instance.fargoLoaded && Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ModLoader.GetMod("FargowiltasSouls").ItemType("Masochist"));
            }
        }
    }
}
