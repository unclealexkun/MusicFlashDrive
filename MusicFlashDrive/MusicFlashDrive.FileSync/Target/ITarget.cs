namespace MusicFlashDrive.FileSync
{
	/// <summary>
	/// Целевое расположение.
	/// </summary>
	public interface ITarget
	{
		/// <summary>
		/// Перенос.
		/// </summary>
		/// <returns>Результат переноса.</returns>
		bool Transfer();
	}
}
