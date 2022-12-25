using MathNet.Numerics.LinearAlgebra;
using mnd = MathNet.Numerics.LinearAlgebra.Double;

namespace MGANN
{
    public class CNN
    {
        void ForwardPropogation()
        {

        }

        void BackPropogation()
        {

        }

        void Train()
        {

        }
    }

    public class ConvolutionLayer
    {
        int kernelNum, kernelSize;
        List<Matrix<double>> kernels;
        Matrix<double> image;

        public ConvolutionLayer(int kernelNum, int kernelSize)
        {
            this.kernelNum = kernelNum;
            this.kernelSize = kernelSize;
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

        List<Matrix<double>> ForwardPropogation(Matrix<double> image)
        {
            int imageHeight = image.RowCount;
            int imageWidth = image.ColumnCount;
            int listLen = imageHeight - kernelSize + 1;
            List<Matrix<double>> convolutionOutput = new List<Matrix<double>>(listLen);
            for (int i = 0; i < listLen; i++)
            {
                convolutionOutput[i] = mnd.DenseMatrix.Create(imageWidth-kernelSize+1, kernelNum, 0);
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

        List<Matrix<double>> BackPropogation(List<Matrix<double>> dE_dY, double alpha)
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
                        kernels[i][j, k] = 2 * rand.NextDouble() - 1;
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
                    List<Matrix<double>> patch = new(kernelSize);
                    for (int k = 0; k < kernelSize; k++)
                    {
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

        List<Matrix<double>> ForwardPropogation(List<Matrix<double>> image)
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
                    double max = -99999;
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

        List<Matrix<double>> BackPropogation(List<Matrix<double>> dE_dY)
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
        Matrix<double> Weights;
        Vector<double> Biases;

        public SoftMaxLayer(int inputCount, int outputCount)
        {
            Biases = mnd.DenseVector.Create(outputCount, 0);
            Weights = mnd.DenseMatrix.Create(inputCount, outputCount, 0);
            SetWeightsRandom(inputCount);
        }

        void ForwardPropogation()
        {

        }

        void BackPropogation()
        {

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
