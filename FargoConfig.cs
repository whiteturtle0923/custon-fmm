using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("[i:771] Unlimited Ammo at 3996+")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo { get; set; }

        [Label("[i:42] Unlimited Consumable Weapons at 3996+")]
        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons { get; set; }

        [Label("[i:292] Unlimited Potion Buffs for 60+ Potions")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120 { get; set; }

        [Label("[i:2374] Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset { get; set; }

        [Label("[i:2294] Extra Lures on Fishing Rods")]
        [DefaultValue(true)]
        public bool ExtraLures
        {
            get; set;
        }

        [Label("[i:3213] Stalker Money Trough")]
        [DefaultValue(true)]
        public bool StalkerMoneyTrough { get; set; }

        [Label("[i:267] Catch Town NPCs")]
        [DefaultValue(true)]
        public bool CatchNPCs { get; set; }

        [Label("[i:1683] Banner Recipes")]
        [DefaultValue(true)]
        public bool BannerRecipes { get; set; }

        [Label("[i:284] Weapon Conversions")]
        [DefaultValue(true)]
        public bool WeaponConversions { get; set; }

        [Label("[i:2] Increased Max Stacks")]
        [DefaultValue(true)]
        public bool IncreaseMaxStack { get; set; }

        [Label("[i:997] Increased Extractinator Speed")] 
        [DefaultValue(true)]
        public bool ExtractSpeed { get; set; }
    }
}
