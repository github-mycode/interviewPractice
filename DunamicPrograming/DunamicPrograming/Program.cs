using System;
using System.Collections.Generic;
namespace DynamicPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            //_01KnapSap
            Dictionary<int, int> profitW = new Dictionary<int, int>();
            profitW.Add(1, 1);
            profitW.Add(3, 4);
            profitW.Add(4, 5);
            profitW.Add(5, 7);
            _01KnapSap.GetMaxProfit(profitW, 7);


            //LongestCommonMatchSeqLength
            string s1 = "abcdaf";
            string s2 = "acbcf";
            int len = LongestCommonMatchSeq.LongestCommonMatchSeqLength(s1, s2);

            //SubSetSum
            int[] arr = new int[] { 2, 3, 7, 8, 10 };
            bool isSubSet = SubSetSum.GetSubSetSum(arr, 11);

            //Matrix chain multiplication
            int[] mat = new int[] { 2, 3, 6, 4, 5 };
            int mul = MatrixChainMultiplication.GetMatrixChainMultiplication(mat);

            //Patter Without loop
            List<int> pattern = new List<int>();
            PatternWithoutLoop.pattern_util(pattern, 5, 5);

            //SubsetSum Problem
            int[] arr1 = new int[] { 10, 2, -20, -2, 10 };
            SubArraySum.findSubArraySum(arr1, 5, -10);
        }
    }
}
