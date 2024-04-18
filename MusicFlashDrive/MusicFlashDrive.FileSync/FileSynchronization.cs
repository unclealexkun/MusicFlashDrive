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
		public FileSynchronization(string source, string destination)
		{
			this.source = source;
			this.destination = destination;
			Validator();
		}

		#endregion
	}
}
