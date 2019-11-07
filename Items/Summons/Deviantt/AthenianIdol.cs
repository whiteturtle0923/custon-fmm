using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AthenianIdol : DevianttSummon
    {
        public override int summonType => NPCID.Medusa;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Athenian Idol");
            Tooltip.SetDefault("Summons Medusa");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}