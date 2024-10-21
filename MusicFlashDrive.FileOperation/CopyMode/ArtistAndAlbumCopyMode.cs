using TagLib;

namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Режим артист и альбом.
	/// </summary>
	public class ArtistAndAlbumCopyMode : ICopyMode
	{
		#region ICopyMode

		public string DestinationFolder { get; set; }

		public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
		{
			var artist = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).FirstAlbumArtist ?? "unknown");
			var album = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Album ?? "unknown");
			var title = PathCorrector.RemoveIllegalCharInPath(TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Title ?? "unknown");
			var track = TagLib.File.Create(sourceFile.FullName).GetTag(TagTypes.Id3v2).Track;
			this.DestinationFolder = Path.Combine(destinationFolder.FullName, artist, album);
			return this.DestinationFolder + $"\\{track:d3}-{title}{sourceFile.Extension}";
		}

		#endregion
	}
}
