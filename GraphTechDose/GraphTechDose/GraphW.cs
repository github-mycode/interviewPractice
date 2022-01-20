using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTechDose
{
    public class GraphW
    {
        public List<Dictionary<int, Edge>> Adj;
        public static int VertexCount = 0;
        public GraphW(int v)
        {
            VertexCount = v;
            Adj = new List<Dictionary<int, Edge>>();
            for(int i = 0; i<v; i++)
            {
                Adj.Add(new Dictionary<int, Edge>());
            }
        }
        public void AddVertex()
        {
            Adj.Add(new Dictionary<int, Edge>());
            VertexCount++;
        }
        public void AddEdge(int s, int d, int val)
        {
            Adj[s].Add(d, new Edge(val));
        }
        public void AddUndirectedEdge(int s, int d, int val)
        {
            Adj[s].Add(d, new Edge(val));
            Adj[d].Add(s, new Edge(val));
        }
        public static GraphW GetUndirectedGraph()
        {
            GraphW graph = new GraphW(6);
            graph.AddUndirectedEdge(0, 1, 5);
            graph.AddUndirectedEdge(1, 2, 2);
            graph.AddUndirectedEdge(2, 3, 3);
            graph.AddUndirectedEdge(3, 5, 2);
            graph.AddUndirectedEdge(4, 5, 3);
            graph.AddUndirectedEdge(0, 3, 9);
            graph.AddUndirectedEdge(0, 4, 2);
            return graph;
        }
        public int DijkstraSortestPathAlgo(int source, int des)
        {
            int[] distance = new int[VertexCount];
            int[] parent = new int[VertexCount];
            bool[] visited = new bool[VertexCount];
            Queue<int> q = new Queue<int>();
            for (int i=0; i<VertexCount; i++)
            {
                distance[i] = Int32.MaxValue;
                parent[i] = -1;
            }
            distance[source] = 0;
            while(true)
            {
                int v = getMinDistVertex(distance, visited);
                if(v == -1)
                {
                    break;
                }
                q.Enqueue(v);
                while (q.Count > 0)
                {
                    int vr = q.Dequeue();
                    visited[vr] = true;
                    int preDist = distance[vr];
                    foreach(var ver in Adj[vr])
                    {
                        if(distance[ver.Key] > preDist + ver.Value.distance)
                        {
                            distance[ver.Key] = preDist + ver.Value.distance;
                        }
                    }
                }
            }
            return distance[des];
        }

        private int getMinDistVertex(int[] distance, bool[] visited)
        {
            int minVertex = -1;
            int dist = Int32.MaxValue;
            for(int i = 0; i< VertexCount; i++)
            {
                if(distance[i] <= dist && visited[i] == false)
                {
                    dist = distance[i];
                    minVertex = i;
                }
            }
            return minVertex;
        }
    }
}
