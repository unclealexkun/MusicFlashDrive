namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Простой режим копирования.
	/// </summary>
	public class SimpleCopyMode : ICopyMode
	{
		#region ICopyMode

		public string DestinationFolder { get; set; }

		public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
		{
			this.DestinationFolder = destinationFolder.FullName;
			return this.DestinationFolder + sourceFile.Name;
		}

		#endregion
	}
}
