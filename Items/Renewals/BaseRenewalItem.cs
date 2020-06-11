using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Renewals
{
    public class BaseRenewalItem : ModItem
    {
        private readonly String name;
        private readonly String tooltip;
        private readonly String projType;
        private readonly int material;
        private readonly bool supreme;
        private readonly String supremeMaterial;

        protected BaseRenewalItem(String name, String tooltip, String projType, int material, bool supreme = false, String supremeMaterial = "")
        {
            this.name = name;
            this.tooltip = tooltip;
            this.projType = projType;
            this.material = material;
            this.supreme = supreme;
            this.supremeMaterial = supremeMaterial;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType(projType);
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            if (supreme)
            {
                recipe.AddIngredient(mod.ItemType(supremeMaterial), 10);
                recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
                recipe.AddTile(TileID.AlchemyTable);
            }
            else
            {
                recipe.AddIngredient(ItemID.Bottle);
                recipe.AddIngredient(material, 100);
                recipe.AddTile(TileID.Bottles);
            }

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
