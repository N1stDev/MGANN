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

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������ ��� ����������� �������� \"��������� ����\"" +
                "� �������� �������� ������", "� �������");
        }

        private void �����������GitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl("https://google.com");
        }

        public void OpenUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}