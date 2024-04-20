using System.Collections;

namespace MusicFlashDrive.FileSync.Storage
{
	/// <summary>
	/// Потокобезопасный список.
	/// </summary>
	/// <typeparam name="T">Содержимое списка.</typeparam>
	internal class ConcurrentList<T> : IEnumerable<T>, ICollection<T>
	{
		#region Поля и Свойства

		/// <summary>
		/// Коллекция объектов.
		/// </summary>
		private readonly List<T> list;

		/// <summary>
		/// Блокировка.
		/// </summary>
		private readonly ReaderWriterLockSlim _lock;

		#endregion

		#region IEnumerable

		public IEnumerator<T> GetEnumerator() => Enumerate().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => Enumerate().GetEnumerator();

		#endregion

		#region ICollection

		public int Count
		{
			get
			{
				try
				{
					this._lock.EnterReadLock();
					return this.list.Count;
				}
				finally
				{
					this._lock.ExitReadLock();
				}
			}
		}

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			try
			{
				this._lock.EnterWriteLock();
				this.list.Add(item);
			}
			finally
			{
				this._lock.ExitWriteLock();
			}
		}

		public void Clear()
		{
			try
			{
				this._lock.EnterWriteLock();
				this.list.Clear();
			}
			finally
			{
				this._lock.ExitWriteLock();
			}
		}

		public bool Contains(T item)
		{
			try
			{
				this._lock.EnterReadLock();
				return this.list.Contains(item);
			}
			finally
			{
				this._lock.ExitReadLock();
			}
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				this._lock.EnterReadLock();
				this.list.CopyTo(array, arrayIndex);
			}
			finally
			{
				this._lock.ExitReadLock();
			}
		}

		public bool Remove(T item)
		{
			try
			{
				this._lock.EnterWriteLock();
				return this.list.Remove(item);
			}
			finally
			{
				this._lock.ExitWriteLock();
			}
		}

		#endregion

		#region Методы

		/// <summary>
		/// Перечесление.
		/// </summary>
		/// <returns>Коллекция объектов.</returns>
		private IEnumerable<T> Enumerate()
		{
			try
			{
				this._lock.EnterReadLock();
				foreach (T item in this.list)
					yield return item;
			}
			finally
			{
				this._lock.ExitReadLock();
			}
		}

		#endregion

		#region Конструтор

		/// <summary>
		/// Конструктор потокобезопасного списка.
		/// </summary>
		public ConcurrentList() : this(null) { }

		/// <summary>
		/// Конструктор потокобезопасного списка.
		/// </summary>
		/// <param name="items">Коллекция объектов.</param>
		public ConcurrentList(IEnumerable<T> items)
		{
			this.list = items is null ? new List<T>() : new List<T>(items);
			this._lock = new ReaderWriterLockSlim();
		}

		#endregion
	}
}
