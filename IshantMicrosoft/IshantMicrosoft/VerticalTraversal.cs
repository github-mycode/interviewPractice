using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshantMicrosoft
{
    public class VerticalTraversal
    {
        public static List<int> verticalOrder(Tree root)
        {
            List<int> list = new List<int>();
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            verticalOrder_Util(root, dict, 0);
            var ordered = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach(var key in ordered.Keys)
            {
                List<int> temp = dict[key];
                foreach(int d in temp)
                {
                    list.Add(d);
                }
            }
            return list;
        }

        private static void verticalOrder_Util(Tree root, Dictionary<int, List<int>> dict, int v)
        {
            if(root == null)
            {
                return;
            }
            if (dict.ContainsKey(v))
            {
                dict[v].Add(root.data);
            }
            else
            {
                dict.Add(v, new List<int>() { root.data });
            }
            verticalOrder_Util(root.left, dict, v-1);
            verticalOrder_Util(root.right, dict, v+1);
        }
    }
}
