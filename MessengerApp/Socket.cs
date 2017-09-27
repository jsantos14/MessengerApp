using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using SimpleTCP;
using System.IO;

namespace MessengerApp
{
    class Socket
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private string ip = "";
        private int port = 9930;
        TcpClient client;

        public void Initialize()
        {
            
        }

        public async System.Threading.Tasks.Task SendAsync(string textToSend)
        {
            ip = "10.55.23.32";
            client = new TcpClient();

            try
            {
                //Create the StreamSocket and establish a connection to the echo server.
                Windows.Networking.Sockets.StreamSocket socket = new Windows.Networking.Sockets.StreamSocket();

                //The server hostname that we will be establishing a connection to. We will be running the server and client locally,
                //so we will use localhost as the hostname.
                Windows.Networking.HostName serverHost = new Windows.Networking.HostName(ip);

                //Every protocol typically has a standard port number. For example HTTP is typically 80, FTP is 20 and 21, etc.
                //For the echo server/client application we will use a random port 1337.
                string serverPort = "9930";
                await socket.ConnectAsync(serverHost, serverPort);

                //Write data to the echo server.
                Stream streamOut = socket.OutputStream.AsStreamForWrite();
                StreamWriter writer = new StreamWriter(streamOut);
                string request = textToSend;
                await writer.WriteLineAsync(request);
                await writer.FlushAsync();

                //Read data from the echo server.
                Stream streamIn = socket.InputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);
                string response = await reader.ReadLineAsync();
            }
            catch (Exception e)
            {
                //Handle exception here.            
            }
        }

    }
}
