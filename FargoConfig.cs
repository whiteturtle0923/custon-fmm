using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.Fargowiltas.Mutant")]
        [DefaultValue(true)]
        public bool Mutant;

        [Label("$Mods.Fargowiltas.Abom")]
        [DefaultValue(true)]
        public bool Abom;

        [Label("$Mods.Fargowiltas.Devi")]
        [DefaultValue(true)]
        public bool Devi;

        [Label("$Mods.Fargowiltas.Lumber")]
        [DefaultValue(true)]
        public bool Lumber;

        [Label("[i:1774] Halloween Season Active")]
        [DefaultValue(true)]
        public bool Halloween;

        [Label("[i:1869] Christmas Season Active")]
        [DefaultValue(true)]
        public bool Christmas;

        [Label("[i:353] Drunk World Active")]
        [DefaultValue(true)]
        public bool DrunkWorld;

        [Label("[i:1133] Bee World Active")]
        [DefaultValue(true)]
        public bool BeeWorld;

        [Label("[i:2107] For the Worthy World Active")]
        [DefaultValue(true)]
        public bool WorthyWorld;

        [Label("[i:3732] Celebration World Active")]
        [DefaultValue(true)]
        public bool CelebrationWorld;

        [Label("[i:5109] Constant World Active")]
        [DefaultValue(true)]
        public bool ConstantWorld;

        [Label("[i:771] Unlimited Ammo at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo;

        [Label("[i:42] Unlimited Consumable Weapons at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons;

        [Label("[i:292] Unlimited Potion/Class Station Buffs at 30/15+ Stack")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120;

        [Label("[i:2374] Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset;

        [Label("[i:2294] Extra Lures on Fishing Rods")]
        [DefaultValue(true)]
        public bool ExtraLures;

        [Label("[i:3213] Stalker Money Trough")]
        [DefaultValue(true)]
        public bool StalkerMoneyTrough;

        [Label("[i:267] Catch Town NPCs")]
        [DefaultValue(true)]
        public bool CatchNPCs;

        [Label("[i:267] Extra Town NPC sales")]
        [DefaultValue(true)]
        public bool NPCSales;

        [Label("[i:1809] Powerful Rotten Eggs")]
        [DefaultValue(true)]
        public bool RottenEggs;

        [Label("[i:1683] Banner Recipes")]
        [DefaultValue(true)]
        public bool BannerRecipes;

        [Label("[i:2] Increased Max Stacks")]
        [DefaultValue(true)]
        public bool IncreaseMaxStack;

        [Label("[i:997] Increased Extractinator Speed")]
        [DefaultValue(true)]
        public bool ExtractSpeed;

        [Label("[i:909] Fountains Cause Biomes")]
        [DefaultValue(true)]
        public bool Fountains;

        [Label("[i:3117] No enemies spawn during boss fights")]
        [DefaultValue(true)]
        public bool BossZen;

        [Label("[i:87] Informational and Construction Accessories work in Piggy Bank")]
        [DefaultValue(true)]
        public bool PiggyBankAcc;

        [Label("[i:4881] Faster Fishing in Lava")]
        [DefaultValue(true)]
        public bool FasterLavaFishing;

        [Label("[i:1612] Debuffs render above player")]
        [DefaultValue(false)]
        public bool DebuffDisplay;

        [Label("[i:1612] Debuff Display Opacity")]
        [DefaultValue(1f)] [Slider]
        public float DebuffOpacity;

        [Label("[i:1309] Transparent Minions & Support Attacks")]
        [DefaultValue(1f)]
        [Slider]
        public float TransparentMinions;
    }
}
