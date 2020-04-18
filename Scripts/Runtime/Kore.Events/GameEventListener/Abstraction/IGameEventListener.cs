namespace Kore.Events
{
    public interface IGameEventListener
    {
        void Response();
    }

    public interface IGameEventListener<T>
    {
        void Response(T arg);
    }
}
