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
			components = new System.ComponentModel.Container();
			groupBoxFileOperation = new GroupBox();
			labelFillDrive = new Label();
			progressBarFillDrive = new ProgressBar();
			buttonCopyFile = new Button();
			comboBoxDrive = new ComboBox();
			labelDrive = new Label();
			buttonPathSource = new Button();
			textBoxPathSource = new TextBox();
			labelPathSource = new Label();
			labelHello = new Label();
			timerDrive = new System.Windows.Forms.Timer(components);
			groupBoxFileOperation.SuspendLayout();
			SuspendLayout();
			// 
			// groupBoxFileOperation
			// 
			groupBoxFileOperation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
			groupBoxFileOperation.Size = new Size(570, 159);
			groupBoxFileOperation.TabIndex = 0;
			groupBoxFileOperation.TabStop = false;
			groupBoxFileOperation.Text = "Операция с файлами";
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
			progressBarFillDrive.Size = new Size(492, 23);
			progressBarFillDrive.TabIndex = 6;
			// 
			// buttonCopyFile
			// 
			buttonCopyFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCopyFile.Location = new Point(475, 121);
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
			buttonPathSource.Location = new Point(523, 37);
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
			textBoxPathSource.Size = new Size(505, 23);
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
			// timerDrive
			// 
			timerDrive.Interval = 5000;
			timerDrive.Tick += comboBoxDrive_SelectedIndexChanged;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(594, 244);
			Controls.Add(labelHello);
			Controls.Add(groupBoxFileOperation);
			Name = "MainForm";
			Text = "Music Flash Drive";
			groupBoxFileOperation.ResumeLayout(false);
			groupBoxFileOperation.PerformLayout();
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
		private System.Windows.Forms.Timer timerDrive;
		private Label labelFillDrive;
	}
}
