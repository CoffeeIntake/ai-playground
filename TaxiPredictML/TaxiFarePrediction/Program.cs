using System;
using TaxiFarePredictionML.Model;

namespace TaxiFarePrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            float distance = 0;

            Console.WriteLine("Please enter trip distance in miles to calculate taxi fare:");
            distance = Console.Read();

            // Create sample data
            ModelInput input = new ModelInput()
            {
                Vendor_id = "CMT",
                Rate_code = 1,
                Passenger_count = 1,
                Trip_distance = distance,
                Payment_type = "CRD"
            };
            // Make prediction
            ModelOutput prediction = ConsumeModel.Predict(input);

            // Print Prediction
            Console.WriteLine($"Predicted Fare: {prediction.Score}");
            Console.ReadKey();

        }
    }
}
