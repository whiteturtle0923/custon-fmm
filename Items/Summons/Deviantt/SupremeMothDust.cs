using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SupremeMothDust : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.Moth;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supreme Moth Dust");
            Tooltip.SetDefault("Summons Moth");
        }
    }
}