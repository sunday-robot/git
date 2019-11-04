using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using DemoApp.ViewModel;
using System.Windows.Media;

namespace DemoApp
{
    public partial class App : Application
    {
        static App()
        {
            // This code is used to test the app when using other cultures.
            //
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //    System.Threading.Thread.CurrentThread.CurrentUICulture =
            //        new System.Globalization.CultureInfo("it-IT");


            // Ensure the current culture passed into bindings is the OS culture.
            // By default, WPF uses en-US as the culture, regardless of the system settings.
            //
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        App() {
            this.Resources.Add(
                "Brush_HeaderBackground",
                new LinearGradientBrush {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0),
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Color.FromArgb(0x66, 0x00, 0x00, 0x88), 0),
                        new GradientStop(Color.FromArgb(0xBB, 0x00, 0x00, 0x88), 0.5),
                        new GradientStop(Color.FromArgb(0xBB, 0x88, 0x88, 0x88), 1)}});
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var w = new MainWindow();

            // Create the ViewModel to which 
            // the main window binds.
            string path = "Data/customers.xml";
            var vm = new MainWindowViewModel(path);

            // When the ViewModel asks to be closed, 
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                vm.RequestCloseEventHandler -= handler;
                w.Close();
            };
            vm.RequestCloseEventHandler += handler;

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            w.DataContext = vm;

            w.Show();
        }
    }
}