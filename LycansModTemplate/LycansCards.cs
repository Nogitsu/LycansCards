using BepInEx;
using System.IO;
using System;
using System.Timers;
using UnityEngine;
using System.Collections;
using TMPro;

namespace LycansModTemplate
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInProcess("Lycans.exe")]
    public class LycansCards : BaseUnityPlugin
    {

        private static System.Timers.Timer timer;

        public const string PLUGIN_GUID = $"nm-qm.lycans-cards";
        public const string PLUGIN_AUTHOR = "NM & QM";
        public const string PLUGIN_NAME = "Lycans Cards";
        public const string PLUGIN_VERSION = "1.0.0";

        private const string PREFIX = "Lycans Cards > ";
        private static int modsCount = 0;

        private void Awake()
        {
            Log.Init(Logger);

            Log.Info(PREFIX + "Démarrage");
            string gameVersion = Application.version.ToString();
            Log.Info(PREFIX + "Awake Game version: " + gameVersion);

            On.GameUI.ShowMainMenu += OnShowMainMenu;

            // setLateInit();
        }

        private void OnShowMainMenu(On.GameUI.orig_ShowMainMenu orig, GameUI self, bool active)
        {
            int modsCount = CountMods();

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

        private static void setLateInit()
        {
            Log.Info(PREFIX + "setLateInit");
            timer = new System.Timers.Timer(10000); 
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
            timer.Enabled = true;
            Log.Info(PREFIX + "setLateInit done");
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Info(PREFIX + "Timer_Elapsed");
            CountMods();
            Log.Info(PREFIX + "Timer_Elapsed done");
        }

        private void Update()
        {
            Log.Debug(PREFIX + "Update");
        }

        private static int CountMods()
        {
            Log.Info(PREFIX + "Counting mods...");
            string gameVersion = Application.version.ToString();
            Log.Info(PREFIX + "CountMods Game version: " + gameVersion);

            if (Directory.Exists(Paths.PluginPath))
            {
                modsCount = Directory.GetDirectories(Paths.PluginPath).Length;
                Log.Info(PREFIX + "Found " + modsCount + " mods");
            }

            return modsCount;
        }
    }
}