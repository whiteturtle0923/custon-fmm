using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PlunderedBooty : BaseSummon
    {
        public override int Type => NPCID.PirateShip;

        public override string NPCName => "Flying Dutchman";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plundered Booty");
            Tooltip.SetDefault("Summons Flying Dutchman");
        }
    }
}