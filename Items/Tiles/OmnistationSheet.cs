using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationSheet : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Omnistation");
            AddMapEntry(new Color(100, 255, 100), name);
            disableSmartCursor = true;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Main.LocalPlayer.AddBuff(BuffType<Buffs.Omnistation>(), 10);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ItemType<Omnistation>();
        }

        public override bool NewRightClick(int i, int j)
        {
            Item item = Main.LocalPlayer.HeldItem;
            if (item.melee)
            {
                Main.LocalPlayer.AddBuff(BuffID.Sharpened, 60 * 60 * 10);
            }

            if (item.ranged)
            {
                Main.LocalPlayer.AddBuff(BuffID.AmmoBox, 60 * 60 * 10);
            }

            if (item.magic)
            {
                Main.LocalPlayer.AddBuff(BuffID.Clairvoyance, 60 * 60 * 10);
            }

            if (item.summon)
            {
                Main.LocalPlayer.AddBuff(BuffID.Bewitched, 60 * 60 * 10);
            }

            if (item.melee || item.ranged || item.magic || item.summon)
            {
                Main.PlaySound(SoundID.Item44, i * 16 + 8, j * 16 + 8);
            }

            return true;
        }
    }
}