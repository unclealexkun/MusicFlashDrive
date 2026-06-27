namespace MusicFlashDrive
{
  partial class BrowserForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
      comboBoxUrl = new ComboBox();
      webViewMusicService = new Microsoft.Web.WebView2.WinForms.WebView2();
      buttonBack = new Button();
      buttonForward = new Button();
      buttonGetInfo = new Button();
      ((System.ComponentModel.ISupportInitialize)webViewMusicService).BeginInit();
      SuspendLayout();
      // 
      // comboBoxUrl
      // 
      comboBoxUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      comboBoxUrl.FormattingEnabled = true;
      comboBoxUrl.Location = new Point(12, 12);
      comboBoxUrl.Name = "comboBoxUrl";
      comboBoxUrl.Size = new Size(776, 23);
      comboBoxUrl.TabIndex = 0;
      comboBoxUrl.SelectedIndexChanged += comboBoxUrl_SelectedIndexChanged;
      // 
      // webViewMusicService
      // 
      webViewMusicService.AllowExternalDrop = true;
      webViewMusicService.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      webViewMusicService.CreationProperties = null;
      webViewMusicService.DefaultBackgroundColor = Color.White;
      webViewMusicService.Location = new Point(12, 79);
      webViewMusicService.Name = "webViewMusicService";
      webViewMusicService.Size = new Size(776, 359);
      webViewMusicService.TabIndex = 1;
      webViewMusicService.ZoomFactor = 1D;
      // 
      // buttonBack
      // 
      buttonBack.Location = new Point(12, 41);
      buttonBack.Name = "buttonBack";
      buttonBack.Size = new Size(62, 32);
      buttonBack.TabIndex = 2;
      buttonBack.Text = "<--";
      buttonBack.UseVisualStyleBackColor = true;
      buttonBack.Click += buttonBack_Click;
      // 
      // buttonForward
      // 
      buttonForward.Location = new Point(80, 41);
      buttonForward.Name = "buttonForward";
      buttonForward.Size = new Size(62, 32);
      buttonForward.TabIndex = 3;
      buttonForward.Text = "-->";
      buttonForward.UseVisualStyleBackColor = true;
      buttonForward.Click += buttonForward_Click;
      // 
      // buttonGetInfo
      // 
      buttonGetInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      buttonGetInfo.Location = new Point(695, 41);
      buttonGetInfo.Name = "buttonGetInfo";
      buttonGetInfo.Size = new Size(93, 32);
      buttonGetInfo.TabIndex = 4;
      buttonGetInfo.Text = "Info";
      buttonGetInfo.UseVisualStyleBackColor = true;
      buttonGetInfo.Click += buttonGetInfo_Click;
      // 
      // BrowserForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(buttonGetInfo);
      Controls.Add(buttonForward);
      Controls.Add(buttonBack);
      Controls.Add(webViewMusicService);
      Controls.Add(comboBoxUrl);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "BrowserForm";
      Text = "Browser";
      ((System.ComponentModel.ISupportInitialize)webViewMusicService).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private ComboBox comboBoxUrl;
    private Microsoft.Web.WebView2.WinForms.WebView2 webViewMusicService;
    private Button buttonBack;
    private Button buttonForward;
    private Button buttonGetInfo;
  }
}