using System;
using System.Diagnostics;
using System.IO; 
using Spectrogram;
using NAudio; 

namespace MGANN_Spectogramm
{
    class Program2
    {       
        /* Функция чтения данных из .WAV файла */
        (double[] audio, int sampleRate) ReadWavMono(string filePath, double multiplier = 16_000)
        {
            using var afr = new NAudio.Wave.AudioFileReader(filePath);

            int sampleRate = afr.WaveFormat.SampleRate;
            int bytesPerSample = afr.WaveFormat.BitsPerSample / 8;
            int sampleCount = (int)(afr.Length / bytesPerSample);
            int channelCount = afr.WaveFormat.Channels;
            int samplesRead = 0;

            var audio = new List<double>(sampleCount);
            var buffer = new float[sampleRate * channelCount];
            
            while ((samplesRead = afr.Read(buffer, 0, buffer.Length)) > 0)
            {
                audio.AddRange(buffer.Take(samplesRead).Select(x => x * multiplier));
            }
            return (audio.ToArray(), sampleRate);
        }
        
        static void Main2()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            /* Определение пути к папке проекта. 
               C:\Users\username\source\repos\*projectname*\resources */
            string RESOURCE_PATH = Environment.CurrentDirectory;
                   RESOURCE_PATH = RESOURCE_PATH.Substring(0, RESOURCE_PATH.Length - "bin\\Debug\\net6.0".Length);
                   RESOURCE_PATH += "resources";

            string MUSIC_PATH = RESOURCE_PATH + "\\music";                  // C:\Users\username\source\repos\*projectname*\resources\music 
            string SPECTROGRAMS_PATH = RESOURCE_PATH + "\\spectrograms";    // C:\Users\username\source\repos\*projectname*\resources\spectrograms
            string[] GENRES = { "\\classical\\", "\\country\\", "\\disco\\", "\\hiphop\\", "\\jazz\\", "\\metal\\", "\\pop\\", "\\reggae\\", "\\rock\\" };
            var instance = new Program2();

            foreach (string genre in GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(MUSIC_PATH + genre);    /* Каталога со звуковыми файлами */
                FileInfo[] files = place.GetFiles();                            /* Получение файлов из каталога */
                int index = 1;

                foreach (FileInfo i in files)
                {
                    string current_file = MUSIC_PATH + genre + i.Name;
                    try    /* Добавил вот такую конструкцию на случай, если программа попадется на битый файл. */
                    {
                        (double[] audio, int sampleRate) = instance.ReadWavMono(current_file);    
                        var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 500, minFreq: 30, maxFreq: 12000);
                        sg.Add(audio);
                        string ready_file = SPECTROGRAMS_PATH + genre + i.Name;
                               ready_file = ready_file.Substring(0, ready_file.Length - 4);
                               ready_file += ".bmp";
                        sg.SaveImage(ready_file);
                        Console.WriteLine("Создана спектрограмма из файла " + current_file);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Не удалось обработать файл " + current_file);
                    }
                    finally
                    {
                        index++;
                    }
                }
                Console.WriteLine("\n");
            }

            watch.Stop();
            Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} ms"); 
            return;
        }   
    }
}
