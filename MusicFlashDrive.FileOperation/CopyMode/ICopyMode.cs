namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Режим копирования.
	/// </summary>
	public interface ICopyMode
	{
		/// <summary>
		/// Целевой каталог.
		/// </summary>
		public string DestinationFolder { get; set; }

		/// <summary>
		/// Сформировать путь сохранения целевого файла.
		/// </summary>
		/// <param name="sourceFile">Файл источник.</param>
		/// <param name="destinationFolder">Папка для целевых файлов.</param>
		/// <returns></returns>
		string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder);
	}
}
