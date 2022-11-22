using mnd = MathNet.Numerics.LinearAlgebra.Double;
using mn = MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

class Network
{
    mn.Vector<double> inputLayer;

    // Первое значение размера - количество строк
    // - количество нейронов в текущем слое
    // Второе значение размера - количество столбцов
    // - количество нейронов в предыдущем слое

    List<mn.Matrix<double>> weightMatrices;

    public Network(int inputLayerSize, int numHiddenLayers)
    {
        inputLayer = mnd.Vector.Build.Dense(inputLayerSize);

        weightMatrices = new();
    }

    public void AddLayer(int layerSize)
    {
        int previousLayerSize = 0;

        if (!weightMatrices.Any())
            previousLayerSize = inputLayer.Count;
        else
            previousLayerSize = weightMatrices.Last().RowCount;

        var weightMatrix = mnd.Matrix.Build.Random(layerSize, previousLayerSize);
        weightMatrices.Add(weightMatrix);
    }

    public void SetIput(mn.Vector<double> input)
    {
        inputLayer = input;
    }
}

class Program
{
    static void Main()
    {
        var vector1 = mnd.Vector.Build.Dense(3);
        vector1[0] = 5;
        vector1[1] = 3;
        vector1[2] = 1;
        
        var matrix1 = mnd.Matrix.Build.Dense(3, 3);
        matrix1[0, 0] = 1;
        matrix1[1, 0] = 4;
        matrix1[1, 1] = 3;
        matrix1[2, 2] = 2;
        var vector2 = matrix1 * vector1;

        Console.WriteLine(vector1);
        Console.WriteLine(matrix1);
        Console.WriteLine(vector2);
    }
}
