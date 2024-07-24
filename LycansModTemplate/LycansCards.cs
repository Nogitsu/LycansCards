using BepInEx;
using BepInEx.Configuration;
using System.IO;
using UnityEngine;

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

        private void Awake()
        {
            CountMods();
            Log.Init(Logger);
        }

        private void Update()
        {
            
        }

        private void CountMods()
        {
            string gameVersion = Application.version.ToString();
            int modsCount = 0;



            if (Directory.Exists(Paths.PluginPath))
            {
                modsCount = Directory.GetDirectories(Paths.PluginPath).Length; 
            }

            GameObject versionObj = GameObject.Find("Version");
            if (versionObj != null)
            {
                TMPro.TextMeshProUGUI tmPro= versionObj.GetComponent<TMPro.TextMeshProUGUI>();
                if (tmPro != null)
                {
                    string mods = modsCount > 1 ? "mods" : "mod";
                    tmPro.SetText("Modded version " + Application.version.ToString() + " (" + modsCount + " " + mods + " loaded)");
                }
            }
        }
    }
}