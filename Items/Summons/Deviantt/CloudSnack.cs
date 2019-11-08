using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CloudSnack : DevianttSummon
    {
        public override int summonType => NPCID.WyvernHead;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Snack");
            Tooltip.SetDefault("Summons Wyvern");
        }
    }
}