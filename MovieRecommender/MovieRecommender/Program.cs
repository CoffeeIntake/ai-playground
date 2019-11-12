namespace MovieRecommender
{
    using System;
    using System.IO;
    using Microsoft.ML;
    using Microsoft.ML.Trainers;
    
    class Program
    {
        static void Main(string[] args)
        {
            ModelBuilder.CreateModel();
        }        
    }
}
