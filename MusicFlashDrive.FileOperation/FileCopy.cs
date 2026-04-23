using System.Security.Cryptography;

namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Копирование файлов.
  /// </summary>
  public class FileCopy : IFileCopy
  {
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
    /// <summary>
    /// Семафор для асинхронного копирования.
    /// </summary>
    private static readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    #endregion

    #region IFileCopy

    public void Execute(IProgress<CopyProgressInfo> progress, CancellationToken token = default)
    {
      var files = Source.GetFiles(SearchPattern, SearchOption.AllDirectories);
      var steps = (int)Math.Round((double)files.Length / ChunkSize, MidpointRounding.ToPositiveInfinity);

      int processedFilesCount = 0;
      for (int step = 0; step < steps; ++step)
      {
        var processedFiles = files.Skip(step * ChunkSize).Take(ChunkSize);
        Task.Factory.StartNew(() => CopingAsync(processedFiles, token)).Wait(token);

        processedFilesCount += processedFiles.Count();
        var copyProgressInfo = new CopyProgressInfo()
        {
          Value = $"Обработано {processedFilesCount} из {files.Length} файлов",
          Progress = (int)Math.Round((double)(processedFilesCount * 100 / files.Length))
        };
        progress.Report(copyProgressInfo);
      }
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
      await semaphoreSlim.WaitAsync(token);
      try
      {
        foreach (var file in files)
        {
          var destinationFileName = this.copyMode.GeneratePathDestinationFile(file, this.Destination);
          if (File.Exists(destinationFileName))
            if (HashComparison.Compare(file.FullName, destinationFileName))
              continue;

          var destinationDirectoryName = Path.GetDirectoryName(destinationFileName);
          if (!Directory.Exists(destinationDirectoryName) && !string.IsNullOrEmpty(destinationDirectoryName))
            Directory.CreateDirectory(destinationDirectoryName);

          int bufferSize = 8192;
          token.ThrowIfCancellationRequested();
          using (var sourceStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
          {
            using (var destinationStream = new FileStream(destinationFileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, useAsync: true))
            {
              await sourceStream.CopyToAsync(destinationStream, bufferSize, token);
            }
          }
        }
      }
      finally
      {
        semaphoreSlim.Release();
      }
    }

    #endregion

    #region Конструктор

    public FileCopy(string source, string destination, ICopyMode copyMode)
    {
      if (!Path.Exists(source))
        throw new DirectoryNotFoundException(source);
      if (!Path.Exists(destination))
        throw new DirectoryNotFoundException(destination);

      this.Source = new DirectoryInfo(source);
      this.Destination = new DirectoryInfo(destination);
      this.copyMode = copyMode;
    }

    #endregion
  }
}
