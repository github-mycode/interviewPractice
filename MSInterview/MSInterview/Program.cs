using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MSInterview
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<int> l = new List<int>(){1,2,3,4,5,-10};
            int result = maxSubArray(l);
        }
        public static int maxSubArray(List<int> A)
        {
            int maxSum = Int32.MinValue;
            int tempMaxSum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                tempMaxSum += A[i];
                if (tempMaxSum > maxSum)
                {
                    maxSum = tempMaxSum;
                }

                if (tempMaxSum < 0)
                {
                    tempMaxSum = 0;
                }
            }

            return maxSum;
        }

        public static List<int> spiralOrder(List<List<int>> A)
        {
            int m = A.Count;
            int n = A[0].Count;
            List<int> res = new List<int>();

            
            for (int i = 0; i <= m/2; i++)
            {
                //left to right
                for (int j = i; j < n - i; j++)
                {
                    res.Add(A[i][j]);
                }
                //top to bottom
                for (int j = n - i - 1; j >= i; j--)
                {
                    res.Add(A[j][j]);
                }

                //right to left
                for (int j = i; j < n - i; j++)
                {
                    res.Add(A[i][j]);
                }
                //top to bottom
                for (int j = n - i - 1; j >= i; j--)
                {
                    res.Add(A[i][j]);
                }
            }

            return res;
        }
        public static void printMatrixInSpiral()
        {

        }
    }
}
