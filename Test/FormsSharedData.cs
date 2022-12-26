using MGANN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrogram;
using FftSharp;

namespace Test
{
    static internal class FormsSharedData
    {
        public static string genreString = null;

        public static bool test = false;

        public static Bitmap bmpSpectrogram;

        public static CNN neuralNetwork = new();

        public static Form1 mainForm = new();

        public static string loadedFilePath = "";
        public static bool isFileLoaded = false;

        static FormsSharedData()
        {
            neuralNetwork.UploadConfiguration();
        }
    }
}
