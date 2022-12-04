namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Не тыкай в меня, я же работаю!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}