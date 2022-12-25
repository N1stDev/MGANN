using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using mnd = MathNet.Numerics.LinearAlgebra.Double;

namespace MGANN
{
    class Data
    {
        public List<Matrix<double>> cases;
        public List<int> answers;
        public Data()
        {
            answers = new();
            cases = new();
            for (int i = 0; i < VARIABLES.GENRES.Length; i++)
            {
                string genrePath = VARIABLES.SPECTROGRAMS_PATH + VARIABLES.GENRES[i];
                DirectoryInfo dir = new DirectoryInfo(genrePath);
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    string filePath = dir.ToString() + file.Name;
                    Bitmap image = new(filePath);
                    image = new Bitmap(image, new Size(VARIABLES.SIZE, VARIABLES.SIZE));
                    Matrix<double> singleCase = mnd.DenseMatrix.Create(VARIABLES.SIZE, VARIABLES.SIZE, 0);

                    for (int y = 0; y < singleCase.RowCount; y++)
                    {
                        for (int x = 0; x < singleCase.ColumnCount; x++)
                        {
                            singleCase[y, x] = image.GetPixel(x, y).R;
                        }
                    }
                    cases.Add(singleCase);
                    answers.Add(i);
                }
            }
        }
    }
}
