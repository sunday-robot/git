using System.Windows;

namespace WpfPaint.Model
{
    public interface IUpdateListener
    {
        void StrokeAdded(Stroke stroke);

        void StrokeExtended(Stroke stroke);

        void StrokeDeleted(Stroke stroke);
    }
}
