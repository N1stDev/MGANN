using Spectrogram;
using System.IO;

namespace MGANN
{
    class Spectogramm
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

        public static void Generate()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var instance = new Spectogramm();                                                               // !!!!!

            foreach (string genre in VARIABLES.GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(VARIABLES.MUSIC_PATH + genre);    /* Каталога со звуковыми файлами */
                FileInfo[] files = place.GetFiles();                                      /* Получение файлов из каталога */
                int index = 1;

                foreach (FileInfo i in files)
                {
                    string current_file = place.ToString() + i.Name;
                    try    /* Добавил вот такую конструкцию на случай, если программа попадется на битый файл. */
                    {
                        (double[] audio, int sampleRate) = instance.ReadWavMono(current_file);                  // !!!!!
                                                                    // Высота картинки ~ fftsize / 2.
                                                                    // Ширина картинки обратно пропорциональна stepSize.
                                                                                    // 1600 => 412, 800 => 824, 400 => 1649. Непонятно ваще, что за формула тут.
                        var sg = new SpectrogramGenerator(sampleRate, fftSize: 1024, stepSize: 1600, minFreq: 30, maxFreq: 12000);
                        sg.Add(audio);
                        sg.SetColormap(Colormap.Grayscale);

                        string ready_file = VARIABLES.SPECTROGRAMS_PATH + genre + i.Name;
                        ready_file = ready_file.Substring(0, ready_file.Length - 4) + ".bmp";

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
    
