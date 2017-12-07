using GraphApp.Presenters.Interfaces;
using GraphApp.Views.Interfaces;

namespace GraphApp.Presenters.Implementations
{
    public abstract class BasePresenter<T> : IPresenter<T>
        where T : IView
    {
        public T View { get; set; }
    }
}