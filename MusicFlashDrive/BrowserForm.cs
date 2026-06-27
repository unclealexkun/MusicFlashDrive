using Microsoft.Web.WebView2.Core;
using MusicFlashDrive.Downloader;

namespace MusicFlashDrive
{
  public partial class BrowserForm : Form
  {
    #region Поля и Свойства
    /// <summary>
    /// Папка источник.
    /// </summary>
    private string PathSource { get; set; }

    /// <summary>
    /// Выбранный сервис.
    /// </summary>
    private Uri Url => comboBoxUrl.SelectedItem switch
    {
      "VK Music" => new Uri("https://music.vk.com/"),
      _ => new Uri("https://music.yandex.ru/")
    };
    #endregion

    #region Вложенный тип
    /// <summary>
    /// Метаданные песни.
    /// </summary>
    private class SongData
    {
      /// <summary>
      /// Артист.
      /// </summary>
      public string Artist { get; set; } = string.Empty;
      /// <summary>
      /// Название.
      /// </summary>
      public string Title { get; set; } = string.Empty;
      /// <summary>
      /// Альбом.
      /// </summary>
      public string Album { get; set; } = string.Empty;
      /// <summary>
      /// Ссылка на обложку.
      /// </summary>
      public string CoverUrl { get; set; } = string.Empty;
      /// <summary>
      /// Ссылка на песню.
      /// </summary>
      public string SourceUrl { get; set; } = string.Empty;
    }
    #endregion

    #region Методы
    private void comboBoxUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
      webViewMusicService.Source = Url;
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (webViewMusicService.CanGoBack)
        webViewMusicService.GoBack();
    }

    private void buttonForward_Click(object sender, EventArgs e)
    {
      if (webViewMusicService.CanGoForward)
        webViewMusicService.GoForward();
    }

    private void buttonGetInfo_Click(object sender, EventArgs e)
    {

    }

    private void EnsureHttps(object? sender, CoreWebView2NavigationStartingEventArgs args)
    {
      string uri = args.Uri;
      if (!uri.StartsWith("https://"))
      {
        args.Cancel = true;
      }
    }
    #endregion

    #region Конструктор
    /// <summary>
    /// Браузер для захвата.
    /// </summary>
    /// <param name="pathSource">Папка источник для сохранения.</param>
    public BrowserForm(string pathSource)
    {
      InitializeComponent();

      comboBoxUrl.Items.AddRange(new string[] { "Yandex music", "VK Music" });
      comboBoxUrl.SelectedIndex = 0;

      if (Directory.Exists(pathSource))
        PathSource = pathSource;
      else
        throw new DirectoryNotFoundException($"Path {pathSource} not found");

      webViewMusicService.NavigationStarting += EnsureHttps;
    }
    #endregion
  }
}
