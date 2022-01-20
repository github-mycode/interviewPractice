using InterviewQ.MicrosoftInterview3;
using InterviewQ.MicrosoftInterview3.ContactList;
using System;
using System.Collections.Generic;

namespace InterviewQ
{
    class Program
    {
        static void Main1(string[] args)
        {

            //Trie.TrieTest();

            //Contact.TestContact();

            //int[,] mat = new int[4, 4]
            //{
            //    {-1 ,0, -1, 0 },
            //    { 0, 0, -1, 0 },
            //    {-1, 1,  0, 0 },
            //    {-1, 0,  0, 0 }

            //};
            //int days_count = TotalDaysVaccine.GetTotalDaysVaccine(mat);


            //Tree
            //         1
            //    2           2        2
            //3  3   3  3    3  3         3
            //4
            //5
            //6

            Tree root = new Tree(1);
            root.child.Add(new Tree(2));
            root.child.Add(new Tree(2));
            root.child.Add(new Tree(2));

            root.child[0].child.Add(new Tree(3));
            root.child[0].child.Add(new Tree(3));
            root.child[0].child.Add(new Tree(3));
            root.child[0].child.Add(new Tree(3));

            root.child[1].child.Add(new Tree(3));
            root.child[1].child.Add(new Tree(3));

            root.child[2].child.Add(new Tree(3));

            root.child[0].child[0].child.Add(new Tree(4));
            root.child[0].child[0].child[0].child.Add(new Tree(5));
            root.child[0].child[0].child[0].child[0].child.Add(new Tree(6));
            root.child.Add(new Tree(1));
            int distance = FindMaxDistance(root);
        }
        

        //Find max distance between two node
        public static int FindMaxDistance(Tree root)
        {
            if (root == null)
            {
                return 0;
            }
            Responce r = FindMaxDistance_Util(root);
            return Math.Max(r.maxDistance, r.maxPath) + 1;
        }
        public static Responce FindMaxDistance_Util(Tree root)
        {
            if (root == null)
            {
                return new Responce();
            }
            int n = root.child.Count;
            Responce[] res = new Responce[n];
            for(int i= 0; i< n; i++)
            {
                res[i] = FindMaxDistance_Util(root.child[i]);
            }
            int[] maxTwoPath = getMaxTwoPath(res);
            int maxDistance = getMaxDistance(res);
            int internalDistance = maxTwoPath[0] + maxTwoPath[1] + 1;
            if(internalDistance < maxDistance)
            {
                internalDistance = maxDistance;
            }
            return new Responce(Math.Max(maxTwoPath[0], maxTwoPath[1]) + 1, internalDistance);

        }
        private static int[] getMaxTwoPath(Responce[] res)
        {
            int maxPath = 0;
            int maxPath1 = 0;
            int n = res.Length;
            int maxPathIndex = 0;
            for(int i = 0; i< n; i++)
            {
                if(res[i].maxPath > maxPath)
                {
                    maxPath = res[i].maxPath;
                    maxPathIndex = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (res[i].maxPath > maxPath1 && maxPathIndex != i)
                {
                    maxPath1 = res[i].maxPath;
                }
            }
            return new int[] { maxPath, maxPath1 };
        }
        private static int getMaxDistance(Responce[] res)
        {
            int maxDistance = 0;
            int n = res.Length;
            for (int i = 0; i < n; i++)
            {
                if (res[i].maxDistance > maxDistance)
                {
                    maxDistance = res[i].maxDistance;
                }
            }
            return maxDistance;
        }
    }
    public class Responce
    {
        public int maxPath;
        public int maxDistance;
        public Responce(int p, int d)
        {
            maxPath = p;
            maxDistance = d;
        }
        public Responce()
        {
            maxPath = 0;
            maxDistance = 0;
        }
    }
    public class Tree
    {
        public int data;
        public List<Tree> child;
        public Tree (int data)
        {
            this.data = data;
            child = new List<Tree>();
        }
    }
}

                //{ -1 ,2, -1,-1 },
                //{ 2, 1, -1, 3 },
                //{ -1, 1,  1, 2 },
                //{ -1, 1,  2, 3 }