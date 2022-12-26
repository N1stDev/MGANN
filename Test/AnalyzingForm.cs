using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MGANN;
using Spectrogram;

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
            (double[] audio, int sampleRate) = Spectrogramm.ReadWavMono(FormsSharedData.loadedFilePath);

            var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 820, minFreq: 100, maxFreq: 4000);
            sg.SetColormap(Colormap.Grayscale);
            sg.Add(audio);
            FormsSharedData.bmpSpectrogram = sg.GetBitmap();

            pictureBoxSpectrogram.Image = FormsSharedData.bmpSpectrogram;

            Thread processAnalyze = new Thread(ProcessAnalyze);
            processAnalyze.IsBackground = true;

            Stopwatch sw = new();

            sw.Start();
            FormsSharedData.genreString = FormsSharedData.neuralNetwork.DetectGenre(FormsSharedData.bmpSpectrogram);
            sw.Stop();

            StringBuilder sb = new(FormsSharedData.genreString);
            sb = sb.Remove(sb.Length - 1, 1).Remove(0, 1);

            labelResultGenre.Text = sb.ToString();

            labelTimeEnlapsed.Text = sw.ElapsedMilliseconds.ToString();

            //processAnalyze.Start();
            //timer1.Start();
        }

        private void AnalyzingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormsSharedData.mainForm.Show();
        }

        private void ProcessAnalyze()
        {
            FormsSharedData.genreString = FormsSharedData.neuralNetwork.DetectGenre(FormsSharedData.bmpSpectrogram);
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
