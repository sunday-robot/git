using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqoDataToGeometry3Dtest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mqoData = Mq.MqoLoader.Load("test.mqo");
            MQData.MqoDataToGeometry3DList.Convert(mqoData);
        }
    }
}
