using System.Security.Cryptography;

namespace MusicFlashDrive.FileSync.File
{
	/// <summary>
	/// Сущность файла.
	/// </summary>
	internal class FileEntity
	{
		/// <summary>
		///  Хэш.
		/// </summary>
		public string Hash => Convert.ToHexString(SHA1.HashData(System.IO.File.ReadAllBytes(FileInfo.FullName))).ToLowerInvariant();

		/// <summary>
		/// Название.
		/// </summary>
		public string Name => FileInfo.Name;

		/// <summary>
		/// Полное название.
		/// </summary>
		public string FullName => FileInfo.FullName;

		/// <summary>
		/// Размер.
		/// </summary>
		public string Length => BytesToString(FileInfo.Length);

		/// <summary>
		/// Информация о файле.
		/// </summary>
		public required FileInfo FileInfo { get; set; }

		/// <summary>
		/// Вывод данных о размере.
		/// </summary>
		/// <param name="byteCount">Размер файла.</param>
		/// <returns>Информация о рзмере.</returns>
		static string BytesToString(long byteCount)
		{
			string[] suf = { "Byt", "KB", "MB", "GB", "TB", "PB", "EB" };
			if (byteCount == 0)
				return "0" + suf[0];
			var bytes = Math.Abs(byteCount);
			var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			var number = Math.Round(bytes / Math.Pow(1024, place), 1);
			return (Math.Sign(byteCount) * number).ToString() + " " + suf[place];
		}
	}
}
