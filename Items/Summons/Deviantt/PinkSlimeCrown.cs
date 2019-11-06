using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PinkSlimeCrown : DevianttSummon
    {
        public override int summonType => NPCID.Pinky;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink Slime Crown");
            Tooltip.SetDefault("Summons Pinky");
        }
    }
}