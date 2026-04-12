using System.Xml.Linq;

namespace MusicFlashDrive.FileOperation
{
    /// <summary>
    /// Простой режим копирования.
    /// </summary>
    public class SimpleCopyMode : ICopyMode
    {
        #region ICopyMode

        public string GeneratePathDestinationFile(FileInfo sourceFile, DirectoryInfo destinationFolder)
        {
            var result = Path.Combine(destinationFolder.FullName, sourceFile.Name);
            if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                throw new NullReferenceException(nameof(result));
            else
                return result;
        }

        #endregion
    }
}
