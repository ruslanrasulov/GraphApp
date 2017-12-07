using GraphApp.Models;

namespace GraphApp.LogicContracts
{
    public interface IMathGraph
    {
        Graph CreateEmptyGraph();

        Graph LoadGraphFromEdgeList(string path);

        Graph LoadGraphFromAdjacencyMatrix(string path);

        void SaveGraphToEdgeList(string path, Graph graph);

        void SaveGraphToAdjacencyMatrix(string path, Graph graph);

        void AddVertex(Graph graph);

        void RemoveVertex(Graph graph, Vertex vertex);

        void AddWeightedEdge(Graph graph, WeightedEdge weightedEdge);

        void RemoveWeightedEdge(Graph graph, WeightedEdge weightedEdge);

        bool AreVerticesAdjacent(Graph graph, Vertex vertexOne, Vertex vertexTwo);
    }
}