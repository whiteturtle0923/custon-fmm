using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.UI;
using System;
using Terraria.Localization;
using Terraria.UI.Chat;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.UI
{
    public class StatSheetUI : UIState
    {
        public static Regex RemoveItemTags = new Regex(@"\[[^\[\]]*\]");

        public bool NeedsToggleListBuilding;
        public string DisplayMod;
        public string SortCatagory;

        public const int BackWidth = 400;
        public const int BackHeight = 658;

        public UIDragablePanel BackPanel;
        public UIPanel InnerPanel;

        public List<UIText> stats;

        private void addStat(string text)
        {
            UIText stat = new UIText(text);
            stats.Add(stat);
        }

        public override void OnInitialize()
        {
            NeedsToggleListBuilding = true;
            DisplayMod = "";
            SortCatagory = "";

            // This entire layout is cancerous and dangerous to your health because red protected UIElements children
            // If I want to give extra non-children to BackPanel to count as children when seeing if it should drag, I have to abandon
            // all semblence of organization in favour of making it work. Enjoy my write only UI laying out.
            // Oh well, at least it works...


            Player player = Main.player[Main.myPlayer];
            stats = new List<UIText>();

            addStat($"Melee Damage: {player.meleeDamage * 100}%");
            addStat($"Melee Crit: {player.meleeCrit}%");
            addStat($"Ranged Damage: {player.rangedDamage * 100}%");
            addStat($"Ranged Crit: {player.rangedCrit}%");
            addStat($"Magic Damage: {player.magicDamage * 100}%");
            addStat($"Magic Crit: {player.magicCrit}%");
            addStat($"Summon Damage: {player.minionDamage * 100}%");
            addStat($"Max Minions: {player.maxMinions}");
            addStat($"Max Sentries: {player.maxTurrets}");
            addStat($"Damage Reduction: {player.endurance * 100}%");
            addStat($"Life Regen: {player.lifeRegen} HP/second");
            addStat($"Armor Pen: {player.armorPenetration}");
            addStat($"Max Speed: {(player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6} mph");
            addStat($"Wing Time: {player.wingTimeMax / 60} seconds");



            //aggro
            //attack speed
            //hp
            //mana
            //defense
            //mana regen
            //luck





           

            BackPanel = new UIDragablePanel();
            BackPanel.Left.Set(0, 0f);
            BackPanel.Top.Set(0, 0f);
            BackPanel.Width.Set(BackWidth, 0f);
            BackPanel.Height.Set(BackHeight, 0f);
            BackPanel.PaddingLeft = BackPanel.PaddingRight = BackPanel.PaddingTop = BackPanel.PaddingBottom = 0;
            BackPanel.BackgroundColor = new Color(29, 33, 70) * 0.7f;

            InnerPanel = new UIPanel();
            InnerPanel.Width.Set(BackWidth - 12, 0f);
            InnerPanel.Height.Set(BackHeight - 70, 0);
            InnerPanel.Left.Set(6, 0f);
            InnerPanel.Top.Set(32, 0f);
            InnerPanel.BackgroundColor = new Color(73, 94, 171) * 0.9f;

            Append(BackPanel);
            BackPanel.Append(InnerPanel);

            //add stats, but they dont update NOOOOOOOOOOO pbone
            int left = 20;
            int top = 6;

            foreach (UIText text in stats)
            {
                text.Top.Set(top, 0f);
                text.Left.Set(left, 0f);

                top += 25;

                InnerPanel.Append(text);
            }

            base.OnInitialize();
        }

        private void SearchBar_OnTextChange(string oldText, string currentText)
        {
            NeedsToggleListBuilding = true;
        }

        private void hotbarScrollFix(UIScrollWheelEvent evt, UIElement listeningElement)
        {
            Main.LocalPlayer.ScrollHotbar(PlayerInput.ScrollWheelDelta / 120);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            /*if (NeedsToggleListBuilding)
            {
                BuildList();
                NeedsToggleListBuilding = false;
            }*/
        }

        /*public void BuildList()
        {
            ToggleList.Clear();
            Player player = Main.LocalPlayer;
            ToggleBackend toggler = player.GetModPlayer<FargoPlayer>().Toggler;

            IEnumerable<Toggle> displayToggles = toggler.Toggles.Values.Where((toggle) => {
                string[] words = GetRawToggleName(toggle.InternalName).Split(' ');
                return
                (string.IsNullOrEmpty(DisplayMod) || toggle.Mod == DisplayMod) &&
                (string.IsNullOrEmpty(SortCatagory) || toggle.Catagory == SortCatagory) &&
                (string.IsNullOrEmpty(SearchBar.Input) || words.Any(s => s.StartsWith(SearchBar.Input, StringComparison.OrdinalIgnoreCase)));
            });

            HashSet<string> usedHeaders = new HashSet<string>();
            List<Toggle> togglesAsLists = ToggleLoader.LoadedToggles.Values.ToList();

            foreach (Toggle toggle in displayToggles)
            {
                if (ToggleLoader.LoadedHeaders.ContainsKey(toggle.InternalName) && SearchBar.IsEmpty)
                {
                    if (ToggleList.Count > 0) // Don't add for the first header
                        ToggleList.Add(new UIText("", 0.2f)); // Blank line

                    (string name, int item) header = ToggleLoader.LoadedHeaders[toggle.InternalName];
                    ToggleList.Add(new UIHeader(header.name, header.item, (BackWidth - 16, 20)));
                }
                else if (!SearchBar.IsEmpty)
                {
                    int index = togglesAsLists.FindIndex(t => t.InternalName == toggle.InternalName);
                    int closestHeader = ToggleLoader.HeaderToggles.OrderBy(i =>
                        Math.Abs(index - i)).First();

                    if (closestHeader > index)
                        closestHeader = ToggleLoader.HeaderToggles[ToggleLoader.HeaderToggles.FindIndex(i => i == closestHeader) - 1];

                    (string name, int item) header = ToggleLoader.LoadedHeaders[togglesAsLists[closestHeader].InternalName];

                    if (!usedHeaders.Contains(header.name))
                    {
                        if (ToggleList.Count > 0) // Don't add for the first header
                            ToggleList.Add(new UIText("", 0.2f)); // Blank line

                        ToggleList.Add(new UIHeader(header.name, header.item, (BackWidth - 16, 20)));
                        usedHeaders.Add(header.name);
                    }
                }

                ToggleList.Add(new UIToggle(toggle.InternalName));
            }
        }*/

        public string GetRawToggleName(string key)
        {
            string baseText = Language.GetTextValue($"Mods.FargowiltasSouls.{key}Config");
            List<TextSnippet> parsedText = ChatManager.ParseMessage(baseText, Color.White);
            string rawText = "";

            foreach (TextSnippet snippet in parsedText)
            {
                if (!snippet.Text.StartsWith("["))
                {
                    rawText += snippet.Text.Trim();
                }
            }

            return rawText;
        }

        public void SetPositionToPoint(Point point)
        {
            BackPanel.Left.Set(point.X, 0f);
            BackPanel.Top.Set(point.Y, 0f);
        }

        public Point GetPositionAsPoint() => new Point((int)BackPanel.Left.Pixels, (int)BackPanel.Top.Pixels);
    }
}