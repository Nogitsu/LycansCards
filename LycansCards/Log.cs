using BepInEx.Logging;

namespace LycansModTemplate
{
    internal static class Log
    {
        private const string PREFIX = "Lycans Cards > ";

        private static ManualLogSource _logSource;

        internal static void Init(ManualLogSource logSource)
        {
            _logSource = logSource;
        }

        internal static void Debug(object data) => _logSource.LogDebug(PREFIX + data);
        internal static void Error(object data) => _logSource.LogError(PREFIX + data);
        internal static void Fatal(object data) => _logSource.LogFatal(PREFIX + data);
        internal static void Info(object data) => _logSource.LogInfo(PREFIX + data);
        internal static void Message(object data) => _logSource.LogMessage(PREFIX + data);
        internal static void Warning(object data) => _logSource.LogWarning(PREFIX + data);
    }
}