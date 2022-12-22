using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    public static void Main()
    {
        //Spectrogramm.Generate();
        Network network = new(13184, 10, 10, 10, 10);

        network.Train();

        network.Test();
    }
}
