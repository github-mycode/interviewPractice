using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicPrograming
{
    public class _01KnapSap
    {
        public static int GetMaxProfit(Dictionary<int,int> profitW, int w)
        {
            int maxProfit = 0;
            profitW = profitW.OrderBy(x => x.Key).ThenBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int n = profitW.Count;
            int[,] dp = new int[n,w+1];
            int j = 0;
            foreach(int key in profitW.Keys)
            {
                for(int i = 1; i <= w; i++)
                {
                    if (i < key)
                    {
                        if(j == 0)
                        {
                            dp[j, i] = 0;
                        }
                        else
                        {
                            dp[j, i] = dp[j - 1, i];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            dp[j, i] = profitW[key];
                        }
                        else
                        {
                            dp[j, i] = Math.Max(dp[j - 1, i], dp[j - 1, i - key] + profitW[key]);
                        }
                    }
                    if(maxProfit < dp[j, i])
                    {
                        maxProfit = dp[j, i];
                    }
                    
                }
                j++;
            }
            return maxProfit;
        }
    }
}
