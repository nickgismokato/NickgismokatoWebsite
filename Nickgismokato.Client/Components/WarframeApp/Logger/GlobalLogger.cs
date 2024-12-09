using NLog;

namespace Nickgismokato.Client.Components.WarframeApp.Logging;


public static class GlobalLogger
{
    private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

    public static void LogTrace(string message) => logger.Trace(message);
    public static void LogDebug(string message) => logger.Debug(message);
    public static void LogInfo(string message) => logger.Info(message);
    public static void LogWarn(string message) => logger.Warn(message);
    public static void LogError(string message) => logger.Error(message);
    public static void LogFatal(string message) => logger.Fatal(message);

    public static void LogException(Exception ex, string message = null)
    {
        if (message != null)
            logger.Error(ex, message);
        else
            logger.Error(ex);
    }
}