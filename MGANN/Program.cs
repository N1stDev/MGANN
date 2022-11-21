
using MathNet.Numerics.LinearAlgebra.Double;

class NetWork
{
    
}

class Program
{
    static void Main()
    {
        var vector1 = Vector.Build.Dense(3);
        vector1[0] = 5;
        vector1[1] = 3;
        vector1[2] = 1;

        var matrix1 = Matrix.Build.Dense(3, 3);
        matrix1[0, 0] = 1;
        matrix1[1, 1] = 3;
        matrix1[2, 2] = 2;
        var vector2 = matrix1 * vector1;

        Console.WriteLine(matrix1);
        Console.WriteLine(vector2);
    }
}
