using TMPro;
using UnityEngine;

namespace LycansCards.Patches
{
    internal class GameUI
    {
        public static void Patch()
        {
            On.GameUI.ShowMainMenu += OnShowMainMenu;
        }

        private static void OnShowMainMenu(On.GameUI.orig_ShowMainMenu orig, global::GameUI self, bool active)
        {
            int modsCount = LycansCards.CountMods();

            GameObject versionObj = GameObject.Find("/GameUI/Canvas/MainMenu/LayoutGroup/Footer/Version");
            if (versionObj != null)
            {
                TextMeshProUGUI tmPro = versionObj.GetComponent<TextMeshProUGUI>();
                if (tmPro != null)
                {
                    string mods = modsCount > 1 ? "mods" : "mod";
                    tmPro.SetText("Modded version " + Application.version.ToString() + " (" + modsCount + " " + mods + " loaded)");
                }
            }

            orig(self, active);
        }
    }
}
