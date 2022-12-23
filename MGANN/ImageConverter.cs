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
            n = 103;
            m = 45;
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
                    double r = img.GetPixel(x, y).R;
                    imageVec[(int)x + (int)y * n] = r / 255;
                }
            }
        }
     }
}
