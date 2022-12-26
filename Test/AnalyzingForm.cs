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

            StringBuilder sbFileName = new(FormsSharedData.loadedFilePath);

            int trimPos = FormsSharedData.loadedFilePath.LastIndexOf('\\');

            if (trimPos != -1)
            {
                sbFileName.Remove(0, trimPos + 1);
            }

            labelFileName.Text = sbFileName.ToString();

            Stopwatch sw = new();

            sw.Start();
            var accuracyList = FormsSharedData.neuralNetwork.DetectGenre(FormsSharedData.bmpSpectrogram);
            sw.Stop();

            double totalAccuracy = accuracyList.Sum();

            Dictionary<double, string> genre_acuracyDict = new();

            for (int i = 0; i < accuracyList.Count; i++)
            {
                genre_acuracyDict.Add(accuracyList[i], ((VARIABLES.GENRES_ENUM)i).ToString());
            }

            var sortedDict = from genre in genre_acuracyDict orderby genre.Key descending select genre;

            richTextBoxAccuracyList.Text = "MGANN считает что аудиофайл:\n";

            foreach (var g in sortedDict)
            {
                richTextBoxAccuracyList.Text += $"на {Math.Round((g.Key / totalAccuracy) * 100, 1)}% {g.Value}\n";
            }

            labelTimeEnlapsed.Text = sw.ElapsedMilliseconds.ToString();
        }

        private void AnalyzingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormsSharedData.mainForm.Show();
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
