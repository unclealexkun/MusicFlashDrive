using MusicFlashDrive.FileSync.File;
using MusicFlashDrive.FileSync.Storage;

namespace MusicFlashDrive.FileSync
{
	/// <summary>
	/// Синхронизатор файлов.
	/// </summary>
	public class FileSynchronization: IFileSynchronization
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

		#endregion

		#region IFileSynchronization

		public void Execute()
		{
			foreach (var fileEntity in FilesFolder.Instance.GetList())
			{
				Console.WriteLine(fileEntity.Name);
				Console.WriteLine(fileEntity.Hash);
				Console.WriteLine(fileEntity.Length);
				Console.WriteLine(fileEntity.FullName);
				Console.WriteLine("================================");

				var destinationPath = Path.Combine(this.destination, "Ку-ку");
				if (!Directory.Exists(destinationPath))
					Directory.CreateDirectory(destinationPath);
				var file = Path.Combine(destinationPath, fileEntity.Name);
				if (System.IO.File.Exists(file))
					continue;
				fileEntity.FileInfo.MoveTo(file);
			}
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

		/// <summary>
		/// Инициализация файлового хранилища.
		/// </summary>
		private void InitFileStore()
		{
			var files = Directory.GetFiles(this.source, "*.mp3", SearchOption.AllDirectories);
			foreach (var file in files)
			{
				FilesFolder.Instance.Add(new FileEntity()
				{
					FileInfo = new FileInfo(file)
				});
			}
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="source">Источник файлов.</param>
		/// <param name="destination">Целевое место для файлов.</param>
		public FileSynchronization(string source, string destination)
		{
			this.source = source;
			this.destination = destination;
			this.Validator();
			this.InitFileStore();
		}

		#endregion
	}
}
