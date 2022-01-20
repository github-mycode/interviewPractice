using System;
using System.Collections.Generic;
using System.Text;

namespace gfg
{
    public class Tree
    {
        public int data;
        public Tree left, right;
        public Tree(int d)
        {
            data = d;
            left = null;
            right = null;
        }
    }
}
