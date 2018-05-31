using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class DeathBringerFairy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Bringer Fairy");
            Tooltip.SetDefault("Summons all pre-hardmode bosses \nCertain bosses will only spawn if you're in their specific biome");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 2;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.EyeofCthulhu);
            Main.NewText("Eye of Cthulhu has awoken!", 175, 75, 255);
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.KingSlime);

            if (player.ZoneCorrupt || player.ZoneCrimson)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
                NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.BrainofCthulhu);
                Main.NewText("Brain of Cthulhu has awoken!", 175, 75, 255);
            }

            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
            Main.NewText("Skeletron has awoken!", 175, 75, 255);
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.QueenBee);
            Main.NewText("Queen Bee has awoken!", 175, 75, 255);
            NPC.SpawnWOF(player.Center);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}