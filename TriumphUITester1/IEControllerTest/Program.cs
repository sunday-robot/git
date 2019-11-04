using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IE;
using System.Diagnostics;

namespace IEControllerTest {
    class Program {
        static void Main(string[] args) {
            var p = Process.Start(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe");

            var iec = new IEController();
            var addressTextBox = iec.GetAddressTextBox();
            addressTextBox.WaitUntilEnabled();
            Console.WriteLine("current address = [{0}]", addressTextBox.GetText());
            addressTextBox.SetText("http://www.yahoo.co.jp");
//            addressTextBox.SetText("about:blank");
            Console.WriteLine("current address = [{0}]", addressTextBox.GetText());
            Console.ReadKey();
        }
    }
}
