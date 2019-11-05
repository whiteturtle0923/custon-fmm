using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.Mimic;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Chest");
            Tooltip.SetDefault("Summons Mimic");
        }
    }
}