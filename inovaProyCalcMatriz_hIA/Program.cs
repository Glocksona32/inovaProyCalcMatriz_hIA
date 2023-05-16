using System;

namespace inovaProyCalcMatriz_hIA
{
    internal class GaussJordan
    {
        static void Main()
        {
            Console.WriteLine("Método de Gauss-Jordan para resolver matrices inversas" + "\n");
            int n;
            // Pedir al usuario la dimensión de la matriz cuadrada
            Console.Write("Ingrese la dimensión de la matriz cuadrada: ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());

                if (n > 3)
                {
                    Console.WriteLine("Escribe una matriz mas pequeña");
                }
                else if(n<2)
                {
                    Console.WriteLine("Escribir una matriz mas grande");
                }

            } while (n < 1 || n > 3);


            // Crear la matriz y el vector identidad
            double[,] A = new double[n, n];
            double[,] B = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                B[i, i] = 1;
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

            //dererminante 

            bool n1;
            if (n > 2) //matriz de 3x3 
            {
                n1 = true;
            }
            else { n1 = false; } //matriz de 2x2
            double PD;//POSITIVO DETERMIANTE
            double ND; // NEGATIVO DETERMINANTE
            double determinante = 0;

            if (n1 == true)
            {
                PD = A[0, 0] * A[1, 1] * A[2, 2] + A[1, 0] * A[2, 1] * A[0, 2] + A[2, 0] * A[0, 1] * A[1, 2];
                ND = A[2, 0] * A[1, 1] * A[0, 2] + (A[0, 0] * A[2, 1] * A[2, 1]) + A[1, 0] * A[0, 1] * A[2, 2];
                determinante = PD - ND;
            }
            else if (n1 == false)
            {
                PD = (A[0, 0] * A[1, 1]);
                ND = (A[1, 0] * A[0, 1]);
                determinante = PD - ND;
            }

            Console.WriteLine("La determinante es: " + determinante);


            // Algoritmo de Gauss-Jordan
            for (int k = 0; k < n; k++)
            {
                double pivot = A[k, k];
                for (int j = 0; j < n; j++)
                {
                    A[k, j] /= pivot;
                    B[k, j] /= pivot;
                }
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        double factor = A[i, k];
                        for (int j = 0; j < n; j++)
                        {
                            A[i, j] -= factor * A[k, j];
                            B[i, j] -= factor * B[k, j];
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
                    Console.Write("{0}\t", B[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
            
        }
    }
}
