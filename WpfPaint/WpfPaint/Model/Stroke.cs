using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WpfPaint
{
    public sealed class Stroke
    {
        public List<Point> Points { get; } = new List<Point>();
        public Color Color { get; }

        public Stroke(Color color, Point point)
        {
            Color = color;
            Points.Add(point);
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
