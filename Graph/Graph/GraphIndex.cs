using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class GraphIndex
    {
        public int VertexCount;
        public List<List<int>> Adj;

        public GraphIndex()
        {
            VertexCount = 0;
            Adj = new List<List<int>>();
        }

        public int AddNode()
        {
            int node = VertexCount;
            Adj.Add(new List<int>());
            VertexCount++;
            return node;
        }

        public void AddEdge(int from, int to)
        {
            Adj[from].Add(to);
        }
        public int getUnvisitedNode(int v, bool[] visited)
        {
            List<int> nodes = Adj[v];
            for(int i = 0; i< nodes.Count; i++)
            {
                if (!visited[nodes[i]])
                {
                    return nodes[i];
                }
            }
            return -1;
        }
        public List<int> getUnvisitedNodes(int v, bool[] visited)
        {
            List<int> nodes = Adj[v];
            List<int> res = new List<int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!visited[nodes[i]])
                {
                    res.Add(nodes[i]);
                }
            }
            return res;
        }

        public List<int> DFS()
        {
            Stack<int> s = new Stack<int>();
            List<int> res = new List<int>();
            bool[] visited = new bool[VertexCount];
            res.Add(0);
            visited[0] = true;
            s.Push(0);
            while (s.Count > 0)
            {
                int v = s.Peek();
                int unvisitedNode = getUnvisitedNode(v, visited);
                if(unvisitedNode != -1)
                {
                    s.Push(unvisitedNode);
                    visited[unvisitedNode] = true;
                    res.Add(unvisitedNode);
                }
                else
                {
                    s.Pop();
                }
            }
            return res;
        }

        public List<int> BFS()
        {
            bool[] visited = new bool[VertexCount];
            List<int> res = new List<int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            visited[0] = true;
            res.Add(0);
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                List<int> list = getUnvisitedNodes(v, visited);
                foreach(int node in list)
                {
                    q.Enqueue(node);
                    visited[node] = true;
                    res.Add(node);
                }
            }
            return res;
        }

        public bool IsCycleExist()
        {
            bool[] visited = new bool[VertexCount];
            for(int i = 0; i< VertexCount; i++)
            {
                visited[i] = true;
                for(int j =0; j< Adj[i].Count; j++)
                {
                   bool flag = IsCycleExist_Util(Adj[i][j], visited);
                    if (flag)
                    {
                        return true;
                    }
                }
                visited[i] = false;
            }
            return false;
        }

        public bool IsCycleExist_Util(int v, bool[] visited) 
        {
            if (visited[v])
            {
                return true;
            }
            visited[v] = true;
            for(int i = 0; i< Adj[v].Count; i++)
            {
                bool flag = IsCycleExist_Util(Adj[v][i], visited);
                if (flag)
                {
                    return true;
                }
            }
            visited[v] = false;
            return false;
        }

    }
}
