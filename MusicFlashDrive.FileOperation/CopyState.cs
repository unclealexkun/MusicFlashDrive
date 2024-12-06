namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Состояние копирования.
	/// </summary>
	public enum CopyState
	{
		/// <summary>
		/// Ошибка.
		/// </summary>
		Error = -1,
		/// <summary>
		/// Без статуса.
		/// </summary>
		None = 0,
		/// <summary>
		/// Выполняется.
		/// </summary>
		Execution = 1,
		/// <summary>
		/// Завершена.
		/// </summary>
		Completed = 2
	}
}
