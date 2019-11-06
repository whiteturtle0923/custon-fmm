using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class DilutedRainbowMatter : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.RainbowSlime;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diluted Rainbow Matter");
            Tooltip.SetDefault("Summons Rainbow Slime");
        }
    }
}