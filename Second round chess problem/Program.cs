using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace second_round
{
    internal static class MyClass
    {
        public static bool Condition(this int val1)
        {
            if (val1 >= 1 && val1 <= 8)
            {
                return true;
            }

            return false;
        }
    }
    internal class Program
    {
        private static void Main(String[] args)
        {
            {
                int output;
                int ip1;
                ip1 = Convert.ToInt32(Console.ReadLine());
                int ip2;
                ip2 = Convert.ToInt32(Console.ReadLine());
                int ip3;
                ip3 = Convert.ToInt32(Console.ReadLine());
                int ip4;
                ip4 = Convert.ToInt32(Console.ReadLine());
                output = getStepCount(ip1, ip2, ip3, ip4);
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }



        private static int getStepCount(int input1, int input2, int input3, int input4)
        {
            if (input1.Condition() && input2.Condition() && input3.Condition() && input4.Condition())
            {

                int[] movementX = { -2, -2, -1, -1, 1, 1, 2, 2 };
                int[] movementY = { -1, 1, -2, 2, -2, 2, -1, 1 };

                int[,] board = new int[8, 8];

                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        board[row, col] = -1;
                    }
                }

                board[input1 - 1, input2 - 1] = 0;

                for (int step = 0; step < 7; step++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (board[i, j] == step)
                            {
                                for (int k = 0; k < 8; k++)
                                {
                                    if (i + movementY[k] >= 0 && i + movementY[k] < 8 && j + movementX[k] >= 0 &&
                                        j + movementX[k] < 8)
                                        if (board[i + movementY[k], j + movementX[k]] == -1)
                                            board[i + movementY[k], j + movementX[k]] = step + 1;
                                }
                            }
                        }
                    }
                }

                return board[input3 -1, input4-1];
            }
            return -1;
        }
    }
}