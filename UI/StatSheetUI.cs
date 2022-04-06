using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Fargowiltas.UI
{
    public class StatSheetUI : UIState
    {
        public const int BackWidth = 660;
        public const int BackHeight = 251 + 28; // 28 = search bar height (26) + padding (2)
        public const int HowManyPerColumn = 10;
        public const int HowManyColumns = 3;

        public int LineCounter;
        public int ColumnCounter;

        public UISearchBar SearchBar;
        public UIDragablePanel BackPanel;
        public UIPanel InnerPanel;

        public override void OnInitialize()
        {
            Vector2 offset = new Vector2(Main.screenWidth / 2 - BackWidth * 0.75f, Main.screenHeight / 2 - BackHeight * 0.75f);

            BackPanel = new UIDragablePanel();
            BackPanel.Left.Set(offset.X, 0f);
            BackPanel.Top.Set(offset.Y, 0f);
            BackPanel.Width.Set(BackWidth, 0f);
            BackPanel.Height.Set(BackHeight, 0f);
            BackPanel.PaddingLeft = BackPanel.PaddingRight = BackPanel.PaddingTop = BackPanel.PaddingBottom = 0;
            BackPanel.BackgroundColor = new Color(29, 33, 70) * 0.7f;
            Append(BackPanel);

            SearchBar = new UISearchBar(BackWidth - 8, 26);
            SearchBar.Left.Set(4, 0f);
            SearchBar.Top.Set(6, 0f); // 6 so padding lines up
            BackPanel.Append(SearchBar);

            InnerPanel = new UIPanel();
            InnerPanel.Left.Set(6, 0f);
            InnerPanel.Top.Set(6 + 28, 0f); // 28 for search bar
            InnerPanel.Width.Set(BackWidth - 12, 0f);
            InnerPanel.Height.Set(BackHeight - 12 - 28, 0);
            InnerPanel.PaddingLeft = InnerPanel.PaddingRight = InnerPanel.PaddingTop = InnerPanel.PaddingBottom = 0;
            InnerPanel.BackgroundColor = new Color(73, 94, 171) * 0.9f;
            BackPanel.Append(InnerPanel);

            base.OnInitialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Main.GameUpdateCount % (!SearchBar.IsEmpty ? 2 : 4) == 0) // 15 times a second, or 30 times a second if searchbar has text
            {
                RebuildStatList();
            }
        }

        public void RebuildStatList()
        {
            Player player = Main.LocalPlayer;

            InnerPanel.RemoveAllChildren();
            ColumnCounter = LineCounter = 0;

            int Damage(DamageClass damageClass) => (int)(((float)player.GetDamage(DamageClass.Generic) + (float)player.GetDamage(damageClass) - 1) * 100);
            int Crit(DamageClass damageClass) => player.GetCritChance(DamageClass.Generic) + player.GetCritChance(damageClass);

            AddStat($"Melee Damage: {Damage(DamageClass.Melee)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Crit: {Crit(DamageClass.Melee)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Speed: {(int)(1f / player.meleeSpeed * 100)}%", ItemID.CopperBroadsword);
            AddStat($"Ranged Damage: {Damage(DamageClass.Ranged)}%", ItemID.CopperBow);
            AddStat($"Ranged Crit: {Crit(DamageClass.Ranged)}%", ItemID.CopperBow);
            AddStat($"Magic Damage: {Damage(DamageClass.Magic)}%", ItemID.WandofSparking);
            AddStat($"Magic Crit: {Crit(DamageClass.Magic)}%", ItemID.WandofSparking);
            AddStat($"Summon Damage: {Damage(DamageClass.Summon)}%", ItemID.SlimeStaff);
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                AddStat($"Summon Crit: {ModLoader.GetMod("FargowiltasSouls").Call("GetSummonCrit")}%", ItemID.SlimeStaff);
            AddStat($"Max Minions: {player.maxMinions}", ItemID.SlimeStaff);
            AddStat($"Max Sentries: {player.maxTurrets}", ItemID.SlimeStaff);

            AddStat($"HP: {player.statLifeMax2}", ItemID.LifeCrystal);
            AddStat($"Defense: {player.statDefense}", ItemID.CobaltShield);
            AddStat($"Damage Reduction: {(int)(player.endurance * 100)}%", ItemID.WormScarf);
            AddStat($"Life Regen: {player.lifeRegen}/sec", ItemID.BandofRegeneration);
            AddStat($"Mana: {player.statManaMax2}", ItemID.ManaCrystal);
            AddStat($"Mana Regen: {player.manaRegen / 2}/sec", ItemID.ManaCrystal);

            AddStat($"Armor Penetration: {player.armorPenetration}", ItemID.SharkToothNecklace);
            AddStat($"Aggro: {player.aggro}", ItemID.FleshKnuckles);
            AddStat($"Max Speed: {(int)((player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6)} mph", ItemID.HermesBoots);
            AddStat($"Wing Time: {player.wingTimeMax / 60} sec", ItemID.AngelWings);

            AddStat($"Luck: {(int)(player.luck * 100) / 100f}", ItemID.Torch);
        }

        public void AddStat(string text, int item = -1)
        {
            int left = 8 + ColumnCounter * ((BackWidth - 8) / HowManyColumns);
            int top = 8 + LineCounter * (23); // I don't know why but 23 works perfectly
            if (++LineCounter == HowManyPerColumn)
            {
                ColumnCounter++;
                LineCounter = 0;
            }

            UIText ui = new UIText(item > -1 ? $"[i:{item}] {text}" : text);
            ui.Left.Set(left, 0f);
            ui.Top.Set(top, 0f);

            string[] words = text.Split(' ');
            if (!SearchBar.IsEmpty)
            {
                if (words.Any(s => s.StartsWith(SearchBar.Input, StringComparison.OrdinalIgnoreCase)))
                {
                    float fade = MathHelper.Lerp(0.1f, 0.9f, (float)(Math.Sin(Main.GameUpdateCount / 10f) + 1f) / 2f);
                    Color color = Color.Lerp(Color.Yellow, Color.Goldenrod, fade);
                    ui.TextColor = color;
                }
                else
                    // Gray out text when filtered by search
                    ui.TextColor = Color.Gray * 1.5f;
            }

            InnerPanel.Append(ui);
        }

        /*public void SetPositionToPoint(Point point)
        {
            BackPanel.Left.Set(point.X, 0f);
            BackPanel.Top.Set(point.Y, 0f);
        }

        public Point GetPositinAsPoint() => new Point((int)BackPanel.Left.Pixels, (int)BackPanel.Top.Pixels);*/
    }
}