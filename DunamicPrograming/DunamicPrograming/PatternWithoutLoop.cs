using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public class PatternWithoutLoop
    {
        public static void pattern_util(List<int> list, int n, int x, bool isAss = true)
        {
            if (x > n)
            {
                return;
            }
            list.Add(x);
            if (x > 0 && isAss)
            {
                pattern_util(list, n, x - 5);
            }
            else
            {
                pattern_util(list, n, x + 5, false);
            }
        }
    }
}
