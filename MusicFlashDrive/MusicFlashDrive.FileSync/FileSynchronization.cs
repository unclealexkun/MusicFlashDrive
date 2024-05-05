namespace MusicFlashDrive.FileSync
{
	/// <summary>
	/// Синхронизатор файлов.
	/// </summary>
	public class FileSynchronization: IFileOperations
	{
		#region Поля и свойства

		/// <summary>
		/// Целевое хранилище.
		/// </summary>
		private ITarget target;

		#endregion

		#region IFileSynchronization

		public void Execute()
		{
			if (!this.target.Transfer())
				throw new OperationCanceledException();
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="target">Целевое расположение.</param>
		public FileSynchronization(ITarget target)
		{
			this.target = target;
		}

		#endregion
	}
}
