using System;

namespace Neural_Network
{
    public class Program
    {
        static NeuralNetwork network;
        static void Main(string[] args)
        {
            network = new NeuralNetwork(3, 3);

            Console.WriteLine("Current weight before training");
            MatrixEngine.PrintMatrix(network.SynapsesMatrix);
            double[,] trainingInputs = { { 0, 0, 1}, { 1, 1, 1} , {1, 0, 1} };

            double[,] trainingOutputs = MatrixEngine.MatrixTranspose( new double[,] { { 0, 1, 1, 0} });

            Console.WriteLine("Training . . .");
            network.Train(trainingInputs, trainingOutputs, 10000);

            MatrixEngine.PrintMatrix(network.SynapsesMatrix);

            // testing

            var output = network.Think(new double[,] { { 1, 0, 0 } });

            Console.WriteLine("\nSynaptic weight after training");
            Console.Read();
        }
    }
}
