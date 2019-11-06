using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class MothLamp : DevianttSummon
    {
        public override int summonType => NPCID.Moth;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moth Lamp");
            Tooltip.SetDefault("Summons Moth");
        }
    }
}