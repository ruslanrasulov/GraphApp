namespace GraphApp.Presenters.Interfaces
{
    public interface IPresenter<T>
    {
        T View { get; set; }
    }
}