using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public class SubSetSum
    {
        public static bool GetSubSetSum(int[] arr, int sum)
        {
            int n = arr.Length;
            bool[,] dp = new bool[n, sum + 1];
            dp[0, arr[0]] = true;
            for(int i = 0; i< n; i++)
            {
                dp[i, 0] = true;
            }

            for(int i =1; i< n; i++)
            {
                for(int j = 1; j<= sum; j++)
                {
                    if (arr[i] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - arr[i]];
                    }
                }
            }
            return dp[n - 1, sum];
        }
    }
}
