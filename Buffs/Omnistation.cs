using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class Omnistation : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Description.SetDefault("Effects of all vanilla stations");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Sunflower] = true;
            player.buffImmune[BuffID.Campfire] = true;
            player.buffImmune[BuffID.HeartLamp] = true;
            player.buffImmune[BuffID.StarInBottle] = true;

            if (player.whoAmI == Main.myPlayer)
            {
                //sunflower
                player.moveSpeed += 0.1f;
                player.moveSpeed *= 1.1f;
                player.sunflower = true;
                //campfire
                player.lifeRegen++;
                //heart lantern
                player.lifeRegen += 2;
                //star bottle
                player.manaRegenBonus += 2;
            }

            int type = Framing.GetTileSafely(player.Center).type;
            if (type == ModContent.TileType<OmnistationSheet>() || type == ModContent.TileType<OmnistationSheet2>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }
    }
}