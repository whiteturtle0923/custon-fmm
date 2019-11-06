using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class LeesHeadband : DevianttSummon
    {
        public override int summonType => NPCID.BoneLee;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lee's Headband");
            Tooltip.SetDefault("Summons Bone Lee");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}