using mnd = MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MGANN;
using NAudio.Codecs;

class Program
{
    public static void FindGoldenConfiguration()
    {
        Data data = new Data();
        List<(Matrix<double>, int)> cases = new();
        Random random = new Random();
        CNN network = new();
        
        for (int i = 0; i < data.cases.Count; i++)
        {
            cases.Add((data.cases[i], data.answers[i]));
        }

        for (int epoch = 0; epoch < 5; epoch++)
        {
            Console.WriteLine($"Epoch #{epoch + 1}");
            var shuffledCases = cases.OrderBy(i => random.Next()).ToList();

            double loss = 0;
            int success = 0;

            for (int i = 0; i < shuffledCases.Count; i++)
            {
                if (i % 100 == 0)
                {
                    
                    Console.WriteLine($"Step {i + 1}: for the last 100 steps average loss = {loss / 100}, accuracy = {success}%");
                    if (success > VARIABLES.EnoughAccuracy)
                    {
                        network.SaveConfiguration();
                        return;
                    }
                    loss = 0;
                    success = 0;
                    
                }
                var res = network.Train(shuffledCases[i].Item1, shuffledCases[i].Item2);
                loss += res.Item1;
                success += res.Item2;
            }
        }
    }
    public static void Main()
    {
        FindGoldenConfiguration();            
    }
}
