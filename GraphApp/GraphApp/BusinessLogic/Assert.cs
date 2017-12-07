using System;
using GraphApp.Models;

namespace GraphApp.BusinessLogic
{
    public static class Assert
    {
        public static void AssertAboutGraph(Graph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (graph.Edges == null)
            {
                throw new ArgumentNullException(nameof(graph.Edges));
            }

            if (graph.Vertices == null)
            {
                throw new ArgumentNullException(nameof(graph.Vertices));
            }
        }

        public static void AssertAboutVertex(Vertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            if (vertex.Location == null)
            {
                throw new ArgumentNullException(nameof(vertex.Location));
            }
        }

        public static void AssertAboutWeightedEdge(WeightedEdge weightedEdge)
        {
            if (weightedEdge == null)
            {
                throw new ArgumentNullException(nameof(weightedEdge));
            }

            if (weightedEdge.VertexOne == null)
            {
                throw new ArgumentNullException(nameof(weightedEdge.VertexOne));
            }

            if (weightedEdge.VertexTwo == null)
            {
                throw new ArgumentNullException(nameof(weightedEdge.VertexTwo));
            }
        }
    }
}