using System.ComponentModel;

namespace BoundingRectangle
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void _NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        double _width;
        double _height;
        double _angle;  // 単位は度

        double _brWidth;
        double _brHeight;

        public double MinimumAngle => -180;
        public double MaximumAngle => 180;

        public double Width {
            get => _width;
            set {
                _width = value;
                _UpdateBoundingRectangleSize();

                _NotifyPropertyChanged(nameof(Width));
                _NotifyPropertyChanged(nameof(BrWidth));
                _NotifyPropertyChanged(nameof(BrHeight));
            }
        }
        public double Height {
            get => _height;
            set {
                _height = value;
                _UpdateBoundingRectangleSize();

                _NotifyPropertyChanged(nameof(Height));
                _NotifyPropertyChanged(nameof(BrWidth));
                _NotifyPropertyChanged(nameof(BrHeight));
            }
        }

        public double Angle {
            get => _angle;
            set {
                _angle = value;
                _UpdateBoundingRectangleSize();

                _NotifyPropertyChanged(nameof(Angle));
                _NotifyPropertyChanged(nameof(BrWidth));
                _NotifyPropertyChanged(nameof(BrHeight));
            }
        }

        public double BrWidth => _brWidth;

        public double BrHeight => _brHeight;

        public MyViewModel() { }

        void _UpdateBoundingRectangleSize()
        {
            Utility.GetBoundingRectangleSize(_width, _height, _angle, out _brWidth, out _brHeight);
        }
    }
}
