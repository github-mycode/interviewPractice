using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph
    {
        public int Vertex;
        public List<List<Vertex>> Adj;
        public List<Vertex> Vertexes = new List<Vertex>();
        public Graph()
        {
            Vertex = 0;
            Adj = new List<List<Vertex>>();
            Vertexes = new List<Vertex>();
        }

        public void AddVertex(char c)
        {
            if (!IsVertexAlreadyPresent(c))
            {
                Vertex v = new Vertex(c);
                Vertexes.Add(v);
                Adj.Add(new List<Vertex>());
                Vertex++;
            }
            else
            {
                Console.WriteLine("Vertex with given label is already present");
            }
        }
        public bool IsVertexAlreadyPresent(char c)
        {
            foreach(var v in Vertexes)
            {
                if(v.label == c)
                {
                    return true;
                }

            }
            return false;
        }
        public int GetVertexIndex(char c)
        {
            int i = 0;
            foreach (var v in Vertexes)
            {
                if (v.label == c)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public void AddEdge(char from, char to)
        {
            int fromIndex = GetVertexIndex(from);
            int toIndex = GetVertexIndex(to);
            if(fromIndex != -1 && toIndex != -1)
            {
                Adj[fromIndex].Add(new Vertex(to));
            }
            else
            {
                Console.WriteLine("Vertex not present");
            }
        }
        public List<char> BFS()
        {
            List<char> res = new List<char>();
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(Vertexes[0]);
            Vertexes[0].isVisited = true;
            res.Add(Vertexes[0].label);
            while (q.Count > 0)
            {
                Vertex v = q.Dequeue();
                int index = GetVertexIndex(v.label);
                List<Vertex> adjOfV = Adj[index];
                foreach(Vertex temp in adjOfV)
                {
                    int ind = GetVertexIndex(temp.label);
                    if (!Vertexes[ind].isVisited)
                    {
                        
                        Vertexes[ind].isVisited = true;
                        q.Enqueue(temp);
                        res.Add(temp.label);
                    }
                }
            }
            return res;
        }

    }
}
