using TagLib;

namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Режим артист.
  /// </summary>
  public class ArtistCopyMode : ICopyMode
  {
    #region ICopyMode

    public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
    {
      var artist = string.Empty;
      var title = string.Empty;

      using (var tagFile = TagLib.File.Create(sourceFile.FullName))
      {
        var tag = tagFile.GetTag(TagTypes.Id3v2);
        artist = PathCorrector.RemoveIllegalCharInPath(tag.FirstAlbumArtist ?? "unknown");
        title = PathCorrector.RemoveIllegalCharInPath(tag.Title ?? "unknown");
      }

      var result = Path.Combine(destinationFolder.FullName, artist, $"{title}{sourceFile.Extension}");
      if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
        throw new InvalidOperationException(nameof(result));
      else
        return result;
    }

    #endregion
  }
}
