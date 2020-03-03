using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class BetsyEgg : AbomSummon
    {
        public override int SummonType => NPCID.DD2Betsy;

        //public override string NPCName => "Betsy";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Egg");
            Tooltip.SetDefault("Summons Betsy");
        }
    }
}