using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class LeviathanSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Siren's Pearl");
            Tooltip.SetDefault("Summons The Leviathan");
        }

        public override bool Autoload(ref string name)
        {
            if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
            {
                return false;
            }

            return true;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, ModLoader.GetMod("CalamityMod").NPCType("Siren"));
                NetMessage.SendData(23, -1, -1, null, ModLoader.GetMod("CalamityMod").NPCType("Siren"), 0f, 0f, 0f, 0);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}