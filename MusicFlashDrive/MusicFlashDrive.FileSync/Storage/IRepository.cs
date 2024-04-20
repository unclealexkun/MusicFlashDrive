namespace MusicFlashDrive.FileSync.Storage
{
	/// <summary>
	/// Репозиторий.
	/// </summary>
	/// <typeparam name="T">Сущность.</typeparam>
	internal interface IRepository<T> where T : class
	{
		#region Методы

		/// <summary>
		/// Получение всех объектов.
		/// </summary>
		/// <returns>Требуемые объекты.</returns>
		IEnumerable<T> GetList();

		/// <summary>
		/// Получение одного объекта по хэш.
		/// </summary>
		/// <param name="hash">Хэш объекта.</param>
		/// <returns></returns>
		T Get(string hash);

		/// <summary>
		/// Создание объекта.
		/// </summary>
		/// <param name="item">Объект.</param>
		void Add(T item);

		/// <summary>
		/// Обновление объекта.
		/// </summary>
		/// <param name="item">Объект.</param>
		void AddOrUpdate(T item);

		/// <summary>
		/// Удаление объекта по хэш.
		/// </summary>
		/// <param name="hash">Хэш объекта.</param>
		void Delete(string hash);

		#endregion
	}
}
