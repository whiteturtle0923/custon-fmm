using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Thorium
{
    public class OverloadViscount : SwarmSummonBase
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public OverloadViscount() : base(ModContent.NPCType<Viscount>(), "The caverns are dripping with blood!", 50, "ViscountSummon")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Activated Blood Altar 2.0");
            Tooltip.SetDefault("Summons several Viscounts");
        }

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight);
        }
    }
}