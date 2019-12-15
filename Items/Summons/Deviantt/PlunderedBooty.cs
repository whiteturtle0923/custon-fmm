using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PlunderedBooty : DevianttSummon
    {
        public override int SummonType => NPCID.PirateShip;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plundered Booty");
            Tooltip.SetDefault("Summons Flying Dutchman");
        }
    }
}