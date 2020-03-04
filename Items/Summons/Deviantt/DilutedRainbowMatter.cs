using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class DilutedRainbowMatter : BaseSummon
    {
        public override int Type => NPCID.RainbowSlime;

        public override string NPCName => "Rainbow Slime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diluted Rainbow Matter");
            Tooltip.SetDefault("Summons Rainbow Slime");
        }
    }
}