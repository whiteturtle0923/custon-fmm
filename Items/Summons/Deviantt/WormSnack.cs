using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class WormSnack : BaseSummon
    {
        public override int Type => Main.hardMode ? NPCID.DiggerHead : NPCID.GiantWormHead;

        public override string NPCName => "Giant Worm";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Worm Snack Flag");
            Tooltip.SetDefault("Summons a Giant Worm" +
                               "\nOnly usable underground");
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}