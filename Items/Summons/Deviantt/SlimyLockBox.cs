using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SlimyLockBox : DevianttSummon
    {
        public override int summonType => NPCID.DungeonSlime;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Lock Box");
            Tooltip.SetDefault("Summons Dungeon Slime");
        }
    }
}