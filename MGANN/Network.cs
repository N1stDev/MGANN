﻿using MathNet.Numerics.LinearAlgebra;
using System;
using System.ComponentModel;
using mnd = MathNet.Numerics.LinearAlgebra.Double;

namespace MGANN
{
    class Network
    {
        List<Vector<double>> biases = new();
        List<Matrix<double>> weights = new();

        List<Vector<double>> inputs = new();
        List<Vector<double>> outputs = new();

        double learningRate = 0.3;

        int[] layerSizes;

        public Network(params int[] layerSizes)
        {
            this.layerSizes = layerSizes;

            // Самый первый элемент списка -- это входные данные нейросети
            outputs.Add(mnd.DenseVector.Create(layerSizes[0], 0));

            for (int i = 1; i < layerSizes.Length; i++)
            {
                weights.Add(mnd.DenseMatrix.Create(layerSizes[i], layerSizes[i - 1], 0));

                biases.Add(mnd.DenseVector.Create(layerSizes[i], 0));

                outputs.Add(mnd.DenseVector.Create(layerSizes[i], 0));
                inputs.Add(mnd.DenseVector.Create(layerSizes[i], 0));
            }

            this.SetRandom();
        }

        public void Train()
        {
            // Таблица соответстия спектрограмм ответам
            List<(Vector<double>, Vector<double>)> cases = new();
            ImageConverter converter = new();
            int genreIndex = 0;

            foreach (string genre in VARIABLES.GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(VARIABLES.SPECTROGRAMS_PATH + genre);
                FileInfo[] files = place.GetFiles();

                foreach (FileInfo i in files)
                {
                    string imagePath = place.ToString() + i.Name;

                    Vector<double> expectedResult = mnd.DenseVector.Create(10, 0);
                    expectedResult[genreIndex] = 1;
                    cases.Add((converter.imageVec, expectedResult));
                }
                genreIndex++;
            }

            for (int i = 0; i < 10; i++)
            {
                Random rand = new();
                var shuffledCases = cases.OrderBy(i => rand.Next()).ToList();
                int step = 0;
                Vector<double> error = mnd.DenseVector.Create(10, 0);

                foreach (var el in shuffledCases)
                {
                    if (step % 10 == 0 && step != 0)
                    {
                        BackProp(error.Divide(10));
                        error.Clear();
                    }

                    learningRate /= 2;

                    RunForward(el.Item1);
                    error += outputs.Last() - el.Item2;
                    step++;
                }
            }
        }

        public void Test()
        {
            ImageConverter converter = new();
            int genreIndex = 1;
            double success = 0;
            double count = 0;
            foreach (string genre in VARIABLES.GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(VARIABLES.SPECTROGRAMS_PATH + genre);
                FileInfo[] files = place.GetFiles();
                foreach (FileInfo i in files)
                {
                    string imagePath = place.ToString() + i.Name;
                    converter.convert(imagePath);
                    RunForward(converter.imageVec);

                    count++;
                    if (outputs.Last().MaximumIndex() + 1 == genreIndex)
                    {
                        success++;
                    }
                }
                genreIndex++;
            }
            Console.WriteLine($"Accuracy: {Math.Round(success / count * 100, 2)}%");
        }

        public void RunForward(in Vector<double> input)
        {
            outputs[0] = input;

            for (int i = 0; i < layerSizes.Length - 1; i++)
            {
                inputs[i] = (weights[i] * outputs[i]) + biases[i];
                outputs[i + 1] = Sigmoid(inputs[i]);
            }
        }

        public void SetRandom()
        {
            Random rand = new();

            foreach (var v in biases)
            {
                for (int i = 0; i < v.Count; i++)
                {
                    //v[i] = (rand.NextDouble() * 2) - 1;
                    v[i] = 0;
                }
            }

            foreach (var m in weights)
            {
                for (int y = 0; y < m.RowCount; y++)
                {
                    for (int x = 0; x < m.ColumnCount; x++)
                    {
                        //m[y, x] = (rand.NextDouble() * 2) - 1;
                        m[y, x] = 0;
                    }
                }
            }
        }

        public Vector<double> GetOutput()
        {
            return outputs.Last().Clone();
        }

        public void BackProp(Vector<double> error)
        {
            var gradient = GetFirstGradient(error, inputs.Last());

            for (int l = layerSizes.Length - 2; l > 0; l--)
            {
                for (int n = 0; n < weights[l].RowCount; n++)
                {
                    for (int w = 0; w < weights[l].ColumnCount; w++)
                    {
                        weights[l][n, w] -= learningRate * gradient[n] * outputs[l][w];
                        biases[l][n] -= learningRate * gradient[n];
                    }
                }

                gradient = GetGradient(gradient, weights[l], inputs[l - 1]);
            }
        }

        Vector<double> GetFirstGradient(in Vector<double> error, in Vector<double> vector)
        {
            var result = SigmoidDeriv(vector);

            for (int i = 0; i < vector.Count; i++)
            {
                result[i] = error[i] * result[i];
            }
            return result;
        }

        Vector<double> GetGradient(in Vector<double> prevGradient, in Matrix<double> weight, in Vector<double> vector)
        {
            var result = vector.Clone();
            var deriv = SigmoidDeriv(vector);

            for (int i = 0; i < vector.Count; i++)
            {
                double sigma = 0;
                for (int j = 0; j < prevGradient.Count; j++)
                {
                    sigma += prevGradient[j] * weight[j, i];
                }

                result[i] = sigma * deriv[i];
            }

            return result;
        }

        Vector<double> Sigmoid(in Vector<double> vector)
        {
            var result = vector.Clone();
            for (int i = 0; i < vector.Count; i++)
            {
                result[i] = 1 / (1 + Math.Exp(-vector[i]));
            }
            return result;
        }

        Vector<double> SigmoidDeriv(in Vector<double> vector)
        {
            var sigm = Sigmoid(vector);
            var result = vector.Clone();
            for (int i = 0; i < vector.Count; i++)
            {
                result[i] = sigm * (1 - sigm);
            }
            return result;
        }
    }
}
