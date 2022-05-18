using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ModLoader;

namespace Fargowiltas.ShoppingBiomes
{
    public class SkyBiome : IShoppingBiome, ILoadable
    {
        public string NameKey => "Sky";

        public bool IsInBiome(Player player) => player.ZoneSkyHeight;

        public void Load(Mod mod)
        {
            
        }

        public void Unload()
        {
            
        }
    }
}
