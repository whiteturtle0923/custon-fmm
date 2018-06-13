using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class MutantVoodoo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant Voodoo Doll");
            Tooltip.SetDefault("Summons ALL the bosses");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 10;
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
            Main.NewText("Eye of Cthulhu has awoken!", 175, 75);
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.KingSlime);

            if (player.ZoneCorrupt || player.ZoneCrimson)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
                NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.BrainofCthulhu);
                Main.NewText("Brain of Cthulhu has awoken!", 175, 75);
            }

            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.SkeletronHead);
            Main.NewText("Skeletron has awoken!", 175, 75);
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.QueenBee);
            Main.NewText("Queen Bee has awoken!", 175, 75);
            NPC.SpawnWOF(player.Center);

            NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);

            NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(250, 1000), NPCID.Plantera);
            Main.NewText("Plantera has awoken!", 175, 75);
            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 300, NPCID.Golem);
            Main.NewText("Golem has awoken!", 175, 75);
            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 400, NPCID.DukeFishron);
            Main.NewText("Duke Fishron has awoken!", 175, 75);

            int cultist = NPC.NewNPC((int)player.position.X, (int)player.position.Y - 300, NPCID.CultistBoss);
            //so pillars wont spawn when he dies
            Main.npc[cultist].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;
            Main.NewText("Lunatic Cultist has awoken!", 175, 75);

            NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, NPCID.MoonLordCore);
            Main.NewText("The Moon Lord has awoken!", 175, 75);

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}