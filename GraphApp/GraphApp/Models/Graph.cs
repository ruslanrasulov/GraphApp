using System.Collections.Generic;

namespace GraphApp.Models
{
    public class Graph
    {
        public ICollection<WeightedEdge> Edges { get; set; }

        public ICollection<Vertex> Vertices { get; set; }
    }
}