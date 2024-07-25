using TMPro;
using UnityEngine;

namespace LycansCards.Patches
{
    internal class GameUI
    {
        public static void Patch()
        {
            On.GameUI.ShowMainMenu += OnShowMainMenu;
            On.GameUI.ShowRole += OnShowRole;
            On.GameUI.ShowSpectateMenu += OnShowSpectateMenu;
        }

        private static void OnShowMainMenu(On.GameUI.orig_ShowMainMenu orig, global::GameUI self, bool active)
        {
            int modsCount = LycansCards.CountMods();

            GameObject versionObj = GameObject.Find("/GameUI/Canvas/MainMenu/LayoutGroup/Footer/Version");
            TextMeshProUGUI tmPro = versionObj.GetComponent<TextMeshProUGUI>();
            
            string mods = modsCount > 1 ? "mods" : "mod";
            tmPro.SetText("Modded version " + Application.version.ToString() + " (" + modsCount + " " + mods + " loaded)");
            tmPro.enableWordWrapping = false;

            orig(self, active);
        }

        private static void OnShowRole(On.GameUI.orig_ShowRole orig, global::GameUI self, bool active)
        {
            orig(self, active);
            GameObject.Find("GameUI/Canvas/Game/Role").SetActive(false);
        }

        private static void OnShowSpectateMenu(On.GameUI.orig_ShowSpectateMenu orig, global::GameUI self, bool active)
        {
            orig(self, active);
            GameObject spectateInfo = GameObject.Find("GameUI/Canvas/Spectate/SpectateInfo");
            TextMeshProUGUI tmPro = spectateInfo.GetComponent<TextMeshProUGUI>();
            tmPro.color = new Color(1f, 1f, 1f, 0.8f);
        }
    }
}
