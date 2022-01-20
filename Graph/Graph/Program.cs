using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphIndex g = new GraphIndex();
            g.AddNode();//0
            g.AddNode();//1
            g.AddNode();//2
            g.AddNode();//3
            g.AddNode();//4
            g.AddNode();//5
            g.AddNode();//6
            g.AddNode();//7

            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(2, 3); 
            g.AddEdge(4, 6);
            g.AddEdge(4, 0);
            //g.AddEdge(5, 4);
            g.AddEdge(5, 7);

            List<int> data = g.BFS();

            List<int> dataDfs = g.DFS();

            bool isCycle = g.IsCycleExist();
        }
    }
}
