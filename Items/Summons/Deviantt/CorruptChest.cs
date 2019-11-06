using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CorruptChest : DevianttSummon
    {
        public override int summonType => NPCID.BigMimicCorruption;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Chest");
            Tooltip.SetDefault("Summons Corrupt Mimic");
        }
    }
}