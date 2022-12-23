using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    public static void Main()
    {
        //Spectrogramm.Generate();
        Network network = new(4635, 200, 100, 50, 10);

        network.Train();

        network.Test();
    }
}
