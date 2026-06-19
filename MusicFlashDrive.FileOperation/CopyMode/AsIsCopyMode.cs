namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Режим как есть.
  /// </summary>
  public class AsIsCopyMode : ICopyMode
  {
    #region ICopyMode

    public string GeneratePathDestinationFile(DirectoryInfo sourceFolder, FileInfo sourceFile, DirectoryInfo destinationFolder)
    {
      var result = Path.Combine(destinationFolder.FullName, sourceFile.FullName.Replace(sourceFolder.FullName + "\\", string.Empty));
      if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
        throw new InvalidOperationException(nameof(result));
      else
        return result;
    }

    #endregion
  }
}
