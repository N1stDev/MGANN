using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;

class Program
{
    static public void Main()
    {

        Spectogramm sp = new();
        sp.Generate();
        Random rand = new();

        Network network = new(5, 6, 6, 10);
        network.SetRandom();

        Vector<double> input = mnd.DenseVector.Create(5, 0);

        for (int i = 0; i < input.Count; i++)
        {
            input[i] = (rand.NextDouble() * 2) - 1;
        }

        network.RunForward(input);

        Vector<double> expectedOutput = mnd.DenseVector.Create(10, 0);
        expectedOutput[1] = 1;
        expectedOutput[5] = 1;

        for (int i = 0; i < 1000; i++)
        {
            network.BackProp(expectedOutput);
            network.RunForward(input);
            Console.WriteLine(network.GetOutput());
        }
    }
}
