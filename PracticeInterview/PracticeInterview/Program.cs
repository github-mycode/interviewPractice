using System;
using System.Collections.Generic;

namespace PracticeInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree root = new Tree(10);
            root.left = new Tree(12);
            root.right = new Tree(15);
            root.left.left = new Tree(25);
            root.left.right = new Tree(30);
            root.right.left = new Tree(36);
            var res = Tree.createLinkedList(root);
        }
    }


    public class Tree
    {
        public int data;
        public Tree left;
        public Tree right;
        public Tree(int d)
        {
            data = d;
            left = null;
            right = null;
        }
        public static LinkedList<int> createLinkedList(Tree root)
        {
            Stack<Tree> s = new Stack<Tree>();
            LinkedList<int> list = new LinkedList<int>();
            Tree node = root;
            while (true)
            {
                if(node != null)
                {
                    s.Push(node);
                    node = node.left;
                }
                else
                {
                    if (s.Count <= 0)
                    {
                        break;
                    }
                    node = s.Pop();
                    list.AddLast(node.data);
                    node = node.right;
                }
            }
            return list;
        }
    }
}
