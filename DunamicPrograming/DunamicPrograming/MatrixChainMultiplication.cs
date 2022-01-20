using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public class MatrixChainMultiplication
    {
        //2 3 6 4 5
        public static int GetMatrixChainMultiplication(int[] arr)
        {
            int n = arr.Length;
            int[,] dp = new int[n, n];

            //cost of multiplying 1 matrix is zero
            for(int i=1; i<n; i++)
            {
                dp[i, i] = 0;
            }

            //length is 2 or more
            for(int L= 2; L<n; L++)
            {
                for(int i = 1; i< n-L+1; i++)
                {
                    int j = L + i - 1;
                    dp[i, j] = int.MaxValue;
                    //partition
                    for(int k = i; k< j; k++)
                    {
                        int val = dp[i, k] + dp[k+1, j] + arr[k] * arr[i-1] * arr[j];
                        if(val < dp[i, j])
                        {
                            dp[i, j] = val;
                        }
                    }
                }
            }
            return dp[1, n - 1];
        }
    }
}
