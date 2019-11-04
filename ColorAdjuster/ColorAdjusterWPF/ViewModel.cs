using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ColorAdjuster
{
    class ViewModel : INotifyPropertyChanged
    {
        private Model _model;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// BitmapSource(意味不明だが、ImageコントロールはBitmapではなく、BitmapSourceでなければならない)
        /// </summary>
        private BitmapSource _bitmapSource;

        private List<RectangleRegion> _regions = new List<RectangleRegion>();

        public BitmapSource BitmapSource
        {
            get
            {
                return _bitmapSource;
            }
        }

        public void LoadBitmap(string filePath)
        {
            var bitmap = (Bitmap)Bitmap.FromFile(filePath);
            _model.SetBitmap(filePath, bitmap);
            _raisePropertyChangedEvent("BitmapFilePath");

            var intPtr = bitmap.GetHbitmap();
            var sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            _bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            _bitmapSource.Freeze();

            _raisePropertyChangedEvent("BitmapSource");
            _raisePropertyChangedEvent("ImageWidth");
            _raisePropertyChangedEvent("ImageHeight");
        }

        public Double ImageWidth
        {
            get
            {
                if (_bitmapSource == null)
                    return 1;
                var w = _bitmapSource.Width;
                return w;
            }
        }

        public Double ImageHeight
        {
            get
            {
                if (_bitmapSource == null)
                    return 1;
                var h = _bitmapSource.Height;
                return h / 2;
            }
        }

        public void AddRegion(RectangleRegion region)
        {
            _regions.Add(region);
            _raisePropertyChangedEvent("Regions");
        }

        public List<RectangleRegion> Regions
        {
            get
            {
                return _regions;
            }
        }

        /// <summary>
        /// 指定された名前のプロパティが更新されたことを示すイベントを発生させる。
        /// このような仕組みが言語側あるいはランタイムライブラリに用意されていない理由が
        /// わからない。
        /// </summary>
        /// <param name="propertyName"></param>
        private void _raisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<ComboBoxItem> _ZoomComboBoxItems = new List<ComboBoxItem>
        {
            new ComboBoxItem {Content = "Fit"},
            new ComboBoxItem {Content = "100%"},
            new ComboBoxItem {Content = "50%"},
            new ComboBoxItem {Content = "20%"},
            new ComboBoxItem {Content = "10%"}
        };

        public List<ComboBoxItem> ZoomComboBoxItems
        {
            get
            {
                return _ZoomComboBoxItems;
            }
        }

    }
}
