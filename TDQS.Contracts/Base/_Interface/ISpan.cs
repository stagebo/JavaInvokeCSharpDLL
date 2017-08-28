
namespace TDQS
{
    public interface ISpan
    {
        object Start { get; }
        object End { get; }
    }

    public interface ISpan<T>
    {
        T Start { get; }
        T End { get; }
    }
}
