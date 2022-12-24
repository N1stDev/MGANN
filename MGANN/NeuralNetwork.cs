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
                for (int i = 0; i < kernelNum; i++)
                {
                    convolutionOutput[i] = patch * kernels[i];
                }
                double[] 
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
        public MaxPoolingLayer()
        {

        }

        void PatchesGenerator()
        {

        }

        void ForwardPropogation()
        {

        }

        void BackPropogation()
        {

        }

    }

    public class SoftMaxLayer
    {
        public SoftMaxLayer()
        {

        }

        void ForwardPropogation()
        {

        }

        void BackPropogation()
        {

        }
    }
}
