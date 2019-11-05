using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ClownShoe : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.Clown;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clown Shoe");
            Tooltip.SetDefault("Summons Clown");
        }
    }
}