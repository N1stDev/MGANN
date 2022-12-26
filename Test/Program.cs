using MathNet.Numerics.LinearAlgebra;
using MGANN;
using Tensorflow;

namespace Test
{
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(FormsSharedData.mainForm);
        }
    }
}