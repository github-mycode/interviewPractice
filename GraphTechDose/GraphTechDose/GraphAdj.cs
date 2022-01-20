using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTechDose
{
    public class GraphAdj
    {
        //list of list of vertex
        public List<List<int>> Adj;
        public int VertexCount;
        public GraphAdj(int count)
        {
            VertexCount = count;
            Adj = new List<List<int>>();
            for(int i = 0; i<count; i++)
            {
                Adj.Add(new List<int>());
            }
        }
        public void AddVertex()
        {
            Adj.Add(new List<int>());
            VertexCount++;
        }
        public void AddDirectedEdge(int s, int d)
        {
            Adj[s].Add(d);
        }
        public void AddUndirectedEdge(int s, int d)
        {
            Adj[s].Add(d);
            Adj[d].Add(s);
        }
        public static GraphAdj GetUndirectedGraph()
        {
            GraphAdj graph = new GraphAdj(5);
            graph.AddUndirectedEdge(2, 3);
            graph.AddUndirectedEdge(2, 1);
            graph.AddUndirectedEdge(2, 4);
            return graph;
        }
        public static GraphAdj GetDirectedGraph()
        {
            GraphAdj graph = new GraphAdj(5);
            graph.AddDirectedEdge(0, 3);
            graph.AddDirectedEdge(1, 3);
            graph.AddDirectedEdge(2, 0);
            graph.AddDirectedEdge(3, 4);
            graph.AddDirectedEdge(2, 1);
            //graph.AddDirectedEdge(2, 4);

            //graph.AddDirectedEdge(4, 0);
            //graph.AddDirectedEdge(1, 4);
            //graph.AddDirectedEdge(3, 1);
            //graph.AddDirectedEdge(3, 2);
            return graph;
        }
        private int getUnvisitedNode(bool[] visited, int v)
        {
            foreach(int vr in Adj[v])
            {
                if (!visited[vr])
                {
                    return vr;
                }
            }
            return -1;
        }
        public List<int> DFS()
        {
            List<int> res = new List<int>();
            Stack<int> s = new Stack<int>();
            bool[] visited = new bool[VertexCount];
            visited[0] = true;
            s.Push(0);
            while (s.Count > 0)
            {
                int v = getUnvisitedNode(visited, s.Peek());
                if (v == -1)
                {
                    //there is no more node for visit
                    res.Add(s.Pop());
                }
                else
                {
                    visited[v] = true;
                    s.Push(v);
                }
            }
            PrintList(res);
            return res;
        }
        private void PrintList(List<int> list)
        {

            foreach(int v in list)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }
        private List<int> getUnvisitedNodes(bool[] visited, int v)
        {
            List<int> res = new List<int>();
            foreach (int vr in Adj[v])
            {
                if (!visited[vr])
                {
                    res.Add(vr);
                }
            }
            return res;
        }
        public List<int> BFS()
        {
            List<int> res = new List<int>();
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[VertexCount];
            q.Enqueue(0);
            visited[0] = true;
            while(q.Count > 0)
            {
                int v = q.Dequeue();
                List<int> list = getUnvisitedNodes(visited, v);
                foreach(int vr in list)
                {
                    q.Enqueue(vr);
                    visited[vr] = true;
                }
                res.Add(v);
            }
            PrintList(res);
            return res;
        }
        public bool IsCycleInUndirectedGrapgByTushar()
        {
            bool[] visited = new bool[VertexCount];
            for(int  i= 0; i< VertexCount; i++)
            {
                if (!visited[i])
                {
                    if (IsCycleInUndirectedGrapgByTusharUtil(visited, i, -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCycleInUndirectedGrapgByTusharUtil(bool[] visited, int v, int p)
        {
            if (visited[v])
            {
                return true;
            }
            visited[v] = true;
            foreach(int vr in Adj[v])
            {
                if(vr != p)
                {
                    if(IsCycleInUndirectedGrapgByTusharUtil(visited, vr, v))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsCycleByTushar()
        {
            int[] visited = new int[VertexCount];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i=0; i<VertexCount; i++)
            {
                if(visited[i] == 0)
                {
                    if (IsCycleByTusharUtil(visited, dict, i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCycleByTusharUtil(int[] visited, Dictionary<int, int> dict, int v)
        {
            if(visited[v] == 1)
            {
                return true;
            }
            if (visited[v] == 0)
            {
                visited[v] = 1;
                foreach(int vr in Adj[v])
                {
                    if(IsCycleByTusharUtil(visited,dict, vr))
                    {
                        return true;
                    }
                }
                visited[v] = 2;
            }
            return false;
        }

        public bool IsCycle()
        {
            bool[] visited = new bool[VertexCount];
            bool flag = false;
            for(int i =0; i< VertexCount; i++)
            {
                visited[i] = true;
                foreach(int v in Adj[i])
                {
                    if(IsCycleUtil(v, visited))
                    {
                        return true;
                    }
                }
                visited[i] = false;
            }
            return flag;
        }
        public bool IsCycleUtil(int v, bool[] visited)
        {
            if (visited[v])
            {
                return true;
            }
            visited[v] = true;
            foreach(int vr in Adj[v])
            {
                bool flag = IsCycleUtil(vr, visited);
                if (flag)
                {
                    return true;
                }
            }
            visited[v] = false;
            return false;
        }
        public List<int> TopologySortByTushar()
        {
            List<int> res = new List<int>();
            bool[] visited = new bool[VertexCount];
            Stack<int> s = new Stack<int>();
            for(int i = 0; i<VertexCount; i++)
            {
                if (visited[i] == false)
                {
                    TopologySortByTusharUtil(visited, i, s);
                }
            }
            while (s.Count > 0)
            {
                res.Add(s.Pop());
            }
            PrintList(res);
            return res;
        }

        private void TopologySortByTusharUtil(bool[] visited, int v, Stack<int> s)
        {
            if (visited[v])
            {
                Console.WriteLine("Graph has cycle");
                return;
            }
            visited[v] = true;
            foreach(int vr in Adj[v])
            {
                TopologySortByTusharUtil(visited, vr, s);
            }
            //Add data in stack after explore all children
            s.Push(v);
        }
    }
}
