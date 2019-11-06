using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CoreoftheFrostCore : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.IceGolem;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of the Frost Core");
            Tooltip.SetDefault("Summons Ice Golem");
        }
    }
}