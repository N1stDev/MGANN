﻿namespace Test
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
            this.answerLabel.Location = new System.Drawing.Point(12, 153);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(218, 41);
            this.answerLabel.TabIndex = 2;
            this.answerLabel.Text = "Результат:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeLabel.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeLabel.Location = new System.Drawing.Point(12, 226);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(315, 41);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "Время анализа:";
            // 
            // AnalyzingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(156)))), ((int)(((byte)(121)))));
            this.ClientSize = new System.Drawing.Size(605, 426);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.labelAnalyze);
            this.Name = "AnalyzingForm";
            this.Text = "MGANN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalyzingForm_FormClosed);
            this.Load += new System.EventHandler(this.AnalyzingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelAnalyze;
        private Label answerLabel;
        private Label timeLabel;
    }
}