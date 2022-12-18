namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           buttonFileAdd.Click += ButtonFileAdd_Click;
           buttonStart.Click += ButtonStart_Click;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
            Form1 startForm = this;
            startForm.Hide();
            AnalyzingForm analyzingForm = new();
            analyzingForm.Show();
        }

        private void ButtonFileAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не тыкай в меня, я же работаю!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}