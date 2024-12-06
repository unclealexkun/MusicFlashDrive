namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Сравнение хешей.
	/// </summary>
	internal class HashComparison
	{
		/// <summary>
		/// Сравнить.
		/// </summary>
		/// <param name="hashA">Хеш А.</param>
		/// <param name="hashB">Хеш B.</param>
		/// <returns>True - если хеши эквивалентны, иначе - False.</returns>
		public static bool Compare(byte[] hashA, byte[] hashB)
		{
			var result = false;

			if (hashA.Length == hashB.Length)
			{
				result = true;
				for (var index = 0; index < hashA.Length; index++)
					if (hashA[index] != hashB[index])
					{
						result = false;
						break;
					}
			}

			return result;
		}
	}
}
