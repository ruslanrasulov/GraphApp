using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GraphApp.Models;
using GraphApp.Presenters.Interfaces;
using GraphApp.Properties;
using GraphApp.Views.Implementations.Helpers;
using GraphApp.Views.Interfaces;

namespace GraphApp.Views.Implementations
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter _mainPresenter;
        private Graph _graph;

        public MainForm(IMainPresenter mainPresenter)
        {
            InitializeComponent();

            _mainPresenter = mainPresenter;
            _mainPresenter.View = this;

            InitializePictureBox();

            _mainPresenter.CreateGraph();
        }

        public void Draw()
        {
            if (!AssertGraph())
            {
                return;
            }

            using (var g = Graphics.FromImage(pictureBox.Image))
            {
                g.Clear(Color.White);

                var angle = (Math.PI * 2) / _graph.Vertices.Count;

                var index = 0;

                foreach (var vertex in _graph.Vertices)
                {
                    SetCoords(vertex, angle, index++);

                    DrawVertex(g, vertex, Constants.Font);
                }

                foreach (var edge in _graph.Edges)
                {
                    DrawEdge(g, edge, DrawObjects.Pen, Constants.Font);
                }
            }

            pictureBox.Invalidate();
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }

        #region DrawingMethods
        private void SetCoords(Vertex vertex, double angle, int index)
        {
            var alpha = angle * index;
            var sin = Math.Sin(alpha);
            var cos = Math.Cos(alpha);

            vertex.Location.X = (int)(Constants.Multiplier * sin) + (pictureBox.Width / 2);
            vertex.Location.Y = (int)(Constants.Multiplier * cos) + (pictureBox.Height / 2);
        }

        private static void DrawVertex(Graphics g, Vertex vertex, Font font)
        {
            g.DrawEllipse(
                DrawObjects.Pen,
                vertex.Location.X - (Constants.CircleRadius / 2),
                vertex.Location.Y - (Constants.CircleRadius / 2),
                Constants.CircleRadius,
                Constants.CircleRadius);

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            

            g.DrawString(vertex.Number.ToString(), font, DrawObjects.Brush, new PointF(vertex.Location.X, vertex.Location.Y), sf);
        }

        private void DrawEdge(Graphics g, WeightedEdge weightedEdge, Pen pen, Font font)
        {
            var vertexOne = _graph.Vertices.FirstOrDefault(x => x.Number == weightedEdge.VertexOne.Number);
            var vertexTwo = _graph.Vertices.FirstOrDefault(x => x.Number == weightedEdge.VertexTwo.Number);

            if (vertexOne == null || vertexTwo == null)
            {
                WarningMessageBox(Resources.DrawEdgeWarningMessageBox);
                return;
            }
            
            var vx1 = vertexOne.Location.X;
            var vx2 = vertexTwo.Location.X;
            var vy1 = vertexOne.Location.Y;
            var vy2 = vertexTwo.Location.Y;
            const float r = Constants.CircleRadius;

            var fullLength = (int)(Math.Sqrt(Math.Pow(vx2 - vx1, 2) + Math.Pow(vy2 - vy1, 2)));
            var diff = (r / 2 / fullLength);

            var x1 = (vx1 + diff * vx2) / (1 + diff);
            var x2 = (vx2 + diff * vx1) / (1 + diff);
            var y1 = (vy1 + diff * vy2) / (1 + diff);
            var y2 = (vy2 + diff * vy1) / (1 + diff);

            g.DrawLine(pen, x1, y1, x2, y2);

            var offsetX = (x1 >= x2) ? -6 : 6 + Constants.PenSize;
            var offsetY = (y1 >= y2) ? 6 : -6 + Constants.PenSize;

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(
                weightedEdge.Weight.ToString(CultureInfo.InvariantCulture),
                font,
                DrawObjects.Brush,
                new PointF()
                {
                    X = (vertexOne.Location.X + vertexTwo.Location.X) / 2 + offsetX,
                    Y = (vertexOne.Location.Y + vertexTwo.Location.Y) / 2 + offsetY
                },
                sf);
        } 
        #endregion

        #region MessageBoxHelpers
        private void ErrorMessageBox(string message)
            => MessageBox.Show(message, Resources.ErrorMessageBoxLabel, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void WarningMessageBox(string message)
            => MessageBox.Show(message, Resources.WarningMessageBoxLabel, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void InfoMessageBox(string message)
            => MessageBox.Show(message, Resources.InfoMessageBoxLabel, MessageBoxButtons.OK, MessageBoxIcon.Information); 
        #endregion

        #region Events
        private void addVertexButton_Click(object sender, EventArgs e)
        {
            if (!AssertGraph())
            {
                return;
            }

            try
            {
                _mainPresenter.AddVertex(_graph);
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }

            UpdateVertexLabel();
        }

        private void createGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainPresenter.CreateGraph();

            UpdateVertexLabel();
        }

        private void removeVertexButton_Click(object sender, EventArgs e)
        {
            var vertexNumber = removableVertexTextBox.TryGetInt32(
                () => InfoMessageBox(Resources.TryGetInt32InfoMessageBox),
                () => WarningMessageBox(Resources.TryGetInt32WarningMessageBox));

            if (vertexNumber == null)
            {
                return;
            }

            try
            {
                _mainPresenter.RemoveVertex(_graph, vertexNumber.Value);

                UpdateVertexLabel();
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void loadFromAdjacentMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                
                _mainPresenter.LoadGraphFromAdjacentMatrix(openFileDialog.FileName);

                UpdateVertexLabel();
                UpdateEdgeLabel();
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void loadFromEdgeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                
                _mainPresenter.LoadGraphFromEdgeList(openFileDialog.FileName);

                UpdateVertexLabel();
                UpdateEdgeLabel();
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void saveToAdjacentMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AssertGraph())
            {
                return;
            }

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _mainPresenter.SaveGraphToAdjacentMatrix(saveFileDialog.FileName, _graph);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void saveToEdgeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AssertGraph())
            {
                return;
            }

            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                
                _mainPresenter.SaveGraphToEdgeList(saveFileDialog.FileName, _graph);
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void addEdgeButton_Click(object sender, EventArgs e)
        {
            var vertexOneNumber = firstVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterFirstVertexNumber),
                () => WarningMessageBox(Resources.IncorrectFirstVertexNumber));

            var vertexTwoNumber = secondVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterSecondVertexNumber),
                () => WarningMessageBox(Resources.IncorrectSecondVertexNumber));

            var edgeWeight = weightTextBox.TryGetFloat(
                () => InfoMessageBox(Resources.EnterEdgeWeight),
                () => WarningMessageBox(Resources.IncorrectEdgeWeight));

            if (vertexOneNumber == null || vertexTwoNumber == null || edgeWeight == null)
            {
                return;
            }

            try
            {
                _mainPresenter.AddWeightedEdge(_graph, vertexOneNumber.Value, vertexTwoNumber.Value, edgeWeight.Value);

                UpdateEdgeLabel();
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void removeEdgeButton_Click(object sender, EventArgs e)
        {
            var vertexOneNumber = firstVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterFirstVertexNumber),
                () => WarningMessageBox(Resources.IncorrectFirstVertexNumber));

            var vertexTwoNumber = secondVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterSecondVertexNumber),
                () => WarningMessageBox(Resources.IncorrectSecondVertexNumber));

            if (vertexOneNumber == null || vertexTwoNumber == null)
            {
                return;
            }

            try
            {
                _mainPresenter.RemoveWeightedEdge(_graph, vertexOneNumber.Value, vertexTwoNumber.Value);

                UpdateEdgeLabel();
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void verticesAdjacentButton_Click(object sender, EventArgs e)
        {
            var vertexOneNumber = firstVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterFirstVertexNumber),
                () => WarningMessageBox(Resources.IncorrectFirstVertexNumber));

            var vertexTwoNumber = secondVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterSecondVertexNumber),
                () => WarningMessageBox(Resources.IncorrectSecondVertexNumber));

            if (vertexOneNumber == null || vertexTwoNumber == null)
            {
                return;
            }

            try
            {
                var result = _mainPresenter.AreVerticesAdjacent(_graph, vertexOneNumber.Value, vertexTwoNumber.Value);

                var resultText = result ? Resources.AdjacementYesAnswer : Resources.AdjacementNoAnswer;

                MessageBox.Show(
                    resultText,
                    Resources.AdjacementMessageBoxLabel,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }

        private void getWeightButton_Click(object sender, EventArgs e)
        {
            var vertexOneNumber = firstVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterFirstVertexNumber),
                () => WarningMessageBox(Resources.IncorrectFirstVertexNumber));

            var vertexTwoNumber = secondVertexNumber.TryGetInt32(
                () => InfoMessageBox(Resources.EnterSecondVertexNumber),
                () => WarningMessageBox(Resources.EnterSecondVertexNumber));

            if (vertexOneNumber == null || vertexTwoNumber == null)
            {
                return;
            }

            try
            {
                var result = _mainPresenter.GetWeightOfEdge(_graph, vertexOneNumber.Value, vertexTwoNumber.Value);

                MessageBox.Show(
                    result.ToString(CultureInfo.InvariantCulture), 
                    Resources.EdgeWeightMessageBoxLabel,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorMessageBox(ex.Message);
            }
        }
        #endregion

        #region OtherHelpers
        private void InitializePictureBox()
        {
            var map = new Bitmap(pictureBox.Width, pictureBox.Height);

            using (var g = Graphics.FromImage(map))
            {
                g.Clear(Color.White);
            }

            pictureBox.Image = map;
        }

        private void UpdateVertexLabel()
        {
            vertexCountLabel.Text = $"{Resources.UpdateVertexLabel} {_graph.Vertices.Count}";
        }

        private void UpdateEdgeLabel()
        {
            edgesCountLabel.Text =$"{Resources.UpdateEdgeLabel} {_graph.Edges.Count}";
        }

        private bool AssertGraph()
        {
            if (_graph != null)
            {
                return true;
            }
           
            WarningMessageBox(Resources.AssertGraphWarningMessageBox);

            return false;
        }
        #endregion
    }
}