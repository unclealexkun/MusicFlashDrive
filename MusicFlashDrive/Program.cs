namespace MusicFlashDrive
{
  using NLog;

  internal static class Program
  {
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      try
      {
        // Initialize NLog
        LogManager.Setup().LoadConfigurationFromFile("nlog.config");
        
        logger.Info("Application starting...");
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
        
        logger.Info("Application shutting down...");
      }
      catch (Exception ex)
      {
        logger.Fatal(ex, "Application terminated unexpectedly.");
        throw;
      }
      finally
      {
        // Ensure all logs are flushed before exit
        LogManager.Shutdown();
      }
    }
  }
}