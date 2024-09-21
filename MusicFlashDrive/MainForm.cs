namespace MusicFlashDrive
{
	public partial class MainForm : Form
	{
		#region Методы
		public void buttonPathSource_Click(object sender, EventArgs e)
		{
			var openFileDialog = new FolderBrowserDialog();
			var result = openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(result.ToString()))
			{
				textBoxPathSource.Text = openFileDialog.SelectedPath;
				Properties.Settings.Default.LastPath = openFileDialog.SelectedPath;
				Properties.Settings.Default.Save();
			}
		}

		public void buttonCopyFile_Click(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region Конструктор
		public MainForm()
		{
			InitializeComponent();
			labelHello.Text = $"Hello, {Environment.UserName}!";
			var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
			if (drives.Any())
				comboBoxDrive.Items.AddRange(drives.Select(drive => drive.Name).ToArray());
			if (!string.IsNullOrEmpty(Properties.Settings.Default.LastPath))
				textBoxPathSource.Text = Properties.Settings.Default.LastPath;
		}
		#endregion
	}
}
