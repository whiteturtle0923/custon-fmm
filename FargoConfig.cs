using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Unlimited Ammo at 3996+")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo { get; set; }

        [Label("Unlimited Consumable Weapons at 3996+")]
        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons { get; set; }

        [Label("Unlimited Potion Buffs for 60+ Potions")]
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
