using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Vertex
    {
        public char label;
        public bool isVisited;
        public Vertex(char c)
        {
            label = c;
            isVisited = false;
        }
    }
}
