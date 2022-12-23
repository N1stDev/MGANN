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

           // throw new NotImplementedException();
            Form1 startForm = this;
            startForm.Hide();
            AnalyzingForm analyzingForm = new();
            analyzingForm.Show();
        }

        private void ButtonFileAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
          //  тут должна быть дальнейшая реализация
          // что делать с файлом выбранным
            
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //добавить защиту от дурака/чапкина
        }

        
    }
}