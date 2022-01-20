using System;
using System.Collections.Generic;
using System.Text;

namespace IshantMicrosoft
{
    public class RootToLeafPath
    {
        public static long GetRootToLeafPath(Tree root)
        {
            List<string> paths = new List<string>();
            GetRootToLeafPath_Util(root, paths, "");
            long res = 0;
            foreach(string data in paths)
            {
                res = res +  Int64.Parse(data);
            }
            return res;
        }

        private static void GetRootToLeafPath_Util(Tree root, List<string> paths, string path)
        {
            if(root == null)
            {
                return;
            }
            if(root.left == null && root.right == null)
            {
                path += root.data.ToString();
                paths.Add(path);
                return;
            }
            GetRootToLeafPath_Util(root.left, paths, path + root.data);
            GetRootToLeafPath_Util(root.right, paths, path + root.data);
        }
    }
    public class Tree
    {
        public int data;
        public Tree left;
        public Tree right;
        public Tree(int d)
        {
            this.data = d;
            this.left = null;
            this.right = null;
        }
        public static Tree GetTree()
        {
            Tree root = new Tree(2);
            root.left = new Tree(3);
            root.right = new Tree(1);

            root.left.left = new Tree(8);
            root.right.right = new Tree(9);
            root.left.right = new Tree(0);
            root.right.left = new Tree(3);
            return root;
        }
    }
}
