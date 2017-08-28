
namespace TDQS.IO
{
    public interface IFileRecord
    {
        string FullName { get; }
        string Name { get; }
        string Extension { get; }
        bool Exists { get; }
        string Directory { get; }
        System.DateTime RecordTime { get; set; }
    }
}
