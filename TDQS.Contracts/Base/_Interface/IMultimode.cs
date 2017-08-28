
namespace TDQS
{
    public interface IMultimode
    {
        object DefaultMode { get; }
        object Mode { get; set; }
    }

    public interface IMultimode<T> : IMultimode
    {
        T DefaultMode { get; }
        T Mode { get; set; }
    }
}
