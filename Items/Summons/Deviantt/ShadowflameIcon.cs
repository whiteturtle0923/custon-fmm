using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ShadowflameIcon : DevianttSummon
    {
        public override int SummonType => NPCID.GoblinSummoner;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Icon");
            Tooltip.SetDefault("Summons Goblin Summoner" +
                               "\nOnly usable during Goblin Army");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType == InvasionID.GoblinArmy;
        }
    }
}