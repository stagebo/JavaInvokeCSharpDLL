
namespace TDQS.Drawing
{
    public interface IPaint
    {
        void Paint(System.Drawing.IDeviceContext context);
    }

    public interface IPaint<T>
        where T : System.Drawing.IDeviceContext
    {
        void Paint(T context);
    }
}
