using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class RegalStatueSheet : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Regal Statue");
            AddMapEntry(new Color(200, 200, 200), name);
            disableSmartCursor = true;

        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("RegalStatue"));
        }

        /*public override void NearbyEffects(int i, int j, bool closer)
        {
            Main.NewText(Main.checkForSpawns);
            if (Main.netMode != 1)
            {
                //usually 9 so should make it 10x as fast
                //Main.checkForSpawns += 81;
            }
        }*/
    }
}