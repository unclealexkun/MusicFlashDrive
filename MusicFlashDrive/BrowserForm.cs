using Microsoft.Web.WebView2.Core;
using MusicFlashDrive.Downloader;
using System.Text.Json;

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
      public string TrackUrl { get; set; } = string.Empty;
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

    private async void buttonGetInfo_Click(object sender, EventArgs e)
    {
      buttonGetInfo.Enabled = false;

      try
      {
        var tracks = await ExtractTracksAsync();

        if (tracks == null || tracks.Count == 0)
        {
          return;
        }
      }
      finally 
      { 
        buttonGetInfo.Enabled = true; 
      }
    }

    private async Task<List<SongData>?> ExtractTracksAsync()
    {
      string js = @"
        (function() {
            const tracks = [];
            const trackLinks = document.querySelectorAll('a[href*=""/album/""][href*=""/track/""]');
    
    trackLinks.forEach(link => {
        // 1. Название трека
        const title = link.textContent?.trim() || '';
        const trackUrl = link.href;
        
        // 2. Исполнитель: ищем ссылку на /artist/ в том же ""мета-контейнере""
        // Из вашего лога видно, что исполнитель лежит в sibling-элементе того же родителя, что и ссылка на трек
        let metaContainer = link.closest('.Meta_metaContainer__7i2dp') || 
                           link.parentElement?.parentElement?.parentElement;
        
        let artist = '';
        if (metaContainer) {
            const artistLink = metaContainer.querySelector('a[href*=""/artist/""]');
            artist = artistLink?.textContent?.trim() || '';
        }
        
        // 3. Общий контейнер трека (для обложки и длительности)
        // Поднимаемся вверх от ссылки, пока не найдём блок с картинкой и временем
        let commonContainer = link.parentElement;
        for (let i = 0; i < 10 && commonContainer; i++) {
            if (commonContainer.querySelector('img') && 
                Array.from(commonContainer.querySelectorAll('*')).some(el => /^\d{1,2}:\d{2}$/.test(el.textContent?.trim() || ''))) {
                break;
            }
            commonContainer = commonContainer.parentElement;
        }
        
        // 4. Обложка
        const coverImg = commonContainer?.querySelector('img');
        const coverUrl = coverImg?.src || coverImg?.getAttribute('data-src') || '';
        
        if (title) {
            tracks.push({
                title,
                artist,
                album: '',
                coverUrl,
                trackUrl
            });
        }
    });
    
    return JSON.stringify(tracks);
})();";

      string rawResult = await webViewMusicService.CoreWebView2.ExecuteScriptAsync(js);
      string unescapedJson = JsonSerializer.Deserialize<string>(rawResult) ?? "[]";
      return JsonSerializer.Deserialize<List<SongData>>(unescapedJson);
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
