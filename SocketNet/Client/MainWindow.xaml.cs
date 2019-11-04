using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendSingleMessageButton_Click(object sender, RoutedEventArgs e)
        {
            var tcpClient = new TcpClient("localhost", Constants.PortNumber);
            var networkStream = tcpClient.GetStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(networkStream, MessageTextBox.Text);
            //var encoding = Encoding.UTF8;
            //var bytes = encoding.GetBytes(MessageTextBox.Text);
            //networkStream.Write(bytes, 0, bytes.Length);
        }
    }
}
