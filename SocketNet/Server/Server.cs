using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class Server
    {
        TcpListener listener = new TcpListener(Constants.PortNumber);

        public void Start()
        {
            listener.Start();

            while (true)
            {
                var tcpClient = listener.AcceptTcpClient();
                var task = Task.Run(() => Receive(tcpClient));
            }
        }

        private void Receive(TcpClient tcpClient)
        {
            using (tcpClient)
            using (var stream = tcpClient.GetStream())
            {
                var formatter = new BinaryFormatter();
                var receivedObject = formatter.Deserialize(stream);
                var receivedString = (string)receivedObject;
                var responseSting = "Response:[" + receivedString + "]";
                formatter.Serialize(stream, responseSting);

                //var request = stream.Read ReadObject<string>();

                //// 4. リクエストを処理してレスポンスを作る
                //var response = _processor(request);

                //// 5. クライアントにレスポンスを送信する
                //stream.WriteObject(response);
            }
        }

    }
}
