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
      var artist = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).FirstAlbumArtist ?? "unknown");
      var album = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Album ?? "unknown");
      var title = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Title ?? "unknown");
      var track = TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Track;

      var result = Path.Combine(destinationFolder.FullName, artist, album, $"{track:d3}-{title}{sourceFile.Extension}");
      if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
        throw new NullReferenceException(nameof(result));
      else
        return result;
    }

    #endregion
  }
}
