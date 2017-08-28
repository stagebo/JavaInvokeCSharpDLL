
namespace TDQS.Collections.Generic
{
    public interface ITreeNode
    {
        ITreeNode Parent { get; }
        System.Collections.Generic.IList<ITreeNode> Nodes { get; }
    }

    public interface ITreeNode<T> : ITreeNode
        where T : ITreeNode<T>
    {
        T Parent { get; }
        System.Collections.Generic.IList<T> Nodes { get; }
    }
}
