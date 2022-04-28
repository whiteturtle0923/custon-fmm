using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class SuspiciousSkull : BaseSummon
    {
        public override int NPCType => NPCID.SkeletronHead;

        public override string NPCName => "Skeletron";

        public override bool ResetTimeWhenUsed => !NPC.downedMechBoss3;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Suspicious Skull");
            Tooltip.SetDefault("Summons Skeletron without killing the Clothier" +
                               "\nSummons the Dungeon Guardian during the day");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;

        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ItemID.ClothierVoodooDoll)
              .AddTile(TileID.WorkBenches)
              .Register();
        }
    }
}