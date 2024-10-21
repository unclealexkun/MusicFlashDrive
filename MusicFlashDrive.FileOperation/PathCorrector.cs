using System.Text.RegularExpressions;

namespace MusicFlashDrive.FileOperation
{
	/// <summary>
	/// Корректоривка путей.
	/// </summary>
	internal class PathCorrector
	{
		/// <summary>
		/// Удалять некорректные символы из пути.
		/// </summary>
		/// <param name="path">Путь, который нужно откоректировать.</param>
		/// <returns>Путь с исправлениями.</returns>
		public static string RemoveIllegalCharInPath(string path)
		{
			Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
			return illegalInFileName.Replace(path, string.Empty);
		}
	}
}
