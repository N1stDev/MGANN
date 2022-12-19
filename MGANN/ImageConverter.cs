using MathNet.Numerics.LinearAlgebra.Complex;
using SFML.Graphics;
using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;

namespace MGANN
{
     class ImageConverter
     {
        int n, m;
        public Vector<double> imageVec;

        public ImageConverter()
        {
            n = 412;
            m = 511;
            int k = n * m;
            imageVec = mnd.DenseVector.Create(k, 0);
        }

        public void convert(string path)
        {
            Image img = new(path);

            for (uint x=0; x<n; x++)
            {
                for (uint y=0; y<m; y++)
                {
                    int r = img.GetPixel(x, y).R;
                    int g = img.GetPixel(x, y).G;
                    int b = img.GetPixel(x, y).B;
                    double res = 256 * 256 * r + 256 * g + b;
                    res /= 256 * 256 * 255 + 256 * 255 + 255;
                    imageVec[(int)x * n + (int)y] = res;
                }
            }
        }
     }
}
