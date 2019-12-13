using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class MothronEgg : DevianttSummon
    {
        public override int SummonType => NPCID.Mothron;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron Egg");
            Tooltip.SetDefault("Summons Mothron" +
                               "\nOnly usable during Solar Eclipse");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.eclipse;
        }
    }
}