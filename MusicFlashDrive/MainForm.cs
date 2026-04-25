using MusicFlashDrive.FileOperation;

namespace MusicFlashDrive
{
  public partial class MainForm : Form
  {
    #region Свойства

    /// <summary>
    /// Выбранный внешний носитель.
    /// </summary>
    private DriveInfo drive { get; set; }

    #endregion

    #region Методы
    public void buttonPathSource_Click(object sender, EventArgs e)
    {
      var openFileDialog = new FolderBrowserDialog();
      var result = openFileDialog.ShowDialog();
      if (!string.IsNullOrEmpty(result.ToString()))
      {
        textBoxPathSource.Text = openFileDialog.SelectedPath;
        Properties.Settings.Default.LastPathCopy = openFileDialog.SelectedPath;
        Properties.Settings.Default.Save();
      }
    }

    public async void buttonCopyFile_Click(object sender, EventArgs e)
    {
      try
      {
        buttonCopyFile.Enabled = false;

        var progress = new Progress<CopyProgressInfo>(status => {
          toolStripStatusLabel.Text = status.Value;
          toolStripProgressBar.Value = status.Progress;
          toolStripProgressBar.ProgressBar.Refresh();

          StatusFillDrive();
        });

        var fileCopy = new FileCopy(textBoxPathSource.Text, $"{comboBoxDrive.SelectedItem}", new ArtistAndAlbumCopyMode());
        await fileCopy.Execute(progress);
      }
      finally
      {
        buttonCopyFile.Enabled = true;
      }
    }

    private void comboBoxDrive_SelectedIndexChanged(object sender, EventArgs e)
    {
      drive = DriveInfo.GetDrives().Where(drive => drive.IsReady
          && drive.DriveType == DriveType.Removable && drive.Name == $"{comboBoxDrive.SelectedItem}")
          .First();
      StatusFillDrive();
    }

    /// <summary>
    /// Состояние заполненности внешнего носителя.
    /// </summary>
    private void StatusFillDrive()
    {
      progressBarFillDrive.Value = (int)Math.Round((double)((drive.TotalSize - drive.TotalFreeSpace) * 100 / drive.TotalSize));
      labelFillDrive.Text = $"{BytesToString(drive.TotalSize - drive.TotalFreeSpace)} / {BytesToString(drive.TotalSize)}";
      progressBarFillDrive.Refresh();
    }

    /// <summary>
    /// Вывод данных о размере.
    /// </summary>
    /// <param name="byteCount">Размер файла.</param>
    /// <returns>Информация о рзмере.</returns>
    private static string BytesToString(long byteCount)
    {
      string[] suf = { "Byt", "KB", "MB", "GB", "TB", "PB", "EB" };
      if (byteCount == 0)
        return "0" + suf[0];
      var bytes = Math.Abs(byteCount);
      var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
      var number = Math.Round(bytes / Math.Pow(1024, place), 1);
      return (Math.Sign(byteCount) * number).ToString() + " " + suf[place];
    }
    #endregion

    #region Конструктор
    public MainForm()
    {
      InitializeComponent();
      toolStripStatusLabel.Text = string.Empty;
      labelHello.Text = $"Hello, {Environment.UserName}!";

      var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
      if (drives.Any())
      {
        comboBoxDrive.Items.AddRange(drives.Select(drive => drive.Name).ToArray());
        comboBoxDrive.SelectedIndex = 0;
      }  

      if (!string.IsNullOrEmpty(Properties.Settings.Default.LastPathCopy))
        textBoxPathSource.Text = Properties.Settings.Default.LastPathCopy;
    }
    #endregion
  }
}
