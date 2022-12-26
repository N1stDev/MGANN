namespace Test
{
    partial class Form1
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
            this.labelMGANN = new System.Windows.Forms.Label();
            this.buttonFileAdd = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_MGANN
            // 
            this.labelMGANN.CausesValidation = false;
            this.labelMGANN.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMGANN.Font = new System.Drawing.Font("Ravie", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMGANN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(156)))), ((int)(((byte)(121)))));
            this.labelMGANN.Location = new System.Drawing.Point(0, 0);
            this.labelMGANN.Name = "label_MGANN";
            this.labelMGANN.Size = new System.Drawing.Size(675, 105);
            this.labelMGANN.TabIndex = 0;
            this.labelMGANN.Text = "MGANN";
            this.labelMGANN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFileAdd
            // 
            this.buttonFileAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(128)))), ((int)(((byte)(92)))));
            this.buttonFileAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFileAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFileAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonFileAdd.ForeColor = System.Drawing.Color.White;
            this.buttonFileAdd.Location = new System.Drawing.Point(36, 203);
            this.buttonFileAdd.Name = "buttonFileAdd";
            this.buttonFileAdd.Size = new System.Drawing.Size(135, 60);
            this.buttonFileAdd.TabIndex = 1;
            this.buttonFileAdd.Text = "Загрузить файл";
            this.buttonFileAdd.UseVisualStyleBackColor = false;
            this.buttonFileAdd.Click += new System.EventHandler(this.ButtonFileAdd_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(128)))), ((int)(((byte)(92)))));
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Location = new System.Drawing.Point(36, 282);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(135, 60);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Начать анализ";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Звуоквые файлы wav|*.wav";
            this.openFileDialog1.InitialDirectory = ".";
            // 
            // labelFilePath
            // 
            this.labelFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(12, 433);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(145, 15);
            this.labelFilePath.TabIndex = 3;
            this.labelFilePath.Text = "Нет загруженного файла";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.BackgroundImage = global::Test.Properties.Resources.Mushroom_style_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(675, 457);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFileAdd);
            this.Controls.Add(this.labelMGANN);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "MGANN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Label labelMGANN;
        private Button buttonFileAdd;
        private Button buttonStart;
        private OpenFileDialog openFileDialog1;
        private Label labelFilePath;
    }
}