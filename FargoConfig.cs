using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static FargoConfig Instance;

        [Label("Unlimited Potion Buffs for 120+ Potions")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120 { get; set; }

        [Label("Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset { get; set; }

        public override void OnLoaded()
        {
            Instance = this;
        }
    }
}
