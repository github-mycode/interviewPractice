using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public class LongestCommonMatchSeq
    {
        public static int LongestCommonMatchSeqLength(string s1, string s2)
        {
            int n1 = s1.Length + 1;
            int n2 = s2.Length + 1;
            int[,] dp = new int[n1, n2];
            for(int i = 1; i < n1; i++)
            {
                for(int j = 1; j < n2; j++)
                {
                    if(s1[i-1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[n1 - 1, n2 - 1];
        }
    }
}
