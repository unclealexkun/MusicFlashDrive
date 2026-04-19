namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Прогресс копирования.
  /// </summary>
  public class CopyProgressInfo
  {
    /// <summary>
    /// Прогресс.
    /// </summary>

    public int Progress { get; set; }

    /// <summary>
    /// Значение.
    /// </summary>
    public required string Value { get; set; }
  }
}
