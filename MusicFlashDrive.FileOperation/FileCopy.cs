
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
		private readonly string searchPattern = "*.mp3";

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
		/// Семафор.
		/// </summary>
		private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

		#endregion

		#region IFileCopy

		public void Execute()
		{
			var files = Source.GetFiles(searchPattern, SearchOption.AllDirectories);
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
					if (File.Exists(Destination.FullName + file.Name))
					{
						var sourceFile = Convert.ToHexString(SHA1.HashData(File.ReadAllBytes(file.FullName))).ToLowerInvariant();
						var destinationFile = Convert.ToHexString(SHA1.HashData(File.ReadAllBytes(Destination.FullName + file.Name))).ToLowerInvariant();
						if (sourceFile == destinationFile)
							continue;
					}

					using (var sourceStream = File.Open(file.FullName, FileMode.Open))
					{
						using (var destinationStream = File.Create(Destination.FullName + file.Name))
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

		public FileCopy(string source, string destination) 
		{
			if (!Path.Exists(source))
				throw new DirectoryNotFoundException(source);
			if (!Path.Exists(destination))
				throw new DirectoryNotFoundException(destination);

			this.Source = new DirectoryInfo(source);
			this.Destination = new DirectoryInfo(destination);
		}

		#endregion
	}
}
