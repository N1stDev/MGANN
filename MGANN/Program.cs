using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    public static void Main()
    {
        Network network = new(210532, 6, 6, 10);

        network.Train();
    }
}
