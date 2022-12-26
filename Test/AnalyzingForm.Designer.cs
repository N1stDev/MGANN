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
            this.labelAnswer = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.pictureBoxSpectrogram = new System.Windows.Forms.PictureBox();
            this.labelAnswerGiven = new System.Windows.Forms.Label();
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
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAnswer.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAnswer.ForeColor = System.Drawing.Color.White;
            this.labelAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAnswer.Location = new System.Drawing.Point(12, 56);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(218, 41);
            this.labelAnswer.TabIndex = 2;
            this.labelAnswer.Text = "Результат:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTime.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTime.Location = new System.Drawing.Point(12, 271);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(332, 34);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Время анализа (мс):";
            this.labelTime.Click += new System.EventHandler(this.timeLabel_Click);
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
            // labelAnswerGiven
            // 
            this.labelAnswerGiven.AutoSize = true;
            this.labelAnswerGiven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAnswerGiven.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAnswerGiven.ForeColor = System.Drawing.Color.White;
            this.labelAnswerGiven.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAnswerGiven.Location = new System.Drawing.Point(224, 56);
            this.labelAnswerGiven.Name = "labelAnswerGiven";
            this.labelAnswerGiven.Size = new System.Drawing.Size(0, 41);
            this.labelAnswerGiven.TabIndex = 5;
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
            this.labelTimeEnlapsed.Size = new System.Drawing.Size(35, 34);
            this.labelTimeEnlapsed.TabIndex = 6;
            this.labelTimeEnlapsed.Text = "0";
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
            this.Controls.Add(this.labelAnswerGiven);
            this.Controls.Add(this.pictureBoxSpectrogram);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.labelAnalyze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnalyzingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MGANN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalyzingForm_FormClosed);
            this.Load += new System.EventHandler(this.AnalyzingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpectrogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelAnalyze;
        private Label labelAnswer;
        private Label labelTime;
        private PictureBox pictureBoxSpectrogram;
        private Label labelAnswerGiven;
        private Label labelTimeEnlapsed;
        private RichTextBox richTextBoxAccuracyList;
        private Label labelFileName;
    }
}