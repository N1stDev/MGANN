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
            this.label_MGANN = new System.Windows.Forms.Label();
            this.buttonFileAdd = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_MGANN
            // 
            this.label_MGANN.CausesValidation = false;
            this.label_MGANN.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_MGANN.Font = new System.Drawing.Font("Matura MT Script Capitals", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_MGANN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(156)))), ((int)(((byte)(121)))));
            this.label_MGANN.Location = new System.Drawing.Point(0, 0);
            this.label_MGANN.Name = "label_MGANN";
            this.label_MGANN.Size = new System.Drawing.Size(675, 105);
            this.label_MGANN.TabIndex = 0;
            this.label_MGANN.Text = "MGANN";
            this.label_MGANN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_MGANN.Click += new System.EventHandler(this.Label1_Click);
            // 
            // buttonFileAdd
            // 
            this.buttonFileAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(128)))), ((int)(((byte)(92)))));
            this.buttonFileAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFileAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFileAdd.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonFileAdd.ForeColor = System.Drawing.Color.White;
            this.buttonFileAdd.Location = new System.Drawing.Point(36, 203);
            this.buttonFileAdd.Name = "buttonFileAdd";
            this.buttonFileAdd.Size = new System.Drawing.Size(135, 60);
            this.buttonFileAdd.TabIndex = 1;
            this.buttonFileAdd.Text = "Загрузить файл";
            this.buttonFileAdd.UseVisualStyleBackColor = false;
            this.buttonFileAdd.Click += new System.EventHandler(this.ButtonFileAdd_Click);
            this.buttonFileAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonFileAdd_MouseMove);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(128)))), ((int)(((byte)(92)))));
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.BackgroundImage = global::Test.Properties.Resources.Mushroom_style_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(675, 457);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFileAdd);
            this.Controls.Add(this.label_MGANN);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "MGANN";
            this.ResumeLayout(false);

        }


        #endregion

        private Label label_MGANN;
        private Button buttonFileAdd;
        private Button buttonStart;
        private OpenFileDialog openFileDialog1;
    }
}