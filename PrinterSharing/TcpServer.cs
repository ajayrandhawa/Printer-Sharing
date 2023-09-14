using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PrinterSharing
{
    class TcpServer
    {

        //static void Main()
        //{
        //    // Start both server functionalities in separate threads
        //    var messageServerThread = new System.Threading.Thread(StartMessageServer);
        //    var fileServerThread = new System.Threading.Thread(StartFileServer);

        //    messageServerThread.Start();
        //    fileServerThread.Start();

        //    // Start the client for sending messages
        //    StartMessageClient();
        //}

        static void StartMessageServer()
        {
            // Define the server IP address and port for messages
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int messagePort = 12345;

            TcpListener listener = new TcpListener(ipAddress, messagePort);

            listener.Start();
            Console.WriteLine("Message Server listening on " + ipAddress + ":" + messagePort);

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine("Received Message: " + receivedMessage);

                    string responseMessage = "Message received by the server.";
                    byte[] responseBuffer = Encoding.UTF8.GetBytes(responseMessage);

                    stream.Write(responseBuffer, 0, responseBuffer.Length);
                    Console.WriteLine("Sent Message Response: " + responseMessage);
                }
            }
        }

        static void StartFileServer()
        {
            // Define the server IP address and port for file sharing
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int filePort = 54321;

            TcpListener listener = new TcpListener(ipAddress, filePort);

            listener.Start();
            Console.WriteLine("File Server listening on " + ipAddress + ":" + filePort);

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Receive the file name from the client
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string fileName = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received File Name: " + fileName);

                    // Receive and save the file
                    using (FileStream fileStream = File.Create(fileName))
                    {
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    Console.WriteLine("Received and Saved File: " + fileName);
                }
            }
        }

        static void StartMessageClient()
        {
            // Define the server IP address and port for messages
            string serverIp = "127.0.0.1";
            int serverPort = 12345;

            TcpClient client = new TcpClient(serverIp, serverPort);
            NetworkStream stream = client.GetStream();

            string message = "Hello, server!";
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);

            stream.Write(messageBuffer, 0, messageBuffer.Length);
            Console.WriteLine("Sent Message: " + message);

            byte[] responseBuffer = new byte[1024];
            int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
            string responseMessage = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
            Console.WriteLine("Server Message Response: " + responseMessage);

            stream.Close();
            client.Close();
        }
    }
}