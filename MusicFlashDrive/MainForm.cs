using MusicFlashDrive.FileOperation;
using NLog;

namespace MusicFlashDrive
{
  public partial class MainForm : Form
  {
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    
    #region Поля и Свойства
    /// <summary>
    /// Токен отмены.
    /// </summary>
    private CancellationTokenSource cancellationToken = new();
    /// <summary>
    /// Выбранный внешний носитель.
    /// </summary>
    private DriveInfo Drive { get; set; }
    /// <summary>
    /// Выбранный режим копирования.
    /// </summary>
    private ICopyMode CopyMode => comboBoxCopyMode.SelectedItem switch
    {
      "Артист и Альбом" => new ArtistAndAlbumCopyMode(),
      "Артист" => new ArtistCopyMode(),
      "Простой режим" => new SimpleCopyMode(),
      _ => new AsIsCopyMode()
    };
    #endregion

    #region Методы
    public void buttonPathSource_Click(object sender, EventArgs e)
    {
      try
      {
        var openFileDialog = new FolderBrowserDialog();
        var result = openFileDialog.ShowDialog();
        if (!string.IsNullOrEmpty(result.ToString()))
        {
          textBoxPathSource.Text = openFileDialog.SelectedPath;
          Properties.Settings.Default.LastPathCopy = openFileDialog.SelectedPath;
          Properties.Settings.Default.Save();
          logger.Info("Source path selected: {path}", openFileDialog.SelectedPath);
        }
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error selecting source path");
        throw;
      }
    }

    public async void buttonCopyFile_Click(object sender, EventArgs e)
    {
      try
      {
        logger.Info("Starting file copy operation");
        
        buttonCopyFile.Enabled = false;
        buttonCancel.Enabled = true;

        using (cancellationToken = new CancellationTokenSource())
        {
          var progress = new Progress<CopyProgressInfo>(status =>
          {
            toolStripStatusLabel.Text = status.Value;
            toolStripProgressBar.Value = status.Progress;
            toolStripProgressBar.ProgressBar.Refresh();

            StatusFillDrive();
          });

          var fileCopy = new FileCopy(textBoxPathSource.Text, $"{comboBoxDrive.SelectedItem}", CopyMode);
          await fileCopy.Execute(progress, cancellationToken.Token);
          
          logger.Info("File copy operation completed successfully");
        }
      }
      catch (OperationCanceledException)
      {
        toolStripStatusLabel.Text = "Операция отменена";
        logger.Warn("File copy operation was cancelled");
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error during file copy operation");
        throw;
      }
      finally
      {
        buttonCopyFile.Enabled = true;
        buttonCancel.Enabled = false;
      }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      logger.Info("User requested to cancel the operation");
      cancellationToken?.Cancel();
    }

    private void buttonFillFolder_Click(object sender, EventArgs e)
    {
      try
      {
        logger.Debug("Opening browser form for folder: {path}", textBoxPathSource.Text);
        var browser = new BrowserForm(textBoxPathSource.Text);
        browser.ShowDialog();
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error opening browser form");
        throw;
      }
    }

    private void comboBoxDrive_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        Drive = DriveInfo.GetDrives().FirstOrDefault(drive => drive.IsReady
            && drive.DriveType == DriveType.Removable && drive.Name == $"{comboBoxDrive.SelectedItem}") ?? throw new ArgumentNullException();
        logger.Info("Drive selected: {drive}", Drive.Name);
        StatusFillDrive();
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error selecting drive");
        throw;
      }
    }

    /// <summary>
    /// Состояние заполненности внешнего носителя.
    /// </summary>
    private void StatusFillDrive()
    {
      progressBarFillDrive.Value = (int)Math.Round((double)((Drive.TotalSize - Drive.TotalFreeSpace) * 100 / Drive.TotalSize));
      labelFillDrive.Text = $"{BytesToString(Drive.TotalSize - Drive.TotalFreeSpace)} / {BytesToString(Drive.TotalSize)}";
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
      try
      {
        InitializeComponent();
        toolStripStatusLabel.Text = string.Empty;
        buttonCancel.Enabled = false;
        labelHello.Text = $"Hello, {Environment.UserName}!";
        
        logger.Info("MainForm initializing for user: {user}", Environment.UserName);

        comboBoxCopyMode.Items.AddRange(new[] { "Как есть", "Простой режим", "Артист", "Артист и Альбом" });
        comboBoxCopyMode.SelectedIndex = 0;

        var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
        if (drives.Any())
        {
          comboBoxDrive.Items.AddRange(drives.Select(drive => drive.Name).ToArray());
          comboBoxDrive.SelectedIndex = 0;
          logger.Info("Found {count} removable drives", drives.Count());
        }
        else
        {
          logger.Warn("No removable drives found");
        }

        if (!string.IsNullOrEmpty(Properties.Settings.Default.LastPathCopy))
        {
          textBoxPathSource.Text = Properties.Settings.Default.LastPathCopy;
          logger.Debug("Restored last path: {path}", Properties.Settings.Default.LastPathCopy);
        }
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Error initializing MainForm");
        throw;
      }
    }
    #endregion
  }
}
