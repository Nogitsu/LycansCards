using BepInEx;
using System.IO;
using UnityEngine;
using System.Collections;
using TMPro;

namespace LycansModTemplate
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInProcess("Lycans.exe")]
    public class LycansCards : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = $"nm-qm.lycans-cards";
        public const string PLUGIN_AUTHOR = "NM & QM";
        public const string PLUGIN_NAME = "Lycans Cards";
        public const string PLUGIN_VERSION = "1.0.0";

        private const string PREFIX = "Lycans Cards > ";

        private void Awake()
        {
            Log.Init(Logger);

            Log.Info(PREFIX + "Démarrage");
            int modsCount = CountMods();
            Log.Info(PREFIX + "Found " + modsCount + " mods");
        }

        private void Update()
        {
        }

        // private void Start()
        // {
        //     Log.Info(PREFIX + "Start");
        //     CountMods();
        // }

        private int CountMods()
        {
            Log.Info(PREFIX + "Counting mods...");
            string gameVersion = Application.version.ToString();
            int modsCount = 0;



            if (Directory.Exists(Paths.PluginPath))
            {
                modsCount = Directory.GetDirectories(Paths.PluginPath).Length;
            }

             GameObject versionObj = GameObject.Find("/GameUI/Canvas/MainMenu/LayoutGroup/Footer/Version");
            if (versionObj != null)
            {
                Log.Info(PREFIX + "Found version object");
                TextMeshProUGUI tmPro= versionObj.GetComponent<TextMeshProUGUI>();
                if (tmPro != null)
                {
                    string mods = modsCount > 1 ? "mods" : "mod";
                    tmPro.SetText("Modded version " + Application.version.ToString() + " (" + modsCount + " " + mods + " loaded)");
                }
            }
            return modsCount;
        }
    }
}