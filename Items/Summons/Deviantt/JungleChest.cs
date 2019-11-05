using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class JungleChest : DevianttSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";
        public override int summonType => NPCID.BigMimicJungle;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Chest");
            Tooltip.SetDefault("Summons Jungle Mimic");
        }
    }
}