using SFML.Graphics;

namespace MGANN
{
     class ImageConverter
     {
        string path = "C:\\Users\\timot\\Desktop\\car.jpg";
        int n;
        uint[,] imageArr;

        public ImageConverter()
        {
            n = 112;
            imageArr = new uint[n, n];
        }

        public uint[,] convert(string filePath)
        {
            Image img = new(path);

            for (uint x=0; x<n; x++)
            {
                for (uint y=0; y<n; y++)
                {
                    imageArr[x, y] = img.GetPixel(x, y).ToInteger();
                    Console.WriteLine(imageArr[x, y]);
                }
            }

            return imageArr;
        }
     }
}
