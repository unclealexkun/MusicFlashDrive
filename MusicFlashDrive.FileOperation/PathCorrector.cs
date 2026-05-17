using System.Text;

namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Корректировка путей.
  /// </summary>
  internal class PathCorrector
  {
    // Кэшируем недопустимые символы для производительности.
    private static readonly char[] InvalidChars = Path.GetInvalidFileNameChars();

    /// <summary>
    /// Удаляет некорректные символы из пути (имени файла или папки).
    /// </summary>
    /// <param name="path">Путь, который нужно откорректировать.</param>
    /// <returns>Путь с исправлениями.</returns>
    public static string RemoveIllegalCharInPath(string path)
    {
      if (string.IsNullOrEmpty(path))
        return path;

      var result = new StringBuilder(path.Length);

      foreach (char c in path)
      {
        if (Array.IndexOf(InvalidChars, c) == -1)
        {
          result.Append(c);
        }
      }

      return result.ToString();
    }
  }
}