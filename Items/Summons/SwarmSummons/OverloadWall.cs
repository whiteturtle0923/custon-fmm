using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadWall : SwarmSummonBase
    {
        public OverloadWall() : base(NPCID.WallofFlesh, "A fortress of flesh arises from the depths!", 10, "FleshyDoll")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fleshiest Doll");
            Tooltip.SetDefault("Summons several Walls of Flesh");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && player.ZoneUnderworldHeight;
        }
    }
}