using System.Threading;
using System.Timers;
using Fusion;
using LycansCards.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LycansCards.Patches
{
    internal class GameUI
    {
        public static void Patch()
        {
            On.GameUI.Awake += OnAwake;
            On.GameUI.ShowMainMenu += OnShowMainMenu;
            On.GameUI.ShowPregameMenu += OnShowPregameMenu;
            On.GameUI.ShowRole += OnShowRole;
            On.GameUI.ShowSpectateMenu += OnShowSpectateMenu;
        }

        private static void OnAwake(On.GameUI.orig_Awake orig, global::GameUI self)
        {
            orig(self);

            GameObject roleObj = new GameObject("RoleCard");
            roleObj.transform.SetParent(GameObject.Find("GameUI/Canvas/Game/").transform, false);

            GameObject rectoObj = new GameObject("CardRecto");
            rectoObj.transform.SetParent(roleObj.transform, false);

            Sprite rectoSprite = Sprite.Create(Assets.LoadTexture("Villager.png"), new Rect(0, 0, 256, 256), new Vector2(0, 0));
            rectoObj.AddComponent<Image>().sprite = rectoSprite;
            rectoObj.transform.Rotate(Vector3.up, 180f);

            GameObject versoObj = new GameObject("CardVerso");
            versoObj.transform.SetParent(roleObj.transform, false);

            Sprite cardSprite = Sprite.Create(Assets.LoadTexture("CardBack.png"), new Rect(0, 0, 256, 256), new Vector2(0, 0));
            versoObj.AddComponent<Image>().sprite = cardSprite;
            
            roleObj.transform.position = new Vector3(64, 64, 0);
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

        private static void OnShowPregameMenu(On.GameUI.orig_ShowPregameMenu orig, global::GameUI self, bool active)
        {
            orig(self, active);
            GameObject.Find("GameUI/Canvas/Game/RoleCard").SetActive(false);
        }

        private static void OnShowRole(On.GameUI.orig_ShowRole orig, global::GameUI self, bool active)
        {
            orig(self, active);
            GameObject.Find("GameUI/Canvas/Game/Role").SetActive(false);

            GameObject roleObj = GameObject.Find("GameUI/Canvas/Game/RoleCard");
            Image rectoImg = GameObject.Find("GameUI/Canvas/Game/RoleCard/CardRecto").GetComponent<Image>();
            GameObject versoObj = GameObject.Find("GameUI/Canvas/Game/RoleCard/CardVerso");
            roleObj.SetActive(active);

            if (!active) return;

            versoObj.SetActive(true);

            float seconds = 0;
            bool reset = false;
            System.Timers.Timer timer = new System.Timers.Timer(10);
            timer.Elapsed += (sender, e) =>
            {
                seconds += 0.01f;

                float rotation = roleObj.transform.localEulerAngles.y;
                if (rotation >= 180f && !versoObj.activeSelf) {
                    if (rectoImg.color.a <= 0f)
                    {
                        timer.Stop();
                        return;
                    } else if (seconds >= 2f) {
                        if (!reset) {
                            reset = true;
                            seconds = 0f;
                            return;
                        }

                        rectoImg.color = new Color(rectoImg.color.r, rectoImg.color.g, rectoImg.color.b, rectoImg.color.a - 0.01f);
                    }
                } else if (seconds > 1f) {
                    if (rotation >= 90f)
                        versoObj.SetActive(false);

                    roleObj.transform.Rotate(Vector3.up, 2f);
                }
            };
            timer.Start();
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
