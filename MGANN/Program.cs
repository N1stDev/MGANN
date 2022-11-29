using mnd = MathNet.Numerics.LinearAlgebra.Double;
using mn = MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra;
using System.Data.Common;
using System.Reflection.Emit;

class Network
{
    mn.Vector<double> inputLayer;

    // Первое значение размера - количество строк
    // - количество нейронов в текущем слое
    // Второе значение размера - количество столбцов
    // - количество нейронов в предыдущем слое

    List<mn.Matrix<double>> weightMatrices;
    List<mn.Vector<double>> biasVectors;

    List<mn.Vector<double>> deltaVectors;

    List<mn.Vector<double>> outputVectors;

    public Network(int inputLayerSize)
    {
        inputLayer = mnd.Vector.Build.Dense(inputLayerSize);

        weightMatrices = new();
        biasVectors = new();
        deltaVectors = new();

        outputVectors = new();
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

        var delta_weightMatrix = mnd.Matrix.Build.Dense(layerSize, previousLayerSize);
        var delta_biasVector = mnd.Vector.Build.Dense(layerSize);

        weightMatrices.Add(weightMatrix);
        biasVectors.Add(biasVector);
        deltaVectors.Add(mnd.Vector.Build.Dense(layerSize));
        outputVectors.Add(mnd.Vector.Build.Dense(layerSize));
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
            outputVectors[i] = tempOutput;
        }

        
        return tempOutput;
    }

    public void BackPropagate(double learningRate, mn.Vector<double> desiredOutput)
    {
        foreach(var el in weightMatrices)
        {
            Console.WriteLine(el);
        }
        // Перебираем нейроны выходного слоя
        for (int neuron = 0; neuron < deltaVectors.Last().Count; neuron++)
        {
            double a = outputVectors.Last()[neuron];

            deltaVectors.Last()[neuron]
                = SigmoidDeriv(a) * 2 * (desiredOutput[neuron] - a);
        }

        // Вычисляем дельты для остальных слоев
        for (int layer = deltaVectors.Count - 2; layer > 0; layer--)
        {
            for (int neuron = 0; neuron < deltaVectors[layer].Count; neuron++)
            {
                // Для каждого нейрона текущего слоя необходимо вычислить следующюю сумму
                double sum = 0;
                for (int i = 0; i < deltaVectors[layer + 1].Count; i++)
                {
                    sum += deltaVectors[layer + 1][i] * weightMatrices[layer + 1][i, neuron];
                }

                double a = outputVectors.Last()[neuron];
    
                deltaVectors[layer][neuron] = SigmoidDeriv(a) * sum;
            }
        }

        // Теперь применяем изменения для всех весов и байасов
        for (int layer = deltaVectors.Count - 1; layer > 1; layer--)
        {
            for (int row = 0; row < weightMatrices[layer].RowCount; row++)
            {
                biasVectors[layer][row]
                        -= learningRate * deltaVectors[layer][row];

                for (int column = 0; column < weightMatrices[layer].ColumnCount; column++)
                {
                    weightMatrices[layer][row, column]
                        -= learningRate * deltaVectors[layer][row] * outputVectors[layer - 1][column];
                }
            }
        }

        // Повторяем вычисления для весов и байасов первого спрятанного слоя
        for (int row = 0; row < weightMatrices[0].RowCount; row++)
        {
            biasVectors[0][row]
                    -= learningRate * deltaVectors[0][row];

            for (int column = 0; column < weightMatrices[0].ColumnCount; column++)
            {
                weightMatrices[0][row, column]
                -= learningRate * deltaVectors[0][row] * inputLayer[column];
            }
        }
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

    double SigmoidDeriv(double input)
    {
        return input * (1 - input);
    }
}

class Program
{
    static void Main()  // TODO не меняет матрицы
    {
        Network network = new(3);


        network.AddLayer(3);
        network.AddLayer(3);

        Vector<double> input = mnd.Vector.Build.Dense(3);
        Vector<double> output;
        Random random = new();

        for (int i = 0; i < 10; i++)
        {
            input[0] = random.NextDouble();
            input[1] = random.NextDouble();
            input[2] = random.NextDouble();

            //Console.WriteLine("{0}, {1}, {2}", input[0], input[1], input[2]);

            network.SetIput(input);
            output = network.GetOutput();

            //Console.WriteLine(output);

            network.BackPropagate(0.1, input);

            
        }
        input[0] = 0.1;
        input[1] = 0.2;
        input[2] = 0.3;
        output = network.GetOutput();
        Console.WriteLine(output);
    }
}
