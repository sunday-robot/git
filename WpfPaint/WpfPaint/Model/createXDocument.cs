using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace WpfPaint.Model
{
    static class CreateXDocument
    {
        public static void createXDocument(List<Stroke> strokes)
        {
            var xd = new XDocument();
            var rootElement = new XElement("strokes");
            strokes.ForEach(e => rootElement.Add(createStrokeElement(e)));
        }

        private static XElement createStrokeElement(Stroke stroke)
        {
            var strokeElement = new XElement("stroke");
            strokeElement.Add(createColorAttribute(stroke.Color));
            stroke.Points.ForEach(e => strokeElement.Add(createPointElement(e)));
            return strokeElement;
        }

        private static object createPointElement(Point e)
        {
            return new XElement("point", e);
        }

        private static XAttribute createColorAttribute(Color color)
        {
            return new XAttribute("color", $"{color.R:X2}{color.G:X2}{color.B:X2}");
        }
    }
}
