using TagLib;

namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Режим артист.
	/// </summary>
	public class ArtistCopyMode : ICopyMode
	{
		#region ICopyMode

		public string DestinationFolder { get; set; }

		public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
		{
			var artist = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).FirstAlbumArtist ?? "unknown");
			var title = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Title ?? "unknown");
			this.DestinationFolder = Path.Combine(destinationFolder.FullName, artist);
			return this.DestinationFolder + $"\\{title}{sourceFile.Extension}";
		}

		#endregion
	}
}
