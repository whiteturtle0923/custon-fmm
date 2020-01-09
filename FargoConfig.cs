using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Unlimited Potion Buffs for 120+ Potions")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120 { get; set; }

        [Label("Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset { get; set; }

        [Label("Stalker Money Trough")]
        [DefaultValue(true)]
        public bool StalkerMoneyTrough { get; set; }
    }
}
