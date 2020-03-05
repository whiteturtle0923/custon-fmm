using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;

namespace Fargowiltas.Items.Misc
{
    public class Stats : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
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
            if (Fargowiltas.ModLoaded["ThoriumMod"]) ThoriumStats(tooltips, player);
            tooltips.Add(new TooltipLine(mod, "info", $"Damage Reduction: {player.endurance * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Life Regen: {player.lifeRegen} HP/second"));
            tooltips.Add(new TooltipLine(mod, "info", $"Armor Pen: {player.armorPenetration}"));
            tooltips.Add(new TooltipLine(mod, "info", $"Max Speed: {(player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6} mph"));
            tooltips.Add(new TooltipLine(mod, "info", $"Wing Time: {player.wingTimeMax / 60} seconds"));
        }

        private void ThoriumStats(List<TooltipLine> tooltips, Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            tooltips.Add(new TooltipLine(mod, "info", $"Symphonic Damage: {thoriumPlayer.symphonicDamage * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Symphonic Speed: {(thoriumPlayer.symphonicSpeed * 100) + 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Symphonic Crit: {thoriumPlayer.symphonicCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Inspiration Regen: {thoriumPlayer.inspirationRegenBonus * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Empowerment Duration: {thoriumPlayer.bardBuffDuration / 60} seconds"));
            tooltips.Add(new TooltipLine(mod, "info", $"Radiant Damage: {thoriumPlayer.radiantBoost * 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Radiant Speed: {(thoriumPlayer.radiantSpeed * 100) + 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Healing Speed: {(thoriumPlayer.healingSpeed * 100) + 100}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Radiant Crit: {thoriumPlayer.radiantCrit}%"));
            tooltips.Add(new TooltipLine(mod, "info", $"Bonus Healing: {thoriumPlayer.healBonus}"));
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