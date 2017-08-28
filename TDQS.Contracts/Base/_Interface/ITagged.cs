
namespace TDQS
{
    public interface ITagged
    {
        object Tag { get; set; }
    }

    public interface ITagged<T>
    {
        T Tag { get; set; }
    }
}
