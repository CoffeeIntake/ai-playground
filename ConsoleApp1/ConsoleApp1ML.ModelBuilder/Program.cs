namespace ConsoleApp1ML.ModelRebuilder
{
    using ConsoleApp1ML.ConsoleApp;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Rebuilding model");

            // Rebuild the model
            ModelBuilder.CreateModel();

            Console.WriteLine("Model has been rebuilt");
        }
    }
}
