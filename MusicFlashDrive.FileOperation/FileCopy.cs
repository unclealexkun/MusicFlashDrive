using System.Security.Cryptography;

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
		/// <summary>
		/// Поисковый паттерн.
		/// </summary>
		private readonly string SearchPattern = "*.mp3";

		#endregion

		#region Поля и свойства

		/// <summary>
		/// Режим копирования.
		/// </summary>
		private ICopyMode copyMode;
		/// <summary>
		/// Директория источник.
		/// </summary>
		public DirectoryInfo Source { get; private set; }
		/// <summary>
		/// Целевая директория.
		/// </summary>
		public DirectoryInfo Destination { get; private set; }
		/// <summary>
		/// Статус копирования.
		/// </summary>
		public CopyState CopyState { get; private set; }
		/// <summary>
		/// Семафор.
		/// </summary>
		private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

		#endregion

		#region IFileCopy

		public void Execute()
		{
			var files = Source.GetFiles(SearchPattern, SearchOption.AllDirectories);
			var steps = (int)Math.Round((double)files.Length / ChunkSize, MidpointRounding.ToPositiveInfinity);

			for (int step = 0; step < steps; ++step)
			{
				var processedFiles = files.Skip(step * ChunkSize).Take(ChunkSize);
				Thread thread = new(() => CopingAsync(processedFiles));
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
		private async void CopingAsync(IEnumerable<FileInfo> files)
		{
			await semaphoreSlim.WaitAsync();
			try
			{
				foreach (var file in files)
				{
					var destinationFileName = this.copyMode.GeneratePathDestinationFile(file, this.Destination);

					if (File.Exists(destinationFileName))
						if (HashComparison.Compare(SHA256.HashData(File.ReadAllBytes(file.FullName)), SHA256.HashData(File.ReadAllBytes(destinationFileName))))
							continue;

					if (!Directory.Exists(this.copyMode.DestinationFolder))
						Directory.CreateDirectory(this.copyMode.DestinationFolder);

					using (var sourceStream = File.Open(file.FullName, FileMode.Open))
					{
						using (var destinationStream = File.Create(destinationFileName))
						{
							await sourceStream.CopyToAsync(destinationStream);
						}
					}
				}
			}
			finally
			{
				semaphoreSlim.Release();
			}
		}

		#endregion

		#region Конструктор

		public FileCopy(string source, string destination, ICopyMode copyMode) 
		{
			if (!Path.Exists(source))
				throw new DirectoryNotFoundException(source);
			if (!Path.Exists(destination))
				throw new DirectoryNotFoundException(destination);

			this.Source = new DirectoryInfo(source);
			this.Destination = new DirectoryInfo(destination);
			this.copyMode = copyMode;
		}

		#endregion
	}
}
