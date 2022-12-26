using System.Diagnostics;
using MGANN;
using Spectrogram;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (FormsSharedData.isFileLoaded == true)
            {
                Form1 startForm = this;
                startForm.Hide();
                AnalyzingForm analyzingForm = new();
                analyzingForm.Show();
            }
            else
            {
                MessageBox.Show("Загрузите файл", "Ошибка");
            }
        }

        private void ButtonFileAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                FormsSharedData.loadedFilePath = openFileDialog1.FileName;
                labelFilePath.Text = FormsSharedData.loadedFilePath;
                FormsSharedData.isFileLoaded = true;
            }
            
        }

        private void оПроектеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Проект был подготовлен командой \"Жизненный Цикл\"" +
                "в качестве курсовой работы", "О проекте");
        }

        private void репозиторийGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl("https://google.com");
        }

        public void OpenUrl(string url)
        {
            Process.Start(url);
        }
    }
}