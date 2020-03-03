using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class Stats : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stat Sheet");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[item.owner];

            tooltips.Add(new TooltipLine(mod, "info", $"Melee Damage: {player.meleeDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Melee Speed: {player.meleeSpeed * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Melee Crit: {player.meleeCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Ranged Damage: {player.rangedDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Ranged Crit: {player.rangedCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Magic Damage: {player.magicDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Magic Crit: {player.magicCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Summon Damage: {player.minionDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Max Minions: {player.maxMinions}"));
            tooltips.Add(new TooltipLine(mod, "info", $"Max Sentries: {player.maxTurrets}"));
            tooltips.Add(new TooltipLine(mod, "info", $"Throwing Damage: {player.thrownDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Throwing Crit: {player.thrownCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Damage Reduction: {player.endurance * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Life Regen: {player.lifeRegen} HP/second"));
            tooltips.Add(new TooltipLine(mod, "info", $"Armor Pen: {player.armorPenetration}"));
            tooltips.Add(new TooltipLine(mod, "info", $"Max Speed: {(player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6} mph"));
            tooltips.Add(new TooltipLine(mod, "info", $"Wing Time: {player.wingTimeMax / 60} seconds"));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sign);
            recipe.AddIngredient(ItemID.CopperAxe);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}