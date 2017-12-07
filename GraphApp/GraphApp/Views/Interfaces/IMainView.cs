using GraphApp.Models;

namespace GraphApp.Views.Interfaces
{
    public interface IMainView : IView
    {
        void SetGraph(Graph graph);

        void Draw();
    }
}