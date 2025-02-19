using Serilog;

namespace BusinessLayer
{
    public static class Logger
    {
        static Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Info(string message) => Log.Information(message);
        public static void Error(string message) => Log.Error(message);
    }
}
