using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public static class MatrixEngine
    {
        public static double[,] MatrixDotProduct(double[,] firstMatrix, double[,] secondMatrix)
        {
            int rowLength = firstMatrix.GetLength(0);
            int colLength = firstMatrix.GetLength(1);
            double[,] result = new double[rowLength, colLength];

            if(rowLength != secondMatrix.GetLength(0) ||
                colLength != secondMatrix.GetLength(1)){
                return null;
            }
            else
            {
                for(int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        result[i,j] = firstMatrix[i, j] * secondMatrix[i, j];
                    }
                }
                return result;
            }
        }
        public static double[,] MatrixProduct(double[,] firstMatrix, double[,] secondMatrix)
        {
            int rowLengthFirst = firstMatrix.GetLength(0);
            int colLengthFirst = firstMatrix.GetLength(1);
            int rowLengthSecond = secondMatrix.GetLength(0);
            int colLengthSecond = secondMatrix.GetLength(1);

            int rowLength = rowLengthFirst;
            int colLength = colLengthSecond;

            double[,] result = new double[rowLength, colLength];

            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    double temp = 0;
                    for(int k = 0; k < colLengthFirst; k++)
                    {
                        temp += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                    result[i, j] = temp;
                }
            }

            return result;
        }
        public static double[,] MatrixSubstract(double[,] firstMatrix, double[,] secondMatrix)
        {
            int rowLength = firstMatrix.GetLength(0);
            int colLength = firstMatrix.GetLength(1);

            double[,] result = new double[rowLength, colLength];

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    result[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return result;
        }
        public static double[,] MatrixTranspose(double[,] matrix)
        {
            int rowLength = matrix.GetLength(1);
            int colLength = matrix.GetLength(0);
            double[,] result = new double[rowLength, colLength];

            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
        public static double[,] MatrixSum(double[,] firstMatrix, double[,] secondMatrix)
        {
            int rowLength = firstMatrix.GetLength(0);
            int colLength = firstMatrix.GetLength(1);

            double[,] result = new double[rowLength, colLength];

            for(int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++){
                    result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return result;
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
