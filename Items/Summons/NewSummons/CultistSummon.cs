using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class CultistSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zealot's Possession");
            Tooltip.SetDefault("Summons the Lunatic Cultist");
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
            int cultist = NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.CultistBoss);

            //so pillars wont spawn when he dies
            Main.npc[cultist].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;

            Main.NewText("Lunatic Cultist has awoken!", 175, 75, 255);
            NetMessage.SendData(23, -1, -1, null, NPCID.CultistBoss, 0f, 0f, 0f, 0);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}