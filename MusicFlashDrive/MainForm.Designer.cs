namespace MusicFlashDrive
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      groupBoxFileOperation = new GroupBox();
      buttonFillFolder = new Button();
      labelFillFolder = new Label();
      comboBoxCopyMode = new ComboBox();
      labelCopyMode = new Label();
      buttonCancel = new Button();
      labelFillDrive = new Label();
      progressBarFillDrive = new ProgressBar();
      buttonCopyFile = new Button();
      comboBoxDrive = new ComboBox();
      labelDrive = new Label();
      buttonPathSource = new Button();
      textBoxPathSource = new TextBox();
      labelPathSource = new Label();
      labelHello = new Label();
      statusStrip = new StatusStrip();
      toolStripStatusOperation = new ToolStripStatusLabel();
      toolStripProgressBar = new ToolStripProgressBar();
      toolStripStatusLabel = new ToolStripStatusLabel();
      groupBoxFileOperation.SuspendLayout();
      statusStrip.SuspendLayout();
      SuspendLayout();
      // 
      // groupBoxFileOperation
      // 
      groupBoxFileOperation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      groupBoxFileOperation.Controls.Add(buttonFillFolder);
      groupBoxFileOperation.Controls.Add(labelFillFolder);
      groupBoxFileOperation.Controls.Add(comboBoxCopyMode);
      groupBoxFileOperation.Controls.Add(labelCopyMode);
      groupBoxFileOperation.Controls.Add(buttonCancel);
      groupBoxFileOperation.Controls.Add(labelFillDrive);
      groupBoxFileOperation.Controls.Add(progressBarFillDrive);
      groupBoxFileOperation.Controls.Add(buttonCopyFile);
      groupBoxFileOperation.Controls.Add(comboBoxDrive);
      groupBoxFileOperation.Controls.Add(labelDrive);
      groupBoxFileOperation.Controls.Add(buttonPathSource);
      groupBoxFileOperation.Controls.Add(textBoxPathSource);
      groupBoxFileOperation.Controls.Add(labelPathSource);
      groupBoxFileOperation.Location = new Point(12, 44);
      groupBoxFileOperation.Name = "groupBoxFileOperation";
      groupBoxFileOperation.Size = new Size(575, 220);
      groupBoxFileOperation.TabIndex = 0;
      groupBoxFileOperation.TabStop = false;
      groupBoxFileOperation.Text = "Операция с файлами";
      // 
      // buttonFillFolder
      // 
      buttonFillFolder.Location = new Point(90, 181);
      buttonFillFolder.Name = "buttonFillFolder";
      buttonFillFolder.Size = new Size(89, 23);
      buttonFillFolder.TabIndex = 15;
      buttonFillFolder.Text = "Заполнить";
      buttonFillFolder.UseVisualStyleBackColor = true;
      buttonFillFolder.Click += buttonFillFolder_Click;
      // 
      // labelFillFolder
      // 
      labelFillFolder.AutoSize = true;
      labelFillFolder.Location = new Point(23, 125);
      labelFillFolder.Name = "labelFillFolder";
      labelFillFolder.Size = new Size(156, 15);
      labelFillFolder.TabIndex = 14;
      labelFillFolder.Text = "Заполнить папку источник";
      // 
      // comboBoxCopyMode
      // 
      comboBoxCopyMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      comboBoxCopyMode.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBoxCopyMode.FormattingEnabled = true;
      comboBoxCopyMode.Location = new Point(385, 152);
      comboBoxCopyMode.Name = "comboBoxCopyMode";
      comboBoxCopyMode.Size = new Size(184, 23);
      comboBoxCopyMode.TabIndex = 12;
      // 
      // labelCopyMode
      // 
      labelCopyMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      labelCopyMode.AutoSize = true;
      labelCopyMode.Location = new Point(385, 125);
      labelCopyMode.Name = "labelCopyMode";
      labelCopyMode.Size = new Size(121, 15);
      labelCopyMode.TabIndex = 13;
      labelCopyMode.Text = "Режим копирования";
      // 
      // buttonCancel
      // 
      buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      buttonCancel.Location = new Point(385, 181);
      buttonCancel.Name = "buttonCancel";
      buttonCancel.Size = new Size(89, 23);
      buttonCancel.TabIndex = 8;
      buttonCancel.Text = "Отменить";
      buttonCancel.UseVisualStyleBackColor = true;
      buttonCancel.Click += buttonCancel_Click;
      // 
      // labelFillDrive
      // 
      labelFillDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      labelFillDrive.AutoSize = true;
      labelFillDrive.BackColor = SystemColors.ControlLight;
      labelFillDrive.Location = new Point(275, 84);
      labelFillDrive.Name = "labelFillDrive";
      labelFillDrive.Size = new Size(73, 15);
      labelFillDrive.TabIndex = 7;
      labelFillDrive.Text = "0 Byt  / 0 Byt";
      // 
      // progressBarFillDrive
      // 
      progressBarFillDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      progressBarFillDrive.Location = new Point(72, 81);
      progressBarFillDrive.Name = "progressBarFillDrive";
      progressBarFillDrive.Size = new Size(497, 23);
      progressBarFillDrive.TabIndex = 6;
      // 
      // buttonCopyFile
      // 
      buttonCopyFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      buttonCopyFile.Location = new Point(480, 181);
      buttonCopyFile.Name = "buttonCopyFile";
      buttonCopyFile.Size = new Size(89, 23);
      buttonCopyFile.TabIndex = 5;
      buttonCopyFile.Text = "Копировать";
      buttonCopyFile.UseVisualStyleBackColor = true;
      buttonCopyFile.Click += buttonCopyFile_Click;
      // 
      // comboBoxDrive
      // 
      comboBoxDrive.FormattingEnabled = true;
      comboBoxDrive.Location = new Point(6, 81);
      comboBoxDrive.Name = "comboBoxDrive";
      comboBoxDrive.Size = new Size(60, 23);
      comboBoxDrive.TabIndex = 4;
      comboBoxDrive.SelectedIndexChanged += comboBoxDrive_SelectedIndexChanged;
      // 
      // labelDrive
      // 
      labelDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      labelDrive.AutoSize = true;
      labelDrive.Location = new Point(6, 63);
      labelDrive.Name = "labelDrive";
      labelDrive.Size = new Size(60, 15);
      labelDrive.TabIndex = 3;
      labelDrive.Text = "Носитель";
      // 
      // buttonPathSource
      // 
      buttonPathSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      buttonPathSource.Location = new Point(528, 37);
      buttonPathSource.Name = "buttonPathSource";
      buttonPathSource.Size = new Size(41, 23);
      buttonPathSource.TabIndex = 2;
      buttonPathSource.Text = "...";
      buttonPathSource.UseVisualStyleBackColor = true;
      buttonPathSource.Click += buttonPathSource_Click;
      // 
      // textBoxPathSource
      // 
      textBoxPathSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      textBoxPathSource.Location = new Point(6, 37);
      textBoxPathSource.Name = "textBoxPathSource";
      textBoxPathSource.Size = new Size(510, 23);
      textBoxPathSource.TabIndex = 1;
      // 
      // labelPathSource
      // 
      labelPathSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      labelPathSource.AutoSize = true;
      labelPathSource.Location = new Point(6, 19);
      labelPathSource.Name = "labelPathSource";
      labelPathSource.Size = new Size(96, 15);
      labelPathSource.TabIndex = 0;
      labelPathSource.Text = "Папка источник";
      // 
      // labelHello
      // 
      labelHello.AutoSize = true;
      labelHello.Location = new Point(12, 26);
      labelHello.Name = "labelHello";
      labelHello.Size = new Size(38, 15);
      labelHello.TabIndex = 1;
      labelHello.Text = "Hello!";
      // 
      // statusStrip
      // 
      statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusOperation, toolStripProgressBar, toolStripStatusLabel });
      statusStrip.Location = new Point(0, 265);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new Size(599, 22);
      statusStrip.TabIndex = 2;
      statusStrip.Text = "statusStripInfo";
      // 
      // toolStripStatusOperation
      // 
      toolStripStatusOperation.Name = "toolStripStatusOperation";
      toolStripStatusOperation.Size = new Size(103, 17);
      toolStripStatusOperation.Text = "Статус операции:";
      // 
      // toolStripProgressBar
      // 
      toolStripProgressBar.Name = "toolStripProgressBar";
      toolStripProgressBar.Size = new Size(100, 16);
      // 
      // toolStripStatusLabel
      // 
      toolStripStatusLabel.Name = "toolStripStatusLabel";
      toolStripStatusLabel.Size = new Size(75, 17);
      toolStripStatusLabel.Text = "Обработано";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(599, 287);
      Controls.Add(statusStrip);
      Controls.Add(labelHello);
      Controls.Add(groupBoxFileOperation);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "MainForm";
      Text = "Music Flash Drive";
      groupBoxFileOperation.ResumeLayout(false);
      groupBoxFileOperation.PerformLayout();
      statusStrip.ResumeLayout(false);
      statusStrip.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private GroupBox groupBoxFileOperation;
		private Label labelPathSource;
		private TextBox textBoxPathSource;
		private Button buttonPathSource;
		private ComboBox comboBoxDrive;
		private Label labelDrive;
		private Label labelHello;
		private Button buttonCopyFile;
		private ProgressBar progressBarFillDrive;
		private Label labelFillDrive;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel toolStripStatusOperation;
    private ToolStripProgressBar toolStripProgressBar;
    private ToolStripStatusLabel toolStripStatusLabel;
    private Button buttonCancel;
    private ComboBox comboBoxCopyMode;
    private Label labelCopyMode;
    private Button buttonFillFolder;
    private Label labelFillFolder;
  }
}
