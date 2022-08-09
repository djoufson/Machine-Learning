using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public static class MatrixEngine
    {
        public static double[,] MatrixDotProduct(double[,] inputMatrix, double[,] synapsesMatrix)
        {
            int rowLength = inputMatrix.GetLength(0);
            int colLength = inputMatrix.GetLength(1);
            double[,] result = new double[rowLength, colLength];

            if(rowLength != synapsesMatrix.GetLength(0) ||
                colLength != synapsesMatrix.GetLength(1)){
                return null;
            }
            else
            {
                for(int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        result[i,j] = inputMatrix[i, j] * synapsesMatrix[i, j];
                    }
                }
                return result;
            }
        }
        public static double[,] MatrixProduct(double[,] error, double[,] curSigmoidDerivative)
        {
            throw new NotImplementedException();
        }
        public static double[,] MatrixSubstract(double[,] inputMatrix, double[,] synapsesMatrix)
        {
            throw new NotImplementedException();
        }
        public static double[,] MatrixTranspose(double[,] trainInputMatrix)
        {
            throw new NotImplementedException();
        }
        public static double[,] MatrixSum(double[,] synapsesMatrix, double[,] error_SigmoidDerivative)
        {
            throw new NotImplementedException();
        }
        public static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine("\n");
            }
        }

    }
}
