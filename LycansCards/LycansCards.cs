using BepInEx;
using System.IO;

namespace LycansCards
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
            Log.Info("Démarrage");

            Patches.GameUI.Patch();
        }

        private void Update()
        {
            Log.Debug("Update");
        }

        public static int CountMods()
        {
            Log.Info("Counting mods...");

            if (Directory.Exists(Paths.PluginPath))
            {
                int modsCount = Directory.GetDirectories(Paths.PluginPath).Length;
                Log.Info("Found " + modsCount + " mods");

                return modsCount;
            }

            return 0;
        }
    }
}