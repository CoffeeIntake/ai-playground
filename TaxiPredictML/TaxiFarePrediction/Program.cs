using System;
using TaxiFarePredictionML.Model;

namespace TaxiFarePrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create sample data
            ModelInput input = new ModelInput()
            {
                Vendor_id = "CMT",
                Rate_code = 1,
                Passenger_count = 1,
                Trip_distance = 3.8f,
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
