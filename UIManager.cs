using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Fargowiltas.UI;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowilta
{
    public class UIManager
    {
        public UserInterface StatSheetUserInterface;
        public UserInterface TogglerToggleUserInterface;
        public StatSheetUI StatSheet;
        public StatButton StatButton;
        private GameTime _lastUpdateUIGameTime;

        public Texture2D CheckMark;
        public Texture2D CheckBox;
        public Texture2D StatsButtonTexture;
        public Texture2D StatsButton_MouseOverTexture;
        public Texture2D PresetButtonOutline;
        public Texture2D PresetOffButton;
        public Texture2D PresetOnButton;
        public Texture2D PresetMinimalButton;

        public void LoadUI()
        {
            if (!Main.dedServ)
            {
                // Load textures
                CheckMark = ModContent.GetTexture("Fargowiltas/UI/Assets/CheckMark");
                CheckBox = ModContent.GetTexture("Fargowiltas/UI/Assets/CheckBox");
                StatsButtonTexture = ModContent.GetTexture("Fargowiltas/UI/Assets/StatsButton");
                StatsButton_MouseOverTexture = ModContent.GetTexture("Fargowiltas/UI/Assets/StatsButton_MouseOver");


                // Initialize UserInterfaces
                StatSheetUserInterface = new UserInterface();
                TogglerToggleUserInterface = new UserInterface();

                // Activate UIs
                StatSheet = new StatSheetUI();
                StatSheet.Activate();
                StatButton = new StatButton();
                StatButton.Activate();

                TogglerToggleUserInterface.SetState(StatButton);
            }
        }

        public void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUIGameTime = gameTime;

            //if (!Main.playerInventory)// && SoulConfig.Instance.HideTogglerWhenInventoryIsClosed)
            //    CloseStatSheet();

            if (StatSheetUserInterface?.CurrentState != null)
                StatSheetUserInterface.Update(gameTime);
            if (TogglerToggleUserInterface?.CurrentState != null)
                TogglerToggleUserInterface.Update(gameTime);
        }

        public bool IsStatSheetOpen() => StatSheetUserInterface?.CurrentState == null;
        public void CloseStatSheet() => StatSheetUserInterface?.SetState(null);
        //public bool IsTogglerOpen() => TogglerUserInterface.CurrentState == StatSheet;
        public void OpenStatSheet() => StatSheetUserInterface.SetState(StatSheet);

        public void ToggleStatSheet()
        {
            if (IsStatSheetOpen())
            {
                Main.PlaySound(SoundID.MenuOpen);
                OpenStatSheet();
            }
            else// if (IsTogglerOpen())
            {
                Main.PlaySound(SoundID.MenuClose);
                CloseStatSheet();
            }
        }

        public void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex((layer) => layer.Name == "Vanilla: Inventory");
            if (index != -1)
            {
                layers.Insert(index - 1, new LegacyGameInterfaceLayer("Fargos: Soul Toggler", delegate
                {
                    if (_lastUpdateUIGameTime != null && StatSheetUserInterface?.CurrentState != null)
                        StatSheetUserInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);
                    return true;
                }, InterfaceScaleType.UI));
            }

            index = layers.FindIndex((layer) => layer.Name == "Vanilla: Mouse Text");
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("Fargos: Stat Sheet Toggler", delegate
                {
                    if (_lastUpdateUIGameTime != null && TogglerToggleUserInterface?.CurrentState != null)
                        TogglerToggleUserInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);

                    return true;
                }, InterfaceScaleType.UI));
            }
        }
    }
}