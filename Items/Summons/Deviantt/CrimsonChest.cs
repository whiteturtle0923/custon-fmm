using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CrimsonChest : DevianttSummon
    {
        public override int summonType => NPCID.BigMimicCrimson;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Chest");
            Tooltip.SetDefault("Summons Crimson Mimic");
        }
    }
}