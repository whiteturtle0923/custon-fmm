using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HallowChest : DevianttSummon
    {
        public override int summonType => NPCID.BigMimicHallow;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow Chest");
            Tooltip.SetDefault("Summons Hallowed Mimic");
        }
    }
}