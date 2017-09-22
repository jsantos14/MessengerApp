using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp
{
    class Socket
    {
        private string ip = "";
        private int port = 9930;
        private TcpClient client;

        public void Initialize()
        {
            
        }

        public void Send(string textToSend)
        {
            ip = "10.0.0.196";
            client = new TcpClient();

            client.ConnectAsync(ip, port);

            if (client.Connected)
            {
                Debug.WriteLine("client Connected");

                NetworkStream nwStream = client.GetStream();
                byte[] buf = ASCIIEncoding.ASCII.GetBytes(textToSend);

                nwStream.Write(buf, 0, buf.Length);
            }
            else
            {
                Debug.WriteLine("Client Failed to Connect");
            }
        }

    }
}
