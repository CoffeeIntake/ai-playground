namespace ToxicPredictor.ModelRebuilder
{
    using System;
    using ToxicPredictor.ConsoleApp;

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
