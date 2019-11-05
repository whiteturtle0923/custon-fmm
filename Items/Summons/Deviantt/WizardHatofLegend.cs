using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class WizardHatofLegend : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.RuneWizard;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard Hat of Legend");
            Tooltip.SetDefault("Summons Rune Wizard");
        }
    }
}