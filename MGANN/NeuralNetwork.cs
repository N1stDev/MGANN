using MathNet.Numerics.LinearAlgebra;
using System;
using System.Drawing;
using mnd = MathNet.Numerics.LinearAlgebra.Double;


namespace MGANN
{
    public class CNN
    {
        public Tuple<ConvolutionLayer, MaxPoolingLayer, SoftMaxLayer> layers;
        public CNN(int kernelsNum=16, int kernelsSize=3, int poolingKernelSize = 2, int outputSize=10)
        {
            int softInputSize = (int)Math.Pow((VARIABLES.SIZE - kernelsSize + 1) / 2, 2) * kernelsNum;
            layers = new(new ConvolutionLayer(kernelsNum, kernelsSize), new MaxPoolingLayer(poolingKernelSize), new SoftMaxLayer(softInputSize, outputSize));

        }
        (Vector<double>, double, int) RunForward(Matrix<double> image, int label)
        {
            Matrix<double> output1 = image.Divide(255);
            List<Matrix<double>> output2 = layers.Item1.ForwardPropogation(output1);
            List<Matrix<double>> output3 = layers.Item2.ForwardPropogation(output2);
            Vector<double> output4 = layers.Item3.ForwardPropogation(output3);

            double loss = -1 * Math.Log(output4[label]);
            int success = 0;
            if (output4.MaximumIndex() == label)
            {
                success = 1;
            }

            return (output4, loss, success);
        }

        int GetGenre(Matrix<double> image)
        {
            Matrix<double> output1 = image.Divide(255);
            List<Matrix<double>> output2 = layers.Item1.ForwardPropogation(output1);
            List<Matrix<double>> output3 = layers.Item2.ForwardPropogation(output2);
            Vector<double> output4 = layers.Item3.ForwardPropogation(output3);
            return output4.MaximumIndex();
        }

        List<Matrix<double>> BackPropogation(Vector<double> gradient, double alpha)
        {
            Vector<double> gradientBack1 = gradient;
            List<Matrix<double>> gradientBack2 = layers.Item3.BackPropogation(gradientBack1, alpha);
            List<Matrix<double>> gradientBack3 = layers.Item2.BackPropogation(gradientBack2);
            List<Matrix<double>> gradientBack4 = layers.Item1.BackPropogation(gradientBack3, alpha);

            return gradientBack4;
        }

        public (double, int) Train(Matrix<double> image, int label, double alpha=0.00001)
        {
            (Vector<double>, double, int) resForward = RunForward(image, label);

            Vector<double> gradient = mnd.DenseVector.Create(10, 0);

            gradient[label] = -1 / resForward.Item1[label];

            List<Matrix<double>> gradientBack = BackPropogation(gradient, alpha);

            return (resForward.Item2, resForward.Item3);
        }

        public void SaveConfiguration()
        {
            Console.WriteLine("Saving...");
            var kernels = layers.Item1.kernels;
            using (StreamWriter sw = new(VARIABLES.NETWORK_DATA_PATH + "\\kernels.txt"))
            {
                for (int i = 0; i < kernels.Count; i++)
                {
                    for (int j = 0; j < kernels[0].RowCount; j++)
                    {
                        for (int k = 0; k < kernels[0].ColumnCount; k++)
                        {
                            sw.WriteLine(kernels[i][j, k]);
                        }
                    }
                }
            }

            var weights = layers.Item3.Weights;
            var biases = layers.Item3.Biases;

            using (StreamWriter sw = new(VARIABLES.NETWORK_DATA_PATH + "\\weights.txt"))
            {
                for (int i = 0; i < weights.RowCount; i++)
                {
                    for (int j = 0; j < weights.ColumnCount; j++)
                    {
                        sw.WriteLine(weights[i, j]);
                    }
                }
            }

            using (StreamWriter sw = new(VARIABLES.NETWORK_DATA_PATH + "\\biases.txt"))
            {
                for (int i = 0; i < biases.Count; i++)
                {
                    sw.WriteLine(biases[i]);
                }
            }
        }

        public void UploadConfiguration()
        {
            using (StreamReader sr = new(VARIABLES.NETWORK_DATA_PATH + "\\kernels.txt"))
            {
                for (int i = 0; i < layers.Item1.kernels.Count; i++)
                {
                    for (int j = 0; j < layers.Item1.kernels[0].RowCount; j++)
                    {
                        for (int k = 0; k < layers.Item1.kernels[0].ColumnCount; k++)
                        {
                            layers.Item1.kernels[i][j, k] = double.Parse(sr.ReadLine());
                        }
                    }
                }
            }

            using (StreamReader sr = new(VARIABLES.NETWORK_DATA_PATH + "\\weights.txt"))
            {
                for (int i = 0; i < layers.Item3.Weights.RowCount; i++)
                {
                    for (int j = 0; j < layers.Item3.Weights.ColumnCount; j++)
                    {
                        layers.Item3.Weights[i, j] = double.Parse(sr.ReadLine());
                    }
                }
            }

            using (StreamReader sr = new(VARIABLES.NETWORK_DATA_PATH + "\\biases.txt"))
            {
                for (int i = 0; i < layers.Item3.Biases.Count; i++)
                {
                    layers.Item3.Biases[i] = double.Parse(sr.ReadLine());
                }
            }

        }

        public string DetectGenre(Bitmap spectrogram)
        {
            Bitmap image = new(ImagePath);
            image = new Bitmap(image, new Size(VARIABLES.SIZE, VARIABLES.SIZE));
            Matrix<double> singleCase = mnd.DenseMatrix.Create(VARIABLES.SIZE, VARIABLES.SIZE, 0);

            for (int y = 0; y < singleCase.RowCount; y++)
            {
                for (int x = 0; x < singleCase.ColumnCount; x++)
                {
                    singleCase[y, x] = image.GetPixel(x, y).R;
                }
            }

            int genreIndex = GetGenre(singleCase);

            return VARIABLES.GENRES[genreIndex];
        }
    }

    public class ConvolutionLayer
    {
        int kernelNum, kernelSize;
        public List<Matrix<double>> kernels;
        Matrix<double> image;

        public ConvolutionLayer(int kernelNum, int kernelSize)
        {
            this.kernelNum = kernelNum;
            this.kernelSize = kernelSize;
            kernels = new();
            SetKernelsRandom();
        }

        List<(Matrix<double>, int, int)> PatchesGenerator(Matrix<double> image)
        {
            int imageHeight = image.RowCount;
            int imageWidth = image.ColumnCount;
            this.image = image;
            List<(Matrix<double>, int, int)> patches = new();

            for (int i = 0; i < imageHeight - kernelSize + 1; i++)
            {
                for (int j = 0; j < imageWidth - kernelSize + 1; j++)
                {
                    Matrix<double> patch = mnd.DenseMatrix.Create(kernelSize, kernelSize, 0);
                    for (int k = 0; k < kernelSize; k++)
                    {
                        for (int l = 0; l < kernelSize; l++)
                        {
                            patch[l, k] = image[i + k, j + l];
                        }
                    }
                    patches.Add((patch, i, j));
                }
            }

            return patches;
        }

        public List<Matrix<double>> ForwardPropogation(Matrix<double> image)
        {
            int imageHeight = image.RowCount;
            int imageWidth = image.ColumnCount;
            int listLen = imageHeight - kernelSize + 1;
            List<Matrix<double>> convolutionOutput = new();
            for (int i = 0; i < listLen; i++)
            {
                convolutionOutput.Add(mnd.DenseMatrix.Create(imageWidth-kernelSize+1, kernelNum, 0));
            }
            var patches = PatchesGenerator(image);
            foreach (var el in patches)
            {
                var patch = el.Item1;
                int h = el.Item2;
                int w = el.Item3;
                List<double> sumList = new();
                for (int i = 0; i < kernelNum; i++)
                {
                    Matrix<double> multiplyRes = patch * kernels[i];
                    double sum = 0;
                    for (int r = 0; r < multiplyRes.RowCount; r++)
                    {
                        for (int c = 0; c < multiplyRes.ColumnCount; c++)
                        {
                            sum += multiplyRes[r, c];
                        }
                    }
                    sumList.Add(sum);
                }

                for (int i = 0; i < convolutionOutput[h].ColumnCount; i++)
                {
                    convolutionOutput[h][w, i] = sumList[i];
                }
            }

            return convolutionOutput;
        }

        public List<Matrix<double>> BackPropogation(List<Matrix<double>> dE_dY, double alpha)
        {
            List<Matrix<double>> dE_dK = new();
            for (int i = 0; i < kernelNum; i++) dE_dK.Add(mnd.DenseMatrix.Create(kernelSize, kernelSize, 0));

            var patches = PatchesGenerator(image);
            foreach (var el in patches)
            {
                var patch = el.Item1;
                int h = el.Item2;
                int w = el.Item3;
                for (int i = 0; i < kernelNum; i++)
                {
                    dE_dK[i] += patch * dE_dY[h][w, i];
                }
            }

            for (int i = 0; i < kernelNum; i++)
            {
                kernels[i] -= alpha * dE_dK[i];
            }

            return dE_dK;
        }

        void SetKernelsRandom()
        {
            Random rand = new();
            for (int i = 0; i < kernelNum; i++)
            {
                kernels.Add(mnd.DenseMatrix.Create(kernelSize, kernelSize, 0));
                for (int j = 0; j < kernelSize; j++)
                {
                    for (int k = 0; k < kernelSize; k++)
                    {
                        kernels[i][j, k] = (2 * rand.NextDouble() - 1) / Math.Pow(kernelSize, 2);
                    }
                }
            }
        }
    }

    public class MaxPoolingLayer
    {
        int kernelSize;
        List<Matrix<double>> image;

        public MaxPoolingLayer(int kernelSize)
        {
            this.kernelSize = kernelSize;
        }

        List<(List<Matrix<double>>, int, int)> PatchesGenerator(List<Matrix<double>> image)
        {
            int outputHeight = image.Count / kernelSize;
            int outputWidth = image[0].RowCount / kernelSize;
            int num = image[0].ColumnCount;
            this.image = image;

            List<(List<Matrix<double>>, int, int)> patches = new();

            for (int i = 0; i < outputHeight; i++)
            {
                for (int j = 0; j < outputWidth; j++)
                {
                    List<Matrix<double>> patch = new();
                    for (int k = 0; k < kernelSize; k++)
                    {
                        patch.Add(mnd.DenseMatrix.Create(kernelSize, num, 0));
                        for (int l = 0; l < kernelSize; l++)
                        {
                            for (int m = 0; m < num; m++)
                            {
                                patch[k][l, m] = image[i * kernelSize + k][j * kernelSize + l, m];
                            }
                            
                        }
                    }
                    patches.Add((patch, i, j));
                }
            }

            return patches;
        }

        public List<Matrix<double>> ForwardPropogation(List<Matrix<double>> image)
        {
            int imageHeight = image.Count;
            int imageWidth = image[0].RowCount;
            int kernelNum = image[0].ColumnCount;

            List<Matrix<double>> MaxPoolingOutput = new();

            for (int i = 0; i < imageHeight / kernelSize; i++)
            {
                MaxPoolingOutput.Add(mnd.DenseMatrix.Create(imageWidth / kernelSize, kernelNum, 0));
            }

            var patches = PatchesGenerator(image);

            foreach (var el in patches)
            {
                var patch = el.Item1;
                int h = el.Item2;
                int w = el.Item3;
                List<double> maxList = new();
                for (int index = 0; index < patch[0].ColumnCount; index++)
                {
                    double max = -9999;
                    for (int i = 0; i < patch.Count; i++)
                    {
                        for (int j = 0; j < patch[0].RowCount; j++)
                        {
                            if (patch[i][j, index] > max)
                            {
                                max = patch[i][j, index];
                            }
                        }
                    }
                    maxList.Add(max);
                }
                
                for (int i = 0; i < MaxPoolingOutput[0].ColumnCount; i++)
                {
                    MaxPoolingOutput[h][w, i] = maxList[i];
                }
            }

            return MaxPoolingOutput;
        }

        public List<Matrix<double>> BackPropogation(List<Matrix<double>> dE_dY)
        {
            List<Matrix<double>> dE_dK = new();
            for (int i = 0; i < image.Count; i++)
            {
                dE_dK.Add(mnd.DenseMatrix.Create(image[0].RowCount, image[0].ColumnCount, 0));
            }

            var patches = PatchesGenerator(image);

            foreach (var el in patches)
            {
                var patch = el.Item1;
                int h = el.Item2;
                int w = el.Item3;
                int imageHeight = patch.Count;
                int imageWidth = patch[0].RowCount;
                int kernelNum = patch[0].ColumnCount;
                List<double> maxList = new();
                for (int index = 0; index < kernelNum; index++)
                {
                    double max = -99999;
                    for (int i = 0; i < imageHeight; i++)
                    {
                        for (int j = 0; j < imageWidth; j++)
                        {
                            if (patch[i][j, index] > max)
                            {
                                max = patch[i][j, index];
                            }
                        }
                    }
                    maxList.Add(max);
                }

                for (int i = 0; i < imageHeight; i++)
                {
                    for (int j = 0; j < imageWidth; j++)
                    {
                        for (int k = 0; k < kernelNum; k++)
                        {
                            if (patch[i][j, k] == maxList[k])
                            {
                                dE_dK[h * kernelSize + i][w * kernelSize + j, k] = dE_dY[h][w, k];
                            }
                        }
                    }
                }

                return dE_dK;
            }
            return dE_dK;
        }

    }

    public class SoftMaxLayer
    {
        public Matrix<double> Weights;
        public Vector<double> Biases;
        (int, int, int) size;
        Vector<double> inputVector;
        Vector<double> outputVector;

        public SoftMaxLayer(int inputCount, int outputCount)
        {
            Biases = mnd.DenseVector.Create(outputCount, 0);
            Weights = mnd.DenseMatrix.Create(inputCount, outputCount, 0);
            SetWeightsRandom(inputCount);
        }

        public Vector<double> ForwardPropogation(List<Matrix<double>> image)
        {
            size = (image.Count, image[0].RowCount, image[0].ColumnCount);
            Vector<double> imageVector = mnd.DenseVector.Create(size.Item1 * size.Item2 * size.Item3, 0);
            int vectorIndex = 0;

            for (int i = 0; i < size.Item1; i++)
            {
                for (int j = 0; j < size.Item2; j++)
                {
                    for (int k = 0; k < size.Item3; k++)
                    {
                        imageVector[vectorIndex] = image[i][j, k];
                        vectorIndex++;
                    }
                }
            }

            inputVector = imageVector;

            Vector<double> firstOutput = imageVector * Weights + Biases;
            outputVector = firstOutput;

            Vector<double> softMaxOutput = firstOutput;

            double divider = 0;

            for (int i = 0; i < softMaxOutput.Count; i++)
            {
                softMaxOutput[i] = Math.Exp(softMaxOutput[i]);

                divider += softMaxOutput[i];
            }

            for (int i = 0; i < softMaxOutput.Count; i++)
            {
                softMaxOutput[i] /= divider;
            }

            return softMaxOutput;
        }

        public List<Matrix<double>> BackPropogation(Vector<double> dE_dY, double alpha)
        {
            for (int i = 0; i < dE_dY.Count; i++)
            {
                if (dE_dY[i] == 0)
                {
                    continue;
                }

                Vector<double> transformationEq = mnd.DenseVector.Create(outputVector.Count, 0);
                double totalSum = 0;
                for (int j = 0; j < transformationEq.Count; j++)
                {
                    transformationEq[j] = Math.Exp(outputVector[j]);
                    totalSum += transformationEq[j];

                }

                Vector<double> dY_dZ = transformationEq.Multiply(-transformationEq[i]).Divide(Math.Pow(totalSum, 2));
                dY_dZ[i] = transformationEq[i] * (totalSum - transformationEq[i]) / Math.Pow(totalSum, 2);

                Vector<double> dZ_dW = inputVector;
                int dZ_dB = 1;
                Matrix<double> dZ_dX = Weights;

                Vector<double> dE_dZ = dY_dZ.Multiply(dE_dY[i]);

                Matrix<double> dZ_dW_Matrix = mnd.DenseMatrix.Create(dZ_dW.Count, 1, 0);

                for (int j = 0; j < dZ_dW_Matrix.RowCount; j++)
                {
                    dZ_dW_Matrix[j, 0] = dZ_dW[j];
                }

                Matrix<double> dE_dZ_Matrix = mnd.DenseMatrix.Create(1, dE_dZ.Count, 0);
                for (int j = 0; j < dE_dZ_Matrix.ColumnCount; j++)
                {
                    dE_dZ_Matrix[0, j] = dE_dZ[j];
                }
                Matrix<double> dE_dW = dZ_dW_Matrix * dE_dZ_Matrix;

                Vector<double> dE_dB = dE_dZ * dZ_dB;

                Matrix<double> dE_dZ_Matrix2 = mnd.DenseMatrix.Create(dE_dZ.Count, 1, 0);
                for (int j = 0; j < dE_dZ_Matrix2.RowCount; j++)
                {
                    dE_dZ_Matrix2[j, 0] = dE_dZ[j];
                }

                Matrix<double> dE_dX = dZ_dX * dE_dZ_Matrix2;

                Weights -= dE_dW.Multiply(alpha);
                Biases -= dE_dB.Multiply(alpha);

                List<Matrix<double>> dE_dX_reshape = new();
                int counter = 0;
                for (int j = 0; j < size.Item1; j++)
                {
                    dE_dX_reshape.Add(mnd.DenseMatrix.Create(size.Item2, size.Item3, 0));
                    for (int k = 0; k < size.Item2; k++)
                    {
                        for (int l = 0; l < size.Item3; l++)
                        {
                            dE_dX_reshape[j][k, l] = dE_dX[counter, 0];
                            counter++;
                        }
                    }
                }

                return dE_dX_reshape;
            }
            
            return new List<Matrix<double>>();
        }

        void SetWeightsRandom(int inputCount)
        {
            Random rand = new();
            for (int i = 0; i < Weights.RowCount; i++)
            {
                for (int j = 0; j < Weights.ColumnCount; j++)
                {
                    Weights[i, j] = (2 * rand.NextDouble() - 1) / inputCount;
                }
            }
        }
    }
}
