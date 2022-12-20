using MathNet.Numerics.LinearAlgebra;
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

        double step = 0.05;

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
            ImageConverter converter = new();
            int genreIndex = 0;
            foreach (string genre in VARIABLES.GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(VARIABLES.SPECTROGRAMS_PATH + genre);
                FileInfo[] files = place.GetFiles();
                foreach (FileInfo i in files)
                {
                    string imagePath = place.ToString() + i.Name;
                    converter.convert(imagePath);
                    Vector<double> expectedResult = mnd.DenseVector.Create(10, 0);
                    expectedResult[genreIndex] = 1;
                    BackProp(converter.imageVec, expectedResult);
                }
                genreIndex++;
            }
        }

        public void Test()
        {
            ImageConverter converter = new();
            int genreIndex = 1;
            foreach (string genre in VARIABLES.GENRES)
            {
                DirectoryInfo place = new DirectoryInfo(VARIABLES.SPECTROGRAMS_PATH + genre);
                FileInfo[] files = place.GetFiles();
                foreach (FileInfo i in files)
                {
                    string imagePath = place.ToString() + i.Name;
                    converter.convert(imagePath);
                    RunForward(converter.imageVec);

                    Console.WriteLine($"{outputs.Last().MaximumIndex()+1}, {genreIndex}");
                }
                genreIndex++;
            }
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
                    v[i] = (rand.NextDouble() * 2) - 1;
                }
            }

            foreach (var m in weights)
            {
                for (int y = 0; y < m.RowCount; y++)
                {
                    for (int x = 0; x < m.ColumnCount; x++)
                    {
                        m[y, x] = (rand.NextDouble() * 2) - 1;
                    }
                }
            }
        }

        public Vector<double> GetOutput()
        {
            return outputs.Last().Clone();
        }

        public void BackProp(Vector<double> inputLayer, Vector<double> expectedResult)
        {
            RunForward(inputLayer);
            var error = outputs.Last() - expectedResult;

            var gradient = GetFirstGradient(error, inputs.Last());

            for (int l = layerSizes.Length - 2; l > 0; l--)
            {
                for (int n = 0; n < weights[l].RowCount; n++)
                {
                    for (int w = 0; w < weights[l].ColumnCount; w++)
                    {
                        weights[l][n, w] -= step * gradient[n] * outputs[l][w];
                        biases[l][n] -= step * gradient[n];
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
                    try
                    {
                        sigma += prevGradient[j] * weight[j, i];
                    }
                    catch {
                        Console.WriteLine($"{j}, {i}, {weight.ColumnCount}, {weight.RowCount}, {vector.Count}");
                        throw;
                    }
                    
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
