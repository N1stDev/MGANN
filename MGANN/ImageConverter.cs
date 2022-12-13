using SFML.Graphics;

namespace MGANN
{
     class ImageConverter
     {
        string path = "C:\\Users\\timot\\Desktop\\gradient.png";
        int n;
        uint[,] imageArr;

        public ImageConverter()
        {
            n = 100;
            imageArr = new uint[n, n];
        }

        public uint[,] convert()
        {
            Image img = new(path);

            for (uint x=0; x<1270; x++)
            {
                for (uint y=0; y<1; y++)
                {
                    imageArr[x, y] = img.GetPixel(x, y).ToInteger();
                    Console.WriteLine(imageArr[x, y]);
                }
            }

            return imageArr;
        }
     }
}
