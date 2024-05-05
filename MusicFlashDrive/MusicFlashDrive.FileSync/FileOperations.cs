using MusicFlashDrive.FileSync;

namespace MusicFlashDrive
{
	/// <summary>
	/// Файловые операции.
	/// </summary>
	public class FileOperations
	{
		#region Поля и свойства

		/// <summary>
		/// Файловая операция.
		/// </summary>
		private IFileOperations fileOperations;

		#endregion

		#region Методы

		/// <summary>
		/// Запуск операции.
		/// </summary>
		public void Run()
		{
			this.fileOperations.Execute();
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="fileOperations">Файловая операция.</param>
		public FileOperations(IFileOperations fileOperations)
		{
			this.fileOperations = fileOperations;
		}

		#endregion
	}
}
