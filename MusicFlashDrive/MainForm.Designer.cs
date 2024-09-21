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
			groupBox1 = new GroupBox();
			buttonPathSource = new Button();
			textBoxPathSource = new TextBox();
			labelPathSource = new Label();
			labelDrive = new Label();
			comboBoxDrive = new ComboBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(comboBoxDrive);
			groupBox1.Controls.Add(labelDrive);
			groupBox1.Controls.Add(buttonPathSource);
			groupBox1.Controls.Add(textBoxPathSource);
			groupBox1.Controls.Add(labelPathSource);
			groupBox1.Location = new Point(12, 40);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(570, 123);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Операция с файлами";
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
			// comboBoxDrive
			// 
			comboBoxDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			comboBoxDrive.FormattingEnabled = true;
			comboBoxDrive.Location = new Point(6, 81);
			comboBoxDrive.Name = "comboBoxDrive";
			comboBoxDrive.Size = new Size(60, 23);
			comboBoxDrive.TabIndex = 4;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(594, 208);
			Controls.Add(groupBox1);
			Name = "MainForm";
			Text = "Music Flash Drive";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private Label labelPathSource;
		private TextBox textBoxPathSource;
		private Button buttonPathSource;
		private ComboBox comboBoxDrive;
		private Label labelDrive;
	}
}
