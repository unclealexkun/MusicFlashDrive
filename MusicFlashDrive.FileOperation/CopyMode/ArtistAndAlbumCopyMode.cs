using TagLib;

namespace MusicFlashDrive.FileOperation
{
  /// <summary>
  /// Режим артист и альбом.
  /// </summary>
  public class ArtistAndAlbumCopyMode : ICopyMode
  {
    #region ICopyMode

    public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
    {
      var artist = string.Empty;
      var album = string.Empty;
      var title = string.Empty;
      var track = 0u;

      using (var tagFile = TagLib.File.Create(sourceFile.FullName))
      {
        var tag = tagFile.GetTag(TagTypes.Id3v2);
        artist = PathCorrector.RemoveIllegalCharInPath(tag.FirstAlbumArtist ?? "unknown");
        album = PathCorrector.RemoveIllegalCharInPath(tag.Album ?? "unknown");
        title = PathCorrector.RemoveIllegalCharInPath(tag.Title ?? "unknown");
        track = tag.Track;
      }

      var result = Path.Combine(destinationFolder.FullName, artist, album, $"{track:d3}-{title}{sourceFile.Extension}");
      if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
        throw new NullReferenceException(nameof(result));
      else
        return result;
    }

    #endregion
  }
}
