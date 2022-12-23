using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    public static void Main()
    {
        //Spectrogramm.Generate();
        //return;
        Network network = new(VARIABLES.XSIZE * VARIABLES.YSIZE, 100, 100, 10);

        network.Train();

        network.Test();
    }
}
