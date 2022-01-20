using System;
using System.Collections.Generic;
using System.Linq;

namespace IshantMicrosoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree root = Tree.GetTree();
            var data = VerticalTraversal.verticalOrder(root);
        }
















        public static void Ms1(int N, int[] R, int[] C)
        {
            int n = R.Length;
            string[,] dp = new string[N, N];
            for (int i = 0; i < n; i++)
            {
                dp[R[i], C[i]] = "B";
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (dp[i, j] != "B")
                    {
                        dp[i, j] = getConnected(dp, i, j, N).ToString();
                    }
                }
            }
            PrintMat(dp, N);
        }
        public static void PrintMat(string[,] dp, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string s = "";
                for (int j = 0; j < n; j++)
                {
                    s = s + dp[i, j].ToString();
                }
                Console.WriteLine(s);
                Console.WriteLine("Whole string");
            }
        }
        public static int getConnected(string[,] dp, int i, int j, int n)
        {
            int count = 0;
            if (i - 1 >= 0 && dp[i - 1, j] == "B")
            {
                count++;
            }
            if (i + 1 < n && dp[i + 1, j] == "B")
            {
                count++;
            }
            if (j - 1 >= 0 && dp[i, j - 1] == "B")
            {
                count++;
            }
            if (j + 1 < n && dp[i, j+1] == "B")
            {
                count++;
            }

            if (i - 1 >= 0 && j - 1 >= 0 && dp[i - 1, j - 1] == "B")
            {
                count++;
            }
            if (i - 1 >= 0 && j + 1 < n && dp[i - 1, j + 1] == "B")
            {
                count++;
            }
            if (i + 1 < n && j - 1 >= 0 && dp[i + 1, j - 1] == "B")
            {
                count++;
            }
            if (i + 1 < n && j + 1 < n && dp[i + 1, j + 1] == "B")
            {
                count++;
            }
            return count ;
        }



        public static int GetSum(int [] A)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int sum = Int32.MinValue;
            int index = 0;
            for (int i = 1; i < A.Length; i++)
            {
                index = A[i - 1] + A[i];
                if (sum == index)
                {
                    sum = Int32.MinValue;
                }
                else
                {
                    if (!dict.ContainsKey(index))
                    {
                        index = 0;
                        dict.Add(index, 1);
                        sum = index;
                    }
                    else
                    {
                        index = 0;
                        ++dict[index];
                        sum = index;
                    }
                }
            }
            return dict.Values.Max();
        }

        public static int getCountOfWords(string S)
        {
            int count = 0;
            string[] sentence = S.Split(new char[] { '!', '.', '?' });
            foreach(string str in sentence)
            {
                string[] temp = str.Split(' ');
                int tempCount = 0;
                foreach(string sTemp in temp)
                {
                    if (!String.IsNullOrWhiteSpace(sTemp))
                    {
                        tempCount++;
                    }
                }
                if(tempCount > count)
                {
                    count = tempCount;
                }
            }
            return count;
        }
        
    }
}
