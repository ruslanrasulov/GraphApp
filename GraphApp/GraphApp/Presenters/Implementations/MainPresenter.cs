using System;
using System.Linq;
using GraphApp.LogicContracts;
using GraphApp.Models;
using GraphApp.Presenters.Interfaces;
using GraphApp.Views.Interfaces;

namespace GraphApp.Presenters.Implementations
{
    public class MainPresenter : BasePresenter<IMainView>, IMainPresenter
    {
        private readonly IMathGraph _mathGraph;

        public MainPresenter(IMathGraph mathGraph)
        {
            _mathGraph = mathGraph;
        }

        public void AddVertex(Graph graph)
        {
            try
            {
                _mathGraph.AddVertex(graph);

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public void AddWeightedEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber, float weight)
        {
            try
            {
                _mathGraph.AddWeightedEdge(
                    graph, 
                    GetWeightedEdge(vertexOneNumber, vertexTwoNumber, weight));

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public bool AreVerticesAdjacent(Graph graph, int vertexOneNumber, int vertexTwoNumber)
        {
            try
            {
                return _mathGraph.AreVerticesAdjacent(graph, GetVertex(vertexOneNumber), GetVertex(vertexTwoNumber));
            }
            catch
            {
                throw;
            }
        }

        public void CreateGraph()
        {
            var graph = _mathGraph.CreateEmptyGraph();

            View.SetGraph(graph);

            View.Draw();
        }

        public void LoadGraphFromAdjacentMatrix(string path)
        {
            try
            {
                var graph = _mathGraph.LoadGraphFromAdjacencyMatrix(path);

                View.SetGraph(graph);

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public void LoadGraphFromEdgeList(string path)
        {
            try
            {
                var graph = _mathGraph.LoadGraphFromEdgeList(path);

                View.SetGraph(graph);

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveVertex(Graph graph, int vertexNumber)
        {
            try
            {
                _mathGraph.RemoveVertex(graph, GetVertex(vertexNumber));

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveWeightedEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber)
        {
            try
            {
                _mathGraph.RemoveWeightedEdge(
                    graph,
                    GetWeightedEdge(vertexOneNumber, vertexTwoNumber));

                View.Draw();
            }
            catch
            {
                throw;
            }
        }

        public void SaveGraphToAdjacentMatrix(string path, Graph graph)
        {
            try
            {
                _mathGraph.SaveGraphToAdjacencyMatrix(path, graph);
            }
            catch
            {
                throw;
            }
        }

        public void SaveGraphToEdgeList(string path, Graph graph)
        {
            try
            {
                _mathGraph.SaveGraphToEdgeList(path, graph);
            }
            catch
            {
                throw;
            }
        }
        
        public float GetWeightOfEdge(Graph graph, int vertexOneNumber, int vertexTwoNumber)
        {
            var edge = graph.Edges.FirstOrDefault(x => x.VertexOne.Number == vertexOneNumber && x.VertexTwo.Number == vertexTwoNumber);

            if (edge == null)
            {
                throw new ArgumentException("Graph does not have this edge");
            }

            return edge.Weight;
        }

        private static Vertex GetVertex(int vertexNumber)
        {
            return new Vertex
            {
                Number = vertexNumber,
                Location = new Point()
            };
        }

        private static WeightedEdge GetWeightedEdge(int vertexOneNumber, int vertexTwoNumber, float weight = 0)
        {
            return new WeightedEdge
            {
                VertexOne = GetVertex(vertexOneNumber),
                VertexTwo = GetVertex(vertexTwoNumber),
                Weight = weight
            };
        }
    }
}