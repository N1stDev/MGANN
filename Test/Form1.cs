using System.Diagnostics;

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
            Form1 startForm = this;
            startForm.Hide();
            AnalyzingForm analyzingForm = new();
            analyzingForm.Show();
        }

        private void ButtonFileAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FormsSharedData.loadedFilePath = openFileDialog1.FileName;
            labelFilePath.Text = FormsSharedData.loadedFilePath;
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
            System.Diagnostics.Process.Start(url);
        }
    }
}