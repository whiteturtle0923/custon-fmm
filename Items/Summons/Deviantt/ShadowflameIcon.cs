using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ShadowflameIcon : DevianttSummon
    {
        public override int summonType => NPCID.GoblinSummoner;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Icon");
            Tooltip.SetDefault("Summons Goblin Summoner\nOnly usable during Goblin Army");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType == InvasionID.GoblinArmy;
        }
    }
}