namespace MusicFlashDrive
{
  public partial class BrowserForm : Form
  {
    #region Методы и Свойства
    /// <summary>
    /// Выбранный сервис.
    /// </summary>
    private Uri Url => comboBoxUrl.SelectedItem switch
    {
      "VK Music" => new Uri("https://vk.com/audios136078201"),
      _ => new Uri("https://music.yandex.ru/")
    };
    #endregion

    #region Методы
    private void comboBoxUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
      webViewMusicService.Source = Url;
    }
    #endregion

    #region Конструктор
    public BrowserForm()
    {
      InitializeComponent();

      comboBoxUrl.Items.AddRange(new string[] { "Yandex music", "VK Music" });
      comboBoxUrl.SelectedIndex = 0;
    }
    #endregion
  }
}
