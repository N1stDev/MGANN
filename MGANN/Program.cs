using mnd = MathNet.Numerics.LinearAlgebra.Double;
using mn = MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra;

class Network
{
    mn.Vector<double> inputLayer;

    // Первое значение размера - количество строк
    // - количество нейронов в текущем слое
    // Второе значение размера - количество столбцов
    // - количество нейронов в предыдущем слое

    List<mn.Matrix<double>> weightMatrices;
    List<mn.Vector<double>> biasVectors;

    public Network(int inputLayerSize)
    {
        inputLayer = mnd.Vector.Build.Dense(inputLayerSize);

        weightMatrices = new();
        biasVectors = new();
    }

    public void AddLayer(int layerSize)
    {
        int previousLayerSize = 0;

        if (!weightMatrices.Any())
            previousLayerSize = inputLayer.Count;
        else
            previousLayerSize = weightMatrices.Last().RowCount;

        var weightMatrix = mnd.Matrix.Build.Random(layerSize, previousLayerSize);
        var biasVector = mnd.Vector.Build.Random(layerSize);

        weightMatrices.Add(weightMatrix);
        biasVectors.Add(biasVector);
    }

    public void SetIput(mn.Vector<double> input)
    {
        inputLayer = input;
    }

    public Vector<double> GetOutput()
    {
        Vector<double> tempOutput;

        tempOutput = Sigmoid(inputLayer);

        for (int i = 0; i < weightMatrices.Count; i++)
        {
            tempOutput = Sigmoid(weightMatrices[i] * tempOutput - biasVectors[i]);
        }

        return tempOutput;
    }

    Vector<double> Sigmoid(mn.Vector<double> input)
    {
        mn.Vector<double> outputVector = input.Clone();

        for (int i = 0; i < outputVector.Count; i++)
        {
            outputVector[i] = SigmoidSingle(outputVector[i]);
        }

        return outputVector;

        double SigmoidSingle(double x)
        {
            return 1 / (1 + Math.Exp(x));
        }
    }
}

class Program
{
    static void Main()
    {
        Network network = new(3);

        network.AddLayer(3);
        network.AddLayer(3);
        network.AddLayer(3);

        Vector<double> input = mnd.Vector.Build.Dense(3);
        Vector<double> output;

        input[0] = 1;
        input[1] = 2;
        input[2] = 3;

        network.SetIput(input);
        output = network.GetOutput();

        Console.WriteLine(output);

    }
}
