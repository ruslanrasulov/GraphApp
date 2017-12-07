using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphApp.LogicContracts;
using GraphApp.Models;

namespace GraphApp.BusinessLogic
{
    public class MathGraph : IMathGraph
    {
        public void AddVertex(Graph graph)
        {
            Assert.AssertAboutGraph(graph);

            var maxVertexNumber = graph.Vertices.OrderBy(x => x.Number).LastOrDefault()?.Number ?? 0;

            graph.Vertices.Add(new Vertex
            {
                Number = maxVertexNumber + 1,
                Location = new Point(),
            });
        }

        public void AddWeightedEdge(Graph graph, WeightedEdge weightedEdge)
        {
            Assert.AssertAboutGraph(graph);
            Assert.AssertAboutWeightedEdge(weightedEdge);

            if (!graph.Vertices.Any(x => x.Number == weightedEdge.VertexOne.Number || x.Number == weightedEdge.VertexTwo.Number))
            {
                throw new ArgumentException("Некорректные номера для вершин", nameof(weightedEdge));
            }

            graph.Edges.Add(weightedEdge);
        }

        public bool AreVerticesAdjacent(Graph graph, Vertex vertexOne, Vertex vertexTwo)
        {
            Assert.AssertAboutGraph(graph);
            Assert.AssertAboutVertex(vertexOne);
            Assert.AssertAboutVertex(vertexTwo);

            if (!graph.Vertices.Any(x => x.Number == vertexOne.Number || x.Number == vertexTwo.Number))
            {
                throw new ArgumentException("Граф не содержит вершину с таким номером");
            }

            return graph.Edges.Any(x =>
                (x.VertexOne.Number == vertexOne.Number && x.VertexTwo.Number == vertexTwo.Number) ||
                (x.VertexOne.Number == vertexTwo.Number && x.VertexTwo.Number == vertexOne.Number));
        }

        public Graph CreateEmptyGraph()
        {
            return new Graph
            {
                Edges = new HashSet<WeightedEdge>(),
                Vertices = new HashSet<Vertex>()
            };
        }

        public Graph LoadGraphFromAdjacencyMatrix(string path)
        {
            var lines = File.ReadAllLines(path);

            var vertexCount = int.Parse(lines[0]);

            var graph = CreateGraphWithVertices(vertexCount);

            for (var i = 1; i < lines.Length; i++)
            {
                var weights = lines[i].Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (var j = 0; j < weights.Length; j++)
                {
                    if (weights[j] != "0")
                    {
                        var vertexOne = graph.Vertices.FirstOrDefault(x => x.Number == i);
                        var vertexTwo = graph.Vertices.FirstOrDefault(x => x.Number == j + 1);

                        if (vertexOne == null || vertexTwo == null)
                        {
                            throw new ArgumentException("Некорректная матрица смежности в файле");
                        }

                        graph.Edges.Add(new WeightedEdge
                        {
                            VertexOne = vertexOne,
                            VertexTwo = vertexTwo,
                            Weight = float.Parse(weights[j])
                        });
                    }
                }
            }

            return graph;
        }

        public Graph LoadGraphFromEdgeList(string path)
        {
            var lines = File.ReadAllLines(path);

            var vertexCount = int.Parse(lines[0]);

            var graph = CreateGraphWithVertices(vertexCount);

            for (var i = 1; i < lines.Length; i++)
            {
                var numbers = lines[i].Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var vertexOneNumber = int.Parse(numbers[0]);
                var vertexTwoNumber = int.Parse(numbers[1]);

                var vertexOne = graph.Vertices.FirstOrDefault(x => x.Number == vertexOneNumber);
                var vertexTwo = graph.Vertices.FirstOrDefault(x => x.Number == vertexTwoNumber);

                if (vertexOne == null || vertexTwo == null)
                {
                    throw new ArgumentException("Некорректный список ребер в файле");
                }

                var edgeWeight = float.Parse(numbers[2]);

                graph.Edges.Add(new WeightedEdge
                {
                    VertexOne = vertexOne,
                    VertexTwo = vertexTwo,
                    Weight = edgeWeight
                });
            }

            return graph;
        }

        public void RemoveVertex(Graph graph, Vertex vertex)
        {
            Assert.AssertAboutGraph(graph);
            Assert.AssertAboutVertex(vertex);

            var vertexForRemove = graph.Vertices.FirstOrDefault(x => x.Number == vertex.Number);

            if (vertexForRemove == null)
            {
                throw new ArgumentException("Граф не содержит вершины с такими номерами");
            }

            graph.Vertices.Remove(vertexForRemove);
        }

        public void RemoveWeightedEdge(Graph graph, WeightedEdge weightedEdge)
        {
            Assert.AssertAboutGraph(graph);
            Assert.AssertAboutWeightedEdge(weightedEdge);

            var edgeForRemove = graph.Edges.FirstOrDefault(x =>
                (x.VertexOne.Number == weightedEdge.VertexOne.Number && x.VertexTwo.Number == weightedEdge.VertexTwo.Number) ||
                (x.VertexOne.Number == weightedEdge.VertexTwo.Number && x.VertexTwo.Number == weightedEdge.VertexOne.Number));

            if (edgeForRemove == null)
            {
                throw new ArgumentException("Граф не содержит данное ребро");
            }

            graph.Edges.Remove(edgeForRemove);
        }

        public void SaveGraphToAdjacencyMatrix(string path, Graph graph)
        {
            using (var writer = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                var vertexCount = graph.Vertices.Count;

                writer.WriteLine(vertexCount);

                for (var i = 0; i < vertexCount; i++)
                {
                    for (var j = 0; j < vertexCount; j++)
                    {
                        var edgeForRemove = graph.Edges.FirstOrDefault(x =>
                            (x.VertexOne.Number == i + 1 && x.VertexTwo.Number == j + 1) ||
                            (x.VertexOne.Number == j + 1 && x.VertexTwo.Number == i + 1));

                        writer.Write($"{edgeForRemove?.Weight ?? 0} ");
                    }

                    writer.WriteLine();
                }
            }
        }

        public void SaveGraphToEdgeList(string path, Graph graph)
        {
            using (var writer = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                var vertexCount = graph.Vertices.Count;

                writer.WriteLine(vertexCount);

                foreach (var edge in graph.Edges)
                {
                    writer.WriteLine($"{edge.VertexOne.Number} {edge.VertexTwo.Number} {edge.Weight}");
                }
            }
        }

        private Graph CreateGraphWithVertices(int vertexCount)
        {
            var graph = CreateEmptyGraph();

            for (var i = 0; i < vertexCount; i++)
            {
                graph.Vertices.Add(new Vertex
                {
                    Number = i + 1,
                    Location = new Point(),
                });
            }

            return graph;
        }
    }
}