using MusicFlashDrive.FileSync;

namespace MusicFlashDrive
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Hello, {Environment.UserName}!");

			var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);

			if (!drives.Any())
			{
				Console.WriteLine("No removable media.");
			}
			else
			{
				var source = @"E:\\Музыка с флешки\\Temp\\ВК (Оля Усимова)\\";
				var destination = drives.First().Name;

				Console.WriteLine($"Source: {source}");
				Console.WriteLine($"Destination: {destination}");

				Console.WriteLine("Start synchronization...");

				var fileOperation = new FileOperations(new FileSynchronization(new FlashDrive(source, destination)));
				fileOperation.Run();

				Console.WriteLine("Synchronization completed.");
			}			

			Console.ReadKey();
		}
	}
}
