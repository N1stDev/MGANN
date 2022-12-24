using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MGANN;

namespace Test
{
    public partial class AnalyzingForm : Form
    {
        public AnalyzingForm()
        {
            InitializeComponent();
        }

        private void ViewAnswer (object sender, EventArgs e)
        {
            string answerGenerName;
            //добавить переименование лэйбла в результат
            // answerLabel.Text =
        }

        private void AnalyzingForm_Load(object sender, EventArgs e)
        {
            var convolutionLayer = new ConvolutionLayer(16, 3);
            var maxPoolingLayer = new MaxPoolingLayer(2);
            //var softMaxLayer = new SoftMaxLayer(5776, 10);
        }

        private void AnalyzingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormsSharedData.mainForm.Show();
        }
    }
}
