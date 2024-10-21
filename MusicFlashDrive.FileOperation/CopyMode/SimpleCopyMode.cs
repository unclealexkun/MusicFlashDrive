namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Простой режим копирования.
	/// </summary>
	public class SimpleCopyMode : ICopyMode
	{
		#region Поля и свойства

		/// <summary>
		/// Целевая папка.
		/// </summary>
		public string DestinationFolder { get; private set; }

		#endregion

		#region ICopyMode

		public string GeneratePathDestinationFile(string sourceFile, string destinationFolder)
		{
			this.DestinationFolder = destinationFolder;
			return destinationFolder + sourceFile;
		}

		#endregion
	}
}
