using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public class NeuralNetwork
    {
        private Random _randomObj;
        public int SynapsesMatrixColums;
        public int SynapsesMatrixLines;
        public double[,] SynapsesMatrix;
        public NeuralNetwork(int synapsesMatrixColumns, int synapsesMatrixLines)
        {
            SynapsesMatrixColums = synapsesMatrixColumns;
            SynapsesMatrixLines = synapsesMatrixLines;

            Init();
        }

        private void Init()
        {
            _randomObj = new Random(1);
            _GenerateSynapsesMatrix();
        }

        private void _GenerateSynapsesMatrix()
        {
            SynapsesMatrix = new double[SynapsesMatrixLines, SynapsesMatrixColums];

            for(int i = 0; i < SynapsesMatrixLines; i++)
            {
                for(int j = 0; j < SynapsesMatrixColums; j++)
                {
                    SynapsesMatrix[i, j] = (2 * _randomObj.NextDouble()) - 1;
                }
            }
        }

        ///<summary>
        /// Calculate the sigmoid of a value
        /// </summary>
        /// 
        
        private double[,] _CalculateSigmoid(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    double value = matrix[i, j];
                    matrix[i, j] = 1 / (1 + Math.Exp(-value));
                }
            }

            return matrix;
        }

        ///<summary>
        /// Calculate the sigmoid derivative of a value
        /// </summary>
        /// 

        private double[,] _CalculateSigmativeDerivative(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    double value = matrix[i, j];
                    matrix[i, j] = value * (1 - value);
                }
            }

            return matrix;
        }

        ///<summary>
        /// Will return the outputs give the set of the inputs
        /// </summary>
        /// 

        public double[,] Think(double[,] inputMatrix)
        {
            double[,] productOfTheInputsAndWeight = MatrixEngine.MatrixDotProduct(inputMatrix, SynapsesMatrix);

            return _CalculateSigmoid(productOfTheInputsAndWeight);
        }

        ///<summary>
        /// Train the neural network
        /// </summary>
        /// 

        public void Train(double[,] trainInputMatrix, double[,] trainOutputMatrix, int interactions)
        {
            // run all the interactions
            for(int i = 0; i < interactions; i++)
            {
                // output
                var output = Think(trainInputMatrix);

                // error
                var error = MatrixEngine.MatrixSubstract(trainOutputMatrix, output);

                var curSigmoidDerivative = _CalculateSigmativeDerivative(output);

                var error_SigmoidDerivative = MatrixEngine.MatrixProduct(error, curSigmoidDerivative);

                // adjustment
                var adjustment = MatrixEngine.MatrixDotProduct(MatrixEngine.MatrixTranspose(trainInputMatrix), error_SigmoidDerivative);

                SynapsesMatrix = MatrixEngine.MatrixSum(SynapsesMatrix, adjustment);
            }
        }
    }
}
