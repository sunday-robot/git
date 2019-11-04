using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using WpfPaint.Model;

namespace WpfPaint
{
    public sealed class WpfPaintModel
    {
        static readonly Random _random = new Random(0);
        readonly List<IUpdateListener> _updateListeners = new List<IUpdateListener>();

        public void AddUpdateListener(IUpdateListener listener) => _updateListeners.Add(listener);

        public Stroke CurrentStroke { get; private set; } = null;

        public List<Stroke> Strokes { get; } = new List<Stroke>();

        public WpfPaintModel() { }

        internal void SaveAs(string filePath)
        {
            throw new NotImplementedException();
        }

        public void StartDraw(Point point)
        {
            Console.WriteLine($"{point}");
            CurrentStroke = new Stroke(createNextColor(), point);
            Strokes.Add(CurrentStroke);
            _updateListeners.ForEach(e => e.StrokeAdded(CurrentStroke));
        }

        public void ExtendStroke(Point point)
        {
            CurrentStroke.AddPoint(point);
            _updateListeners.ForEach(e => e.StrokeExtended(CurrentStroke));
        }

        static Color createNextColor()
        {
            return Color.FromRgb(
                (byte)_random.Next(256),
                (byte)_random.Next(256),
                (byte)_random.Next(256));
        }
    }
}
