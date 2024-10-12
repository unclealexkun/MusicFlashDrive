
namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Копирование файлов.
	/// </summary>
	public class FileCopy : IFileCopy
	{
		#region Константы

		/// <summary>
		/// Фрагмент.
		/// </summary>
		private readonly int ChunkSize = 5;

		#endregion

		#region Поля и свойства

		/// <summary>
		/// Директория источник.
		/// </summary>
		public DirectoryInfo Source { get; private set; }
		/// <summary>
		/// Целевая директория.
		/// </summary>
		public DirectoryInfo Destination { get; private set; }
		/// <summary>
		/// Объект-заглушка.
		/// </summary>
		private object locked;

		#endregion

		#region IFileCopy

		public void Execute()
		{
			var files = Source.GetFiles("*.mp3", SearchOption.AllDirectories);
			var steps = (int)Math.Round((double)files.Length / ChunkSize, MidpointRounding.ToPositiveInfinity);

			for (int step = 0; step < steps; ++step)
			{
				var processedFiles = files.Skip(step * ChunkSize).Take(ChunkSize);
				Thread thread = new(() => Coping(processedFiles));
				thread.IsBackground = true;
				thread.Start();
			}
		}
		#endregion

		#region Методы

		/// <summary>
		/// Копирование файлов.
		/// </summary>
		/// <param name="files">Копируемые файлы.</param>
		private void Coping(IEnumerable<FileInfo> files)
		{
			lock (locked)
			{
				foreach (var file in files)
				{
					file.CopyTo(Destination.FullName + file.Name);
				}
			}
		}

		#endregion

		#region Конструктор

		public FileCopy(string source, string destination) 
		{
			if (!Path.Exists(source))
				throw new DirectoryNotFoundException(source);
			if (!Path.Exists(destination))
				throw new DirectoryNotFoundException(destination);

			this.Source = new DirectoryInfo(source);
			this.Destination = new DirectoryInfo(destination);
			this.locked = new();
		}

		#endregion
	}
}
