namespace MusicFlashDrive.FileOperation
{
  using NLog;

  /// <summary>
  /// Копирование файлов.
  /// </summary>
  public class FileCopy : IFileCopy
  {
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    
    #region Константы

    /// <summary>
    /// Фрагмент.
    /// </summary>
    private readonly int ChunkSize = 5;
    /// <summary>
    /// Поисковый паттерн.
    /// </summary>
    private readonly string SearchPattern = "*.mp3";

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Режим копирования.
    /// </summary>
    private readonly ICopyMode copyMode;
    /// <summary>
    /// Директория источник.
    /// </summary>
    public DirectoryInfo Source { get; private set; }
    /// <summary>
    /// Целевая директория.
    /// </summary>
    public DirectoryInfo Destination { get; private set; }
    /// <summary>
    /// Статус копирования.
    /// </summary>
    public CopyState CopyState { get; private set; }

    #endregion

    #region IFileCopy

    public async Task Execute(IProgress<CopyProgressInfo> progress, CancellationToken token = default)
    {
      logger.Info("Starting file copy operation from {source} to {destination}", Source.FullName, Destination.FullName);
      
      var files = Source.GetFiles(SearchPattern, SearchOption.AllDirectories);
      logger.Debug("Found {count} MP3 files to process", files.Length);
      
      var steps = (int)Math.Round((double)files.Length / ChunkSize, MidpointRounding.ToPositiveInfinity);

      int processedFilesCount = 0;
      var copyProgressInfo = new CopyProgressInfo()
      {
        Value = $"Обработано {processedFilesCount} из {files.Length} файлов",
        Progress = 0
      };
      progress.Report(copyProgressInfo);

      for (int step = 0; step < steps; ++step)
      {
        token.ThrowIfCancellationRequested();
        var processedFiles = files.Skip(step * ChunkSize).Take(ChunkSize);

        var task = Task.Run(() => CopingAsync(processedFiles, token), token);
        await Task.WhenAll(task);

        processedFilesCount += processedFiles.Count();
        copyProgressInfo = new CopyProgressInfo()
        {
          Value = $"Обработано {processedFilesCount} из {files.Length} файлов",
          Progress = (int)Math.Round((double)(processedFilesCount * 100 / files.Length))
        };
        progress.Report(copyProgressInfo);
        
        logger.Debug("Progress: {progress}%", copyProgressInfo.Progress);
      }

      processedFilesCount = 0;
      copyProgressInfo = new CopyProgressInfo()
      {
        Value = $"Обработано",
        Progress = 0
      };
      progress.Report(copyProgressInfo);
      
      logger.Info("File copy operation completed");
    }

    #endregion

    #region Методы

    /// <summary>
    /// Копирование файлов.
    /// </summary>
    /// <param name="files">Копируемые файлы.</param>
    /// <param name="token">Токен отмены операции.</param>
    private async Task CopingAsync(IEnumerable<FileInfo> files, CancellationToken token)
    {
      foreach (var file in files)
      {
        try
        {
          var destinationFileName = this.copyMode.GeneratePathDestinationFile(this.Source, file, this.Destination);
          if (File.Exists(destinationFileName))
            if (HashComparison.Compare(file.FullName, destinationFileName))
            {
              logger.Debug("File already exists and matches hash, skipping: {file}", file.Name);
              continue;
            }

          var destinationDirectoryName = Path.GetDirectoryName(destinationFileName);
          if (!Directory.Exists(destinationDirectoryName) && !string.IsNullOrEmpty(destinationDirectoryName))
          {
            logger.Debug("Creating directory: {directory}", destinationDirectoryName);
            Directory.CreateDirectory(destinationDirectoryName);
          }

          try
          {
            int bufferSize = 1024;
            token.ThrowIfCancellationRequested();
            logger.Debug("Copying file: {file} to {destination}", file.Name, destinationFileName);
            
            using (var sourceStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
            {
              using (var destinationStream = new FileStream(destinationFileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, useAsync: true))
              {
                await sourceStream.CopyToAsync(destinationStream, bufferSize, token);
              }
            }
            logger.Debug("Successfully copied file: {file}", file.Name);
          }
          catch (OperationCanceledException)
          {
            logger.Warn("File copy operation was cancelled for file: {file}", file.Name);
            throw;
          }
          catch (IOException ex)
          {
            logger.Error(ex, "IO error copying file: {file}", file.Name);
          }
          catch (UnauthorizedAccessException ex)
          {
            logger.Error(ex, "Access denied copying file: {file}", file.Name);
          }
        }
        catch (Exception ex)
        {
          logger.Error(ex, "Unexpected error processing file: {file}", file.Name);
        }
      }
    }

    #endregion

    #region Конструктор

    public FileCopy(string source, string destination, ICopyMode copyMode)
    {
      try
      {
        if (!Path.Exists(source))
        {
          logger.Error("Source directory not found: {source}", source);
          throw new DirectoryNotFoundException(source);
        }
        if (!Path.Exists(destination))
        {
          logger.Error("Destination directory not found: {destination}", destination);
          throw new DirectoryNotFoundException(destination);
        }

        this.Source = new DirectoryInfo(source);
        this.Destination = new DirectoryInfo(destination);
        this.copyMode = copyMode;
        
        logger.Info("FileCopy initialized - Source: {source}, Destination: {destination}", source, destination);
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error initializing FileCopy");
        throw;
      }
    }

    #endregion
  }
}
