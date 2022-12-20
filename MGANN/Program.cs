using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    public static void Main()
    {
        //Spectogramm.Generate();
        Network network = new(13184, 40, 60, 40, 10);

        network.Train();

        network.Test();
    }
}
