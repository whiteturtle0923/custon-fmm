using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ForbiddenForbiddenFragment : DevianttSummon
    {
        public override int summonType => NPCID.SandElemental;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Forbidden Fragment");
            Tooltip.SetDefault("Summons Sand Elemental");
        }
    }
}