namespace Test
{
    partial class AnalyzingForm
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
            this.labelAnalyze = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.pictureBoxSpectrogram = new System.Windows.Forms.PictureBox();
            this.labelResultGenre = new System.Windows.Forms.Label();
            this.labelTimeEnlapsed = new System.Windows.Forms.Label();
            this.richTextBoxAccuracyList = new System.Windows.Forms.RichTextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpectrogram)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAnalyze
            // 
            this.labelAnalyze.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAnalyze.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAnalyze.ForeColor = System.Drawing.Color.White;
            this.labelAnalyze.Location = new System.Drawing.Point(0, 0);
            this.labelAnalyze.Name = "labelAnalyze";
            this.labelAnalyze.Size = new System.Drawing.Size(605, 56);
            this.labelAnalyze.TabIndex = 0;
            this.labelAnalyze.Text = "Анализ";
            this.labelAnalyze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.answerLabel.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.answerLabel.ForeColor = System.Drawing.Color.White;
            this.answerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.answerLabel.Location = new System.Drawing.Point(12, 56);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(218, 41);
            this.answerLabel.TabIndex = 2;
            this.answerLabel.Text = "Результат:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeLabel.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeLabel.Location = new System.Drawing.Point(12, 271);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(332, 34);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "Время анализа (мс):";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // pictureBoxSpectrogram
            // 
            this.pictureBoxSpectrogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSpectrogram.Location = new System.Drawing.Point(13, 314);
            this.pictureBoxSpectrogram.Name = "pictureBoxSpectrogram";
            this.pictureBoxSpectrogram.Size = new System.Drawing.Size(580, 207);
            this.pictureBoxSpectrogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSpectrogram.TabIndex = 4;
            this.pictureBoxSpectrogram.TabStop = false;
            // 
            // labelResultGenre
            // 
            this.labelResultGenre.AutoSize = true;
            this.labelResultGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelResultGenre.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelResultGenre.ForeColor = System.Drawing.Color.White;
            this.labelResultGenre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelResultGenre.Location = new System.Drawing.Point(224, 56);
            this.labelResultGenre.Name = "labelResultGenre";
            this.labelResultGenre.Size = new System.Drawing.Size(0, 41);
            this.labelResultGenre.TabIndex = 5;
            // 
            // labelTimeEnlapsed
            // 
            this.labelTimeEnlapsed.AutoSize = true;
            this.labelTimeEnlapsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTimeEnlapsed.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeEnlapsed.ForeColor = System.Drawing.Color.White;
            this.labelTimeEnlapsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTimeEnlapsed.Location = new System.Drawing.Point(338, 271);
            this.labelTimeEnlapsed.Name = "labelTimeEnlapsed";
            this.labelTimeEnlapsed.Size = new System.Drawing.Size(0, 34);
            this.labelTimeEnlapsed.TabIndex = 6;
            // 
            // richTextBoxAccuracyList
            // 
            this.richTextBoxAccuracyList.BackColor = System.Drawing.Color.Black;
            this.richTextBoxAccuracyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxAccuracyList.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxAccuracyList.ForeColor = System.Drawing.Color.White;
            this.richTextBoxAccuracyList.Location = new System.Drawing.Point(13, 100);
            this.richTextBoxAccuracyList.Name = "richTextBoxAccuracyList";
            this.richTextBoxAccuracyList.ReadOnly = true;
            this.richTextBoxAccuracyList.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxAccuracyList.ShortcutsEnabled = false;
            this.richTextBoxAccuracyList.Size = new System.Drawing.Size(580, 168);
            this.richTextBoxAccuracyList.TabIndex = 7;
            this.richTextBoxAccuracyList.Text = "Ожидание";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            this.labelFileName.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFileName.ForeColor = System.Drawing.Color.White;
            this.labelFileName.Location = new System.Drawing.Point(12, 524);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(118, 24);
            this.labelFileName.TabIndex = 8;
            this.labelFileName.Text = "Имя файла";
            // 
            // AnalyzingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(156)))), ((int)(((byte)(121)))));
            this.ClientSize = new System.Drawing.Size(605, 558);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.richTextBoxAccuracyList);
            this.Controls.Add(this.labelTimeEnlapsed);
            this.Controls.Add(this.labelResultGenre);
            this.Controls.Add(this.pictureBoxSpectrogram);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.labelAnalyze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnalyzingForm";
            this.Text = "MGANN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalyzingForm_FormClosed);
            this.Load += new System.EventHandler(this.AnalyzingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpectrogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelAnalyze;
        private Label answerLabel;
        private Label timeLabel;
        private PictureBox pictureBoxSpectrogram;
        private Label labelResultGenre;
        private Label labelTimeEnlapsed;
        private RichTextBox richTextBoxAccuracyList;
        private Label labelFileName;
    }
}