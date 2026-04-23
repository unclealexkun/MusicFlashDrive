using System.Security.Cryptography;

namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Сравнение хешей.
  /// </summary>
  internal class HashComparison
  {
    /// <summary>
    /// Сравнить.
    /// </summary>
    /// <param name="filePathA">Путь до файла А.</param>
    /// <param name="filePathB">Путь до файла B.</param>
    /// <returns>True - если хеши эквивалентны, иначе - False.</returns>
    public static bool Compare(string filePathA, string filePathB)
    {
      var fileAInfo = new FileInfo(filePathA);
      var fileBInfo = new FileInfo(filePathB);

      if (fileAInfo.Length != fileBInfo.Length || fileAInfo.LastWriteTime != fileBInfo.LastWriteTime)
        return false;

      using (var sha256 = SHA256.Create())
      {
        using (var streamFileA = File.OpenRead(filePathA))
        {
          using (var streamFileB = File.OpenRead(filePathB))
          {
            var hashFileA = sha256.ComputeHash(streamFileA);
            var hashFileB = sha256.ComputeHash(streamFileB);

            return CryptographicOperations.FixedTimeEquals(hashFileA, hashFileB);
          }
        }
      }
    }
  }
}
