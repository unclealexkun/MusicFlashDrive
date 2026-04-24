namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Копирование файлов.
  /// </summary>
  public interface IFileCopy
  {
    /// <summary>
    /// Выполнить.
    /// </summary>
    /// <param name="progress">Информация о прогрессе копирования.</param>
    /// <param name="token">Токен отмены операции.</param>
    /// <returns>Возращаем Task для параллельной обработки.</returns>
    public Task Execute(IProgress<CopyProgressInfo> progress, CancellationToken token = default);
  }
}
