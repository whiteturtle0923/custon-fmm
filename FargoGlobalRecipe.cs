using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public class FargoGlobalRecipe : GlobalRecipe
    {
        public override bool RecipeAvailable(Recipe recipe)
        {
            if (Main.LocalPlayer.GetModPlayer<FargoPlayer>().ElementalAssemblerNearby > 0)
                Main.LocalPlayer.ZoneGraveyard = true;

            return base.RecipeAvailable(recipe);
        }
    }
}
