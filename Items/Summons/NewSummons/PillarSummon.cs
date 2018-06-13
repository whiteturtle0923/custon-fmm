using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class PillarSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outsider's Portal");
            Tooltip.SetDefault("Summons the Celestial Pillars");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 9;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            int[] pillars = new int[] { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };

            for (int i = 0; i < pillars.Length; i++)
            {
                NPC.NewNPC((int)player.position.X + (400 * i) - 600, (int)player.position.Y - 200, pillars[i]);
                NetMessage.SendData(23, -1, -1, null, pillars[i], 0f, 0f, 0f, 0);
            }

            Main.NewText("The Celestial Pillars have awoken!", 175, 75);

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}