using MusicFlashDrive.FileSync.File;

namespace MusicFlashDrive.FileSync.Storage
{
	/// <summary>
	/// Локальное хранилище целевой папки с файлами.
	/// </summary>
	internal class FilesFolder : IRepository<FileEntity>
	{
		#region Константы

		/// <summary>
		/// Экземпляр локального хранилища.
		/// </summary>
		private static readonly Lazy<FilesFolder> instance = new(() => new FilesFolder());

		#endregion

		#region Поля

		/// <summary>
		/// Целевое место для файлов.
		/// </summary>
		private static ConcurrentList<FileEntity> files;

		#endregion

		#region Свойства

		/// <summary>
		/// Экземпляр локального хранилища.
		/// </summary>
		public static FilesFolder Instance { get { return instance.Value; } }

		#endregion

		#region IRepository

		public void Add(FileEntity item)
		{
			files.Add(item);
		}

		public void Delete(string hash)
		{
			var file = files.FirstOrDefault(f => f.Hash == hash);
			if (file != null)
				files.Remove(file);
		}

		public FileEntity? Get(string hash)
		{
			return files.FirstOrDefault(f => f.Hash == hash);
		}

		public IEnumerable<FileEntity> GetList()
		{
			return files.AsEnumerable<FileEntity>();
		}

		public void AddOrUpdate(FileEntity item)
		{
			var file = files.FirstOrDefault(f => f.Hash == item.Hash);
			if (file == null)
			{
				files.Add(item);
				return;
			}
			file.FileInfo = item.FileInfo;
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Инициализация локального хранилища.
		/// </summary>
		private FilesFolder()
		{
			if (files == null)
			{
				files = new ConcurrentList<FileEntity>();
			}
		}

		#endregion
	}
}
