using BepInEx;
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
            Log.Init(Logger);
        }

        private void Update()
        {
            
        }
    }
}