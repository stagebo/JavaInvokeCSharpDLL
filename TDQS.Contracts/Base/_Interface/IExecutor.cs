
namespace TDQS
{
    public interface IExecutor
    {
        void Execute(object state);
    }

    public interface IExecutor<T>
    {
        void Execute(T state);
    }
}
