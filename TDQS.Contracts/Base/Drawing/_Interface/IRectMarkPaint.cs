
namespace TDQS.Drawing
{
    public interface IRectMarkPaint<TContext, TMode> : IPaint<TContext>, IRectangular, IMultimode<TMode>
        where TContext : System.Drawing.IDeviceContext
    {
    }
}
