using System.Text.RegularExpressions;

namespace MusicFlashDrive.FileSync
{
	/// <summary>
	/// Источник съёмный накопитель.
	/// </summary>
	public class FlashDrive: ITarget
	{
		#region Поля и свойства

		/// <summary>
		/// Источник файлов.
		/// </summary>
		private readonly string source;

		/// <summary>
		/// Целевое место для файлов.
		/// </summary>
		private readonly string destination;

		/// <summary>
		/// Некорректные символы в пути.
		/// </summary>
		private readonly string illegalChar = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

		#endregion

		#region ITarget

		public bool Transfer()
		{
			var regex = new Regex(string.Format("[{0}]", Regex.Escape(this.illegalChar)));
			var files = Directory.GetFiles(this.source, "*.mp3", SearchOption.AllDirectories);

			var tasks = new List<Task>();

      foreach (var file in files)
      {
				var entity = new FileEntity()
				{
					FileInfo = new FileInfo(file)
				};

				tasks.Add(new Task(() =>
				{
					var destinationPath = Path.Combine(this.destination, 
						regex.Replace(entity.Tag.JoinedAlbumArtists ?? "Неизвестный", string.Empty), 
						regex.Replace(entity.Tag.Album ?? "Неизвестный", string.Empty));
					if (!Directory.Exists(destinationPath))
						Directory.CreateDirectory(destinationPath);

					var filePath = Path.Combine(destinationPath, $"{entity.Tag.TrackCount} - {entity.Name}");
					if (!File.Exists(filePath))
						entity.FileInfo.CopyTo(filePath);
				}));
      }

			foreach(var task in tasks)
				task.Start();

			Task.WaitAll(tasks.ToArray());

			return tasks.All(task => task.IsCompletedSuccessfully);
		}

		#endregion

		#region Методы

		/// <summary>
		/// Валидация директорий.
		/// </summary>
		/// <exception cref="ArgumentException">Target directory does not exist.</exception>
		private void Validator()
		{
			if (!Directory.Exists(this.source))
				throw new ArgumentException("Source directory does not exist.");
			if (!Directory.Exists(this.destination))
				throw new ArgumentException("Destination directory does not exist.");
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="source">Источник файлов.</param>
		/// <param name="destination">Целевое место для файлов.</param>
		public FlashDrive(string source, string destination)
		{
			this.source = source;
			this.destination = destination;
			this.Validator();
		}

		#endregion
	}
}
