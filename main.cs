using System;
using System.Net.Sockets;

namespace TcpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // I overall tried to make this quite simple. It is important to note this is only a framework and
            // you can't really do much with this 
            // NOTE: THE SERVER PORT AND IP HAS TO BE ENTERED BY THE USER!!
            // Create a TCP client
            TcpClient client = new TcpClient();

            // Get the server's IP address and port
            var serverAddress = Console.ReadLine();
            var serverPort = int.Parse(Console.ReadLine());

            // Connect to the server
            client.Connect(serverAddress, serverPort);

            // Write some data to the server
            var stream = client.GetStream();
            var data = System.Text.Encoding.ASCII.GetBytes("Hello, server!");
            stream.Write(data, 0, data.Length);

            // Read the data from the server
            data = new Byte[256];
            var responseData = String.Empty;
            var bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes
