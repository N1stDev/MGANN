﻿using MathNet.Numerics.LinearAlgebra.Complex;
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
            n = VARIABLES.XSIZE;
            m = VARIABLES.YSIZE;
            int k = n * m;
            imageVec = mnd.DenseVector.Create(k, 0);
        }

        public void convert(string path)
        {
            Image img = new(path);

            for (uint y = 0; y < VARIABLES.YSIZE; y++)
            {
                for (uint x = 0; x < VARIABLES.XSIZE; x++)
                {
                    double r = img.GetPixel(x, y).R;
                    imageVec[(int)x + (int)y * (int)VARIABLES.XSIZE] = r / 255;
                }
            }
        }
     }
}
