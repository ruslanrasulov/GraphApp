using GraphApp.Models;
using GraphApp.Views.Interfaces;

namespace GraphApp.Presenters.Interfaces
{
    public interface IMainPresenter : IPresenter<IMainView>
    {
        void CreateGraph();

        void LoadGraphFromEdgeList(string path);

        void LoadGraphFromAdjacentMatrix(string path);

        void SaveGraphToEdgeList(string path, Graph graph);

        void SaveGraphToAdjacentMatrix(string path, Graph graph);

        void AddVertex(Graph graph);

        void RemoveVertex(Graph graph, int vertexNumber);

        void AddWeightedEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber, float weight);

        void RemoveWeightedEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber);

        bool AreVerticesAdjacent(Graph graph, int vertexOneNumber, int vertexTwoNumber);

        float GetWeightOfEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber);
    }
}