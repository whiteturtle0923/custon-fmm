using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class RunawayProbe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runaway Probe");
            Tooltip.SetDefault("Starts the Martian invasion");
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
            Main.StartInvasion(4); //martians
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}