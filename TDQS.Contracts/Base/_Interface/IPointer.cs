
namespace TDQS
{
    public interface IPointer
    {
        object Instance { get; }
    }

    public interface IPointer<T> : IPointer
    {
        T Instance { get; }
    }
}
