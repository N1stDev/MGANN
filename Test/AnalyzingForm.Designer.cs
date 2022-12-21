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
            this.analyzingProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelAnalyze
            // 
            this.labelAnalyze.AutoSize = true;
            this.labelAnalyze.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAnalyze.Location = new System.Drawing.Point(14, 12);
            this.labelAnalyze.Name = "labelAnalyze";
            this.labelAnalyze.Size = new System.Drawing.Size(323, 39);
            this.labelAnalyze.TabIndex = 0;
            this.labelAnalyze.Text = "Прогресс нализа";
            this.labelAnalyze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // analyzingProgressBar
            // 
            this.analyzingProgressBar.ForeColor = System.Drawing.SystemColors.Info;
            this.analyzingProgressBar.Location = new System.Drawing.Point(357, 14);
            this.analyzingProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.analyzingProgressBar.Name = "analyzingProgressBar";
            this.analyzingProgressBar.Size = new System.Drawing.Size(297, 37);
            this.analyzingProgressBar.TabIndex = 1;
            this.analyzingProgressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // AnalyzingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(203)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(914, 647);
            this.Controls.Add(this.analyzingProgressBar);
            this.Controls.Add(this.labelAnalyze);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AnalyzingForm";
            this.Text = "MGANN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelAnalyze;
        private ProgressBar analyzingProgressBar;
    }
}