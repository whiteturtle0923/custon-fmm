using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PlunderedBooty : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.PirateShip;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plundered Booty");
            Tooltip.SetDefault("Summons Flying Dutchman");
        }
    }
}