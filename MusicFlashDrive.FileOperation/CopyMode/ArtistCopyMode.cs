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
            var artist = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).FirstAlbumArtist ?? "unknown");
            var title = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Title ?? "unknown");
			
			var result = Path.Combine(destinationFolder.FullName, artist, $"{title}{sourceFile.Extension}");
            if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                throw new NullReferenceException(nameof(result));
            else
                return result;
        }

		#endregion
	}
}
