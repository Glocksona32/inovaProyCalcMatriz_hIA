using System;

namespace inovaProyCalcMatriz_hIA
{
    internal class GaussJordan
    {
        static void Main()
        {
            Console.WriteLine("Método de Gauss-Jordan para resolver matrices inversas" + "\n");

            // Pedir al usuario la dimensión de la matriz cuadrada
            Console.Write("Ingrese la dimensión de la matriz cuadrada: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Crear la matriz y el vector identidad
            double[,] A = new double[n, n];
            double[,] I = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                I[i, i] = 1;
            }

            // Pedir al usuario los elementos de la matriz
            Console.WriteLine("Ingrese los elementos de la matriz:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i + 1, j + 1);
                    A[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            // Imprimir la matriz original
            Console.WriteLine("Matriz original:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", A[i, j]);
                }
                Console.WriteLine();
            }

            // Algoritmo de Gauss-Jordan
            for (int k = 0; k < n; k++)
            {
                double pivot = A[k, k];
                for (int j = 0; j < n; j++)
                {
                    A[k, j] /= pivot;
                    I[k, j] /= pivot;
                }
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        double factor = A[i, k];
                        for (int j = 0; j < n; j++)
                        {
                            A[i, j] -= factor * A[k, j];
                            I[i, j] -= factor * I[k, j];
                        }
                    }
                }
            }

            // Imprimir la matriz inversa
            Console.WriteLine("Matriz inversa:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", I[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}