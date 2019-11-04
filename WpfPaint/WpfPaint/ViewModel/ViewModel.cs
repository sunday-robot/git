using MvvmBindingSample;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfPaint.Model;

namespace WpfPaint
{
    sealed class ViewModel : INotifyPropertyChanged, IUpdateListener
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RenderTargetBitmap CanvasImageSource => _renderTargetBitmap;
        public void SrartDraw(Point point) => _model.StartDraw(point);
        public void ExtendStroke(Point point) => _model.ExtendStroke(point);
        public DelegateCommand SaveCommand { get; }

        readonly DrawingVisual _drawVisual = new DrawingVisual();
        Point lastPosition;

        readonly WpfPaintModel _model;
        const int CanvasWidth = 400;
        const int CanvasHeight = 300;
        RenderTargetBitmap _renderTargetBitmap = new RenderTargetBitmap(CanvasWidth, CanvasHeight, 96, 96, PixelFormats.Default);
        private Brush currentBrush;

        public ViewModel(WpfPaintModel model)
        {
            _model = model;
            _model.AddUpdateListener(this);
            SaveCommand = new DelegateCommand(
                _ =>
                {
                    // TODO ここでファイルパスをユーザーに問い合わせるのだが、MVVM的にはどうするのかわからない。
                    string filePath;
                    filePath = "abc.xml";
                    model.SaveAs(filePath);
                });
        }

        void notifyPropertyChanged(string propertyName) => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public void StrokeAdded(Stroke stroke)
        {
            var p = stroke.Points[0];
            currentBrush = new SolidColorBrush(stroke.Color);
            var dc = _drawVisual.RenderOpen();
            dc.DrawEllipse(currentBrush, null, p, 6, 6);
            dc.Close();
            _renderTargetBitmap.Render(_drawVisual);
            lastPosition = p;

            notifyPropertyChanged(nameof(CanvasImageSource));
        }

        public void StrokeExtended(Stroke stroke)
        {
            var p = stroke.Points[0];

            var dc = _drawVisual.RenderOpen();
            Pen pen = new Pen(currentBrush, 12);
            dc.DrawLine(pen, lastPosition, p); // 前回の位置からの直線を描画 
            dc.DrawEllipse(currentBrush, null, p, 6, 6); // 最終座標に円を描画 
            dc.Close();
            _renderTargetBitmap.Render(_drawVisual);
            lastPosition = p;

            notifyPropertyChanged(nameof(CanvasImageSource));
        }

        public void StrokeDeleted(Stroke stroke)
        {
            throw new NotImplementedException();
        }
    }
}
