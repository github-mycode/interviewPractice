using System;

namespace GraphTechDose
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAdj graph = GraphAdj.GetDirectedGraph();
            var dfs = graph.DFS();
            var bfs = graph.BFS();
            var isCycle = graph.IsCycleInUndirectedGrapgByTushar();
            var topo = graph.TopologySortByTushar();

            GraphW graphW = GraphW.GetUndirectedGraph();
            int data = graphW.DijkstraSortestPathAlgo(0, 3);
        }
    }
}
