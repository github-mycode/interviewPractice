using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public class SubArraySum
    {
        public static int findSubArraySum(int[] arr, int n, int k)
        {
            int[,] dp = new int[n,n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                dp[i,i] = arr[i];
            }
            for (int l = 2; l < n; l++)
            {
                for (int i = 0; i < n - l + 1; i++)
                {
                    int j = l + i-1;
                    dp[i,j] = dp[i,j] + arr[j];
                    if (dp[i,j] == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
