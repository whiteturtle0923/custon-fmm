using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class MothronEgg : DevianttSummon
    {
        public override int summonType => NPCID.Mothron;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron Egg");
            Tooltip.SetDefault("Summons Mothron");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.eclipse;
        }
    }
}